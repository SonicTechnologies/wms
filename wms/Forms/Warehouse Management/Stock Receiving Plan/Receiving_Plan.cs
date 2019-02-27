using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wms.Entity_Class;

namespace wms.Forms.Warehouse_Management.Stock_Receiving_Plan
{
    public partial class Receiving_Plan : Form
    {
        object sCode, vanCode;
        private wmsdb obj;
        public Receiving_Plan()
        {
            obj = new wmsdb();
            InitializeComponent();
         
        }

        private void Receiving_Plan_Load(object sender, EventArgs e)
        {
            getSite();
            GetVanList();
        }

        public void getSite()
        {
            var sites = (from c in obj.WMS_MSTR_SITE

                         select new
                         {
                             c.site_id,
                             c.site_name,

                         }).OrderBy(c => new { c.site_id }).ToList();

            comboBox3.Items.Clear();

            if (sites.Count != 0)
            {

                foreach (var row in sites)
                {

                    comboBox3.Items.Add(row.site_name);

                }
                comboBox3.SelectedIndex = -1;
            }
            else
            {

            }

        }
        public void GetVanList()
        {
            //DateTime datefrm = DatePickerFrom.Value;
            //DateTime dateto = DatePickerTo.Value;
            string sitename = comboBox3.Text;
            string vanno = textBox7.Text;
            var vans = (from c in obj.WMS_MSTR_DVMR
                        join s in obj.WMS_MSTR_SITE on c.site_code equals s.site_code
                        where c.dvmr_cvan.StartsWith(vanno) && s.site_name == sitename
                        //where c.dvmr_rdd >= datefrm.Date && c.dvmr_rdd <= dateto.Date
                        select new 
                            {
                                c.dvmr_cvan,
                                c.dvmr_rdd,
                                c.dvmr_schedule_date,
                                s.site_name

                            }).Distinct().OrderBy(c => c.dvmr_cvan).ToList();

            vanDataGrid.Rows.Clear();
           
            if (vans.Count != 0)
            {
                vanDataGrid.ColumnHeadersVisible = true;
                foreach (var row in vans)
                {
                    string xdatesched = row.dvmr_schedule_date.HasValue ? row.dvmr_schedule_date.Value.ToString("yyyy-MM-dd") : string.Empty;
                    vanDataGrid.Rows.Add(false,row.dvmr_cvan,row.site_name, row.dvmr_rdd.ToString("yyyy-MM-dd"), xdatesched);

                }
                
            }
            else
            {
                vanDataGrid.ColumnHeadersVisible = false;
            }
            vanDataGrid.ClearSelection();
            siteGridView.Rows.Clear();
            siteGridView.ColumnHeadersVisible = false;
            BillDocGridView.Rows.Clear();
            BillDocGridView.ColumnHeadersVisible = false;
        }

   
        
        public void vanTableClicked1(string van_no)
        {
            
            //siteGridView.Rows.Clear();
            var query1 = (from a in obj.WMS_MSTR_DVMR
                          join b in obj.WMS_MSTR_SITE on a.site_code equals b.site_code                      
                          where a.dvmr_cvan == van_no 
                          group a by new { a.site_code, b.site_name, a.dvmr_category, a.dvmr_cvan } into c
                          select new
                          {
                              c.Key.site_code,
                              c.Key.site_name,
                              c.Key.dvmr_category,
                              c.Key.dvmr_cvan,
                              tqty = c.Sum(d => d.dvmr_qty)

                          }).Distinct().ToList();
            if (query1.Count != 0)
            {
                siteGridView.ColumnHeadersVisible = true;
                int a = 0;
                foreach (var rows in query1)
                {
                    a = a + 1;
                    siteGridView.Rows.Add(a.ToString() + rows.dvmr_cvan, rows.site_code, rows.site_name, rows.dvmr_category, rows.tqty.ToString(), rows.dvmr_cvan);
                }
            }
            else
            {
                siteGridView.ColumnHeadersVisible = false;
            }
            siteGridView.ClearSelection();
            label14.Text = TotalCases1().ToString();

            //BillDocGridView.Rows.Clear();
            var query2 = (from r in obj.WMS_MSTR_DVMR
                         where r.dvmr_cvan == van_no
                         select new
                         {
                             BillDoc = r.dvmr_billdoc,
                             SiteCode = r.site_code,
                             Cvan = r.dvmr_cvan

                         }).Distinct().ToList();
            if (query2.Count != 0)
            {
                BillDocGridView.ColumnHeadersVisible = true;
                int b = 0;
                foreach (var billdoc in query2)
                {
                    b = b + 1;
                    var siteName = obj.WMS_MSTR_SITE.Where(s => s.site_code == billdoc.SiteCode).Select(s => s.site_name).SingleOrDefault();
                    BillDocGridView.Rows.Add(b.ToString() + billdoc.Cvan, billdoc.BillDoc, siteName, billdoc.Cvan);
                }
            }
            else
            {
                BillDocGridView.ColumnHeadersVisible = false;
            }
            BillDocGridView.ClearSelection();
            label7.Text = BillDocGridView.Rows.Count.ToString();


        }

