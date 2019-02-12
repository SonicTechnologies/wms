using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using wms.Class;
using wms.Entity_Class;
using System.IO;

namespace wms.Forms.Administration.SALESMAN
{
    public partial class SB_Booking_Upload_Data : Form
    {
        public SB_Booking_Upload_Data()
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
        int TranCounter2;

        int updated;
        int inserted;

        Excel.Application Excel1;
        Excel.Workbook Workbook1;
        Excel.Worksheet Worksheet1;

        int sitenotexist;

        int TotalError;

        int a;

        object misValue1 = System.Reflection.Missing.Value;


        private void label2_Click(object sender, EventArgs e)
        {

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
                this.Height = 177;

            }
        }

        public void getMaxLineItems1()
        {
            progressBar1.Value = 0;
            strConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox1.Text + ";Extended Properties='Excel 12.0 Xml;HDR=YES'";
            con1.ConnectionString = strConnectionString;

            con1.Open();
            cmd1.CommandText = "select DISTINCT [Site] from [Sheet1$] WHERE [Salesman Code]<>''";
            cmd1.Connection = con1;
            OleDbDataReader dr1 = cmd1.ExecuteReader();

            if (dr1.Read() == true)
            {
                dt1.Reset();
                dr1.Close();
                adapt1.SelectCommand = cmd1;
                adapt1.Fill(dt1);
  
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

        public void getMaxLineItems2()
        {
           

            con1.Open();
            cmd1.CommandText = "select DISTINCT * from [Sheet1$] WHERE [Salesman Code]<>'' ORDER BY [Salesman Name]";
            cmd1.Connection = con1;
            OleDbDataReader dr1 = cmd1.ExecuteReader();

            if (dr1.Read() == true)
            {
                dt1.Reset();
                dr1.Close();
                adapt1.SelectCommand = cmd1;
                adapt1.Fill(dt1);

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

        private void Execute1()
        {
            label2.Text = "Validating Site..";
            label2.Visible = true;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void Execute2()
        {

            label2.Text = "Uploading 0 out of " + max.ToString() + " Salesman";
            label1.Text = "0% Completed";
            backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker2.RunWorkerAsync();
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
                getMaxLineItems1();
                Execute1();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Excel1 = new Microsoft.Office.Interop.Excel.Application();
            Workbook1 = Excel1.Workbooks.Add(misValue1);
            Worksheet1 = Workbook1.Sheets["Sheet1"];

            sitenotexist = 0;

            TranCounter1 = 0;

            TotalError = 0;

            a = 0;

            con1.Open();
            cmd1.CommandText = "select DISTINCT [Site] from [Sheet1$] WHERE [Salesman Code]<>''";
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
                    var xxsite = i["Site"].ToString();
                    var xsite = (from c in obj.WMS_MSTR_SITE
                                 where c.site_id == xxsite
                                 select c.site_id).ToList();
                    if (xsite.Count > 0)
                    {


                    }
                    else
                    {
                        Worksheet1.Cells[1, 1] = "Site";
                        Worksheet1.Cells[1, 2] = "Remarks";

                        Worksheet1.Cells[2 + a, 1] = i["Site"].ToString();
                        Worksheet1.Cells[2 + a, 2] = "Site not registered.";

                        a = a + 1;

                        sitenotexist = sitenotexist + 1;
                    }

                    TranCounter1 = TranCounter1 + 1;

                    backgroundWorker1.ReportProgress(Convert.ToInt32(100 * TranCounter1 / max), "Validating " + TranCounter1.ToString() + " out of " + max.ToString() + " Site(s)");

                    if (backgroundWorker1.CancellationPending)
                    {
                        backgroundWorker1.ReportProgress(Convert.ToInt32(100 * TranCounter1 / max), "Cancelling...");
                
                        backgroundWorker1.ReportProgress(100, "Cancelled!");
                        break;
                    }

                }
            }
            con1.Close();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
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

                Excel1.DisplayAlerts = false;

                TotalError = sitenotexist;

                if (TotalError > 0)
                {

                    Worksheet1.Activate();
                    Excel.Range myRange;
                    myRange = Worksheet1.Range["A2", "Z" + Worksheet1.UsedRange.Rows.Count.ToString()];
                    myRange.Select();
                    myRange.Sort(Key1: myRange.Range["A2"], Order1: Microsoft.Office.Interop.Excel.XlSortOrder.xlAscending, Orientation: Microsoft.Office.Interop.Excel.XlSortOrientation.xlSortColumns);

                    if (File.Exists(Path.GetDirectoryName(openFileDialog1.FileName).ToString() + @"\" + Path.GetFileNameWithoutExtension(openFileDialog1.SafeFileName).ToString() + " - Site Not Registered" + Path.GetExtension(openFileDialog1.FileName)))
                    {
                        File.Delete(Path.GetDirectoryName(openFileDialog1.FileName).ToString() + @"\" + Path.GetFileNameWithoutExtension(openFileDialog1.SafeFileName).ToString() + " - Site Not Registered" + Path.GetExtension(openFileDialog1.FileName));
                        Worksheet1.SaveAs(Path.GetDirectoryName(openFileDialog1.FileName).ToString() + @"\" + Path.GetFileNameWithoutExtension(openFileDialog1.SafeFileName).ToString() + " - Site Not Registered" + Path.GetExtension(openFileDialog1.FileName));
                    }
                    else
                    {
                        Worksheet1.SaveAs(Path.GetDirectoryName(openFileDialog1.FileName).ToString() + @"\" + Path.GetFileNameWithoutExtension(openFileDialog1.SafeFileName).ToString() + " - Site Not Registered" + Path.GetExtension(openFileDialog1.FileName));
                    }

                    MessageBox.Show("Cannot upload file.. \n\n" + "View error log saved in " + Path.GetDirectoryName(openFileDialog1.FileName).ToString() + ".", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                else
                {

                    getMaxLineItems2();
                    Execute2();

                }
            }

            Workbook1.Close();

            Excel1.Quit();
            releaseObject(Excel1);
            releaseObject(Workbook1);
            releaseObject(Worksheet1);
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            inserted = 0;
            updated = 0;

            con1.Open();
            cmd1.CommandText = "select DISTINCT * from [Sheet1$] WHERE [Salesman Code]<>'' ORDER BY [Salesman Name]";
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

                    var xxslsmancode = i["Salesman Code"].ToString();
                    var xslsmancode = (from c in obj.WMS_MSTR_SLSMAN
                                       where c.salesman_id == xxslsmancode
                                       select c.salesman_id).FirstOrDefault();
                    if (xslsmancode == null)
                    {

                        var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                        DateTime serverDate = dateQuery.AsEnumerable().First();

                        var slsman = obj.Set<WMS_MSTR_SLSMAN>();
                        slsman.Add(new WMS_MSTR_SLSMAN
                        {
                            salesman_id = i["Salesman Code"].ToString().ToUpper(),
                            salesman_name = i["Salesman Name"].ToString().ToUpper(),
                            salesman_type_id = 1,
                            site_id = i["Site"].ToString().ToUpper(),
                            salesman_datecrtd = serverDate,
                            salesman_crtdby = loggedin_user.userId

                        });

                        if (obj.SaveChanges() > 0)
                        {

                        }
                        else
                        {

                        }

                        inserted = inserted + 1;

                    }
                    else
                    {

                        var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                        DateTime serverDate = dateQuery.AsEnumerable().First();

                        var xxsalesmancode = i["Salesman Code"].ToString();

                        obj.WMS_MSTR_SLSMAN.Where(c => c.salesman_id == xxsalesmancode).ToList().ForEach(x =>
                        {

                            x.salesman_name = i["Salesman Name"].ToString().ToUpper();
                            x.salesman_type_id = 1;
                            x.site_id = i["Site"].ToString().ToUpper();
                            x.salesman_dateuptd = serverDate;
                            x.salesman_uptdby = loggedin_user.userId;

                        });

                        if (obj.SaveChanges() > 0)
                        {

                        }
                        else
                        {

                        }

                        updated = updated + 1;

                    }


                    TranCounter2 = TranCounter2 + 1;

                    backgroundWorker2.ReportProgress(Convert.ToInt32(100 * TranCounter2 / max), "Uploading " + TranCounter2.ToString() + " out of " + max.ToString() + " Salesman(s)");

                    if (backgroundWorker2.CancellationPending)
                    {
                        backgroundWorker2.ReportProgress(Convert.ToInt32(100 * TranCounter2 / max), "Cancelling...");
                        //    e.Cancel = true;
                        backgroundWorker2.ReportProgress(100, "Cancelled!");
                        break;
                    }


                }

            }
            con1.Close();
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label2.Text = Convert.ToString(e.UserState);
            label1.Text = e.ProgressPercentage.ToString() + "% complete";
            progressBar1.Increment(1);
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                MessageBox.Show("Successfully Uploaded " + TranCounter2.ToString() + " out of " + max.ToString() + " Salesman(s) \n\n" + "New: " + inserted.ToString() + "\n" + "Updated: " + updated.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void SB_Booking_Upload_Data_Load(object sender, EventArgs e)
        {
            Main_Form.GetInstance().Enabled = false;
        }

        private void SB_Booking_Upload_Data_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main_Form.GetInstance().Enabled = true;
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
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
