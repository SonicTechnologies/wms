using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wms.Entity_Class;
using wms.Class;

namespace wms.Forms.Administration.Users
{
    public partial class US_Upload_Data : Form
    {
        public US_Upload_Data()
        {
            InitializeComponent();
        }

        OleDbCommand cmd1 = new OleDbCommand();
        OleDbConnection con1 = new OleDbConnection();

        DataTable dt1 = new DataTable();
        OleDbDataAdapter adapt1 = new OleDbDataAdapter();
 
        wmsdb obj = new wmsdb();

        string strConnectionString;

        int max;

        int TranCounter1;

        int inserted;

        int updated;

        private void US_Upload_Data_Load(object sender, EventArgs e)
        {
            Main_Form.GetInstance().Enabled = false;
        }

        private void US_Upload_Data_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main_Form.GetInstance().Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Microsoft Excel 2007|*.xlsx|Microsoft Excel 2003|*.xls";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                textBox1.Text = "";
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        public void getMaxLineItems()
        {
            progressBar1.Value = 0;
            strConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox1.Text + ";Extended Properties='Excel 12.0 Xml;HDR=YES'";
            con1.ConnectionString = strConnectionString;

            con1.Open();

            cmd1.CommandText = "select DISTINCT * from [Sheet1$] WHERE [Username]<>'' AND [Password]<>'' AND [First Name]<>'' AND [Last Name]<>'' AND [User Type]<>'' AND [User Group]<>'' AND [Status]<>'' ORDER BY [Username]";
            cmd1.Connection = con1;
            OleDbDataReader dr1 = cmd1.ExecuteReader();

            if (dr1.Read() == true)
            {

                dt1.Reset();
                dr1.Close();
                adapt1.SelectCommand = cmd1;
                adapt1.Fill(dt1);
                //dataGridView1.Rows.Clear();
                if (dt1.Rows.Count > 0)
                {

                    max = dt1.Rows.Count;
                    progressBar1.Maximum = dt1.Rows.Count;

                }
                else
                {

                    max = 0;
                    progressBar1.Maximum = 0;

                }

            }
            con1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {

            }
            else
            {
                textBox1.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                getMaxLineItems();
                Execute1();
            }
        }

        private void Execute1()
        {
            label2.Text = "Uploading 0 out of " + max.ToString() + " Item(s)";
            label2.Visible = true;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            TranCounter1 = 0;

            inserted = 0;

            updated = 0;

            con1.Open();
            cmd1.CommandText = "select DISTINCT * from [Sheet1$] WHERE [Username]<>'' AND [Password]<>'' AND [First Name]<>'' AND [Last Name]<>'' AND [User Type]<>'' AND [User Group]<>'' AND [Status]<>'' ORDER BY [Username]";
            cmd1.Connection = con1;
            OleDbDataReader dr1 = cmd1.ExecuteReader();

            if (dr1.Read() == true)
            {
                dt1.Reset();
                dr1.Close();
                adapt1.SelectCommand = cmd1;
                adapt1.Fill(dt1);

                foreach (DataRow i in dt1.Rows)
                {
                    var xxusername = i["Username"].ToString();
                    var xusrid = (from c in obj.WMS_MSTR_USRS
                                  where c.usr_username == xxusername
                                  select c.usr_id).ToList();

                    string xusrtypedesc = i["User Type"].ToString();
                    int? xusrtypeid = null;
                    var usrtypeid = (from c in obj.WMS_TYPE_USRS
                                     where c.usr_type_name == xusrtypedesc
                                     select c.usr_type_id).FirstOrDefault();

                    xusrtypeid = usrtypeid;

                    string xusrgroupdesc = i["User Group"].ToString();
                    int? xusrgroupid = null;
                    var usrgroupid = (from c in obj.WMS_MSTR_UGRP
                                     where c.grp_name == xusrgroupdesc
                                     select c.grp_id).FirstOrDefault();

                    xusrgroupid = usrgroupid;

                    string xstatdesc = i["Status"].ToString();
                    int? xstatid = null;
                    var statid = (from c in obj.WMS_TYPE_STAT
                                  where c.stat_desc == xstatdesc
                                  select c.stat_id).FirstOrDefault();

                    xstatid = statid;

                    var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                    DateTime serverDate = dateQuery.AsEnumerable().First();

                    if (xusrid.Count > 0)
                    {

                        obj.WMS_MSTR_USRS.Where(c => c.usr_username == xxusername).ToList().ForEach(x =>
                        {
                            x.usr_password = i["Password"].ToString();
                            x.usr_fname = i["First Name"].ToString().ToUpper();
                            x.usr_lname = i["First Name"].ToString().ToUpper();
                            x.usr_type_id = Convert.ToInt32(xusrtypeid);
                            x.grp_id = Convert.ToInt32(xusrgroupid);
                            x.stat_id = Convert.ToInt32(xstatid);
                            x.usr_dateuptd = serverDate;
                            x.usr_uptdby = loggedin_user.userId;

                        });
                        obj.SaveChanges();

                        updated = updated + 1;
                    }
                    else
                    {

                        var xuser = obj.Set<WMS_MSTR_USRS>();
                        xuser.Add(new WMS_MSTR_USRS
                        {
                            usr_username = i["Username"].ToString(),
                            usr_password = i["Password"].ToString(),
                            usr_fname = i["First Name"].ToString().ToUpper(),
                            usr_lname = i["Last Name"].ToString().ToUpper(),
                            usr_type_id = Convert.ToInt32(xusrtypeid),
                            grp_id = Convert.ToInt32(xusrgroupid),
                            stat_id = Convert.ToInt32(xstatid),
                            usr_datecrtd = serverDate,
                            usr_crtdby = loggedin_user.userId
                        });

                        obj.SaveChanges();

                        inserted = inserted + 1;
                    }


                    TranCounter1 = TranCounter1 + 1;

                    backgroundWorker1.ReportProgress(Convert.ToInt32(100 * TranCounter1 / max), "Uploading " + TranCounter1.ToString() + " out of " + max.ToString() + " User(s)");

                    if (backgroundWorker1.CancellationPending)
                    {
                        backgroundWorker1.ReportProgress(Convert.ToInt32(100 * TranCounter1 / max), "Cancelling...");
                        //    e.Cancel = true;
                        backgroundWorker1.ReportProgress(100, "Cancelled!");
                        break;
                    }

                }

            }
            con1.Close();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label2.Text = Convert.ToString(e.UserState);
            label1.Text = e.ProgressPercentage.ToString() + "% complete";
            progressBar1.Increment(1);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)

                MessageBox.Show(e.Error.Message, " Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (e.Cancelled)
            {
                //  cnnOLEDBx.Close();
                MessageBox.Show("Task Cancelled by User!", " Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Successfully Uploaded " + TranCounter1.ToString() + " out of " + max.ToString() + " User(s). \n\n" + "New: " + inserted.ToString() + "\n" + "Updated: " + updated.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

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
    }
}
