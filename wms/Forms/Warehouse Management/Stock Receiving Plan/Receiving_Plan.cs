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
            GetVanList(vanDataGrid, siteGridView, BillDocGridView, label9);
        }

        public void GetVanList(DataGridView vanDataGrid, DataGridView siteGridView, DataGridView BillDocGridView, Label label)
        {
            DateTime datefrm = DatePickerFrom.Value;
            DateTime dateto = DatePickerTo.Value;
            var vans = (from c in obj.WMS_MSTR_DVMR
                        where c.dvmr_rdd >= datefrm.Date && c.dvmr_rdd <= dateto.Date
                        select new 
                            {
                                c.dvmr_cvan,
                                c.dvmr_rdd,
                                c.dvmr_schedule_date

                            }).OrderBy(c => new { c.dvmr_schedule_date }).ThenBy(c => c.dvmr_cvan).Distinct().ToList();

            vanDataGrid.Rows.Clear();
            label.Text = vans.Count.ToString();
            if (vans.Count != 0)
            {
                vanDataGrid.ColumnHeadersVisible = true;
                foreach (var row in vans)
                {

                    vanDataGrid.Rows.Add(false,row.dvmr_cvan, row.dvmr_rdd.ToString("yyyy-MM-dd"), row.dvmr_schedule_date);

                }
            }
            else
            {
                vanDataGrid.ColumnHeadersVisible = false;
            }
            vanDataGrid.ClearSelection();
            siteGridView.Rows.Clear();
            BillDocGridView.Rows.Clear();
        }
        
        public void vanTableClicked(string van_no)
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
                              tqty = c.Sum(d => d.dvmr_qty),

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
            label14.Text = TotalCases(siteGridView).ToString();

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
                              tqty = c.Sum(d => d.dvmr_qty),

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
            label15.Text = TotalCases(DataGridView6).ToString();

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
                DataGridView8.ColumnHeadersVisible = true;
                int b = 0;
                foreach (var billdoc in query2)
                {
                    b = b + 1;
                    var siteName = obj.WMS_MSTR_SITE.Where(s => s.site_code == billdoc.SiteCode).Select(s => s.site_name).SingleOrDefault();
                    DataGridView8.Rows.Add(b.ToString() + billdoc.Cvan, billdoc.BillDoc, siteName, billdoc.Cvan);
                }
            }
            else
            {
                DataGridView8.ColumnHeadersVisible = false;
            }
            DataGridView8.ClearSelection();

            label13.Text = BillDocGridView.Rows.Count.ToString();
        }

        private void DatePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            GetVanList(vanDataGrid, siteGridView, BillDocGridView, label9);
        }

        private void DatePickerTo_ValueChanged(object sender, EventArgs e)
        {
            GetVanList(vanDataGrid, siteGridView, BillDocGridView, label9);
        }

        private void DateTimeSchedule_ValueChanged(object sender, EventArgs e)
        {
            string message = "Are you sure you want to schedule this date?";
            string title = "Message Alert!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                var pickedItems = (from d in obj.WMS_MSTR_DVMR
                                   join i in obj.WMS_MSTR_INVTY on d.invty_id equals i.invty_id
                                   where d.site_code == sCode.ToString() && d.dvmr_cvan == vanCode.ToString() && d.dvmr_rdd >= DatePickerFrom.Value && d.dvmr_rdd <= DatePickerTo.Value
                                   select d).ToList();
                foreach (var item in pickedItems)
                {
                    item.dvmr_schedule_date = DateTimeSchedule.Value;
                    obj.SaveChanges();
                }
                MessageBox.Show("Schedule Saved.", "Success!");
            }
            else
            {
            }
        }
        
        private void AddBtn_Click(object sender, EventArgs e)
        {
            DateTimeSchedule.Enabled = true;
            GetVanList(DataGridView5, DataGridView6, DataGridView8, label17);
        }

        private void vanDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //vanTableClicked(vanDataGrid.CurrentRow.Cells[0].Value.ToString());

            var dgv = sender as DataGridView;
            dgv.ClearSelection();
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                allchecked1(vanDataGrid);
            }
            else
            {
                    if (Convert.ToBoolean(dgv.CurrentRow.Cells[0].Value) == true)
                    {
                        dgv.CurrentRow.Cells[0].Value = false;
                        dgv.CurrentRow.Cells[0].Style.BackColor = Color.White;
                        dgv.CurrentRow.Cells[1].Style.BackColor = Color.White;
                        dgv.CurrentRow.Cells[2].Style.BackColor = Color.White;
                        dgv.CurrentRow.Cells[3].Style.BackColor = Color.White;
                        dgv.CurrentRow.Cells[0].Style.ForeColor = Color.Black;
                        dgv.CurrentRow.Cells[1].Style.ForeColor = Color.Black;
                        dgv.CurrentRow.Cells[2].Style.ForeColor = Color.Black;
                        dgv.CurrentRow.Cells[3].Style.ForeColor = Color.Black;

                        remVan(dgv.CurrentRow.Cells[1].Value.ToString(), siteGridView, BillDocGridView, label7);
                    }
                    else
                    {

                        dgv.CurrentRow.Cells[0].Value = true;
                        dgv.CurrentRow.Cells[0].Style.BackColor = Color.FromArgb(20, 104, 179);
                        dgv.CurrentRow.Cells[1].Style.BackColor = Color.FromArgb(20, 104, 179);
                        dgv.CurrentRow.Cells[2].Style.BackColor = Color.FromArgb(20, 104, 179);
                        dgv.CurrentRow.Cells[3].Style.BackColor = Color.FromArgb(20, 104, 179);

                        dgv.CurrentRow.Cells[0].Style.ForeColor = Color.White;
                        dgv.CurrentRow.Cells[1].Style.ForeColor = Color.White;
                        dgv.CurrentRow.Cells[2].Style.ForeColor = Color.White;
                        dgv.CurrentRow.Cells[3].Style.ForeColor = Color.White;

                        vanTableClicked(dgv.CurrentRow.Cells[1].Value.ToString());
                    }
            }
        }


        private void allchecked1(DataGridView vanDataGrid)
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

                        xrow.Cells[0].Style.ForeColor = Color.Black;
                        xrow.Cells[1].Style.ForeColor = Color.Black;
                        xrow.Cells[2].Style.ForeColor = Color.Black;
                        xrow.Cells[3].Style.ForeColor = Color.Black;
                    }
                    else
                    {
                        xrow.Cells[0].Value = true;
                        xrow.Cells[0].Style.BackColor = Color.FromArgb(20, 104, 179);
                        xrow.Cells[1].Style.BackColor = Color.FromArgb(20, 104, 179);
                        xrow.Cells[2].Style.BackColor = Color.FromArgb(20, 104, 179);
                        xrow.Cells[3].Style.BackColor = Color.FromArgb(20, 104, 179);
                        xrow.Cells[0].Style.ForeColor = Color.White;
                        xrow.Cells[1].Style.ForeColor = Color.White;
                        xrow.Cells[2].Style.ForeColor = Color.White;
                        xrow.Cells[3].Style.ForeColor = Color.White;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow xrow in vanDataGrid.Rows)
                {
                    if (Convert.ToBoolean(xrow.Cells[0].Value) == true)
                    {

                    }
                    else
                    {
                        xrow.Cells[0].Value = true;
                        xrow.Cells[0].Style.BackColor = Color.FromArgb(20, 104, 179);
                        xrow.Cells[1].Style.BackColor = Color.FromArgb(20, 104, 179);
                        xrow.Cells[2].Style.BackColor = Color.FromArgb(20, 104, 179);
                        xrow.Cells[3].Style.BackColor = Color.FromArgb(20, 104, 179);

                        xrow.Cells[0].Style.ForeColor = Color.White;
                        xrow.Cells[1].Style.ForeColor = Color.White;
                        xrow.Cells[2].Style.ForeColor = Color.White;
                        xrow.Cells[3].Style.ForeColor = Color.White;
 
                    }
                }
            }

        }

        private int TotalCases(DataGridView siteGridView)
        {
            int a = 0;

            foreach (DataGridViewRow xrow in siteGridView.Rows)
            {
                a = a + Convert.ToInt32(xrow.Cells[4].Value);
               
            }
            return a;
        }

        private void remVan(string vanno, DataGridView siteGridView, DataGridView BillDocGridView, Label label)
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
            label.Text = BillDocGridView.Rows.Count.ToString();
        }

        private void DataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            dgv.ClearSelection();
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
            {
                allchecked1(DataGridView5);
            }
            else
            {
                if (Convert.ToBoolean(dgv.CurrentRow.Cells[0].Value) == true)
                {
                    dgv.CurrentRow.Cells[0].Value = false;
                    dgv.CurrentRow.Cells[0].Style.BackColor = Color.White;
                    dgv.CurrentRow.Cells[1].Style.BackColor = Color.White;
                    dgv.CurrentRow.Cells[2].Style.BackColor = Color.White;
                    dgv.CurrentRow.Cells[3].Style.BackColor = Color.White;
                    dgv.CurrentRow.Cells[0].Style.ForeColor = Color.Black;
                    dgv.CurrentRow.Cells[1].Style.ForeColor = Color.Black;
                    dgv.CurrentRow.Cells[2].Style.ForeColor = Color.Black;
                    dgv.CurrentRow.Cells[3].Style.ForeColor = Color.Black;

                    remVan(dgv.CurrentRow.Cells[1].Value.ToString(), DataGridView6, DataGridView8, label13);
                }
                else
                {

                    dgv.CurrentRow.Cells[0].Value = true;
                    dgv.CurrentRow.Cells[0].Style.BackColor = Color.FromArgb(20, 104, 179);
                    dgv.CurrentRow.Cells[1].Style.BackColor = Color.FromArgb(20, 104, 179);
                    dgv.CurrentRow.Cells[2].Style.BackColor = Color.FromArgb(20, 104, 179);
                    dgv.CurrentRow.Cells[3].Style.BackColor = Color.FromArgb(20, 104, 179);

                    dgv.CurrentRow.Cells[0].Style.ForeColor = Color.White;
                    dgv.CurrentRow.Cells[1].Style.ForeColor = Color.White;
                    dgv.CurrentRow.Cells[2].Style.ForeColor = Color.White;
                    dgv.CurrentRow.Cells[3].Style.ForeColor = Color.White;

                    vanTableClicked2(dgv.CurrentRow.Cells[1].Value.ToString());
                }
            }
        }

        private class PInfo
        {
            public string VanName { get; set; }
            public DateTime Rdd { get; set; }
            public DateTime? Schedule { get; set; }
        }
    }

}
