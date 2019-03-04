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
using wms.Forms;

namespace wms.Forms.Warehouse_Management
{
    public partial class Dvmr_Uploading_Data : Form
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

        int updated;
        int inserted;


        Excel.Application Excel1;
        Excel.Workbook Workbook1;
        Excel.Worksheet Worksheet1;

        Excel.Application Excel2;
        Excel.Workbook Workbook2;
        Excel.Worksheet Worksheet2;

        object misValue1 = System.Reflection.Missing.Value;
        object misValue2 = System.Reflection.Missing.Value;

        int ItemNotRegistered;
        int SiteNotRegistered;

        int TotalError;

        int a;
        int b;

        public Dvmr_Uploading_Data()
        {
            InitializeComponent();
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

        public void getMaxLineItem()
        {
            progressBar1.Value = 0;
            strConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox1.Text + ";Extended Properties='Excel 12.0 Xml;HDR=YES'";
            con1.ConnectionString = strConnectionString;
            con1.Open();
            cmd1.CommandText = "select DISTINCT [Material] from [Sheet1$] WHERE [Material] <>  null  ORDER BY [Material]";
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

        public void getMaxLineSite()
        {
            progressBar1.Value = 0;

            con1.Open();
            cmd1.CommandText = "select DISTINCT [Ship-to] from [Sheet1$] WHERE [Material]<> null  ORDER BY [Ship-to]";
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

        public void getMaxLineDvmr()
        {
            progressBar1.Value = 0;
            con1.Open();
            cmd1.CommandText = "select * from [Sheet1$] WHERE [Material]<> null ORDER BY [Customer Name]";
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

            label2.Text = "Validating Item..";
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

            label2.Text = "Uploading 0 out of " + max.ToString() + " Dvmr(s)";
            label1.Text = "0% Completed";
            backgroundWorker3.WorkerReportsProgress = true;
            backgroundWorker3.RunWorkerAsync();
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
                getMaxLineItem();
                Execute1();

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Excel1 = new Excel.Application();
            Workbook1 = Excel1.Workbooks.Add(misValue1);
            Worksheet1 = Workbook1.Sheets["Sheet1"];

            ItemNotRegistered = 0;
            TranCounter1 = 0;
            a = 0;
            con1.Open();
            cmd1.CommandText = "select DISTINCT [Material] from [Sheet1$] WHERE [Material]<> null ORDER BY [Material]";
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

                    string xItem = i["Material"].ToString();
                    var Item = (from c in obj.WMS_MSTR_INVTY
                                where c.invty_id == xItem
                                select c.invty_id).ToList();
                    if (Item.Count > 0)
                    {


                    }
                    else
                    {

                        Worksheet1.Cells[1, 1] = "Material";


                        Worksheet1.Cells[2 + a, 1] = i["Material"].ToString();


                        a = a + 1;

                        ItemNotRegistered = ItemNotRegistered + 1;
                    }

                    TranCounter1 = TranCounter1 + 1;

                    backgroundWorker1.ReportProgress(Convert.ToInt32(100 * TranCounter1 / max), "Checking " + TranCounter1.ToString() + " out of " + max.ToString() + " Item(s)");

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
            cmd1.CommandText = "select DISTINCT [Ship-to] from [Sheet1$] WHERE [Material]<> null ORDER BY [Ship-to]";
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

                    string xsite = i["Ship-to"].ToString();
                    var site = (from c in obj.WMS_MSTR_SITE
                                where c.site_code == xsite
                                select c.site_code).ToList();
                    if (site.Count > 0)
                    {

                    
                    }
                    else
                    {
                        Worksheet2.Cells[1, 1] = "Ship-to";

                        Worksheet2.Cells[2 + b, 1] = i["Ship-to"].ToString();

                        b = b + 1;

                        SiteNotRegistered = SiteNotRegistered + 1;

                    }

                    TranCounter2 = TranCounter2 + 1;

                    backgroundWorker2.ReportProgress(Convert.ToInt32(100 * TranCounter2 / max), "Initiated " + TranCounter2.ToString() + " out of " + max.ToString() + " Dvmr(s)");

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
            inserted = 0;
            updated = 0;
            con1.Open();

            cmd1.CommandText = "select * from [Sheet1$] WHERE [Material]<>NULL ";
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
               

                    string xItem = i["Material"].ToString();         
                    string xBillDoc = i["Bill#Doc#"].ToString();

                    var Item = (from c in obj.WMS_MSTR_DVMR
                                    where c.dvmr_billdoc == xBillDoc
                                 && c.invty_id == xItem 
                                select c.invty_id).FirstOrDefault();

                 
                    if (Item == null)
                    {

                            var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                            DateTime serverDate = dateQuery.AsEnumerable().First();

                            var dvmr = obj.Set<WMS_MSTR_DVMR>();
                            dvmr.Add(new WMS_MSTR_DVMR
                            {
                                dvmr_load_date = Convert.ToDateTime(i["Load Date"]),
                                site_code = i["Ship-to"].ToString().ToUpper(),
                                dvmr_customer = i["Customer Name"].ToString().ToUpper(),
                                dvmr_rdd = Convert.ToDateTime(i["RDD"].ToString()),
                                dvmr_shipment = i["Shipment"].ToString().ToUpper(),
                                dvmr_shipping_line = i["Shipping Line"].ToString(),
                                dvmr_truck_no = i["Truck No"].ToString(),
                                dvmr_cvan = i["CVAN"].ToString(),
                                dvmr_salesdoc = i["Sales Doc#"].ToString(),
                                dvmr_po_number = i["PO number"].ToString(),
                                dvmr_billdoc = i["Bill#Doc#"].ToString(),
                                dvmr_category = i["Category"].ToString(),
                                invty_id = i["Material"].ToString(),
                                dvmr_qty = Convert.ToInt32(i["Qty"]),
                                dvmr_date_added = serverDate

                            });


                   

                        obj.SaveChanges();
                        inserted = inserted + 1;


                    }
                    else
                    {

                        string xItem2 = i["Material"].ToString();
                        string xBillDoc2 = i["Bill#Doc#"].ToString();

                        var Item2 = (from c in obj.WMS_MSTR_DVMR
                                    where c.dvmr_billdoc == xBillDoc2
                                 && c.invty_id == xItem2
                                    select c.invty_id).FirstOrDefault();

                        var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                        DateTime serverDate = dateQuery.AsEnumerable().First();

                        obj.WMS_MSTR_DVMR.Where(c => c.invty_id == Item2 && c.dvmr_schedule_date == null).ToList().ForEach(x =>
                        {
                            x.dvmr_load_date = Convert.ToDateTime(i["Load Date"]);
                            x.site_code = i["Ship-to"].ToString().ToUpper();
                            x.dvmr_customer = i["Customer Name"].ToString().ToUpper();
                            x.dvmr_rdd = Convert.ToDateTime(i["RDD"].ToString());
                            x.dvmr_shipment = i["Shipment"].ToString().ToUpper();
                            x.dvmr_shipping_line = i["Shipping Line"].ToString();
                            x.dvmr_truck_no = i["Truck No"].ToString();
                            x.dvmr_cvan = i["CVAN"].ToString();
                            x.dvmr_salesdoc = i["Sales Doc#"].ToString();
                            x.dvmr_po_number = i["PO number"].ToString();
                            x.dvmr_billdoc = i["Bill#Doc#"].ToString();
                            x.dvmr_category = i["Category"].ToString();
                            x.invty_id = i["Material"].ToString();
                            x.dvmr_qty = Convert.ToInt32(i["Qty"]);
                            x.dvmr_date_added = serverDate;

                        });
       
                  

                        updated = updated + 1;


                    }

                    TranCounter3 = TranCounter3 + 1;

                    backgroundWorker3.ReportProgress(Convert.ToInt32(100 * TranCounter3 / max), "Uploading " + TranCounter3.ToString() + " out of " + max.ToString() + " Dvmr(s)");

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

                TotalError = ItemNotRegistered + SiteNotRegistered;

                if (TotalError > 0)
                {

                    if (ItemNotRegistered > 0)
                    {
                        Worksheet1.Activate();
                        Excel.Range myRange;
                        myRange = Worksheet1.Range["A2", "Z" + Worksheet1.UsedRange.Rows.Count.ToString()];
                        myRange.Select();
                        myRange.Sort(Key1: myRange.Range["A2"], Order1: Microsoft.Office.Interop.Excel.XlSortOrder.xlAscending, Orientation: Microsoft.Office.Interop.Excel.XlSortOrientation.xlSortColumns);

                        if (File.Exists(Path.GetDirectoryName(openFileDialog1.FileName).ToString() + @"\" + Path.GetFileNameWithoutExtension(openFileDialog1.SafeFileName).ToString() + " - Item Not Found" + Path.GetExtension(openFileDialog1.FileName)))
                        {
                            File.Delete(Path.GetDirectoryName(openFileDialog1.FileName).ToString() + @"\" + Path.GetFileNameWithoutExtension(openFileDialog1.SafeFileName).ToString() + " - Item Not Found" + Path.GetExtension(openFileDialog1.FileName));
                            Worksheet1.SaveAs(Path.GetDirectoryName(openFileDialog1.FileName).ToString() + @"\" + Path.GetFileNameWithoutExtension(openFileDialog1.SafeFileName).ToString() + " - Item Not Found" + Path.GetExtension(openFileDialog1.FileName));
                        }
                        else
                        {
                            Worksheet1.SaveAs(Path.GetDirectoryName(openFileDialog1.FileName).ToString() + @"\" + Path.GetFileNameWithoutExtension(openFileDialog1.SafeFileName).ToString() + " - Item Not Found" + Path.GetExtension(openFileDialog1.FileName));
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

                    getMaxLineDvmr();
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
                MessageBox.Show("Successfully Uploaded " + TranCounter3.ToString() + " out of " + max.ToString() + "\n" + "New: " + inserted.ToString() + "\n" + "Updated: " + updated.ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Dvmr_Uploading_Data_Load(object sender, EventArgs e)
        {
            Main_Form.GetInstance().Enabled = false;
        }

        private void Dvmr_Uploading_Data_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main_Form.GetInstance().Enabled = true;
        }
    }
}
