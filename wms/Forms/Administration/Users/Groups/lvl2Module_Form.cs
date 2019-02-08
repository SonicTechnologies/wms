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
    public partial class lvl2Module_Form : Form
    {
        wmsdb obj = new wmsdb();
        public lvl2Module_Form()
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

        public void placeSubModuleName(string smodname)
        {
            textBox2.Text = smodname;
        }

        private void ModuleList()
        {
            var modid = US_Groups_Form.lvl1modid;
            var modules = (from c in obj.WMS_MSTR_S1MODULE
                           where !obj.WMS_MSTR_UGRPLVL2.Any(d => d.s1mod_id == c.s1mod_id) && c.mod_id == modid 
                           select new
                           {
                               c.s1mod_id,
                               c.s1mod_name,
                               c.stat_id

                           }).OrderBy(c => new { c.s1mod_id }).ToList();

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
                    dataGridView1.Rows.Add(row.s1mod_id,
                                           row.s1mod_name,
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
            var modid = US_Groups_Form.lvl1modid;
            var smodname = textBox1.Text.Trim();
            var smodules = (from c in obj.WMS_MSTR_S1MODULE
                           where c.s1mod_name.StartsWith(smodname) && !obj.WMS_MSTR_UGRPLVL2.Any(d => d.s1mod_id == c.s1mod_id) && c.mod_id == modid
                           select new
                           {
                               c.s1mod_id,
                               c.s1mod_name,
                               c.stat_id

                           }).OrderBy(c => new { c.s1mod_id }).ToList();

            dataGridView1.Rows.Clear();

            if (smodules.Count != 0)
            {
                dataGridView1.ColumnHeadersVisible = true;
                foreach (var row in smodules)
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
                    dataGridView1.Rows.Add(row.s1mod_id,
                                           row.s1mod_name,
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchMod();
        }

        private void lvl2Module_Form_Load(object sender, EventArgs e)
        {
            ModuleList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {

                var xugrp = obj.Set<WMS_MSTR_UGRPLVL2>();
                xugrp.Add(new WMS_MSTR_UGRPLVL2
                {
                    grp_id = Convert.ToInt32(US_Groups_Form.groupid),
                    s1mod_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString())

                });
                obj.SaveChanges();

                var mm = Application.OpenForms.OfType<US_Groups_Form>().Single();
                mm.GroupListLevel2();

                //this.Close();

                if (textBox1.Text.Trim() == "")
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