        public void vanTableClicked2(string van_no)
        {

            var query1 = (from a in obj.WMS_MSTR_DVMR
                          join b in obj.WMS_MSTR_SITE on a.site_code equals b.site_code
                          where a.dvmr_cvan == van_no
                          group a by new { a.site_code, b.site_name, a.dvmr_category, a.dvmr_cvan } into c
                          select new
                          {
                              c.Key.site_code,
                              c.Key.site_name,
                              c.Key.dvmr_category,
                              c.Key.dvmr_cvan,
                              tqty = c.Sum(d => d.dvmr_qty)

                          }).Distinct().ToList();
            if (query1.Count != 0)
            {
                DataGridView6.ColumnHeadersVisible = true;
                int a = 0;
                foreach (var rows in query1)
                {
                    a = a + 1;
                    DataGridView6.Rows.Add(a.ToString() + rows.dvmr_cvan, rows.site_code, rows.site_name, rows.dvmr_category, rows.tqty.ToString(), rows.dvmr_cvan);
                }
            }
            else
            {
                DataGridView6.ColumnHeadersVisible = false;
            }
            DataGridView6.ClearSelection();
            label9.Text = TotalCases2().ToString();

            var query2 = (from r in obj.WMS_MSTR_DVMR
                          where r.dvmr_cvan == van_no
                          select new
                          {
                              BillDoc = r.dvmr_billdoc,
                              SiteCode = r.site_code,
                              Cvan = r.dvmr_cvan

                          }).Distinct().ToList();
            if (query2.Count != 0)
            {
                dataGridView8.ColumnHeadersVisible = true;
                int b = 0;
                foreach (var billdoc in query2)
                {
                    b = b + 1;
                    var siteName = obj.WMS_MSTR_SITE.Where(s => s.site_code == billdoc.SiteCode).Select(s => s.site_name).SingleOrDefault();
                    dataGridView8.Rows.Add(b.ToString() + billdoc.Cvan, billdoc.BillDoc, siteName, billdoc.Cvan);
                }
            }
            else
            {
                dataGridView8.ColumnHeadersVisible = false;
            }
            dataGridView8.ClearSelection();
            label13.Text = dataGridView8.Rows.Count.ToString();


        }

        private void siteGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            SRP_Item_Details.vanNo = dgv.CurrentRow.Cells[5].Value.ToString();
            SRP_Item_Details.category = dgv.CurrentRow.Cells[3].Value.ToString();
            SRP_Item_Details srpid = new SRP_Item_Details();
            srpid.Show();
        }

