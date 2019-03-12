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

namespace wms.Forms.Warehouse_Management.Incoming_Shipment
{
    public partial class Incoming_Shipment : Form
    {
        private wmsdb obj;
        public Incoming_Shipment()
        {
            obj = new wmsdb();
            InitializeComponent();
        }

        private void Incoming_Shipment_Load(object sender, EventArgs e)
        {
            GetSites();
        }

        private void siteComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            GetBilldocs();
        }

        private void rddFromPicker_ValueChanged(object sender, EventArgs e)
        {
            GetBilldocs();
        }

        private void rddToPicker_ValueChanged(object sender, EventArgs e)
        {
            GetBilldocs();
        }

        private void GetSites()
        {
            var sites = (from s in obj.WMS_MSTR_SITE
                         select new { s.site_id, s.site_name })
                         .OrderBy(s => new { s.site_id }).ToList();

            siteComboBox.Items.Clear();

            if (sites.Count != 0)
            {
                foreach (var site in sites)
                {
                    siteComboBox.Items.Add(site.site_name);
                }
                siteComboBox.SelectedIndex = -1;
            }
        }

        private void GetBilldocs()
        {
            DateTime datefrom = rddFromPicker.Value;
            DateTime dateto = rddToPicker.Value;
            var sitename = siteComboBox.Text;
            var billdocs = (from d in obj.WMS_MSTR_DVMR
                            join s in obj.WMS_MSTR_SITE on d.site_code equals s.site_code
                            where s.site_name == sitename && d.dvmr_rdd >= datefrom.Date && d.dvmr_rdd <= dateto.Date
                            select new
                            {
                                d.dvmr_billdoc,
                                s.site_name,
                                d.dvmr_rdd,
                                d.dvmr_schedule_date
                            }).Distinct().OrderBy(d => d.dvmr_billdoc).ToList();

            billdocsDataGrid.Rows.Clear();
            if (billdocs.Count != 0)
            {
                billdocsDataGrid.ColumnHeadersVisible = true;
                foreach (var row in billdocs)
                {
                    string xdatesched = row.dvmr_schedule_date.HasValue ? row.dvmr_schedule_date.Value.ToString("yyyy-MM-dd") : string.Empty;
                    billdocsDataGrid.Rows.Add(false, row.dvmr_billdoc, row.site_name, row.dvmr_rdd, xdatesched);
                }
            }
            else
            {
                billdocsDataGrid.ColumnHeadersVisible = false;
            }
            billdocsDataGrid.ClearSelection();
        }
        
        private void billdocTableClicked(string billdocs)
        {
            var sitename = siteComboBox.Text;
            billdocTextBox.Text = billdocs;

            var items = (from d in obj.WMS_MSTR_DVMR
                         join s in obj.WMS_MSTR_SITE on d.site_code equals s.site_code
                         join i in obj.WMS_MSTR_INVTY on d.invty_id equals i.invty_id
                         where s.site_name == sitename && d.dvmr_billdoc == billdocs
                         select new
                         {
                             d.invty_id,
                             i.invty_desc,
                             d.dvmr_qty
                         }).OrderBy(c => c.invty_id).ToList();
            itemsGridView.Rows.Clear();
            if (items.Count != 0)
            {
                itemsGridView.ColumnHeadersVisible = true;
                foreach (var item in items)
                {
                    itemsGridView.Rows.Add(false, item.invty_id, item.invty_desc, item.dvmr_qty);
                }
            }
            else
            {
                itemsGridView.ColumnHeadersVisible = false;
            }
            SaveToHeader(billdocs);
        }
        
        private void SaveToHeader(string billdoc)
        {
            bool checker = CheckIfRecordExists(billdoc);

            if (checker.Equals(false))
            {
                var rcvd = DateTime.Now;
                var header = obj.Set<WMS_INC_HEADER>();
                header.Add(new WMS_INC_HEADER { billdoc = billdoc, date_rcvd = rcvd.ToString("yyyy/MM/dd"), stat_id = 1 });
                obj.SaveChanges();
                statusLabel.Text = "Open";
                MessageBox.Show("Billdoc Recorded to Table.");
            }
        }

        private bool CheckIfRecordExists(string bill)
        {
            var header = obj.WMS_INC_HEADER.Where(h => h.billdoc == bill).SingleOrDefault();
            if (header == null)
            {
                return false;
            }
            else
            {
                if (header.stat_id.Equals(1))
                { statusLabel.Text = "Open"; }
                else if (header.stat_id.Equals(2))
                { statusLabel.Text = "Closed"; }
                return true;
            }
        }

        private bool CheckIfLineExists(string casecode)
        {
            var line = (from lines in obj.WMS_INC_LINES
                        join items in obj.WMS_MSTR_INVTY on lines.invty_id equals items.invty_id
                        where items.invty_casecode == casecode
                        select lines).SingleOrDefault();
            if (line == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ScanItemsInLine()
        {
            if (statusLabel.Text.Equals("Open"))
            {
                
            }
            else if (statusLabel.Text.Equals("Closed"))
            {
                MessageBox.Show("Header is already closed.");
            }
        }

        private void billdocsDataGrid_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in billdocsDataGrid.Rows)
            {
                row.Cells[0].Value = false;
                row.Cells[0].Style.BackColor = Color.White;
                row.Cells[1].Style.BackColor = Color.White;
                row.Cells[2].Style.BackColor = Color.White;
                row.Cells[3].Style.BackColor = Color.White;
                row.Cells[4].Style.BackColor = Color.White;

                row.Cells[0].Style.ForeColor = Color.Black;
                row.Cells[1].Style.ForeColor = Color.Black;
                row.Cells[2].Style.ForeColor = Color.Black;
                row.Cells[3].Style.ForeColor = Color.Black;
                row.Cells[4].Style.ForeColor = Color.Black;
            }

            var dgv = sender as DataGridView;
            dgv.ClearSelection();
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

                billdocTableClicked(dgv.CurrentRow.Cells[1].Value.ToString());
            }
        }
        
        private void barcodeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CheckIfLineExists(barcodeTextBox.Text).Equals(true))
            {
                MessageBox.Show("Casecode exists.");
            }
            else
            {
                MessageBox.Show("Casecode does not exists.");
            }
        }

        private void statBtn_Click(object sender, EventArgs e)
        {
            var header = obj.WMS_INC_HEADER.Where(c => c.billdoc == billdocTextBox.Text).SingleOrDefault();
            if (header.stat_id.Equals(1))
            {
                header.stat_id = 2;
                statusLabel.Text = "Closed";
                obj.SaveChanges();
            }
            else if (header.stat_id.Equals(2))
            {
                header.stat_id = 1;
                statusLabel.Text = "Open";
                obj.SaveChanges();
            }
        }
    }
}
