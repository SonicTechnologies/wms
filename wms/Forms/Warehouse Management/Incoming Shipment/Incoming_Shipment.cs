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


        private void GetItems()
        {

        }

        private void billdocsDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
            }
        }
    }
}
