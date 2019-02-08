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
namespace wms.Forms.Administration.Users.Groups
{
    public partial class US_Groups_Form : Form
    {
        wmsdb obj = new wmsdb();
        public static int? groupid;
        public static int? lvl1modid;
        public static int? lvl2modid;

        private static int? x_groupid
        {
            get { return groupid; }
            set { groupid = value; }

        }

        private static int? x_lvl1modid
        {
            get { return lvl1modid; }
            set { lvl1modid = value; }

        }

        private static int? x_lvl2modid
        {
            get { return lvl2modid; }
            set { lvl2modid = value; }

        }

        public US_Groups_Form()
        {
            InitializeComponent();
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

        private void clearFieldslvl1()
        {
            textBox2.Text = "";
            comboBox4.SelectedIndex = -1;
            textBox2.Focus();
            saveBtn.Text = "Save";
            togglelvl1();
        }

        private void togglelvl1()
        {
            if (panel3.Height == 110)
            {

            }
            else
            {
                panel3.Height = 110;
            }
        }

        private void GroupList()
        {

            var groups = (from c in obj.WMS_MSTR_UGRP
                           select new
                           {
                               c.grp_id,
                               c.grp_name,
                               c.stat_id

                           }).OrderBy(c => new { c.grp_id }).ToList();

            dataGridView1.Rows.Clear();

            if (groups.Count != 0)
            {
                dataGridView1.ColumnHeadersVisible = true;
                foreach (var row in groups)
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
                    dataGridView1.Rows.Add(row.grp_id,
                                           row.grp_name,
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

        private void SearchGroup()
        {
            var grpname = textBox3.Text.Trim();
            var groups = (from c in obj.WMS_MSTR_UGRP
                           where c.grp_name.StartsWith(grpname)
                           select new
                           {
                               c.grp_id,
                               c.grp_name,
                               c.stat_id

                           }).OrderBy(c => new { c.grp_id }).ToList();

            dataGridView1.Rows.Clear();

            if (groups.Count != 0)
            {
                dataGridView1.ColumnHeadersVisible = true;
                foreach (var row in groups)
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
                    dataGridView1.Rows.Add(row.grp_id,
                                           row.grp_name,
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

        private void SearchGroupLevel1()
        {
            var modname = textBox1.Text.Trim();
            var modules = (from c in obj.WMS_GRPLVL1_VIEW
                          where c.mod_name.StartsWith(modname)
                          select new
                          {
                              c.grpdl1_id,
                              c.grp_id,
                              c.grp_name,
                              c.mod_id,
                              c.mod_name,
                              c.stat_desc

                          }).OrderBy(c => new { c.grpdl1_id }).ToList();

            dataGridView2.Rows.Clear();

            if (modules.Count != 0)
            {
                dataGridView2.ColumnHeadersVisible = true;
                foreach (var row in modules)
                {

                    dataGridView2.Rows.Add(row.grpdl1_id,
                                           row.grp_id,
                                           row.mod_id,
                                           row.mod_name,
                                           row.stat_desc,
                                           "Remove");
                }
            }
            else
            {
                dataGridView2.ColumnHeadersVisible = false;
            }
            dataGridView2.ClearSelection();
        }

        private void SearchGroupLevel2()
        {
            var modname = textBox5.Text.Trim();
            var modules = (from c in obj.WMS_GRPLVL2_VIEW
                           where c.s1mod_name.StartsWith(modname) && c.mod_id == lvl1modid && c.grp_id == groupid
                           select new
                           {
                               c.grpdl2_id,
                               c.grp_id,
                               c.grp_name,
                               c.s1mod_id,
                               c.s1mod_name,
                               c.stat_desc

                           }).OrderBy(c => new { c.grpdl2_id }).ToList();

            dataGridView3.Rows.Clear();

            if (modules.Count != 0)
            {
                dataGridView3.ColumnHeadersVisible = true;
                foreach (var row in modules)
                {

                    dataGridView3.Rows.Add(row.grpdl2_id,
                                           row.grp_id,
                                           row.s1mod_id,
                                           row.s1mod_name,
                                           row.stat_desc,
                                           "Remove");
                }
            }
            else
            {
                dataGridView3.ColumnHeadersVisible = false;
            }
            dataGridView3.ClearSelection();
        }

        private void SearchGroupLevel3()
        {
            var modname = textBox8.Text.Trim();
            var modules = (from c in obj.WMS_GRPLVL3_VIEW
                           where c.s2mod_name.StartsWith(modname) && c.s1mod_id == lvl2modid && c.grp_id == groupid
                           select new
                           {
                               c.grpdl3_id,
                               c.grp_id,
                               c.grp_name,
                               c.s2mod_id,
                               c.s2mod_name,
                               c.stat_desc

                           }).OrderBy(c => new { c.grpdl3_id }).ToList();

            dataGridView4.Rows.Clear();

            if (modules.Count != 0)
            {
                dataGridView4.ColumnHeadersVisible = true;
                foreach (var row in modules)
                {

                    dataGridView4.Rows.Add(row.grpdl3_id,
                                           row.grp_id,
                                           row.s2mod_id,
                                           row.s2mod_name,
                                           row.stat_desc,
                                           "Remove");
                }
            }
            else
            {
                dataGridView4.ColumnHeadersVisible = false;
            }
            dataGridView4.ClearSelection();
        }

        public void GroupListLevel1()
        {

            var grouplvl1 = (from c in obj.WMS_GRPLVL1_VIEW
                             where c.grp_id == groupid
                          select new
                          {
                              c.grpdl1_id,
                              c.grp_id,
                              c.grp_name,
                              c.mod_id,
                              c.mod_name,
                              c.stat_desc
      

                          }).OrderBy(c => new { c.grpdl1_id }).ToList();

            dataGridView2.Rows.Clear();

            if (grouplvl1.Count != 0)
            {
                dataGridView2.ColumnHeadersVisible = true;
                foreach (var row in grouplvl1)
                {
                  
                    dataGridView2.Rows.Add(row.grpdl1_id,
                                           row.grp_id,
                                           row.mod_id,
                                           row.mod_name,
                                           row.stat_desc,
                                           "Remove");
                }
            }
            else
            {
                dataGridView2.ColumnHeadersVisible = false;
            }
            dataGridView2.ClearSelection();
        }

        public void GroupListLevel2()
        {

            var grouplvl2 = (from c in obj.WMS_GRPLVL2_VIEW
                             where c.grp_id == groupid && c.mod_id == lvl1modid
                             select new
                             {
                                 c.grpdl2_id,
                                 c.grp_id,
                                 c.grp_name,
                                 c.s1mod_id,
                                 c.s1mod_name,
                                 c.stat_desc


                             }).OrderBy(c => new { c.grpdl2_id }).ToList();

            dataGridView3.Rows.Clear();

            if (grouplvl2.Count != 0)
            {
                dataGridView3.ColumnHeadersVisible = true;
                foreach (var row in grouplvl2)
                {

                    dataGridView3.Rows.Add(row.grpdl2_id,
                                           row.grp_id,
                                           row.s1mod_id,
                                           row.s1mod_name,
                                           row.stat_desc,
                                           "Remove");
                }
            }
            else
            {
                dataGridView3.ColumnHeadersVisible = false;
            }
            dataGridView3.ClearSelection();
        }

        public void GroupListLevel3()
        {

            var grouplvl3 = (from c in obj.WMS_GRPLVL3_VIEW
                             where c.grp_id == groupid && c.s1mod_id == lvl2modid
                             select new
                             {
                                 c.grpdl3_id,
                                 c.grp_id,
                                 c.grp_name,
                                 c.s2mod_id,
                                 c.s2mod_name,
                                 c.stat_desc


                             }).OrderBy(c => new { c.grpdl3_id }).ToList();

            dataGridView4.Rows.Clear();

            if (grouplvl3.Count != 0)
            {
                dataGridView4.ColumnHeadersVisible = true;
                foreach (var row in grouplvl3)
                {

                    dataGridView4.Rows.Add(row.grpdl3_id,
                                           row.grp_id,
                                           row.s2mod_id,
                                           row.s2mod_name,
                                           row.stat_desc,
                                           "Remove");
                }
            }
            else
            {
                dataGridView4.ColumnHeadersVisible = false;
            }
            dataGridView4.ClearSelection();
        }

        private void US_Groups_Form_Load(object sender, EventArgs e)
        {
            getStatus1();
            GroupList();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            panel3.Height = 0;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            clearFieldslvl1();
            togglelvl1();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SearchGroup();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
           if (textBox2.Text.Trim() == "")
           {

           }
           else
           {
                if (comboBox4.Text == "")
                {

                }
                else
                {
                    if (saveBtn.Text == "Save")
                    {
                        DialogResult dialog = MessageBox.Show("Are you sure you want to save User Group?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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


                            var xugrp = obj.Set<WMS_MSTR_UGRP>();
                            xugrp.Add(new WMS_MSTR_UGRP
                            {
                                grp_name = textBox2.Text.Trim(),
                                grp_datecrtd = serverDate,
                                grp_crtdby = loggedin_user.userId,
                                stat_id = xstatid

                            });
                            obj.SaveChanges();

                            MessageBox.Show("Successfully saved User Group.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearFieldslvl1();
                            panel3.Height = 0;
                            GroupList();
                            
                        }
                        else if (dialog == DialogResult.No)
                        {

                        }
                    }
                    else
                    {
                        DialogResult dialog = MessageBox.Show("Are you sure you want to update User Group?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

                            int xgrpid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                            obj.WMS_MSTR_UGRP.Where(c => c.grp_id == xgrpid).ToList().ForEach(x =>
                            {
                                x.grp_name = textBox2.Text.ToString().Replace("'", "''");
                                x.grp_dateuptd = serverDate;
                                x.grp_uptdby = loggedin_user.userId;
                                x.stat_id = xstatid;
                            });
                            obj.SaveChanges();

                            MessageBox.Show("Successfully updated User Group.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearFieldslvl1();
                            panel3.Height = 0;
                            GroupList();

                        }
                        else if (dialog == DialogResult.No)
                        {

                        }
                    }
                }
           }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox2.Focus();
                togglelvl1();
                saveBtn.Text = "Update";
            }
            else
            {

            }
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            if (groupid == null)
            {

            }
            else
            {
                lvl1Module_Form lvl1mf = new lvl1Module_Form();
                lvl1mf.Show();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "")
            {
                MessageBox.Show("Please select Main Module (Level 1).", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lvl2Module_Form lvl2mf = new lvl2Module_Form();
                lvl2mf.placeSubModuleName(textBox4.Text);
                lvl2mf.Show();
            }           
        }
        private void button3_Click(object sender, EventArgs e)
        {
            lvl3Module_Form lvl3mf = new lvl3Module_Form();
            lvl3mf.placeModuleName(textBox6.Text);
            lvl3mf.placeSubModuleName(textBox7.Text);
            lvl3mf.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = "Group Default Access - "  + dataGridView1.CurrentRow.Cells[1].Value.ToString();
            groupid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            GroupListLevel1();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            lvl1modid = Convert.ToInt32(dataGridView2.CurrentRow.Cells[2].Value.ToString());
            GroupListLevel2();
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = textBox4.Text;
            textBox7.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            lvl2modid = Convert.ToInt32(dataGridView3.CurrentRow.Cells[2].Value.ToString());
            GroupListLevel3();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchGroupLevel1();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                try
                {
                    DialogResult dialog = MessageBox.Show("Are you sure you want to remove Module?\n\nThis process will also remove its Level 2 & 3 Sub-Module(s).", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        int xgrplvl1id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                        int xmodid = Convert.ToInt32(dataGridView2.CurrentRow.Cells[2].Value.ToString());
                        
                        var grplvl1id = obj.WMS_MSTR_UGRPLVL1.Where(c => c.grpdl1_id == xgrplvl1id).First();
                        obj.WMS_MSTR_UGRPLVL1.Remove(grplvl1id);
                       
                        var s1modid = (from c in obj.WMS_GRPLVL2_VIEW
                                         where c.mod_id == xmodid
                                         select new
                                         {
                                             c.s1mod_id


                                         }).OrderBy(c => new { c.s1mod_id }).ToList();

                        if (s1modid.Count != 0)
                        {

                            foreach (var row in s1modid)
                            {
                                var xs1modid = obj.WMS_MSTR_UGRPLVL2.Where(c => c.s1mod_id == row.s1mod_id).First();
                                obj.WMS_MSTR_UGRPLVL2.Remove(xs1modid);

                                var s2modid = (from c in obj.WMS_GRPLVL3_VIEW
                                               where c.s1mod_id == row.s1mod_id
                                               select new
                                               {
                                                   c.s2mod_id

                                               }).OrderBy(c => new { c.s2mod_id }).ToList();

                                if (s1modid.Count != 0)
                                {

                                    foreach (var xrow in s2modid)
                                    {
                                        var xs2modid = obj.WMS_MSTR_UGRPLVL3.Where(c => c.s2mod_id == xrow.s2mod_id).First();
                                        obj.WMS_MSTR_UGRPLVL3.Remove(xs2modid);
                                    }
                                  
                                }
                                else
                                {

                                }
                            }

                            
                        }
                        else
                        {
                           
                        }

                        obj.SaveChanges();
                        GroupListLevel1();
                        textBox4.Text = "";
                        textBox5.Text = "";
                        dataGridView3.Rows.Clear();
                        dataGridView3.ColumnHeadersVisible = false;
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        dataGridView4.Rows.Clear();
                        dataGridView4.ColumnHeadersVisible = false;

                    }
                    else if (dialog == DialogResult.No)
                    {

                    }

                }
                catch
                {

                }
                

               

            }
            else
            {

            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                try
                {
                    DialogResult dialog = MessageBox.Show("Are you sure you want to remove Level 2 Sub-Module?\n\nThis process will also remove its Level 3 Sub-Module(s).", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        int xgrplvl2id = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value.ToString());
                        int xsmodid = Convert.ToInt32(dataGridView3.CurrentRow.Cells[2].Value.ToString());

                        var grplvl2id = obj.WMS_MSTR_UGRPLVL2.Where(c => c.grpdl2_id == xgrplvl2id).First();
                        obj.WMS_MSTR_UGRPLVL2.Remove(grplvl2id);

                        var s2modid = (from c in obj.WMS_GRPLVL3_VIEW
                                       where c.s1mod_id == xsmodid
                                       select new
                                       {
                                           c.s2mod_id


                                       }).OrderBy(c => new { c.s2mod_id }).ToList();

                        if (s2modid.Count != 0)
                        {

                            foreach (var row in s2modid)
                            {
                                var xs2modid = obj.WMS_MSTR_UGRPLVL3.Where(c => c.s2mod_id == row.s2mod_id).First();
                                obj.WMS_MSTR_UGRPLVL3.Remove(xs2modid);
                            }

                            
                        }
                        else
                        {

                        }

                        obj.SaveChanges();
                        GroupListLevel2();
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        dataGridView4.Rows.Clear();
                        dataGridView4.ColumnHeadersVisible = false;

                    }
                    else if (dialog == DialogResult.No)
                    {

                    }

                    
                }
                catch
                {

                }

                
            }
            else
            {

            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                try
                {

                    int xgrplvl3id = Convert.ToInt32(dataGridView4.CurrentRow.Cells[0].Value.ToString());
                    var grplvl3id = obj.WMS_MSTR_UGRPLVL3.Where(c => c.grpdl3_id == xgrplvl3id).First();
                    obj.WMS_MSTR_UGRPLVL3.Remove(grplvl3id);
                    obj.SaveChanges();

                }
                catch
                {

                }


                GroupListLevel3();
            }
            else
            {

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SearchGroupLevel2();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            SearchGroupLevel3();
        }
    }
}
