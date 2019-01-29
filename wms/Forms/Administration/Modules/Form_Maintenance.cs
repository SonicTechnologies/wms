using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using wms.Class;
using wms.Entity_Class;

namespace wms.Forms.Administration.Modules
{
    public partial class Module_Maintenance : Form
    {
        wmsdb obj = new wmsdb();
        public Module_Maintenance()
        {
            InitializeComponent();
        }

        private void Form_Maintenance_Load(object sender, EventArgs e)
        {
            getStatus1();
            getStatus2();
            ModuleList();
            
        }

        public void getStatus1()
        {
            var status = (from c in obj.WMS_TYPE_STAT
                          select new
                          {
                              c.stat_id,
                              c.stat_desc,

                          }).OrderBy(c => new { c.stat_desc }).ToList();

            comboBox4.Items.Clear();

            if (status.Count != 0)
            {

                foreach (var row in status)
                {
                    comboBox4.Items.Add(row.stat_desc);
                }
                comboBox4.SelectedIndex = -1;
            }

        }

        public void getStatus2()
        {
            var status = (from c in obj.WMS_TYPE_STAT
                          select new
                          {
                              c.stat_id,
                              c.stat_desc,

                          }).OrderBy(c => new { c.stat_desc }).ToList();

            comboBox1.Items.Clear();

            if (status.Count != 0)
            {

                foreach (var row in status)
                {
                    comboBox1.Items.Add(row.stat_desc);
                }
                comboBox1.SelectedIndex = -1;
            }

        }

