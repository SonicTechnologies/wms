﻿using System;
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
    public partial class Add_Lv3_Module : Form
    {
        US_Authorization_Form uaf = (US_Authorization_Form)Application.OpenForms["US_Authorization_Form"];
   
        wmsdb obj = new wmsdb();
        public Add_Lv3_Module()
        {
            InitializeComponent();
        }


        public void getS3Module()
        {
         

            var userId = US_Authorization_Form.userId;

            var getS1ModuleId = (from c in obj.WMS_MSTR_S1MODULE
                               where uaf.moduleNamelvl3 == c.s1mod_name && c.stat_id == 1
                               select new { c.s1mod_id });

            foreach (var id in getS1ModuleId)
            {

                var items = (from c in obj.WMS_MSTR_S2MODULE
                             join o in obj.WMS_MSTR_S1MODULE on c.s1mod_id equals o.s1mod_id
                             where !obj.WMS_MSTR_LVL3M.Any(lvl3 => lvl3.s2mod_id == c.s2mod_id && lvl3.usr_id == userId) && c.stat_id == 1 && o.stat_id == 1 && o.s1mod_id == id.s1mod_id

                             select new
                             {
                                 c.s2mod_id,
                                 o.s1mod_id,
                                 o.s1mod_name,
                                 c.s2mod_name,
                                 c.s2mod_form_name,
                                 c.s2mod_datecrtd

                             }).OrderBy(c => new { c.s2mod_id }).ToList();

                dataGridView1.Rows.Clear();

                if (items.Count != 0)
                {
                    dataGridView1.ColumnHeadersVisible = true;
                    foreach (var row in items)
                    {

                        dataGridView1.Rows.Add(
                                 row.s2mod_id,
                                 row.s1mod_id,
                                 row.s1mod_name,
                                 row.s2mod_name,
                                 row.s2mod_form_name,
                                 row.s2mod_datecrtd);

                    }
                }
                else
                {
                    dataGridView1.ColumnHeadersVisible = false;
                }

                dataGridView1.ClearSelection();

            }

    }
       

        private void Add_Lv3_Module_Load(object sender, EventArgs e)
        {
            Main_Form.GetInstance().Enabled = false;
            getS3Module();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                var userId = US_Authorization_Form.userId;
                int S1modId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                var UserValidation1 = (from c in obj.WMS_MSTR_LVL2M
                                       where c.usr_id == userId &&
                                       c.s1mod_id == S1modId
                                       select new { c.usr_id ,c.lvl2mod_id}).FirstOrDefault();

                if (UserValidation1 != null)
                {
                    int s2mod_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                    DialogResult dialog = MessageBox.Show("Are you sure you want to add " + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {

                        var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                        DateTime serverDate = dateQuery.AsEnumerable().First();

                        var users = obj.Set<WMS_MSTR_LVL3M>();
                        users.Add(new WMS_MSTR_LVL3M
                        {
                            usr_id = userId,
                            s2mod_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()),
                            date_added = serverDate,
                            added_by = loggedin_user.userId,
 
                      //s1mod_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString()),

                        });
                        obj.SaveChanges();
                        MessageBox.Show("Successfully saved " + dataGridView1.CurrentRow.Cells[3].Value.ToString() + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        uaf.ViewAccessModule();
                        getS3Module();
                    }
                }



                else
                {
                    MessageBox.Show("" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + " cannot be added .Register First the " + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "  in Access-Module Level 2", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {

            }
        }

  

        private void Add_Lv3_Module_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main_Form.GetInstance().Enabled = true;
        }

      

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = null;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[3].Value.ToString().ToLower().StartsWith(textBox7.Text.ToLower()))
                {
                    row.Visible = true;
                    row.Selected = true;
                }
                else
                {
                    row.Visible = false;
                }
            }

            dataGridView1.ClearSelection();
        }
    }
}
