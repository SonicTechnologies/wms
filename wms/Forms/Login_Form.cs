using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wms.Forms;
using wms.Class;
using wms.Entity_Class;
using System.Threading;

namespace wms
{
    public partial class Login_Form : Form
    {
        public static Login_Form loginFormInstance = null;

        public Login_Form()
        {
            InitializeComponent();
        }
        
        public static Login_Form GetInstance()
        {
            if (Login_Form.loginFormInstance == null)
            {
                Login_Form.loginFormInstance = new Login_Form();
                Login_Form.loginFormInstance.FormClosed += new FormClosedEventHandler(loginFormInstance_FormClosed);
                
            }
            return Login_Form.loginFormInstance;
        }

        static void loginFormInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login_Form.loginFormInstance = null;
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            AcceptButton = button1;
            set_default_server();
        }

        public void set_default_server()
        {
            Select_Server_Form.read_default_server();
            textBox4.Text = Select_Server_Form.xserver_name;
            textBox1.Text = Select_Server_Form.xdbname;
            Select_Server_Form.setdbconn();
        }

        public void get_server()
        {
            textBox4.Text = Select_Server_Form.xserver_name;
            textBox1.Text = Select_Server_Form.xdbname;
            Select_Server_Form.setdbconn();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Select_Server_Form ssf = new Select_Server_Form();
            ssf.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                if (textBox2.Text.Trim() == "" && textBox3.Text.Trim() == "")
                {
                    MessageBox.Show("Please provide username.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox2.Focus();

                }
                else if (textBox2.Text.Trim() == "" && textBox3.Text.Trim() != "")
                {
                    MessageBox.Show("Please provide username.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox2.Focus();
                }
                else if (textBox2.Text.Trim() != "" && textBox3.Text.Trim() == "")
                {
                    MessageBox.Show("Please provide password.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox3.Focus();
                }
            }
            else
            {
                wmsdb obj = new wmsdb();
                var cc = (from c in obj.WMS_USRS_VIEW
                          where c.usr_username == textBox2.Text.Trim()
                          select c.usr_username).FirstOrDefault();
                if (cc != null)
                {
                    var dd = (from c in obj.WMS_USRS_VIEW
                              where c.usr_username == textBox2.Text.Trim()
                              select new
                              {
                                  c.usr_id,
                                  c.usr_username,
                                  c.usr_password,
                                  c.usr_fname,
                                  c.usr_lname,
                                  c.usr_type_id,
                                  c.usr_type_name
                              }).FirstOrDefault();
                    
                    if (textBox3.Text.Trim() == dd.usr_password)
                    {
                        loggedin_user.userId = dd.usr_id;
                        loggedin_user.userName = dd.usr_username;
                        loggedin_user.fistName = dd.usr_fname;
                        loggedin_user.lastName = dd.usr_lname;
                        loggedin_user.userTypeId = dd.usr_type_id;
                        loggedin_user.userTypeName = dd.usr_type_name;

                        label1.Focus();
                        Thread.Sleep(1);
                        this.Hide();
                        textBox2.Text = "";
                        textBox3.Text = "";
                        Form xmf = Application.OpenForms["Main_Form"];
                        if (xmf != null)
                        {
                            Main_Form.GetInstance().Show();
                        }
                        else
                        {
                           Main_Form.GetInstance().Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("You have entered invalid password.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You are not registered, Please contact administrator.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
