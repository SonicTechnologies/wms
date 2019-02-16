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

namespace wms.Forms.Administration.Users
{
    public partial class Users_Maintenance : Form
    {
        wmsdb obj = new wmsdb();
        public Users_Maintenance()
        {
            InitializeComponent();
        }

        private void Users_Maintenance_Load(object sender, EventArgs e)
        {
            getStatus();
            getUserType();
            getUserGroup();
        }

        public void getStatus()
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

        public void getUserType()
        {

            var usertype = (from c in obj.WMS_TYPE_USRS
                            select new
                            {
                                c.usr_type_id,
                                c.usr_type_name,

                            }).OrderBy(c => new { c.usr_type_id }).ToList();

            comboBox2.Items.Clear();

            if (usertype.Count != 0)
            {

                foreach (var row in usertype)
                {

                    comboBox2.Items.Add(row.usr_type_name);

                }
                comboBox2.SelectedIndex = -1;
            }
            else
            {

            }
        }

        public void getUserGroup()
        {

            var usergroup = (from c in obj.WMS_MSTR_UGRP
                            select new
                            {
                                c.grp_id,
                                c.grp_name,

                            }).OrderBy(c => new { c.grp_id }).ToList();

            comboBox3.Items.Clear();

            if (usergroup.Count != 0)
            {

                foreach (var row in usergroup)
                {

                    comboBox3.Items.Add(row.grp_name);

                }
                comboBox3.SelectedIndex = -1;
            }
            else
            {

            }
        }

        public void enableAddControls()
        {

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            label7.Text = "Show Password";
            textBox5.Text = "";
            textBox6.Text = "";

            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;

            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";

            textBox3.Enabled = true;
            textBox4.Enabled = true;
            label7.Visible = true;

            textBox5.Enabled = true;
            textBox6.Enabled = true;

            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;

            panel63.Visible = true;

        }

        public void disableAddControls()
        {

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;

            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";

            textBox3.Enabled = false;
            textBox4.Enabled = false;
            label7.Visible = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;

            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;

            panel63.Visible = false;

        }

        public void GetUsers()
        {
            var users = (from c in obj.WMS_USRS_VIEW
                         select new
                         {
                             c.usr_id,
                             c.usr_username,
                             c.usr_password,
                             c.usr_fname,
                             c.usr_lname,
                             c.usr_type_id,
                             c.usr_type_name,
                             c.grp_id,
                             c.grp_name,
                             c.stat_id,
                             c.stat_desc,
                             c.usr_datecrtd,
                             c.crtdby,
                             c.usr_dateuptd,
                             c.uptdby

                         }).OrderBy(c => new { c.usr_id }).ToList();

            dataGridView1.Rows.Clear();

            if (users.Count != 0)
            {
                dataGridView1.ColumnHeadersVisible = true;
                foreach (var row in users)
                {

                    dataGridView1.Rows.Add(row.usr_id,
                                           row.usr_username,
                                           row.usr_password,
                                           row.usr_fname,
                                           row.usr_lname,
                                           row.usr_type_id,
                                           row.usr_type_name,
                                           row.grp_id,
                                           row.grp_name,
                                           row.stat_id,
                                           row.stat_desc,
                                           row.usr_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.crtdby,
                                           row.usr_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.uptdby);
                }
            }
            else
            {
                dataGridView1.ColumnHeadersVisible = false;
            }

        }

