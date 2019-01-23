using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading.Tasks;
using System.Windows.Forms;
using wms.Entity_Class;
using System.IO;
using wms.Class;

namespace wms.Forms.Administration.Customer
{
    public partial class CM_Upload_Data : Form
    {
        OleDbCommand cmd1 = new OleDbCommand();
        OleDbConnection con1 = new OleDbConnection();

        DataTable dt1 = new DataTable();
        OleDbDataAdapter adapt1 = new OleDbDataAdapter();

        wmsdb obj = new wmsdb();

        string strConnectionString;

        int max;
        int TranCounter1;
        int TranCounter2;
        int TranCounter3;



        Excel.Application Excel1;
        Excel.Workbook Workbook1;
        Excel.Worksheet Worksheet1;

        Excel.Application Excel2;
        Excel.Workbook Workbook2;
        Excel.Worksheet Worksheet2;

        object misValue1 = System.Reflection.Missing.Value;
        object misValue2 = System.Reflection.Missing.Value;

        int SlsmanNotRegistered;
        int SiteNotRegistered;

        int TotalError;

        int a;
        int b;
        public CM_Upload_Data()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter= "Microsoft Excel 2007|*.xlsx|Microsoft Excel 2003|*.xls";
            openFileDialog1.ShowDialog();

            if(openFileDialog1.FileName != "")
            {
                textBox1.Text = "";
                textBox1.Text = openFileDialog1.FileName;
                this.Height = 177;
            }
        }

