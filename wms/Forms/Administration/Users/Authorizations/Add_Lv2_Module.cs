using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wms.Class;
using wms.Entity_Class;

namespace wms.Forms.Administration.Users.Authorizations
{
    public partial class Add_Lv2_Module : Form
    {
         US_Authorization_Form uaf = (US_Authorization_Form)Application.OpenForms["US_Authorization_Form"];
        wmsdb obj = new wmsdb();

        public Add_Lv2_Module()
        {
            InitializeComponent();
        }

       
        private void Add_Lv2_Module_Load(object sender, EventArgs e)
        {
            Main_Form.GetInstance().Enabled = false;
            GetModuleData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var userId = US_Authorization_Form.userId;
            if (e.ColumnIndex==5)
            {
                 
                    int modId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    var UserValidation = (from c in obj.WMS_MSTR_LVL1M
                                          where c.usr_id == userId &&
                                          c.mod_id == modId
                                          select new { c.usr_id ,c.lvl1mod_id}).FirstOrDefault();

                    if (UserValidation != null)
                    {
                        int s1mod_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        var user = (from c in obj.WMS_MSTR_LVL2M
                                    where c.usr_id == userId &&
                                    c.s1mod_id == s1mod_id
                                    select c.usr_id).FirstOrDefault();

                            DialogResult dialog = MessageBox.Show("Are you sure you want to add " + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialog == DialogResult.Yes)
                            {

                                var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                                DateTime serverDate = dateQuery.AsEnumerable().First();
                                var users = obj.Set<WMS_MSTR_LVL2M>();
                                 users.Add(new WMS_MSTR_LVL2M
                                {
                                    usr_id = userId,
                                    s1mod_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()),
                                    date_added = serverDate,
                                    added_by = loggedin_user.userId

                                 });
                                obj.SaveChanges();
                                MessageBox.Show("Successfully saved " + dataGridView1.CurrentRow.Cells[3].Value.ToString() + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                 uaf.ViewAccessModule();
                                 GetModuleData();

                            }

                    }
                    else
                    {
                        MessageBox.Show("" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + " cannot be added .Register First the " + dataGridView1.CurrentRow.Cells[2].Value.ToString() + " in Access-Module Level 1", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
               
            }
        }
        private void  GetModuleData()
        {
      
            var userId = US_Authorization_Form.userId;

            var getModuleId = (from c in obj.WMS_MSTR_MODULE
                               where uaf.moduleNamelvl2 == c.mod_name && c.stat_id == 1
                               select new { c.mod_id });

            foreach (var id in getModuleId)
            {
                var items = (from c in obj.WMS_MSTR_S1MODULE
                             join m in obj.WMS_MSTR_MODULE on c.mod_id equals m.mod_id
                             where !obj.WMS_MSTR_LVL2M.Any(lvl2 => lvl2.s1mod_id == c.s1mod_id && lvl2.usr_id == userId) && c.stat_id == 1 && m.mod_id == id.mod_id
    
                         select new
                         {
                             c.s1mod_id,
                             m.mod_id,
                             m.mod_name,
                             c.s1mod_name,
                             c.s1mod_datecrtd,

                         }).OrderBy(c => new { c.s1mod_id }).ToList();

                dataGridView1.Rows.Clear();

                if (items.Count != 0)
                {
                    dataGridView1.ColumnHeadersVisible = true;
                    foreach (var row in items)
                    {

                        dataGridView1.Rows.Add(
                                 row.s1mod_id,
                                 row.mod_id,
                                 row.mod_name,
                                 row.s1mod_name,
                                 row.s1mod_datecrtd);

                    }
                }
                else
                {

                    dataGridView1.ColumnHeadersVisible = false;
                }
            }
        }

 

        private void Add_Lv2_Module_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main_Form.GetInstance().Enabled = true;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["AccessModuleLevel2"].Value.ToString().ToLower().StartsWith(textBox7.Text.ToLower()))
                {
                    row.Visible = true;
                    row.Selected = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }
    }
}
