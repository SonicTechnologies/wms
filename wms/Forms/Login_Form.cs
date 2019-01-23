using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using wms.Class;
using wms.Entity_Class;
using wms.Forms;

namespace wms
{
    public partial class Login_Form : Form
    {
        public static Login_Form loginFormInstance = null;
        public Login_Form()
        {
            InitializeComponent();
        }

        public string UsernameValue
        {
            get { return usernameBox.Text; }
            set { usernameBox.Text = value; }
        }
        
        private void Login_Form_Load(object sender, EventArgs e)
        {
            AcceptButton = loginBtn;
            set_default_server();
        }

        public void set_default_server()
        {
            Select_Server_Form.read_default_server();
            servernameBox.Text = Select_Server_Form.xserver_name;
            databaseBox.Text = Select_Server_Form.xdbname;
            Select_Server_Form.setdbconn();
        }
        public void get_server()
        {

            servernameBox.Text = Select_Server_Form.xserver_name;
            databaseBox.Text = Select_Server_Form.xdbname;
            Select_Server_Form.setdbconn();
        }

        private void optionBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Select_Server_Form ssf = new Select_Server_Form();
            ssf.Show();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (usernameBox.Text.Trim() == "" || passwordBox.Text.Trim() == "")
            {
                if (usernameBox.Text.Trim() == "" && passwordBox.Text.Trim() == "")
                {
                    MessageBox.Show("Please provide username.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    usernameBox.Focus();

                }
                else if (usernameBox.Text.Trim() == "" && passwordBox.Text.Trim() != "")
                {
                    MessageBox.Show("Please provide username.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    usernameBox.Focus();
                }
                else if (usernameBox.Text.Trim() != "" && passwordBox.Text.Trim() == "")
                {
                    MessageBox.Show("Please provide password.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    passwordBox.Focus();
                }
            }
            else
            {

                FeederMasterDB obj = new FeederMasterDB();
                var cc = (from c in obj.FDR_USRS_VIEW
                          where c.usr_username == usernameBox.Text.Trim()
                          select c.usr_username).FirstOrDefault();
                if (cc != null)
                {

                    var dd = (from c in obj.FDR_USRS_VIEW
                              where c.usr_username == usernameBox.Text.Trim()
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


                    if (passwordBox.Text.Trim() == dd.usr_password)
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

                        usernameBox.Text = "";
                        passwordBox.Text = "";


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

        public void getPreviousUser()
        {
            usernameBox.Text = loggedin_user.userName;
        }

        public void setpwdFocus()
        {
            passwordBox.Focus();
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

        private void clearUserBtn_Click(object sender, EventArgs e)
        {
            usernameBox.Text = "";
            usernameBox.Focus();
        }

        private void clearPassBtn_Click(object sender, EventArgs e)
        {
            passwordBox.Text = "";
            usernameBox.Focus();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to exit E-Picklist?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
