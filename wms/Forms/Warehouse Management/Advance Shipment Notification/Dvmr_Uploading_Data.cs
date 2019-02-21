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
                this.Height = 177;
            }
        }

        public void getMaxLineItem()
        {
            progressBar1.Value = 0;
            strConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox1.Text + ";Extended Properties='Excel 12.0 Xml;HDR=YES'";
            con1.ConnectionString = strConnectionString;
            con1.Open();
            cmd1.CommandText = "select DISTINCT [Material],[Customer Name] from [Sheet1$] WHERE [Material] <>  null  ORDER BY [Material]";
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
            cmd1.CommandText = "select DISTINCT [Ship-to] from [Sheet1$] WHERE [Material]<> null ORDER BY [Ship-to]";
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
            cmd1.CommandText = "select DISTINCT [Material],[Customer Name] from [Sheet1$] WHERE [Material]<> null ORDER BY [Material]";
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
                                    select c.invty_id).FirstOrDefault();
                    if (Item == null)
                    {
                        Worksheet1.Cells[1, 1] = "Material";
                        Worksheet1.Cells[1, 2] = "Customer Name";

                        Worksheet1.Cells[2 + a, 1] = i["Material"].ToString();
                        Worksheet1.Cells[2 + a, 2] = i["Customer Name"].ToString();

                        a = a + 1;

                        ItemNotRegistered = ItemNotRegistered + 1;
                    }
                    else
                    {

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
            cmd1.CommandText = "select DISTINCT [Ship-to],[Material]  from [Sheet1$]";
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
                    string material = i["Material"].ToString();

                    var site = (from c in obj.WMS_MSTR_SITE
                                where c.site_code == xsite || xsite == "" || material == ""
                                select c.site_code).FirstOrDefault();
                    if (site == null)
                    {

                        Worksheet2.Cells[1, 1] = "Ship-to";

                        Worksheet2.Cells[2 + b, 1] = i["Ship-to"].ToString();

                        b = b + 1;

                        SiteNotRegistered = SiteNotRegistered + 1;
                    }
                    else
                    {

                    }

                    TranCounter2 = TranCounter2 + 1;

                    backgroundWorker2.ReportProgress(Convert.ToInt32(100 * TranCounter2 / max), "Initiated " + TranCounter2.ToString() + " out of " + max.ToString() + " Dvmr(s)");

                    if (backgroundWorker2.CancellationPending)
                    {
                        backgroundWorker2.ReportProgress(Convert.ToInt32(100 * TranCounter2 / max), "Cancelling...");
                    
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

            cmd1.CommandText = "select * from [Sheet1$] WHERE [Material]";
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

                    if (i != null)
                    {
                        string xItem = i["Material"].ToString();
                        var Item = (from c in obj.WMS_MSTR_INVTY
                                    where c.invty_id == xItem
                                    select c.invty_id).FirstOrDefault();


                   
                        if (Item != null)
                        {


                            string xSite = i["Ship-to"].ToString();
                            var Site = (from c in obj.WMS_MSTR_SITE
                                        where c.site_code == xSite
                                        select c.site_code).FirstOrDefault();
                            string loadDate = "";
                            if (i["Load Date"].ToString().ToUpper() == "")
                            {
                                loadDate = null;
                            }
                            else
                            {
                                loadDate = i["Load Date"].ToString().ToUpper();
                            }
                            string shipTo = "";
                            if (i["Ship-to"].ToString().ToUpper() == "")
                            {
                                shipTo = null;
                            }
                            else
                            {
                                shipTo = i["Ship-to"].ToString().ToUpper();
                            }
                            string Customer = "";
                            if (i["Customer Name"].ToString().ToUpper() == "")
                            {
                                Customer = null;
                            }
                            else
                            {
                                Customer = i["Customer Name"].ToString().ToUpper();
                            }
                            string rdd = "";
                            if (i["RDD"].ToString().ToUpper() == "")
                            {
                                rdd = null;
                            }
                            else
                            {
                                rdd = i["RDD"].ToString().ToUpper();
                            }
                            string shipment = "";
                            if (i["Shipment"].ToString().ToUpper() == "")
                            {
                                shipment = null;
                            }
                            else
                            {
                                shipment = i["Shipment"].ToString().ToUpper();
                            }

                            string shippingLine = "";
                            if (i["Shipping Line"].ToString().ToUpper() == "")
                            {
                                shippingLine = null;
                            }
                            else
                            {
                                shippingLine = i["Shipping Line"].ToString().ToUpper();
                            }

                         

                            string truck = "";
                            if (i["Truck No"].ToString().ToUpper() == "")
                            {
                                truck = null;
                            }
                            else
                            {
                                truck = i["Truck No"].ToString().ToUpper();
                            }

                            string cvan = "";
                            if (i["CVAN"].ToString().ToUpper() == "")
                            {
                                cvan = null;
                            }
                            else
                            {
                                cvan = i["CVAN"].ToString().ToUpper();
                            }

                            string sales = "";
                            if (i["Sales Doc#"].ToString().ToUpper() == "")
                            {
                                sales = null;
                            }
                            else
                            {
                                sales = i["Sales Doc#"].ToString().ToUpper();
                            }

                            string po = "";
                            if (i["PO number"].ToString().ToUpper() == "")
                            {
                                po = null;
                            }
                            else
                            {
                                po = i["PO number"].ToString().ToUpper();
                            }

                            string bill = "";
                            if (i["Bill#Doc#"].ToString().ToUpper() == "")
                            {
                                bill = null;
                            }
                            else
                            {
                                bill = i["Bill#Doc#"].ToString().ToUpper();
                            }

                            string category = "";
                            if (i["Category"].ToString().ToUpper() == "")
                            {
                                category = null;
                            }
                            else
                            {
                                category = i["Category"].ToString().ToUpper();
                            }

                            string material = "";
                            if (i["Material"].ToString().ToUpper() == "")
                            {
                                material = null;
                            }
                            else
                            {
                                material = i["Material"].ToString().ToUpper();
                            }


                            string qty = "";
                            if (i["Qty"].ToString().ToUpper() == "")
                            {
                                qty = null;
                            }
                            else
                            {
                                qty = i["Qty"].ToString().ToUpper();
                            }


                            if (Site != null)
                            {

                                var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                                DateTime serverDate = dateQuery.AsEnumerable().First();

                                var dvmr = obj.Set<WMS_MSTR_DVMR>();
                                dvmr.Add(new WMS_MSTR_DVMR
                                {
                                    dvmr_load_date = Convert.ToDateTime(loadDate),
                                    site_code =shipTo,
                                    dvmr_customer = Customer,
                                    dvmr_rdd = Convert.ToDateTime(rdd),
                                    dvmr_shipment = shipment,
                                    dvmr_shipping_line = shippingLine,
                                    dvmr_truck_no = truck,
                                    dvmr_cvan = cvan,
                                    dvmr_salesdoc = sales,
                                    dvmr_po_number = po,
                                    dvmr_billdoc = bill,
                                    dvmr_category = category,
                                    invty_id = material,
                                    dvmr_qty = Convert.ToInt32(qty),
                                    dvmr_date_added = serverDate,



                                });

                                if (obj.SaveChanges() > 0)
                                {

                                }
                                else
                                {

                                }
                            }
                           
                        }
                        else
                        {

                        }
                    }


                    else
                    {
                        
                        //string xItem = i["Material"].ToString();
                        //var Item = (from c in obj.WMS_MSTR_INVTY
                        //            where c.invty_id == xItem
                        //            select c.invty_id).FirstOrDefault();


                        //    string xSite = i["Ship-to"].ToString();
                        //    var Site = (from c in obj.WMS_MSTR_SITE
                        //                where c.site_code == xSite
                        //                select c.site_code).FirstOrDefault();
                        //    string loadDate = "";
                        //    if (i["Load Date"].ToString().ToUpper() == "")
                        //    {
                        //        loadDate = null;
                        //    }
                        //    else
                        //    {
                        //        loadDate = i["Load Date"].ToString().ToUpper();
                        //    }
                        //    string shipTo = "";
                        //    if (i["Ship-to"].ToString().ToUpper() == "")
                        //    {
                        //        shipTo = null;
                        //    }
                        //    else
                        //    {
                        //        shipTo = i["Ship-to"].ToString().ToUpper();
                        //    }
                        //    string Customer = "";
                        //    if (i["Customer Name"].ToString().ToUpper() == "")
                        //    {
                        //        Customer = null;
                        //    }
                        //    else
                        //    {
                        //        Customer = i["Customer Name"].ToString().ToUpper();
                        //    }
                        //    string rdd = "";
                        //    if (i["RDD"].ToString().ToUpper() == "")
                        //    {
                        //        rdd = null;
                        //    }
                        //    else
                        //    {
                        //        rdd = i["RDD"].ToString().ToUpper();
                        //    }
                        //    string shipment = "";
                        //    if (i["Shipment"].ToString().ToUpper() == "")
                        //    {
                        //        shipment = null;
                        //    }
                        //    else
                        //    {
                        //        shipment = i["Shipment"].ToString().ToUpper();
                        //    }

                        //    string shippingLine = "";
                        //    if (i["Shipping Line"].ToString().ToUpper() == "")
                        //    {
                        //        shippingLine = null;
                        //    }
                        //    else
                        //    {
                        //        shippingLine = i["Shipping Line"].ToString().ToUpper();
                        //    }



                        //    string truck = "";
                        //    if (i["Truck No"].ToString().ToUpper() == "")
                        //    {
                        //        truck = null;
                        //    }
                        //    else
                        //    {
                        //        truck = i["Truck No"].ToString().ToUpper();
                        //    }

                        //    string cvan = "";
                        //    if (i["CVAN"].ToString().ToUpper() == "")
                        //    {
                        //        cvan = null;
                        //    }
                        //    else
                        //    {
                        //        cvan = i["CVAN"].ToString().ToUpper();
                        //    }

                        //    string sales = "";
                        //    if (i["Sales Doc#"].ToString().ToUpper() == "")
                        //    {
                        //        sales = null;
                        //    }
                        //    else
                        //    {
                        //        sales = i["Sales Doc#"].ToString().ToUpper();
                        //    }

                        //    string po = "";
                        //    if (i["PO number"].ToString().ToUpper() == "")
                        //    {
                        //        po = null;
                        //    }
                        //    else
                        //    {
                        //        po = i["PO number"].ToString().ToUpper();
                        //    }

                        //    string bill = "";
                        //    if (i["Bill#Doc#"].ToString().ToUpper() == "")
                        //    {
                        //        bill = null;
                        //    }
                        //    else
                        //    {
                        //        bill = i["Bill#Doc#"].ToString().ToUpper();
                        //    }

                        //    string category = "";
                        //    if (i["Category"].ToString().ToUpper() == "")
                        //    {
                        //        category = null;
                        //    }
                        //    else
                        //    {
                        //        category = i["Category"].ToString().ToUpper();
                        //    }

                        //    string material = "";
                        //    if (i["Material"].ToString().ToUpper() == "")
                        //    {
                        //        material = null;
                        //    }
                        //    else
                        //    {
                        //        material = i["Material"].ToString().ToUpper();
                        //    }


                        //    string qty = "";
                        //    if (i["Qty"].ToString().ToUpper() == "")
                        //    {
                        //        qty = null;
                        //    }
                        //    else
                        //    {
                        //        qty = i["Qty"].ToString().ToUpper();
                        //    }


                        //var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                        //DateTime serverDate = dateQuery.AsEnumerable().First();

                        //obj.WMS_MSTR_DVMR.Where(c => c.invty_id == xItem).ToList().ForEach(x =>
                        //{
                        //    x.dvmr_load_date = Convert.ToDateTime(loadDate);
                        //    x.site_code = shipTo;
                        //    x.dvmr_customer = Customer;
                        //    x.dvmr_rdd = Convert.ToDateTime(rdd);
                        //    x.dvmr_shipment = shipment;
                        //    x.dvmr_shipping_line = shippingLine;
                        //    x.dvmr_truck_no = truck;
                        //    x.dvmr_cvan = cvan;
                        //    x.dvmr_salesdoc = sales;
                        //    x.dvmr_po_number = po;
                        //    x.dvmr_billdoc = bill;
                        //    x.dvmr_category = category;
                        //    x.invty_id = material;
                        //    x.dvmr_qty = Convert.ToInt32(qty);
                        //    x.dvmr_date_added = serverDate;

                        //});
                        //obj.SaveChanges();

                    }

                    TranCounter3 = TranCounter3 + 1;

                    backgroundWorker3.ReportProgress(Convert.ToInt32(100 * TranCounter3 / max), "Uploading " + TranCounter3.ToString() + " out of " + max.ToString() + " Dvmr(s)");

                    if (backgroundWorker3.CancellationPending)
                    {
                        backgroundWorker3.ReportProgress(Convert.ToInt32(100 * TranCounter3 / max), "Cancelling...");
               
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
        
                MessageBox.Show("Task Cancelled by User!", " Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Successfully Uploaded " + TranCounter3.ToString() + " out of " + max.ToString() + " Dvmr(s)", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
