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

        public void InitializeTable1()
        {
            vanDataGrid.Rows.Clear();
            var vans = obj.WMS_MSTR_DVMR
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
                vanDataGrid.Rows.Add(van.VanName, loadedString, van.Schedule);
            }
        }

        public void DatePicked()
        {
            vanDataGrid.Rows.Clear();
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
                vanDataGrid.Rows.Add(van.VanName, loadedString, van.Schedule);
            }
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
                         }).Distinct();
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
                          }).Distinct();
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
            DataGridView7.Rows.Clear();
            int qty = 0;
            sCode = DataGridView6.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            var query = (from d in obj.WMS_MSTR_DVMR
                         join i in obj.WMS_MSTR_INVTY on d.invty_id equals i.invty_id
                         where d.site_code == sCode.ToString() && d.dvmr_rdd >= DatePickerFrom.Value && d.dvmr_rdd <= DatePickerTo.Value
                         select new
                         {
                             invtyId = d.invty_id,
                             invtyDesc = i.invty_desc
                         }).Distinct();
            foreach (var items in query)
            {
                var qtyPerItem = obj.WMS_MSTR_DVMR.Where(d => d.invty_id == items.invtyId).Select(d => d.dvmr_qty).ToList();
                foreach (var x in qtyPerItem)
                {
                    qty += x;
                }
                DataGridView7.Rows.Add(items.invtyId, items.invtyDesc, qty.ToString());
            }
        }
        
        public void vanTableClicked(DataGridViewCellEventArgs e)
        {
            BillDocGridView.Rows.Clear();
            siteGridView.Rows.Clear();
            int qty = 0;
            var van = vanDataGrid.Rows[e.RowIndex].Cells[0].Value;
            var query = (from r in obj.WMS_MSTR_DVMR
                         where r.dvmr_cvan == van.ToString() && r.dvmr_rdd >= DatePickerFrom.Value && r.dvmr_rdd <= DatePickerTo.Value
                         select new
                         {
                             BillDoc = r.dvmr_billdoc,
                             SiteCode = r.site_code
                         }).Distinct().ToList();
            foreach (var billdoc in query)
            {
                var siteName = obj.WMS_MSTR_SITE.Where(s => s.site_code == billdoc.SiteCode).Select(s => s.site_name).SingleOrDefault();
                BillDocGridView.Rows.Add(billdoc.BillDoc, siteName);
            }

            var query2 = (from d in obj.WMS_MSTR_DVMR
                          where d.dvmr_cvan == van.ToString() && d.dvmr_rdd >= DatePickerFrom.Value && d.dvmr_rdd <= DatePickerTo.Value
                          select new
                          {
                              SiteCode = d.site_code
                          }).Distinct().ToList();
            foreach (var items in query2)
            {
                var insideQuery = obj.WMS_MSTR_DVMR.Where(d => d.site_code == items.SiteCode).Select(d => d.dvmr_qty).ToList();
                foreach (var x in insideQuery)
                {
                    qty += x;
                }
                var siteName = obj.WMS_MSTR_SITE.Where(s => s.site_code == items.SiteCode).Select(d => d.site_name).SingleOrDefault();
                siteGridView.Rows.Add(items.SiteCode, siteName, qty.ToString());
            }
        }

        public void siteTableClicked(DataGridViewCellEventArgs e)
        {
            DataGridView3.Rows.Clear();
            int qty = 0;
            var siteCode = siteGridView.Rows[e.RowIndex].Cells[0].Value;
            var query = (from d in obj.WMS_MSTR_DVMR
                         where d.site_code == siteCode.ToString()
                         select new
                         {
                             invtyId = d.invty_id
                         }).Distinct();
            foreach (var items in query)
            {
                var desc = obj.WMS_MSTR_INVTY.Where(i => i.invty_id == items.invtyId).Select(i => i.invty_desc).SingleOrDefault();
                var qtyPerItem = obj.WMS_MSTR_DVMR.Where(d => d.invty_id == items.invtyId).Select(d => d.dvmr_qty).ToList();
                foreach (var x in qtyPerItem)
                {
                    qty += x;
                }
                DataGridView3.Rows.Add(items.invtyId, desc.ToString(), qty.ToString());
            }
        }

        private void vanDataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            vanTableClicked(e);
        }

        private void siteGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            siteTableClicked(e);
        }

        private void DataGridView5_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Table5Clicked(e);
        }
        
        private void DataGridView6_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Table6Clicked(e);
        }

        private void DatePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            DatePicked();
        }

        private void DatePickerTo_ValueChanged(object sender, EventArgs e)
        {
            DatePicked();
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


        private class PInfo
        {
            public string VanName { get; set; }
            public DateTime Rdd { get; set; }
            public DateTime? Schedule { get; set; }
        }
    }

}
