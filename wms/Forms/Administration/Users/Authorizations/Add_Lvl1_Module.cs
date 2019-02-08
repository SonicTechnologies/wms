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
using wms.Forms;

namespace wms.Forms.Administration.Users.Authorizations
{
    public partial class Add_Lvl1_Module : Form
    {
        wmsdb obj = new wmsdb();
      
        public Add_Lvl1_Module()
        {
            InitializeComponent();
        }


        public void getModule()
        {
          
            var userId = US_Authorization_Form.userId;

            var items = (from m in obj.WMS_MSTR_MODULE
                         where !obj.WMS_MSTR_LVL1M.Any(lvl1=> lvl1.mod_id== m.mod_id && lvl1.usr_id == userId)  && m.stat_id==1
                         select new
                        {
                            m.mod_id,
                            m.mod_name,
                            m.mod_datecrtd,


                        }).OrderBy(c => new { c.mod_id }).ToList();

            dataGridView1.Rows.Clear();

            if (items.Count != 0)
            {
                dataGridView1.ColumnHeadersVisible = true;
                foreach (var row in items)
                {

                    dataGridView1.Rows.Add(row.mod_id,
                                           row.mod_name,
                                           row.mod_datecrtd);

                }
            }
            else
            {
                dataGridView1.ColumnHeadersVisible = false;
            }
        }

        private void Add_Lvl1_Module_Load(object sender, EventArgs e)
        {
            Main_Form.GetInstance().Enabled = false;
            getModule();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var userId = US_Authorization_Form.userId;
            if (e.ColumnIndex == 3)
            {

                DialogResult dialog = MessageBox.Show("Are you sure you want to add " + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {

                    var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                    DateTime serverDate = dateQuery.AsEnumerable().First();

                    var customer = obj.Set<WMS_MSTR_LVL1M>();
                    customer.Add(new WMS_MSTR_LVL1M
                    {
                        usr_id = userId,
                        mod_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()),
                        date_added = serverDate,
                        added_by = loggedin_user.userId

                    });
                    obj.SaveChanges();
                    MessageBox.Show("Successfully saved " + dataGridView1.CurrentRow.Cells[1].Value.ToString() + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    getModule();
                    var uaf = Application.OpenForms.OfType<US_Authorization_Form>().Single();
                    uaf.listItem();


                }
                else
                {

                }
            }
        }

        private void Add_Lvl1_Module_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main_Form.GetInstance().Enabled = true;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

            dataGridView1.CurrentCell = null;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["moduleName"].Value.ToString().ToLower().StartsWith(textBox7.Text.ToLower()))
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
