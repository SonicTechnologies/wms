using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wms.Entity_Class;

namespace wms.Forms.Administration.Users.Groups
{
    public partial class lvl1Module_Form : Form
    {
        wmsdb obj = new wmsdb();
        public lvl1Module_Form()
        {
            InitializeComponent();
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb != null)
            {
                tb.BackColor = Color.Orange;
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb != null)
            {
                tb.BackColor = System.Drawing.SystemColors.Info;
            }
        }

        private void ModuleList()
        {
            var modules = (from c in obj.WMS_MSTR_MODULE
                           where !obj.WMS_MSTR_UGRPLVL1.Any(d => d.mod_id == c.mod_id)
                           select new
                          {
                              c.mod_id,
                              c.mod_name,
                              c.stat_id

                          }).OrderBy(c => new { c.mod_id }).ToList();

            dataGridView1.Rows.Clear();

            if (modules.Count != 0)
            {
                dataGridView1.ColumnHeadersVisible = true;
                foreach (var row in modules)
                {
                    string xstatus;
                    if (row.stat_id == 1)
                    {
                        xstatus = "Active";
                    }
                    else
                    {
                        xstatus = "Inactive";
                    }
                    dataGridView1.Rows.Add(row.mod_id,
                                           row.mod_name,
                                           xstatus,
                                           "Add");
                }
            }
            else
            {
                dataGridView1.ColumnHeadersVisible = false;
            }
            dataGridView1.ClearSelection();
        }

        private void SearchMod()
        {
            var modname = textBox2.Text.Trim();
            var modules = (from c in obj.WMS_MSTR_MODULE
                          where c.mod_name.StartsWith(modname) && !obj.WMS_MSTR_UGRPLVL1.Any(d => d.mod_id == c.mod_id)
                           select new
                          {
                              c.mod_id,
                              c.mod_name,
                              c.stat_id

                          }).OrderBy(c => new { c.mod_id }).ToList();

            dataGridView1.Rows.Clear();

            if (modules.Count != 0)
            {
                dataGridView1.ColumnHeadersVisible = true;
                foreach (var row in modules)
                {
                    string xstatus;
                    if (row.stat_id == 1)
                    {
                        xstatus = "Active";
                    }
                    else
                    {
                        xstatus = "Inactive";
                    }
                    dataGridView1.Rows.Add(row.mod_id,
                                           row.mod_name,
                                           xstatus,
                                           "Add");
                }
            }
            else
            {
                dataGridView1.ColumnHeadersVisible = false;
            }
            dataGridView1.ClearSelection();
        }

        private void lvl1Module_Form_Load(object sender, EventArgs e)
        {
            ModuleList();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SearchMod();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                
                var xugrp = obj.Set<WMS_MSTR_UGRPLVL1>();
                xugrp.Add(new WMS_MSTR_UGRPLVL1
                {
                    grp_id = Convert.ToInt32(US_Groups_Form.groupid),
                    mod_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString())

                });
                obj.SaveChanges();

                var mm = Application.OpenForms.OfType<US_Groups_Form>().Single();
                mm.GroupListLevel1();

                //this.Close();

                if (textBox2.Text.Trim() == "")
                {
                    ModuleList();
                }
                else
                {
                    SearchMod();
                }
            }
            else
            {

            }
        }
    }
}
