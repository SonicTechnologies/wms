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
    public partial class lvl3Module_Form : Form
    {
        wmsdb obj = new wmsdb();
        public lvl3Module_Form()
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

        public void placeModuleName(string modname)
        {
            textBox2.Text = modname;
        }

        public void placeSubModuleName(string smodname)
        {
            textBox1.Text = smodname;
        }

        private void ModuleList()
        {
            var s1modid = US_Groups_Form.lvl2modid;
            var modules = (from c in obj.WMS_MSTR_S2MODULE
                           where !obj.WMS_MSTR_UGRPLVL3.Any(d => d.s2mod_id == c.s2mod_id) && c.s1mod_id == s1modid
                           select new
                           {
                               c.s2mod_id,
                               c.s2mod_name,
                               c.stat_id

                           }).OrderBy(c => new { c.s2mod_id }).ToList();

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
                    dataGridView1.Rows.Add(row.s2mod_id,
                                           row.s2mod_name,
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
            var smodname = textBox3.Text.Trim();
            var s1modid = US_Groups_Form.lvl2modid;
            var modules = (from c in obj.WMS_MSTR_S2MODULE
                           where c.s2mod_name.StartsWith(smodname) && !obj.WMS_MSTR_UGRPLVL3.Any(d => d.s2mod_id == c.s2mod_id) && c.s1mod_id == s1modid
                           select new
                           {
                               c.s2mod_id,
                               c.s2mod_name,
                               c.stat_id

                           }).OrderBy(c => new { c.s2mod_id }).ToList();

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
                    dataGridView1.Rows.Add(row.s2mod_id,
                                           row.s2mod_name,
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

        private void lvl3Module_Form_Load(object sender, EventArgs e)
        {
            ModuleList();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SearchMod();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {

                var xugrp = obj.Set<WMS_MSTR_UGRPLVL3>();
                xugrp.Add(new WMS_MSTR_UGRPLVL3
                {
                    grp_id = Convert.ToInt32(US_Groups_Form.groupid),
                    s2mod_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString())

                });
                obj.SaveChanges();

                var mm = Application.OpenForms.OfType<US_Groups_Form>().Single();
                mm.GroupListLevel3();

                //this.Close();

                if (textBox3.Text.Trim() == "")
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