        public void getMaxLineSlsman()
        {
            progressBar1.Value = 0;
            strConnectionString= "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox1.Text + ";Extended Properties='Excel 12.0 Xml;HDR=YES'";
            con1.ConnectionString = strConnectionString;
            con1.Open();
            cmd1.CommandText= "select DISTINCT [Salesman],[Salesman Name] from [Sheet1$] WHERE [Salesman]<>'' ORDER BY [Salesman]";
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

        public void getMaxLineSite()
        {
            progressBar1.Value = 0;

            con1.Open();
            cmd1.CommandText= "select DISTINCT [Delivering Site] from [Sheet1$] WHERE [Salesman]<>'' ORDER BY [Delivering Site]";
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

        public void getMaxLineCustomers()
        {
            progressBar1.Value = 0;     
            con1.Open();
            cmd1.CommandText = "select * from [Sheet1$] WHERE [Salesman]<>'' ORDER BY [Name1]";
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

            label2.Text = "Validating Salesman..";
            label2.Visible = true;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerAsync();
        }
        private void Execute2()
        {

            label2.Text = "Validating Site..";
            label1.Text = "0% Completed";
            backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker2.RunWorkerAsync();
        }

        private void Execute3()
        {

            label2.Text = "Uploading 0 out of " + max.ToString() + " Customer(s)";
            label1.Text = "0% Completed";
            backgroundWorker3.WorkerReportsProgress = true;
            backgroundWorker3.RunWorkerAsync();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if( textBox1.Text.Trim() == "")
            {

            }
            else
            {
                textBox1.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                getMaxLineSlsman();
                Execute1();
                
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Excel1 = new Excel.Application();
            Workbook1 = Excel1.Workbooks.Add(misValue1);
            Worksheet1 = Workbook1.Sheets["Sheet1"];

            SlsmanNotRegistered = 0;
            TranCounter1 = 0;
            a = 0;
            con1.Open();
            cmd1.CommandText = "select DISTINCT [Salesman],[Salesman Name] from [Sheet1$] WHERE [Salesman]<>'' ORDER BY [Salesman]";
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

                    string xsalesman = i["Salesman"].ToString().Replace("/", "");
                    var salesman = (from c in obj.WMS_SLSMAN_VIEW
                                    where c.salesman_id == xsalesman
                                    select c.salesman_id).FirstOrDefault();
                    if (salesman == null)
                    {
                        Worksheet1.Cells[1, 1] = "Salesman";
                        Worksheet1.Cells[1, 2] = "Salesman Name";

                        Worksheet1.Cells[2 + a, 1] = i["Salesman"].ToString().Replace("/", "");
                        Worksheet1.Cells[2 + a, 2] = i["Salesman Name"].ToString().Replace("/", "");

                        a = a + 1;

                        SlsmanNotRegistered = SlsmanNotRegistered + 1;
                    }
                    else
                    {

                    }

                    TranCounter1 = TranCounter1 + 1;

                    backgroundWorker1.ReportProgress(Convert.ToInt32(100 * TranCounter1 / max), "Checking " + TranCounter1.ToString() + " out of " + max.ToString() + " Salesman");

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

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            Excel2 = new Excel.Application();
            Workbook2 = Excel2.Workbooks.Add(misValue2);
            Worksheet2 = Workbook2.Sheets["Sheet1"];


            SiteNotRegistered = 0;

            TranCounter2 = 0;


            b = 0;

            con1.Open();
            cmd1.CommandText = "select DISTINCT [Delivering Site] from [Sheet1$] WHERE [Salesman]<>'' ORDER BY [Delivering Site]";
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

                    string xsite = i["Delivering Site"].ToString();
                    var site = (from c in obj.WMS_MSTR_SITE
                                where c.site_id == xsite
                                select c.site_id).FirstOrDefault();
                    if (site == null)
                    {

                        Worksheet2.Cells[1, 1] = "Delivering Site";

                        Worksheet2.Cells[2 + b, 1] = i["Delivering Site"].ToString();

                        b = b + 1;

                        SiteNotRegistered = SiteNotRegistered + 1;
                    }
                    else
                    {

                    }

                    TranCounter2 = TranCounter2 + 1;

                    backgroundWorker2.ReportProgress(Convert.ToInt32(100 * TranCounter2 / max), "Initiated " + TranCounter2.ToString() + " out of " + max.ToString() + " Order(s)");

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

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {

            TranCounter3 = 0;

            con1.Open();

            cmd1.CommandText = "select * from [Sheet1$] WHERE [Salesman]<>'' ORDER BY [Name1]";
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
                    int stat = 0;

                    if (i["Status"].ToString() == "Active")
                    {
                        stat = 1;
                    }
                    else
                    {
                        stat = 2;
                    }

                    string xcustomer = i["Outlet Code"].ToString();
                    var customer = (from c in obj.WMS_CUST_VIEW
                                    where c.cust_id == xcustomer
                                    select c.cust_id).FirstOrDefault();
                    if (customer == null)
                    {
                        var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                        DateTime serverDate = dateQuery.AsEnumerable().First();

                        var customers = obj.Set<WMS_MSTR_CUST>();
                        customers.Add(new WMS_MSTR_CUST
                        {
                            cust_id = i["Outlet Code"].ToString().ToUpper(),
                            cust_name = i["Name1"].ToString().ToUpper(),
                            cust_address = i["Street"].ToString().ToUpper(),
                            salesman_id = i["Salesman"].ToString().Replace("/", "").ToUpper(),
                            site_id = i["Delivering Site"].ToString().ToUpper(),
                            cust_latitude = Convert.ToDouble(i["Latitude"]),
                            cust_longitude = Convert.ToDouble(i["Longitude"]),
                            stat_id = stat,
                            cust_datecrtd = serverDate,
                            cust_crtdby = loggedin_user.userId

                        });
                        obj.SaveChanges();

                    }
                    else
                    {

                        var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                        DateTime serverDate = dateQuery.AsEnumerable().First();

                        obj.WMS_MSTR_CUST.Where(c => c.cust_id == xcustomer).ToList().ForEach(x =>
                        {
                            x.cust_name = i["Name1"].ToString().ToUpper();
                            x.cust_address = i["Street"].ToString().ToUpper();
                            x.salesman_id = i["Salesman"].ToString().Replace("/", "").ToUpper();
                            x.site_id = i["Delivering Site"].ToString().ToUpper();
                            x.cust_latitude = Convert.ToDouble(i["Latitude"]);
                            x.cust_longitude = Convert.ToDouble(i["Longitude"]);
                            x.stat_id = stat;
                            x.cust_dateuptd = serverDate;
                            x.cust_uptdby = loggedin_user.userId;

                        });
                        obj.SaveChanges();

                    }

                    TranCounter3 = TranCounter3 + 1;

                    backgroundWorker3.ReportProgress(Convert.ToInt32(100 * TranCounter3 / max), "Uploading " + TranCounter3.ToString() + " out of " + max.ToString() + " Customer(s)");

                    if (backgroundWorker3.CancellationPending)
                    {
                        backgroundWorker3.ReportProgress(Convert.ToInt32(100 * TranCounter3 / max), "Cancelling...");
                        //    e.Cancel = true;
                        backgroundWorker3.ReportProgress(100, "Cancelled!");
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

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label1.Text = e.ProgressPercentage.ToString() + "% complete";
            progressBar1.Increment(1);
        }

        private void backgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e)
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
                getMaxLineSite();
                Execute2();
            }
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
                Excel1.DisplayAlerts = false;
                Excel2.DisplayAlerts = false;

                TotalError = SlsmanNotRegistered + SiteNotRegistered;

                if (TotalError > 0)
                {

                    if (SlsmanNotRegistered > 0)
                    {
                        Worksheet1.Activate();
                        Excel.Range myRange;
                        myRange = Worksheet1.Range["A2", "Z" + Worksheet1.UsedRange.Rows.Count.ToString()];
                        myRange.Select();
                        myRange.Sort(Key1: myRange.Range["A2"], Order1: Microsoft.Office.Interop.Excel.XlSortOrder.xlAscending, Orientation: Microsoft.Office.Interop.Excel.XlSortOrientation.xlSortColumns);

                        if (File.Exists(Path.GetDirectoryName(openFileDialog1.FileName).ToString() + @"\" + Path.GetFileNameWithoutExtension(openFileDialog1.SafeFileName).ToString() + " - Salesman Not Found" + Path.GetExtension(openFileDialog1.FileName)))
                        {
                            File.Delete(Path.GetDirectoryName(openFileDialog1.FileName).ToString() + @"\" + Path.GetFileNameWithoutExtension(openFileDialog1.SafeFileName).ToString() + " - Salesman Not Found" + Path.GetExtension(openFileDialog1.FileName));
                            Worksheet1.SaveAs(Path.GetDirectoryName(openFileDialog1.FileName).ToString() + @"\" + Path.GetFileNameWithoutExtension(openFileDialog1.SafeFileName).ToString() + " - Salesman Not Found" + Path.GetExtension(openFileDialog1.FileName));
                        }
                        else
                        {
                            Worksheet1.SaveAs(Path.GetDirectoryName(openFileDialog1.FileName).ToString() + @"\" + Path.GetFileNameWithoutExtension(openFileDialog1.SafeFileName).ToString() + " - Salesman Not Found" + Path.GetExtension(openFileDialog1.FileName));
                        }

                    }

                    if (SiteNotRegistered > 0)
                    {
                        Worksheet2.Activate();
                        Excel.Range myRange;
                        myRange = Worksheet2.Range["A2", "Z" + Worksheet2.UsedRange.Rows.Count.ToString()];
                        myRange.Select();
                        myRange.Sort(Key1: myRange.Range["A2"], Order1: Microsoft.Office.Interop.Excel.XlSortOrder.xlAscending, Orientation: Microsoft.Office.Interop.Excel.XlSortOrientation.xlSortColumns);

                        if (File.Exists(Path.GetDirectoryName(openFileDialog1.FileName).ToString() + @"\" + Path.GetFileNameWithoutExtension(openFileDialog1.SafeFileName).ToString() + " - Site Not Found" + Path.GetExtension(openFileDialog1.FileName)))
                        {
                            File.Delete(Path.GetDirectoryName(openFileDialog1.FileName).ToString() + @"\" + Path.GetFileNameWithoutExtension(openFileDialog1.SafeFileName).ToString() + " - Site Not Found" + Path.GetExtension(openFileDialog1.FileName));
                            Worksheet2.SaveAs(Path.GetDirectoryName(openFileDialog1.FileName).ToString() + @"\" + Path.GetFileNameWithoutExtension(openFileDialog1.SafeFileName).ToString() + " - Site Not Found" + Path.GetExtension(openFileDialog1.FileName));
                        }
                        else
                        {
                            Worksheet2.SaveAs(Path.GetDirectoryName(openFileDialog1.FileName).ToString() + @"\" + Path.GetFileNameWithoutExtension(openFileDialog1.SafeFileName).ToString() + " - Site Not Found" + Path.GetExtension(openFileDialog1.FileName));
                        }

                    }

                    MessageBox.Show("Cannot upload file.. \n\n" + "View error log saved in " + Path.GetDirectoryName(openFileDialog1.FileName).ToString() + ".", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {

                    getMaxLineCustomers();
                    Execute3();

                }



            }


            Workbook1.Close();
            Workbook2.Close();

            Excel1.Quit();
            releaseObject(Excel1);
            releaseObject(Workbook1);
            releaseObject(Worksheet1);

            Excel2.Quit();
            releaseObject(Excel2);
            releaseObject(Workbook2);
            releaseObject(Worksheet2);

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


        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                MessageBox.Show("Successfully Uploaded " + TranCounter3.ToString() + " out of " + max.ToString() + " Customer(s)", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
        }

        private void CM_Upload_Data_Load(object sender, EventArgs e)
        {
            Main_Form.GetInstance().Enabled = false;
        }

        private void CM_Upload_Data_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main_Form.GetInstance().Enabled = true;
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
