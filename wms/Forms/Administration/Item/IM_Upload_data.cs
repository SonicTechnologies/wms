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
using wms.Class;
using wms.Entity_Class;

namespace wms.Forms.Administration.Item
{
    public partial class IM_Upload_data : Form
    {
        OleDbCommand cmd1 = new OleDbCommand();
        OleDbConnection con1 = new OleDbConnection();

        DataTable dt1 = new DataTable();
        OleDbDataAdapter adapt1 = new OleDbDataAdapter();
        wmsdb obj = new wmsdb();

        string strConnectionString;

        int max;

        int TranCounter1;

        public IM_Upload_data()
        {
            InitializeComponent();
        }

        private void optionBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Microsoft Excel 2007|*.xlsx|Microsoft Excel 2003|*.xls";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                itemTxtBox.Text = "";
                itemTxtBox.Text = openFileDialog1.FileName;
                
            }
        }

        public void getMaxLineItems()
        {
            progressBar.Value = 0;
            strConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + itemTxtBox.Text + ";Extended Properties='Excel 12.0 Xml;HDR=YES'";
            con1.ConnectionString = strConnectionString;

            con1.Open();
            cmd1.CommandText = "select DISTINCT * from [Sheet1$] WHERE [Article Code]<>'' AND [Status]<>'' AND [Unit Conversion2]<>0 ORDER BY [Article Description]";
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
                    progressBar.Maximum = dt1.Rows.Count;
                }
                else
                {
                    max = 0;
                    progressBar.Maximum = 0;
                }
            }
            con1.Close();
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            if (itemTxtBox.Text.Trim() == "")
            {

            }
            else
            {
                itemTxtBox.Enabled = false;
                optionBtn.Enabled = false;
                uploadBtn.Enabled = false;
                getMaxLineItems();
                Execute1();
            }
        }

        private void Execute1()
        {
            itemLabel.Text = "Uploading 0 out of " + max.ToString() + " Item(s)";
            itemLabel.Visible = true;
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            TranCounter1 = 0;

            con1.Open();
            cmd1.CommandText = "select DISTINCT * from [Sheet1$] WHERE [Article Code]<>'' AND [Status]<>'' AND [Unit Conversion2]<>0 ORDER BY [Article Description]";
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
                    var xxitem = i["Article Code"].ToString();
                    var xitem = (from c in obj.WMS_INVTY_VIEW
                                 where c.invty_id == xxitem
                                 select c.invty_id).FirstOrDefault();
                    if (xitem == null)
                    {

                        string xstatdesc = i["Status"].ToString();
                        int xstatid = 1;
                        var statid = (from c in obj.WMS_TYPE_STAT
                                      where c.stat_desc == xstatdesc
                                      select c.stat_id).FirstOrDefault();

                        xstatid = statid;

                        var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                        DateTime serverDate = dateQuery.AsEnumerable().First();

                        string xbcode = "";
                        if (i["Barcode"].ToString().ToUpper() == "")
                        {
                            xbcode = null;
                        }
                        else
                        {
                            xbcode = i["Barcode"].ToString().ToUpper();
                        }
                        string xccode = "";
                        if (i["Casecode"].ToString().ToUpper() == "")
                        {
                            xccode = null;
                        }
                        else
                        {
                            xccode = i["Casecode"].ToString().ToUpper();
                        }
                        string xcat1 = "";
                        if (i["Assortment No"].ToString().ToUpper() == "")
                        {
                            xcat1 = null;
                        }
                        else
                        {
                            xcat1 = i["Assortment No"].ToString().ToUpper();
                        }
                        string xcat2 = "";
                        if (i["Division"].ToString().ToUpper() == "")
                        {
                            xcat2 = null;
                        }
                        else
                        {
                            xcat2 = i["Division"].ToString().ToUpper();
                        }
                        string xcat3 = "";
                        if (i["Category"].ToString().ToUpper() == "")
                        {
                            xcat3 = null;
                        }
                        else
                        {
                            xcat3 = i["Category"].ToString().ToUpper();
                        }
                        string xbrand = "";
                        if (i["Brand"].ToString().ToUpper() == "")
                        {
                            xbrand = null;
                        }
                        else
                        {
                            xbrand = i["Brand"].ToString().ToUpper();
                        }

                        var item = obj.Set<WMS_MSTR_INVTY>();
                        item.Add(new WMS_MSTR_INVTY
                        {
                            invty_id = i["Article Code"].ToString().ToUpper(),
                            invty_desc = i["Article Description"].ToString().ToUpper(),
                            invty_barcode = xbcode,
                            invty_casecode = xccode,
                            invty_ppu = Convert.ToInt32(i["Unit Conversion2"].ToString().ToUpper()),
                            invty_cat1 = xcat1,
                            invty_cat2 = xcat2,
                            invty_cat3 = xcat3,
                            invty_cat4 = xcat3,
                            invty_brand = xbrand,
                            stat_id = statid,
                            invty_datecrtd = serverDate,
                            invty_crtdby = loggedin_user.userId

                        });

                        if (obj.SaveChanges() > 0)
                        {

                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        string xstatdesc = i["Status"].ToString();
                        int xstatid = 1;
                        var statid = (from c in obj.WMS_TYPE_STAT
                                      where c.stat_desc == xstatdesc
                                      select c.stat_id).FirstOrDefault();
                        xstatid = statid;

                        var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                        DateTime serverDate = dateQuery.AsEnumerable().First();

                        var xxitem2 = i["Article Code"].ToString();

                        string xbcode = "";
                        if (i["Barcode"].ToString().ToUpper() == "")
                        {
                            xbcode = null;
                        }
                        else
                        {
                            xbcode = i["Barcode"].ToString().ToUpper();
                        }
                        string xccode = "";
                        if (i["Casecode"].ToString().ToUpper() == "")
                        {
                            xccode = null;
                        }
                        else
                        {
                            xccode = i["Casecode"].ToString().ToUpper();
                        }
                        string xcat1 = "";
                        if (i["Assortment No"].ToString().ToUpper() == "")
                        {
                            xcat1 = null;
                        }
                        else
                        {
                            xcat1 = i["Assortment No"].ToString().ToUpper();
                        }
                        string xcat2 = "";
                        if (i["Division"].ToString().ToUpper() == "")
                        {
                            xcat2 = null;
                        }
                        else
                        {
                            xcat2 = i["Division"].ToString().ToUpper();
                        }
                        string xcat3 = "";
                        if (i["Category"].ToString().ToUpper() == "")
                        {
                            xcat3 = null;
                        }
                        else
                        {
                            xcat3 = i["Category"].ToString().ToUpper();
                        }
                        string xbrand = "";
                        if (i["Brand"].ToString().ToUpper() == "")
                        {
                            xbrand = null;
                        }
                        else
                        {
                            xbrand = i["Brand"].ToString().ToUpper();
                        }
                        obj.WMS_MSTR_INVTY.Where(c => c.invty_id == xxitem2).ToList().ForEach(x =>
                        {

                            x.invty_desc = i["Article Description"].ToString().ToUpper();
                            x.invty_barcode = xbcode;
                            x.invty_casecode = xccode;
                            x.invty_ppu = Convert.ToInt32(i["Unit Conversion2"].ToString().ToUpper());
                            x.invty_cat1 = xcat1;
                            x.invty_cat2 = xcat2;
                            x.invty_cat3 = xcat3;
                            x.invty_cat4 = xcat3;
                            x.invty_brand = xbrand;
                            x.stat_id = statid;
                            x.invty_dateuptd = serverDate;
                            x.invty_uptdby = loggedin_user.userId;

                        });
                    }
                    TranCounter1 = TranCounter1 + 1;
                    backgroundWorker.ReportProgress(Convert.ToInt32(100 * TranCounter1 / max), "Uploading " + TranCounter1.ToString() + " out of " + max.ToString() + " Item(s)");
                    if (backgroundWorker.CancellationPending)
                    {
                        backgroundWorker.ReportProgress(Convert.ToInt32(100 * TranCounter1 / max), "Cancelling...");
                        //    e.Cancel = true;
                        backgroundWorker.ReportProgress(100, "Cancelled!");
                        break;
                    }
                }
            }
            con1.Close();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            itemLabel.Text = Convert.ToString(e.UserState);
            progressLabel.Text = e.ProgressPercentage.ToString() + "% complete";
            progressBar.Increment(1);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, " Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("Task Cancelled by User!", " Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Successfully Uploaded " + TranCounter1.ToString() + " out of " + max.ToString() + " Item(s)", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void IM_Upload_Data_Load(object sender, EventArgs e)
        {
            Main_Form.GetInstance().Enabled = false;
        }

        private void IM_Upload_Data_FormClosing(object sender, FormClosingEventArgs e)
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