        private void SearchModlvl1()
        {
            var modname = textBox3.Text.Trim();
            var modules = (from c in obj.WMS_MSTR_MODULE
                         where c.mod_name.StartsWith(modname)
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
                                           "Edit");
                }
            }
            else
            {
                dataGridView1.ColumnHeadersVisible = false;
            }
            dataGridView1.ClearSelection();
        }

        private void SearchModlvl2()
        {
            string xmodname = textBox2.Text;
            int? xmodid = null;
            var modid = (from c in obj.WMS_MSTR_MODULE
                          where c.mod_name == xmodname
                          select c.mod_id).FirstOrDefault();
            xmodid = modid;

            var modname = textBox5.Text.Trim();
            var modules = (from c in obj.WMS_MSTR_S1MODULE
                           where c.s1mod_name.StartsWith(modname) && c.mod_id == xmodid
                           select new
                           {
                               c.s1mod_id,
                               c.s1mod_name,
                               c.stat_id

                           }).OrderBy(c => new { c.s1mod_id }).ToList();

            dataGridView2.Rows.Clear();

            if (modules.Count != 0)
            {
                dataGridView2.ColumnHeadersVisible = true;
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
                    dataGridView2.Rows.Add(row.s1mod_id,
                                           row.s1mod_name,
                                           xstatus,
                                           "Edit");
                }
            }
            else
            {
                dataGridView2.ColumnHeadersVisible = false;
            }
            dataGridView2.ClearSelection();
        }

        private void ModuleList()
        {

            var modules = (from c in obj.WMS_MSTR_MODULE
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
                                           "Edit");
                }
            }
            else
            {
                dataGridView1.ColumnHeadersVisible = false;
            }
            dataGridView1.ClearSelection();
        }

        private void ModuleListlvl2()
        {
           
            int xmodid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            var modules = (from c in obj.WMS_MSTR_S1MODULE 
                           where c.mod_id == xmodid
                           select new
                           {
                               c.s1mod_id,
                               c.s1mod_name,
                               c.stat_id

                           }).OrderBy(c => new { c.s1mod_id }).ToList();

            dataGridView2.Rows.Clear();

            if (modules.Count != 0)
            {
                dataGridView2.ColumnHeadersVisible = true;
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
                    dataGridView2.Rows.Add(row.s1mod_id,
                                           row.s1mod_name,
                                           xstatus,
                                           "Edit");
                }
            }
            else
            {
                dataGridView2.ColumnHeadersVisible = false;
            }
            dataGridView2.ClearSelection();
        }



        private void addBtn_Click(object sender, EventArgs e)
        {
            clearFieldslvl1();
        }

        private void clearFieldslvl1()
        {
            textBox1.Text = "";
            comboBox4.SelectedIndex = -1;
            textBox1.Focus();
            saveBtn.Text = "Save";
            togglelvl1();

        }

        private void clearFieldslvl2()
        {
            textBox4.Text = "";
            comboBox1.SelectedIndex = -1;
            textBox4.Focus();
            button3.Text = "Save";
            togglelvl2();

        }

        private void togglelvl1()
        {
            if (panelvl1.Height == 110)
            {

            }
            else
            {
                panelvl1.Height = 110;
            }
        }

        private void togglelvl2()
        {
            if (panelvl2.Height == 110)
            {

            }
            else
            {
                panelvl2.Height = 110;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            panelvl1.Height = 0;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SearchModlvl1();
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

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Please fill up 'Module Name'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                if (comboBox4.Text == "")
                {
                    MessageBox.Show("Please select 'Module Status'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBox4.Focus();                   
                }
                else
                {
                    if (saveBtn.Text == "Save")
                    {
                        DialogResult dialog = MessageBox.Show("Are you sure you want to save Module?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {

                            var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                            DateTime serverDate = dateQuery.AsEnumerable().First();


                            var xmodule = obj.Set<WMS_MSTR_MODULE>();
                            xmodule.Add(new WMS_MSTR_MODULE
                            {
                                mod_name = textBox1.Text.Trim(),
                                mod_datecrtd = serverDate,
                                mod_crtdby = loggedin_user.userId

                            });
                            obj.SaveChanges();

                            MessageBox.Show("Successfully saved Module.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearFieldslvl1();
                            ModuleList();
                            Main_Form.GetInstance().AddItemsToModule();
                        }
                        else if (dialog == DialogResult.No)
                        {

                        }
                    }
                    else
                    {
                        DialogResult dialog = MessageBox.Show("Are you sure you want to update Module?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {
                            string xstatdesc = comboBox4.Text;
                            int xstatid = 1;
                            var statid = (from c in obj.WMS_TYPE_STAT
                                          where c.stat_desc == xstatdesc
                                          select c.stat_id).FirstOrDefault();
                            xstatid = statid;

                            var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                            DateTime serverDate = dateQuery.AsEnumerable().First();

                            int xmodid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                            obj.WMS_MSTR_MODULE.Where(c => c.mod_id == xmodid).ToList().ForEach(x =>
                            {
                                x.mod_name = textBox1.Text.ToString().Replace("'", "''");
                                x.mod_dateuptd = serverDate;
                                x.mod_uptdby = loggedin_user.userId;
                                x.stat_id = xstatid;
                            });
                            obj.SaveChanges();

                            MessageBox.Show("Successfully updated Module.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearFieldslvl1();
                            ModuleList();
                            Main_Form.GetInstance().AddItemsToModule();
                        }
                        else if (dialog == DialogResult.No)
                        {

                        }
                    }
                }
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv.Name == "dataGridView1")
            {
                if (e.ColumnIndex == 3)
                {
                    textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    comboBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox1.Focus();
                    togglelvl1();
                    saveBtn.Text = "Update";
                }
                else
                {

                }
            }
            else if (dgv.Name == "dataGridView2")
            {
                if (e.ColumnIndex == 3)
                {
                    textBox4.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                    comboBox1.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                    textBox4.Focus();
                    togglelvl2();
                    button3.Text = "Update";
                }
                else
                {

                }
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Please select 'Main Module'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                clearFieldslvl2();
            }
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox5.Enabled = true;
            panelvl2.Height = 0;
            clearFieldslvl2();
            ModuleListlvl2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelvl2.Height = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Please select 'Main Module'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (textBox4.Text.Trim() == "")
                {
                    MessageBox.Show("Please fill up 'Sub-Module Name'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox4.Focus();
                }            
                else
                {
                    if (comboBox1.Text == "")
                    {
                        MessageBox.Show("Please select 'Sub-Module Status'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        comboBox1.Focus();
                    }
                    else
                    {
                        if (button3.Text == "Save")
                        {
                            DialogResult dialog = MessageBox.Show("Are you sure you want to save Sub-Module?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialog == DialogResult.Yes)
                            {
                                string modname = textBox2.Text;
                                int? xmodid = null;
                                var modid = (from c in obj.WMS_MSTR_MODULE
                                             where c.mod_name == modname
                                             select c.mod_id).FirstOrDefault();
                                xmodid = modid;

                                string xstatdesc = comboBox1.Text;
                                int xstatid = 1;
                                var statid = (from c in obj.WMS_TYPE_STAT
                                              where c.stat_desc == xstatdesc
                                              select c.stat_id).FirstOrDefault();
                                xstatid = statid;

                                var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                                DateTime serverDate = dateQuery.AsEnumerable().First();


                                var xmodule = obj.Set<WMS_MSTR_S1MODULE>();
                                xmodule.Add(new WMS_MSTR_S1MODULE
                                {
                                    mod_id = Convert.ToInt32(xmodid),
                                    s1mod_name = textBox4.Text.Trim(),
                                    s1mod_datecrtd = serverDate,
                                    s1mod_crtdby = loggedin_user.userId,
                                    stat_id = xstatid
                                });
                                obj.SaveChanges();

                                MessageBox.Show("Successfully saved Sub-Module.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearFieldslvl2();
                                ModuleListlvl2();

                            }
                            else if (dialog == DialogResult.No)
                            {

                            }
                        }
                        else
                        {
                            DialogResult dialog = MessageBox.Show("Are you sure you want to update Sub-Module?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialog == DialogResult.Yes)
                            {
                                string xstatdesc = comboBox1.Text;
                                int xstatid = 1;
                                var statid = (from c in obj.WMS_TYPE_STAT
                                              where c.stat_desc == xstatdesc
                                              select c.stat_id).FirstOrDefault();
                                xstatid = statid;

                                var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                                DateTime serverDate = dateQuery.AsEnumerable().First();

                                int xsmodid = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);

                                obj.WMS_MSTR_S1MODULE.Where(c => c.s1mod_id == xsmodid).ToList().ForEach(x =>
                                {
                                    x.s1mod_name = textBox4.Text.ToString().Replace("'", "''");
                                    x.s1mod_dateuptd = serverDate;
                                    x.s1mod_uptdby = loggedin_user.userId;
                                    x.stat_id = xstatid;
                                });
                                obj.SaveChanges();

                                MessageBox.Show("Successfully updated Module.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearFieldslvl2();
                                ModuleListlvl2();
                            }
                            else if (dialog == DialogResult.No)
                            {

                            }
                        }
                        
                    }
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SearchModlvl2();
        }
    }
}