        public void searchUser()
        {
            if (textBox1.Text.Trim() == "")
            {
                dataGridView1.ColumnHeadersVisible = false;
                dataGridView1.Rows.Clear();
            }
            else
            {
                if (comboBox1.Text == "User ID")
                {
                    var userid = Convert.ToInt32(textBox1.Text.Trim());
                    var users = (from c in obj.WMS_USRS_VIEW
                                 where c.usr_id == userid
                                 select new
                                 {
                                     c.usr_id,
                                     c.usr_username,
                                     c.usr_password,
                                     c.usr_fname,
                                     c.usr_lname,
                                     c.usr_type_id,
                                     c.usr_type_name,
                                     c.grp_id,
                                     c.grp_name,
                                     c.stat_id,
                                     c.stat_desc,
                                     c.usr_datecrtd,
                                     c.crtdby,
                                     c.usr_dateuptd,
                                     c.uptdby

                                 }).OrderBy(c => new { c.usr_id }).ToList();

                    dataGridView1.Rows.Clear();

                    if (users.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in users)
                        {

                            dataGridView1.Rows.Add(row.usr_id,
                                                   row.usr_username,
                                                   row.usr_password,
                                                   row.usr_fname,
                                                   row.usr_lname,
                                                   row.usr_type_id,
                                                   row.usr_type_name,
                                                   row.grp_id,
                                                   row.grp_name,
                                                   row.stat_id,
                                                   row.stat_desc,
                                                   row.usr_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.crtdby,
                                                   row.usr_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.uptdby);
                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }

                }
                else if (comboBox1.Text == "Username")
                {
                    var usrname = textBox1.Text.Trim();
                    var users = (from c in obj.WMS_USRS_VIEW
                                 where c.usr_username == usrname
                                 select new
                                 {
                                     c.usr_id,
                                     c.usr_username,
                                     c.usr_password,
                                     c.usr_fname,
                                     c.usr_lname,
                                     c.usr_type_id,
                                     c.usr_type_name,
                                     c.grp_id,
                                     c.grp_name,
                                     c.stat_id,
                                     c.stat_desc,
                                     c.usr_datecrtd,
                                     c.crtdby,
                                     c.usr_dateuptd,
                                     c.uptdby
                                 }).OrderBy(c => new { c.usr_id }).ToList();

                    dataGridView1.Rows.Clear();

                    if (users.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in users)
                        {

                            dataGridView1.Rows.Add(row.usr_id,
                                                   row.usr_username,
                                                   row.usr_password,
                                                   row.usr_fname,
                                                   row.usr_lname,
                                                   row.usr_type_id,
                                                   row.usr_type_name,
                                                   row.grp_id,
                                                   row.grp_name,
                                                   row.stat_id,
                                                   row.stat_desc,
                                                   row.usr_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.crtdby,
                                                   row.usr_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.uptdby);

                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }

                }
                else if (comboBox1.Text == "First Name")
                {
                    var firstname = textBox1.Text.Trim();
                    var users = (from c in obj.WMS_USRS_VIEW
                                 where c.usr_fname.Contains(firstname)
                                 select new
                                 {
                                     c.usr_id,
                                     c.usr_username,
                                     c.usr_password,
                                     c.usr_fname,
                                     c.usr_lname,
                                     c.usr_type_id,
                                     c.usr_type_name,
                                     c.grp_id,
                                     c.grp_name,
                                     c.stat_id,
                                     c.stat_desc,
                                     c.usr_datecrtd,
                                     c.crtdby,
                                     c.usr_dateuptd,
                                     c.uptdby

                                 }).OrderBy(c => new { c.usr_id }).ToList();

                    dataGridView1.Rows.Clear();

                    if (users.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in users)
                        {
                            dataGridView1.Rows.Add(row.usr_id,
                                                   row.usr_username,
                                                   row.usr_password,
                                                   row.usr_fname,
                                                   row.usr_lname,
                                                   row.usr_type_id,
                                                   row.usr_type_name,
                                                   row.grp_id,
                                                   row.grp_name,
                                                   row.stat_id,
                                                   row.stat_desc,
                                                   row.usr_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.crtdby,
                                                   row.usr_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.uptdby);
                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }

                }
                else if (comboBox1.Text == "Last Name")
                {
                    var lastname = textBox1.Text.Trim();
                    var users = (from c in obj.WMS_USRS_VIEW
                                 where c.usr_lname.Contains(lastname)
                                 select new
                                 {
                                     c.usr_id,
                                     c.usr_username,
                                     c.usr_password,
                                     c.usr_fname,
                                     c.usr_lname,
                                     c.usr_type_id,
                                     c.usr_type_name,
                                     c.grp_id,
                                     c.grp_name,
                                     c.stat_id,
                                     c.stat_desc,
                                     c.usr_datecrtd,
                                     c.crtdby,
                                     c.usr_dateuptd,
                                     c.uptdby

                                 }).OrderBy(c => new { c.usr_id }).ToList();

                    dataGridView1.Rows.Clear();

                    if (users.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in users)
                        {

                            dataGridView1.Rows.Add(row.usr_id,
                                                   row.usr_username,
                                                   row.usr_password,
                                                   row.usr_fname,
                                                   row.usr_lname,
                                                   row.usr_type_id,
                                                   row.usr_type_name,
                                                   row.grp_id,
                                                   row.grp_name,
                                                   row.stat_id,
                                                   row.stat_desc,
                                                   row.usr_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.crtdby,
                                                   row.usr_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.uptdby);

                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }

                }
                else if (comboBox1.Text == "User Type")
                {
                    var usertype = textBox1.Text.Trim();
                    var users = (from c in obj.WMS_USRS_VIEW
                                 where c.usr_type_name.StartsWith(usertype)
                                 select new
                                 {
                                     c.usr_id,
                                     c.usr_username,
                                     c.usr_password,
                                     c.usr_fname,
                                     c.usr_lname,
                                     c.usr_type_id,
                                     c.usr_type_name,
                                     c.grp_id,
                                     c.grp_name,
                                     c.stat_id,
                                     c.stat_desc,
                                     c.usr_datecrtd,
                                     c.crtdby,
                                     c.usr_dateuptd,
                                     c.uptdby

                                 }).OrderBy(c => new { c.usr_id }).ToList();

                    dataGridView1.Rows.Clear();

                    if (users.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in users)
                        {

                            dataGridView1.Rows.Add(row.usr_id,
                                                   row.usr_username,
                                                   row.usr_password,
                                                   row.usr_fname,
                                                   row.usr_lname,
                                                   row.usr_type_id,
                                                   row.usr_type_name,
                                                   row.grp_id,
                                                   row.grp_name,
                                                   row.stat_id,
                                                   row.stat_desc,
                                                   row.usr_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.crtdby,
                                                   row.usr_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.uptdby);
                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }

                }
                else if (comboBox1.Text == "Status")
                {
                    var status = textBox1.Text.Trim();
                    var users = (from c in obj.WMS_USRS_VIEW
                                 where c.stat_desc.StartsWith(status)
                                 select new
                                 {
                                     c.usr_id,
                                     c.usr_username,
                                     c.usr_password,
                                     c.usr_fname,
                                     c.usr_lname,
                                     c.usr_type_id,
                                     c.usr_type_name,
                                     c.grp_id,
                                     c.grp_name,
                                     c.stat_id,
                                     c.stat_desc,
                                     c.usr_datecrtd,
                                     c.crtdby,
                                     c.usr_dateuptd,
                                     c.uptdby

                                 }).OrderBy(c => new { c.usr_id }).ToList();

                    dataGridView1.Rows.Clear();

                    if (users.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in users)
                        {

                            dataGridView1.Rows.Add(row.usr_id,
                                                   row.usr_username,
                                                   row.usr_password,
                                                   row.usr_fname,
                                                   row.usr_lname,
                                                   row.usr_type_id,
                                                   row.usr_type_name,
                                                   row.grp_id,
                                                   row.grp_name,
                                                   row.stat_id,
                                                   row.stat_desc,
                                                   row.usr_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.crtdby,
                                                   row.usr_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.uptdby);
                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }

                }
                else
                {

                }

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

        private void button3_Click(object sender, EventArgs e)
        {
            button4.Text = "Save";
            enableAddControls();
            textBox3.Focus();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            var lbl = sender as Label;
            if (lbl != null)
            {
                if (lbl.Text == "Show Password")
                {
                    lbl.Text = "Hide Password";
                    textBox4.UseSystemPasswordChar = false;
                }
                else
                {
                    lbl.Text = "Show Password";
                    textBox4.UseSystemPasswordChar = true;
                }
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "All")
            {
                textBox1.Text = "";
                textBox1.Enabled = false;
                GetUsers();
            }
            else
            {
                textBox1.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchUser();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button4.Text = "Update";
            enableAddControls();
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();

            textBox9.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();

            if (Convert.ToString(dataGridView1.CurrentRow.Cells[13].Value) == string.Empty)
            {
                textBox11.Text = "";
            }
            else
            {
                textBox11.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            }

            if (Convert.ToString(dataGridView1.CurrentRow.Cells[14].Value) == string.Empty)
            {
                textBox12.Text = "";
            }
            else
            {
                textBox12.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            }
        }

        int group_id = 0;
        bool isUpdate = false;
        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Save")
            {
                if (textBox3.Text != "")
                {
                    if (textBox4.Text != "")
                    {
                        if (textBox5.Text != "")
                        {
                            if (textBox6.Text != "")
                            {
                                if (comboBox2.Text != "")
                                {
                                    if (comboBox3.Text != "")
                                    {
                                        if (comboBox4.Text != "")
                                        {
                                            DialogResult dialog = MessageBox.Show("Are you sure you want to save User?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            if (dialog == DialogResult.Yes)
                                            {
                                                isUpdate = false;
                                                string xstatdesc = comboBox4.Text;
                                                int? xstatid = null;
                                                var statid = (from c in obj.WMS_TYPE_STAT
                                                              where c.stat_desc == xstatdesc
                                                              select c.stat_id).FirstOrDefault();

                                                xstatid = statid;

                                                string xusertypedesc = comboBox2.Text;
                                                int? xusertypeid = null;
                                                var xxusertypeid = (from c in obj.WMS_TYPE_USRS
                                                                    where c.usr_type_name == xusertypedesc
                                                                    select c.usr_type_id).FirstOrDefault();

                                                xusertypeid = xxusertypeid;

                                                string xusergroup = comboBox3.Text;
                                                int? xusergroupid = null;
                                                var xxusergroupid = (from c in obj.WMS_MSTR_UGRP
                                                                    where c.grp_name == xusergroup
                                                                     select c.grp_id).FirstOrDefault();

                                                xusergroupid = xxusergroupid;

                                                var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                                                DateTime serverDate = dateQuery.AsEnumerable().First();

                                                var user = (from c in obj.WMS_USRS_VIEW
                                                            where c.usr_username == textBox3.Text.Trim()
                                                            select c.usr_username).FirstOrDefault();
                                                if (user == null)
                                                {
                                                    group_id = Convert.ToInt32(xusergroupid);
                                                    var customer = obj.Set<WMS_MSTR_USRS>();
                                                    customer.Add(new WMS_MSTR_USRS
                                                    {
                                                        usr_username = textBox3.Text.Trim(),
                                                        usr_password = textBox4.Text.Trim(),
                                                        usr_fname = textBox5.Text.Trim(),
                                                        usr_lname = textBox6.Text.Trim(),
                                                        usr_type_id = Convert.ToInt32(xusertypeid),
                                                        grp_id = Convert.ToInt32(xusergroupid),
                                                        stat_id = Convert.ToInt32(xstatid),
                                                        usr_datecrtd = serverDate,
                                                        usr_crtdby = loggedin_user.userId
                                                    });
                                                    
                                                    obj.SaveChanges();
                                                    AddDefaultModuleLvl1();
                                                    MessageBox.Show("Successfully saved User.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    comboBox1.Text = "Username";
                                                    textBox1.Text = "";
                                                    textBox1.Text = textBox3.Text.Trim();
                                                    disableAddControls();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("'Customer ID' already exist.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    comboBox1.Text = "Customer ID";
                                                    textBox1.Text = textBox2.Text.Trim();
                                                }


                                            }
                                            else if (dialog == DialogResult.No)
                                            {

                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please select 'Status'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            comboBox4.Focus();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please select 'User Group'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        comboBox3.Focus();
                                    }
                                    
                                }
                                else
                                {
                                    MessageBox.Show("Please select 'User Type'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    comboBox2.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please fill up 'Last Name'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBox6.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please fill up 'First Name'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox5.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please fill up 'Password'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox4.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please fill up 'Username'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Focus();
                }
            }
            else
            {
                if (textBox3.Text != "")
                {
                    if (textBox4.Text != "")
                    {
                        if (textBox5.Text != "")
                        {
                            if (textBox6.Text != "")
                            {
                                if (comboBox2.Text != "")
                                {
                                    if (comboBox3.Text != "")
                                    {
                                        if (comboBox4.Text != "")
                                        {
                                            DialogResult dialog = MessageBox.Show("Are you sure you want to update User?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                            if (dialog == DialogResult.Yes)
                                            {
                                                isUpdate = true;
                                                string xstatdesc = comboBox4.Text;
                                                int? xstatid = null;
                                                var statid = (from c in obj.WMS_TYPE_STAT
                                                              where c.stat_desc == xstatdesc
                                                              select c.stat_id).FirstOrDefault();

                                                xstatid = statid;

                                                string xusertypedesc = comboBox2.Text;
                                                int? xusertypeid = null;
                                                var xxusertypeid = (from c in obj.WMS_TYPE_USRS
                                                                    where c.usr_type_name == xusertypedesc
                                                                    select c.usr_type_id).FirstOrDefault();

                                                xusertypeid = xxusertypeid;

                                                string xusergroup = comboBox3.Text;
                                                int? xusergroupid = null;
                                                var xxusergroupid = (from c in obj.WMS_MSTR_UGRP
                                                                    where c.grp_name == xusergroup
                                                                    select c.grp_id).FirstOrDefault();

                                                xusergroupid = xxusergroupid;
                                                group_id = Convert.ToInt32(xusergroupid);

                                                var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                                                DateTime serverDate = dateQuery.AsEnumerable().First();

                                                var userid = Convert.ToInt32(textBox2.Text.Trim());

                                                obj.WMS_MSTR_USRS.Where(c => c.usr_id == userid).ToList().ForEach(x =>
                                                {
                                                    x.usr_username = textBox3.Text.Trim();
                                                    x.usr_password = textBox4.Text.Trim();
                                                    x.usr_fname = textBox5.Text.Trim();
                                                    x.usr_lname = textBox6.Text.Trim();
                                                    x.usr_type_id = Convert.ToInt32(xusertypeid);
                                                    x.grp_id = Convert.ToInt32(xusergroupid);
                                                    x.stat_id = Convert.ToInt32(xstatid);
                                                    x.usr_dateuptd = serverDate;
                                                    x.usr_uptdby = loggedin_user.userId;
                                                });

                                                obj.SaveChanges();
                                                AddDefaultModuleLvl1();
                                                MessageBox.Show("Successfully updated User.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                comboBox1.Text = "User ID";
                                                textBox1.Text = "";
                                                textBox1.Text = textBox2.Text.Trim();
                                                disableAddControls();
                                            }
                                            else if (dialog == DialogResult.No)
                                            {

                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please select 'Status'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            comboBox4.Focus();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please select 'User Group'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        comboBox3.Focus();
                                    }
                                    
                                }
                                else
                                {
                                    MessageBox.Show("Please select 'User Type'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    comboBox2.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please fill up 'Last Name'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBox6.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please fill up 'First Name'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox5.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please fill up 'Password'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox4.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please fill up 'Username'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Focus();
                }
            }
        }

        public void AddDefaultModuleLvl1()
        {
            string username = textBox3.Text.Trim();
            var getUserId = obj.WMS_MSTR_USRS.Where(u => u.usr_username == username).SingleOrDefault();
            var userid = getUserId.usr_id;
            var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
            DateTime serverDate = dateQuery.AsEnumerable().First();

            if (isUpdate == true) {
                obj.WMS_MSTR_LVL1M.RemoveRange(obj.WMS_MSTR_LVL1M.Where(x => x.usr_id == userid));
                obj.WMS_MSTR_LVL2M.RemoveRange(obj.WMS_MSTR_LVL2M.Where(y => y.usr_id == userid));
                obj.WMS_MSTR_LVL3M.RemoveRange(obj.WMS_MSTR_LVL3M.Where(z => z.usr_id == userid));
            }
            var lvl1GrpMod = (from m in obj.WMS_GRPLVL1_VIEW where m.grp_id == group_id select new { m.mod_id, m.stat_desc });
            foreach (var mod in lvl1GrpMod)
            {
                var users = obj.Set<WMS_MSTR_LVL1M>();
                users.Add(new WMS_MSTR_LVL1M
                {
                    usr_id = userid,
                    mod_id = mod.mod_id,
                    date_added = serverDate,
                    added_by = loggedin_user.userId
                });
            }
            obj.SaveChanges();
            AddDefaultModuleLvl2();
        }

        public List<int> lvl1IdArray = new List<int>();
        public void AddDefaultModuleLvl2()
        {
            string username = textBox3.Text.Trim();
            var getUserId = obj.WMS_MSTR_USRS.Where(u => u.usr_username == username).SingleOrDefault();
            var userid = getUserId.usr_id;

            var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
            DateTime serverDate = dateQuery.AsEnumerable().First();

            var lvl2GrpMod = (from m in obj.WMS_GRPLVL2_VIEW where m.grp_id == group_id select new { m.s1mod_id, m.stat_desc });
            int x = 0;
            foreach (var mod in lvl2GrpMod)
            {
                var users = obj.Set<WMS_MSTR_LVL2M>();
                users.Add(new WMS_MSTR_LVL2M
                {
                    usr_id = userid,
                    s1mod_id = mod.s1mod_id,
                    date_added = serverDate,
                    added_by = loggedin_user.userId
                });
                x++;
            }
            obj.SaveChanges();
            AddDefaultModuleLvl3();
        }

        public List<int> lvl2IdArray = new List<int>();
        public void AddDefaultModuleLvl3()
        {
            string username = textBox3.Text.Trim();
            var getUserId = obj.WMS_MSTR_USRS.Where(u => u.usr_username == username).SingleOrDefault();
            var userid = getUserId.usr_id;

            var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
            DateTime serverDate = dateQuery.AsEnumerable().First();

            var lvl3GrpMod = (from m in obj.WMS_GRPLVL3_VIEW where m.grp_id == group_id select new { m.s2mod_id, m.stat_desc });
            foreach (var mod in lvl3GrpMod)
            {
                var users = obj.Set<WMS_MSTR_LVL3M>();
                users.Add(new WMS_MSTR_LVL3M
                {
                    usr_id = userid,
                    s2mod_id = mod.s2mod_id,
                    date_added = serverDate,
                    added_by = loggedin_user.userId
                });
            }
            obj.SaveChanges();
            lvl1IdArray.Clear();
            lvl2IdArray.Clear();
            MessageBox.Show("Successfully Added Default User Module.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            US_Upload_Data usup = new US_Upload_Data();
            usup.Show();
        }
        private void GrpAccess()
        {
           
        }
    }
}
