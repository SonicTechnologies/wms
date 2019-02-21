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
            GetVanList();
        }

        public void GetVanList()
        {
            //DateTime datefrm = DatePickerFrom.Value;
            //DateTime dateto = DatePickerTo.Value;
            var vans = (from c in obj.WMS_MSTR_DVMR
                        //where c.dvmr_rdd >= datefrm.Date && c.dvmr_rdd <= dateto.Date
                        select new 
                            {
                                c.dvmr_cvan,
                                c.dvmr_rdd,
                                c.dvmr_schedule_date

                            }).OrderBy(c => new { c.dvmr_schedule_date }).ThenBy(c => c.dvmr_cvan).Distinct().ToList();

            vanDataGrid.Rows.Clear();
            label9.Text = vans.Count.ToString();
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

       
        public void Table5Clicked(DataGridViewCellEventArgs e)
        {
            DataGridView8.Rows.Clear();
            DataGridView6.Rows.Clear();
            int qty = 0;
            vanCode = DataGridView5.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            var query = (from d in obj.WMS_MSTR_DVMR
                         join s in obj.WMS_MSTR_SITE on d.site_code equals s.site_code
                         where d.dvmr_rdd >= DatePickerFrom.Value && d.dvmr_rdd <= DatePickerTo.Value && d.dvmr_cvan == vanCode.ToString()
                         select new
                         {
                             BillDoc = d.dvmr_billdoc,
                             SiteName = s.site_name
                         }).OrderBy(d => new { d.BillDoc }).Distinct();
            foreach (var billdoc in query)
            {
                DataGridView8.Rows.Add(billdoc.BillDoc, billdoc.SiteName);
            }

            var query2 = (from d in obj.WMS_MSTR_DVMR
                          join s in obj.WMS_MSTR_SITE on d.site_code equals s.site_code
                          join i in obj.WMS_MSTR_INVTY on d.invty_id equals i.invty_id
                          where d.dvmr_cvan == vanCode.ToString() && d.dvmr_rdd >= DatePickerFrom.Value && d.dvmr_rdd <= DatePickerTo.Value
                          select new
                          {
                              SiteCode = d.site_code,
                              SiteName = s.site_name
                          }).OrderBy(d => new { d.SiteCode }).Distinct();
            foreach (var items in query2)
            {
                var insideQuery = obj.WMS_MSTR_DVMR.Where(d => d.site_code == items.SiteCode).Select(d => d.dvmr_qty).ToList();
                foreach (var x in insideQuery)
                {
                    qty += x;
                }
                DataGridView6.Rows.Add(items.SiteCode, items.SiteName, qty.ToString());
            }
        }

        public void Table6Clicked(DataGridViewCellEventArgs e)
        {
            //DataGridView7.Rows.Clear();
            //int qty = 0;
            //sCode = DataGridView6.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            //var query = (from d in obj.WMS_MSTR_DVMR
                         //join i in obj.WMS_MSTR_INVTY on d.invty_id equals i.invty_id
                         //where d.site_code == sCode.ToString() && d.dvmr_rdd >= DatePickerFrom.Value && d.dvmr_rdd <= DatePickerTo.Value
                         //select new
                         //{
                             //invtyId = d.invty_id,
                             //invtyDesc = i.invty_desc
                         //}).Distinct();
            //foreach (var items in query)
            //{
                //var qtyPerItem = obj.WMS_MSTR_DVMR.Where(d => d.invty_id == items.invtyId).Select(d => d.dvmr_qty).ToList();
                //foreach (var x in qtyPerItem)
                //{
                    //qty += x;
                //}
                //DataGridView7.Rows.Add(items.invtyId, items.invtyDesc, qty.ToString());
            //}
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
            label14.Text = TotalCases().ToString();

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

        public void siteTableClicked(DataGridViewCellEventArgs e)
        {
            //DataGridView3.Rows.Clear();
            //int qty = 0;
            //var siteCode = siteGridView.Rows[e.RowIndex].Cells[0].Value;
            //var query = (from d in obj.WMS_MSTR_DVMR
                         //where d.site_code == siteCode.ToString()
                         //select new
                         //{
                             //invtyId = d.invty_id
                         //}).Distinct();
            //foreach (var items in query)
            //{
                //var desc = obj.WMS_MSTR_INVTY.Where(i => i.invty_id == items.invtyId).Select(i => i.invty_desc).SingleOrDefault();
                //var qtyPerItem = obj.WMS_MSTR_DVMR.Where(d => d.invty_id == items.invtyId).Select(d => d.dvmr_qty).ToList();
                //foreach (var x in qtyPerItem)
                //{
                    //qty += x;
                //}
                //DataGridView3.Rows.Add(items.invtyId, desc.ToString(), qty.ToString());
            //}
        }

        private void siteGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            siteTableClicked(e);
        }

        private void DataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Table5Clicked(e);
        }

        private void DataGridView6_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Table6Clicked(e);
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
            DataGridView5.Rows.Clear();
            var vans = obj.WMS_MSTR_DVMR.Where(v => v.dvmr_rdd >= DatePickerFrom.Value && v.dvmr_rdd <= DatePickerTo.Value)
                .Select(v => new PInfo
                {
                    VanName = v.dvmr_cvan,
                    Rdd = v.dvmr_rdd,
                    Schedule = v.dvmr_schedule_date
                }).Distinct();
            foreach (var van in vans)
            {
                string loadedString = "";
                if (van.Schedule == null)
                { loadedString = "False"; }
                else { loadedString = "True"; }
                DataGridView5.Rows.Add(van.VanName, loadedString, van.Schedule);
            }
        }

        private void vanDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //vanTableClicked(vanDataGrid.CurrentRow.Cells[0].Value.ToString());

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


                        dgv.CurrentRow.Cells[0].Style.ForeColor = Color.Black;
                        dgv.CurrentRow.Cells[1].Style.ForeColor = Color.Black;
                        dgv.CurrentRow.Cells[2].Style.ForeColor = Color.Black;
                        dgv.CurrentRow.Cells[3].Style.ForeColor = Color.Black;

                        remVan(dgv.CurrentRow.Cells[1].Value.ToString());
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
        private int TotalCases()
        {
            int a = 0;

            foreach (DataGridViewRow xrow in siteGridView.Rows)
            {
                a = a + Convert.ToInt32(xrow.Cells[4].Value);
               
            }
            return a;
        }

        private void remVan(string vanno)
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

            //foreach (DataGridViewRow xrow in siteGridView.Rows)
            //{
            //if (xrow.Cells[4].Value.ToString() == vanno)
            //{
            //siteGridView.Rows.Remove(xrow);
            //}
            //else
            //{

            //}

            //}
            label7.Text = BillDocGridView.Rows.Count.ToString();
        }

        private class PInfo
        {
            public string VanName { get; set; }
            public DateTime Rdd { get; set; }
            public DateTime? Schedule { get; set; }
        }
    }

}