        private void DataGridView6_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void DatePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            GetVanList();
        }

        private void DatePickerTo_ValueChanged(object sender, EventArgs e)
        {
            GetVanList();
        }

        private void DateTimeSchedule_ValueChanged(object sender, EventArgs e)
        {
            schedVanList();
        }
        
        private void AddBtn_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow xrow in vanDataGrid.Rows)
            {

                if (Convert.ToBoolean(xrow.Cells[0].Value) == true)
                {
                    var cvan = xrow.Cells[1].Value.ToString();
                    obj.WMS_MSTR_DVMR.Where(c => c.dvmr_cvan == cvan).ToList().ForEach(x =>
                    {
                        x.dvmr_schedule_date = DateTimeSchedule.Value.Date;
                    });
                    obj.SaveChanges();

                }
                else
                {

                }

            }
            GetVanList();
            schedVanList();
        }

        private void schedVanList()
        {
            string sitename = textBox1.Text;
            var schedvans = (from c in obj.WMS_MSTR_DVMR
                        join s in obj.WMS_MSTR_SITE on c.site_code equals s.site_code
                        where c.dvmr_schedule_date == DateTimeSchedule.Value.Date && s.site_name == sitename
                        //where c.dvmr_rdd >= datefrm.Date && c.dvmr_rdd <= dateto.Date
                        select new
                        {
                            c.dvmr_cvan,
                            c.dvmr_schedule_date

                        }).Distinct().OrderBy(c => c.dvmr_cvan).ToList();

            DataGridView5.Rows.Clear();

            if (schedvans.Count != 0)
            {
                DataGridView5.ColumnHeadersVisible = true;
                foreach (var row in schedvans)
                {

                    DataGridView5.Rows.Add(false, row.dvmr_cvan);

                }

            }
            else
            {
                DataGridView5.ColumnHeadersVisible = false;
            }
            DataGridView5.ClearSelection();
            DataGridView6.Rows.Clear();
            DataGridView6.ColumnHeadersVisible = false;
            dataGridView8.Rows.Clear();
            dataGridView8.ColumnHeadersVisible = false;


        }

        private void vanDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            dgv.ClearSelection();
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {

                    allchecked1();

            }
            else
            {

                //if (e.ColumnIndex == 0)
                //{
                   
                    if (Convert.ToBoolean(dgv.CurrentRow.Cells[0].Value) == true)
                    {

                        dgv.CurrentRow.Cells[0].Value = false;
                        dgv.CurrentRow.Cells[0].Style.BackColor = Color.White;
                        dgv.CurrentRow.Cells[1].Style.BackColor = Color.White;
                        dgv.CurrentRow.Cells[2].Style.BackColor = Color.White;
                        dgv.CurrentRow.Cells[3].Style.BackColor = Color.White;
                        dgv.CurrentRow.Cells[4].Style.BackColor = Color.White;


                        dgv.CurrentRow.Cells[0].Style.ForeColor = Color.Black;
                        dgv.CurrentRow.Cells[1].Style.ForeColor = Color.Black;
                        dgv.CurrentRow.Cells[2].Style.ForeColor = Color.Black;
                        dgv.CurrentRow.Cells[3].Style.ForeColor = Color.Black;
                        dgv.CurrentRow.Cells[4].Style.ForeColor = Color.Black;

                        remVan1(dgv.CurrentRow.Cells[1].Value.ToString());
                    }
                    else
                    {

                        dgv.CurrentRow.Cells[0].Value = true;
                        dgv.CurrentRow.Cells[0].Style.BackColor = Color.FromArgb(20, 104, 179);
                        dgv.CurrentRow.Cells[1].Style.BackColor = Color.FromArgb(20, 104, 179);
                        dgv.CurrentRow.Cells[2].Style.BackColor = Color.FromArgb(20, 104, 179);
                        dgv.CurrentRow.Cells[3].Style.BackColor = Color.FromArgb(20, 104, 179);
                        dgv.CurrentRow.Cells[4].Style.BackColor = Color.FromArgb(20, 104, 179);

                        dgv.CurrentRow.Cells[0].Style.ForeColor = Color.White;
                        dgv.CurrentRow.Cells[1].Style.ForeColor = Color.White;
                        dgv.CurrentRow.Cells[2].Style.ForeColor = Color.White;
                        dgv.CurrentRow.Cells[3].Style.ForeColor = Color.White;
                        dgv.CurrentRow.Cells[4].Style.ForeColor = Color.White;

                        vanTableClicked1(dgv.CurrentRow.Cells[1].Value.ToString());
                    }

                //}
                //else
                //{

                //}

            }
        }


        private void allchecked1()
        {
            int a;
            int c;
            a = 0;

            c = vanDataGrid.Rows.Count;
            foreach (DataGridViewRow xrow in vanDataGrid.Rows)
            {
                if (Convert.ToBoolean(xrow.Cells[0].Value) == true)
                {
                    a = a + 1;
                }
                else
                {

                }
            }

            if (a == c)
            {
                foreach (DataGridViewRow xrow in vanDataGrid.Rows)
                {
                    if (Convert.ToBoolean(xrow.Cells[0].Value) == true)
                    {
                        xrow.Cells[0].Value = false;
                        xrow.Cells[0].Style.BackColor = Color.White;
                        xrow.Cells[1].Style.BackColor = Color.White;
                        xrow.Cells[2].Style.BackColor = Color.White;
                        xrow.Cells[3].Style.BackColor = Color.White;
                        xrow.Cells[4].Style.BackColor = Color.White;

                        xrow.Cells[0].Style.ForeColor = Color.Black;
                        xrow.Cells[1].Style.ForeColor = Color.Black;
                        xrow.Cells[2].Style.ForeColor = Color.Black;
                        xrow.Cells[3].Style.ForeColor = Color.Black;
                        xrow.Cells[4].Style.ForeColor = Color.Black;

                        remVan1(xrow.Cells[1].Value.ToString());

                    }
                    else
                    {
                        xrow.Cells[0].Value = true;
                        xrow.Cells[0].Style.BackColor = Color.FromArgb(20, 104, 179);
                        xrow.Cells[1].Style.BackColor = Color.FromArgb(20, 104, 179);
                        xrow.Cells[2].Style.BackColor = Color.FromArgb(20, 104, 179);
                        xrow.Cells[3].Style.BackColor = Color.FromArgb(20, 104, 179);
                        xrow.Cells[4].Style.BackColor = Color.FromArgb(20, 104, 179);

                        xrow.Cells[0].Style.ForeColor = Color.White;
                        xrow.Cells[1].Style.ForeColor = Color.White;
                        xrow.Cells[2].Style.ForeColor = Color.White;
                        xrow.Cells[3].Style.ForeColor = Color.White;
                        xrow.Cells[4].Style.ForeColor = Color.White;

                        vanTableClicked1(xrow.Cells[1].Value.ToString());
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow xrow in vanDataGrid.Rows)
                {
                    if (Convert.ToBoolean(xrow.Cells[0].Value) == true)
                    {
                        remVan1(xrow.Cells[1].Value.ToString());
                    }
                    else
                    {
                        xrow.Cells[0].Value = true;
                        xrow.Cells[0].Style.BackColor = Color.FromArgb(20, 104, 179);
                        xrow.Cells[1].Style.BackColor = Color.FromArgb(20, 104, 179);
                        xrow.Cells[2].Style.BackColor = Color.FromArgb(20, 104, 179);
                        xrow.Cells[3].Style.BackColor = Color.FromArgb(20, 104, 179);
                        xrow.Cells[4].Style.BackColor = Color.FromArgb(20, 104, 179);

                        xrow.Cells[0].Style.ForeColor = Color.White;
                        xrow.Cells[1].Style.ForeColor = Color.White;
                        xrow.Cells[2].Style.ForeColor = Color.White;
                        xrow.Cells[3].Style.ForeColor = Color.White;
                        xrow.Cells[4].Style.ForeColor = Color.White;

                        vanTableClicked1(xrow.Cells[1].Value.ToString());
                    }
                }
            }

        }

        private void allchecked2()
        {
            int a;
            int c;
            a = 0;

            c = DataGridView5.Rows.Count;
            foreach (DataGridViewRow xrow in DataGridView5.Rows)
            {
                if (Convert.ToBoolean(xrow.Cells[0].Value) == true)
                {
                    a = a + 1;
                }
                else
                {

                }
            }

            if (a == c)
            {
                foreach (DataGridViewRow xrow in DataGridView5.Rows)
                {
                    if (Convert.ToBoolean(xrow.Cells[0].Value) == true)
                    {
                        xrow.Cells[0].Value = false;
                        xrow.Cells[0].Style.BackColor = Color.White;
                        xrow.Cells[1].Style.BackColor = Color.White;

                        xrow.Cells[0].Style.ForeColor = Color.Black;
                        xrow.Cells[1].Style.ForeColor = Color.Black;

                        remVan2(xrow.Cells[1].Value.ToString());
                    }
                    else
                    {
                        xrow.Cells[0].Value = true;
                        xrow.Cells[0].Style.BackColor = Color.FromArgb(20, 104, 179);
                        xrow.Cells[1].Style.BackColor = Color.FromArgb(20, 104, 179);

                        xrow.Cells[0].Style.ForeColor = Color.White;
                        xrow.Cells[1].Style.ForeColor = Color.White;

                        vanTableClicked2(xrow.Cells[1].Value.ToString());
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow xrow in DataGridView5.Rows)
                {
                    if (Convert.ToBoolean(xrow.Cells[0].Value) == true)
                    {
                        remVan2(xrow.Cells[1].Value.ToString());
                    }
                    else
                    {
                        xrow.Cells[0].Value = true;
                        xrow.Cells[0].Style.BackColor = Color.FromArgb(20, 104, 179);
                        xrow.Cells[1].Style.BackColor = Color.FromArgb(20, 104, 179);

                        xrow.Cells[0].Style.ForeColor = Color.White;
                        xrow.Cells[1].Style.ForeColor = Color.White;

                        vanTableClicked2(xrow.Cells[1].Value.ToString());
                    }
                }
            }

        }
        private int TotalCases1()
        {
            int a = 0;

            foreach (DataGridViewRow xrow in siteGridView.Rows)
            {
                a = a + Convert.ToInt32(xrow.Cells[4].Value);
               
            }
            return a;
        }

        private int TotalCases2()
        {
            int a = 0;

            foreach (DataGridViewRow xrow in DataGridView6.Rows)
            {
                a = a + Convert.ToInt32(xrow.Cells[4].Value);

            }
            return a;
        }

        private void remVan1(string vanno)
        {
            List<string> listnum1 = new List<string>();
            List<string> listnum2 = new List<string>();

            foreach (DataGridViewRow xrow in siteGridView.Rows)
            {

                if (xrow.Cells[5].Value.ToString() == vanno.ToString())
                {
                    listnum1.Add(xrow.Cells[0].Value.ToString());
                }
                else
                {

                }
            }

            foreach (var xnum1 in listnum1)
            {
                foreach (DataGridViewRow xrow in siteGridView.Rows)
                {
                    if (xrow.Cells[0].Value.ToString() == xnum1)
                    {
                        siteGridView.Rows.Remove(xrow);
                    }
                    else
                    {

                    }

                }

            }

            foreach (DataGridViewRow xrow in BillDocGridView.Rows)
            {
               
                if (xrow.Cells[3].Value.ToString() == vanno.ToString())
                {
                    listnum2.Add(xrow.Cells[0].Value.ToString());
                }
                else
                {
 
                }
            }

            foreach (var xnum2 in listnum2)
            {
                foreach (DataGridViewRow xrow in BillDocGridView.Rows)
                {
                    if (xrow.Cells[0].Value.ToString() == xnum2)
                    {
                        BillDocGridView.Rows.Remove(xrow);
                    }
                    else
                    {

                    }

                }

            }

            siteGridView.ColumnHeadersVisible = false;
            BillDocGridView.ColumnHeadersVisible = false;
            label14.Text = TotalCases1().ToString();
            label7.Text = BillDocGridView.Rows.Count.ToString();
        }

        private void remVan2(string vanno)
        {
            List<string> listnum1 = new List<string>();
            List<string> listnum2 = new List<string>();

            foreach (DataGridViewRow xrow in DataGridView6.Rows)
            {

                if (xrow.Cells[5].Value.ToString() == vanno.ToString())
                {
                    listnum1.Add(xrow.Cells[0].Value.ToString());
                }
                else
                {

                }
            }

            foreach (var xnum1 in listnum1)
            {
                foreach (DataGridViewRow xrow in DataGridView6.Rows)
                {
                    if (xrow.Cells[0].Value.ToString() == xnum1)
                    {
                        DataGridView6.Rows.Remove(xrow);
                    }
                    else
                    {

                    }

                }

            }

            foreach (DataGridViewRow xrow in dataGridView8.Rows)
            {

                if (xrow.Cells[3].Value.ToString() == vanno.ToString())
                {
                    listnum2.Add(xrow.Cells[0].Value.ToString());
                }
                else
                {

                }
            }

            foreach (var xnum2 in listnum2)
            {
                foreach (DataGridViewRow xrow in dataGridView8.Rows)
                {
                    if (xrow.Cells[0].Value.ToString() == xnum2)
                    {
                        dataGridView8.Rows.Remove(xrow);
                    }
                    else
                    {

                    }

                }

            }

            DataGridView6.ColumnHeadersVisible = false;
            dataGridView8.ColumnHeadersVisible = false;
            label9.Text = TotalCases2().ToString();
            label13.Text = dataGridView8.Rows.Count.ToString();
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            GetVanList();        
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            var cmbx3 = sender as ComboBox;
            GetVanList();
            textBox1.Text = cmbx3.Text;
            schedVanList();
        }

        private void DataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {       
            var dgv = sender as DataGridView;
            dgv.ClearSelection();
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {

                allchecked2();

            }
            else
            {

                //if (e.ColumnIndex == 0)
                //{

                if (Convert.ToBoolean(dgv.CurrentRow.Cells[0].Value) == true)
                {

                    dgv.CurrentRow.Cells[0].Value = false;
                    dgv.CurrentRow.Cells[0].Style.BackColor = Color.White;
                    dgv.CurrentRow.Cells[1].Style.BackColor = Color.White;

                    dgv.CurrentRow.Cells[0].Style.ForeColor = Color.Black;
                    dgv.CurrentRow.Cells[1].Style.ForeColor = Color.Black;

                    remVan2(dgv.CurrentRow.Cells[1].Value.ToString());
                }
                else
                {

                    dgv.CurrentRow.Cells[0].Value = true;
                    dgv.CurrentRow.Cells[0].Style.BackColor = Color.FromArgb(20, 104, 179);
                    dgv.CurrentRow.Cells[1].Style.BackColor = Color.FromArgb(20, 104, 179);


                    dgv.CurrentRow.Cells[0].Style.ForeColor = Color.White;
                    dgv.CurrentRow.Cells[1].Style.ForeColor = Color.White;
        

                    vanTableClicked2(dgv.CurrentRow.Cells[1].Value.ToString());
                }

                //}
                //else
                //{

                //}

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow xrow in DataGridView5.Rows)
            {

                if (Convert.ToBoolean(xrow.Cells[0].Value) == true)
                {
                    var cvan = xrow.Cells[1].Value.ToString();
                    obj.WMS_MSTR_DVMR.Where(c => c.dvmr_cvan == cvan).ToList().ForEach(x =>
                    {
                        x.dvmr_schedule_date = null;
                        remVan2(cvan);
                    });
                    obj.SaveChanges();

                }
                else
                {

                }

            }
            GetVanList();
            schedVanList();
        }

        private class PInfo
        {
            public string VanName { get; set; }
            public DateTime Rdd { get; set; }
            public DateTime? Schedule { get; set; }
        }
    }

}
