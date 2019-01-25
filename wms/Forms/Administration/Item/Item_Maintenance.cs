using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wms.Class;
using wms.Entity_Class;

namespace wms.Forms.Administration.Item
{
    public partial class Item_Maintenance : Form
    {
        wmsdb obj = new wmsdb();
        public Item_Maintenance()
        {
            InitializeComponent();
        }

        private void Item_Maintenance_Load(object sender, EventArgs e)
        {
            getStatus();
        }

        public void getStatus()
        {
            var status = (from c in obj.WMS_TYPE_STAT
                          select new
                          {
                              c.stat_id,
                              c.stat_desc,

                          }).OrderBy(c => new { c.stat_desc }).ToList();

            comboBox4.Items.Clear();

            if (status.Count != 0)
            {

                foreach (var row in status)
                {
                    comboBox4.Items.Add(row.stat_desc);
                }
                comboBox4.SelectedIndex = -1;
            }
           
        }
        
        private void searchTxtBox_TextChanged(object sender, EventArgs e)
        {
            searchItem();
        }

        public void searchItem()
        {
            if (searchTxtBox.Text.Trim() == "")
            {
                dataGridView1.ColumnHeadersVisible = false;
                dataGridView1.Rows.Clear();
            }
            else
            {
                if (searchComboBox.Text == "Itemcode")
                {
                    var itemcode = searchTxtBox.Text.Trim();
                    var items = (from c in obj.WMS_INVTY_VIEW
                                 where c.invty_id == itemcode
                                 select new
                                 {
                                     c.invty_id,
                                     c.invty_desc,
                                     c.invty_barcode,
                                     c.invty_casecode,
                                     c.invty_ppu,
                                     c.invty_cat1,
                                     c.invty_cat2,
                                     c.invty_cat3,
                                     c.invty_cat4,
                                     c.invty_brand,
                                     c.stat_desc,
                                     c.invty_datecrtd,
                                     c.crtdby,
                                     c.invty_dateuptd,
                                     c.uptdby
                                 }).OrderBy(c => new { c.invty_desc }).ToList();

                    dataGridView1.Rows.Clear();

                    if (items.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in items)
                        {
                            dataGridView1.Rows.Add(row.invty_id,
                                                   row.invty_desc,
                                                   row.invty_barcode,
                                                   row.invty_casecode,
                                                   row.invty_ppu,
                                                   row.invty_cat1,
                                                   row.invty_cat2,
                                                   row.invty_cat3,
                                                   row.invty_cat4,
                                                   row.invty_brand,
                                                   row.stat_desc,
                                                   row.invty_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.crtdby,
                                                   row.invty_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.uptdby);
                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }
                }
                else if (searchComboBox.Text == "Item Description")
                {
                    var itemdesc = searchTxtBox.Text.Trim();
                    var items = (from c in obj.WMS_INVTY_VIEW
                                 where c.invty_desc.StartsWith(itemdesc)
                                 select new
                                 {
                                     c.invty_id,
                                     c.invty_desc,
                                     c.invty_barcode,
                                     c.invty_casecode,
                                     c.invty_ppu,
                                     c.invty_cat1,
                                     c.invty_cat2,
                                     c.invty_cat3,
                                     c.invty_cat4,
                                     c.invty_brand,
                                     c.stat_desc,
                                     c.invty_datecrtd,
                                     c.crtdby,
                                     c.invty_dateuptd,
                                     c.uptdby

                                 }).OrderBy(c => new { c.invty_desc }).ToList();

                    dataGridView1.Rows.Clear();

                    if (items.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in items)
                        {
                            dataGridView1.Rows.Add(row.invty_id,
                                                   row.invty_desc,
                                                   row.invty_barcode,
                                                   row.invty_casecode,
                                                   row.invty_ppu,
                                                   row.invty_cat1,
                                                   row.invty_cat2,
                                                   row.invty_cat3,
                                                   row.invty_cat4,
                                                   row.invty_brand,
                                                   row.stat_desc,
                                                   row.invty_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.crtdby,
                                                   row.invty_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.uptdby);
                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }
                }
                else if (searchComboBox.Text == "Barcode")
                {
                    var barcode = searchTxtBox.Text.Trim();
                    var items = (from c in obj.WMS_INVTY_VIEW
                                 where c.invty_barcode.Contains(barcode)
                                 select new
                                 {
                                     c.invty_id,
                                     c.invty_desc,
                                     c.invty_barcode,
                                     c.invty_casecode,
                                     c.invty_ppu,
                                     c.invty_cat1,
                                     c.invty_cat2,
                                     c.invty_cat3,
                                     c.invty_cat4,
                                     c.invty_brand,
                                     c.stat_desc,
                                     c.invty_datecrtd,
                                     c.crtdby,
                                     c.invty_dateuptd,
                                     c.uptdby
                                 }).OrderBy(c => new { c.invty_desc }).ToList();

                    dataGridView1.Rows.Clear();

                    if (items.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in items)
                        {

                            dataGridView1.Rows.Add(row.invty_id,
                                                   row.invty_desc,
                                                   row.invty_barcode,
                                                   row.invty_casecode,
                                                   row.invty_ppu,
                                                   row.invty_cat1,
                                                   row.invty_cat2,
                                                   row.invty_cat3,
                                                   row.invty_cat4,
                                                   row.invty_brand,
                                                   row.stat_desc,
                                                   row.invty_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.crtdby,
                                                   row.invty_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.uptdby);
                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }
                }
                else if (searchComboBox.Text == "Casecode")
                {
                    var casecode = searchTxtBox.Text.Trim();
                    var items = (from c in obj.WMS_INVTY_VIEW
                                 where c.invty_casecode.Contains(casecode)
                                 select new
                                 {
                                     c.invty_id,
                                     c.invty_desc,
                                     c.invty_barcode,
                                     c.invty_casecode,
                                     c.invty_ppu,
                                     c.invty_cat1,
                                     c.invty_cat2,
                                     c.invty_cat3,
                                     c.invty_cat4,
                                     c.invty_brand,
                                     c.stat_desc,
                                     c.invty_datecrtd,
                                     c.crtdby,
                                     c.invty_dateuptd,
                                     c.uptdby
                                 }).OrderBy(c => new { c.invty_desc }).ToList();

                    dataGridView1.Rows.Clear();

                    if (items.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in items)
                        {
                            dataGridView1.Rows.Add(row.invty_id,
                                                   row.invty_desc,
                                                   row.invty_barcode,
                                                   row.invty_casecode,
                                                   row.invty_ppu,
                                                   row.invty_cat1,
                                                   row.invty_cat2,
                                                   row.invty_cat3,
                                                   row.invty_cat4,
                                                   row.invty_brand,
                                                   row.stat_desc,
                                                   row.invty_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.crtdby,
                                                   row.invty_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.uptdby);
                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }
                }
                else if (searchComboBox.Text == "Category1")
                {
                    var cat1 = searchTxtBox.Text.Trim();
                    var items = (from c in obj.WMS_INVTY_VIEW
                                 where c.invty_cat1.StartsWith(cat1)
                                 select new
                                 {
                                     c.invty_id,
                                     c.invty_desc,
                                     c.invty_barcode,
                                     c.invty_casecode,
                                     c.invty_ppu,
                                     c.invty_cat1,
                                     c.invty_cat2,
                                     c.invty_cat3,
                                     c.invty_cat4,
                                     c.invty_brand,
                                     c.stat_desc,
                                     c.invty_datecrtd,
                                     c.crtdby,
                                     c.invty_dateuptd,
                                     c.uptdby
                                 }).OrderBy(c => new { c.invty_desc }).ToList();
                    dataGridView1.Rows.Clear();

                    if (items.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in items)
                        {
                            dataGridView1.Rows.Add(row.invty_id,
                                                   row.invty_desc,
                                                   row.invty_barcode,
                                                   row.invty_casecode,
                                                   row.invty_ppu,
                                                   row.invty_cat1,
                                                   row.invty_cat2,
                                                   row.invty_cat3,
                                                   row.invty_cat4,
                                                   row.invty_brand,
                                                   row.stat_desc,
                                                   row.invty_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.crtdby,
                                                   row.invty_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.uptdby);
                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }
                }
                else if (searchComboBox.Text == "Category2")
                {
                    var cat2 = searchTxtBox.Text.Trim();
                    var items = (from c in obj.WMS_INVTY_VIEW
                                 where c.invty_cat2.StartsWith(cat2)
                                 select new
                                 {
                                     c.invty_id,
                                     c.invty_desc,
                                     c.invty_barcode,
                                     c.invty_casecode,
                                     c.invty_ppu,
                                     c.invty_cat1,
                                     c.invty_cat2,
                                     c.invty_cat3,
                                     c.invty_cat4,
                                     c.invty_brand,
                                     c.stat_desc,
                                     c.invty_datecrtd,
                                     c.crtdby,
                                     c.invty_dateuptd,
                                     c.uptdby

                                 }).OrderBy(c => new { c.invty_desc }).ToList();

                    dataGridView1.Rows.Clear();

                    if (items.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in items)
                        {
                            dataGridView1.Rows.Add(row.invty_id,
                                                   row.invty_desc,
                                                   row.invty_barcode,
                                                   row.invty_casecode,
                                                   row.invty_ppu,
                                                   row.invty_cat1,
                                                   row.invty_cat2,
                                                   row.invty_cat3,
                                                   row.invty_cat4,
                                                   row.invty_brand,
                                                   row.stat_desc,
                                                   row.invty_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.crtdby,
                                                   row.invty_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.uptdby);
                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }
                }
                else if (searchComboBox.Text == "Category3")
                {
                    var cat3 = searchTxtBox.Text.Trim();
                    var items = (from c in obj.WMS_INVTY_VIEW
                                 where c.invty_cat3.StartsWith(cat3)
                                 select new
                                 {
                                     c.invty_id,
                                     c.invty_desc,
                                     c.invty_barcode,
                                     c.invty_casecode,
                                     c.invty_ppu,
                                     c.invty_cat1,
                                     c.invty_cat2,
                                     c.invty_cat3,
                                     c.invty_cat4,
                                     c.invty_brand,
                                     c.stat_desc,
                                     c.invty_datecrtd,
                                     c.crtdby,
                                     c.invty_dateuptd,
                                     c.uptdby
                                 }).OrderBy(c => new { c.invty_desc }).ToList();

                    dataGridView1.Rows.Clear();

                    if (items.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in items)
                        {
                            dataGridView1.Rows.Add(row.invty_id,
                                                   row.invty_desc,
                                                   row.invty_barcode,
                                                   row.invty_casecode,
                                                   row.invty_ppu,
                                                   row.invty_cat1,
                                                   row.invty_cat2,
                                                   row.invty_cat3,
                                                   row.invty_cat4,
                                                   row.invty_brand,
                                                   row.stat_desc,
                                                   row.invty_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.crtdby,
                                                   row.invty_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.uptdby);
                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }
                }
                else if (searchComboBox.Text == "Category4")
                {
                    var cat4 = searchTxtBox.Text.Trim();
                    var items = (from c in obj.WMS_INVTY_VIEW
                                 where c.invty_cat4.StartsWith(cat4)
                                 select new
                                 {
                                     c.invty_id,
                                     c.invty_desc,
                                     c.invty_barcode,
                                     c.invty_casecode,
                                     c.invty_ppu,
                                     c.invty_cat1,
                                     c.invty_cat2,
                                     c.invty_cat3,
                                     c.invty_cat4,
                                     c.invty_brand,
                                     c.stat_desc,
                                     c.invty_datecrtd,
                                     c.crtdby,
                                     c.invty_dateuptd,
                                     c.uptdby

                                 }).OrderBy(c => new { c.invty_desc }).ToList();
                    dataGridView1.Rows.Clear();

                    if (items.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in items)
                        {
                            dataGridView1.Rows.Add(row.invty_id,
                                                   row.invty_desc,
                                                   row.invty_barcode,
                                                   row.invty_casecode,
                                                   row.invty_ppu,
                                                   row.invty_cat1,
                                                   row.invty_cat2,
                                                   row.invty_cat3,
                                                   row.invty_cat4,
                                                   row.invty_brand,
                                                   row.stat_desc,
                                                   row.invty_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.crtdby,
                                                   row.invty_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.uptdby);
                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }
                }
                else if (searchComboBox.Text == "Item Brand")
                {
                    var brand = searchTxtBox.Text.Trim();
                    var items = (from c in obj.WMS_INVTY_VIEW
                                 where c.invty_brand.Contains(brand)
                                 select new
                                 {
                                     c.invty_id,
                                     c.invty_desc,
                                     c.invty_barcode,
                                     c.invty_casecode,
                                     c.invty_ppu,
                                     c.invty_cat1,
                                     c.invty_cat2,
                                     c.invty_cat3,
                                     c.invty_cat4,
                                     c.invty_brand,
                                     c.stat_desc,
                                     c.invty_datecrtd,
                                     c.crtdby,
                                     c.invty_dateuptd,
                                     c.uptdby
                                 }).OrderBy(c => new { c.invty_desc }).ToList();

                    dataGridView1.Rows.Clear();

                    if (items.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in items)
                        {
                            dataGridView1.Rows.Add(row.invty_id,
                                                   row.invty_desc,
                                                   row.invty_barcode,
                                                   row.invty_casecode,
                                                   row.invty_ppu,
                                                   row.invty_cat1,
                                                   row.invty_cat2,
                                                   row.invty_cat3,
                                                   row.invty_cat4,
                                                   row.invty_brand,
                                                   row.stat_desc,
                                                   row.invty_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.crtdby,
                                                   row.invty_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.uptdby);
                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }
                }
                else if (searchComboBox.Text == "Item Status")
                {
                    var status = searchTxtBox.Text.Trim();
                    var items = (from c in obj.WMS_INVTY_VIEW
                                 where c.invty_desc == status
                                 select new
                                 {
                                     c.invty_id,
                                     c.invty_desc,
                                     c.invty_barcode,
                                     c.invty_casecode,
                                     c.invty_ppu,
                                     c.invty_cat1,
                                     c.invty_cat2,
                                     c.invty_cat3,
                                     c.invty_cat4,
                                     c.invty_brand,
                                     c.stat_desc,
                                     c.invty_datecrtd,
                                     c.crtdby,
                                     c.invty_dateuptd,
                                     c.uptdby
                                 }).OrderBy(c => new { c.invty_desc }).ToList();
                    dataGridView1.Rows.Clear();

                    if (items.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in items)
                        {
                            dataGridView1.Rows.Add(row.invty_id,
                                row.invty_desc,
                                row.invty_barcode,
                                row.invty_casecode,
                                row.invty_ppu,
                                row.invty_cat1,
                                row.invty_cat2,
                                row.invty_cat3,
                                row.invty_cat4,
                                row.invty_brand,
                                row.stat_desc,
                                row.invty_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                row.crtdby,
                                row.invty_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                row.uptdby);
                        }
                    }
                    else
                    { dataGridView1.ColumnHeadersVisible = false; }
                }
            }
        }

        public void GetItems()
        {
            var items = (from c in obj.WMS_INVTY_VIEW
                         select new
                         {
                             c.invty_id,
                             c.invty_desc,
                             c.invty_barcode,
                             c.invty_casecode,
                             c.invty_ppu,
                             c.invty_cat1,
                             c.invty_cat2,
                             c.invty_cat3,
                             c.invty_cat4,
                             c.invty_brand,
                             c.stat_desc,
                             c.invty_datecrtd,
                             c.crtdby,
                             c.invty_dateuptd,
                             c.uptdby
                         }).OrderBy(c => new { c.invty_desc }).ToList();
            dataGridView1.Rows.Clear();

            if (items.Count != 0)
            {
                dataGridView1.ColumnHeadersVisible = true;
                foreach (var row in items)
                {
                    dataGridView1.Rows.Add(row.invty_id,
                        row.invty_desc,
                        row.invty_barcode,
                        row.invty_casecode,
                        row.invty_ppu,
                        row.invty_cat1,
                        row.invty_cat2,
                        row.invty_cat3,
                        row.invty_cat4,
                        row.invty_brand,
                        row.stat_desc,
                        row.invty_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                        row.crtdby,
                        row.invty_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                        row.uptdby);
                }
            }
            else
            { dataGridView1.ColumnHeadersVisible = false; }
        }

        public void enableAddControls()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            comboBox4.SelectedIndex = -1;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            textBox10.Enabled = true;
            textBox11.Enabled = true;
            comboBox4.Enabled = true;
            panel82.Visible = true;
        }

        public void disableAddControls()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            comboBox4.SelectedIndex = -1;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            comboBox4.Enabled = false;
            panel82.Visible = false;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            saveBtn.Text = "Save";
            enableAddControls();
            textBox2.Focus();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            disableAddControls();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            if (searchComboBox.Text == "All" && searchTxtBox.Text.Trim() == "")
            {
                GetItems();
            }
            else
            {
                if (searchComboBox.Text == "" && searchTxtBox.Text.Trim() != "")
                {  }
                else
                {
                    searchItem();
                }

            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            saveBtn.Text = "Update";
            enableAddControls();
            textBox2.Enabled = false;       
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            if (Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value) == string.Empty)
            {
                textBox4.Text = "";
            }
            else
            {
                textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }

            if (Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value) == string.Empty)
            {
                textBox5.Text = "";
            }
            else
            {
                textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            if (Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value) == string.Empty)
            {
                textBox8.Text = "";
            }
            else
            {
                textBox8.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }

            if (Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value) == string.Empty)
            {
                textBox9.Text = "";
            }
            else
            {
                textBox9.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            }

            if (Convert.ToString(dataGridView1.CurrentRow.Cells[8].Value) == string.Empty)
            {
                textBox10.Text = "";
            }
            else
            {
                textBox10.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            }

            if (Convert.ToString(dataGridView1.CurrentRow.Cells[9].Value) == string.Empty)
            {
                textBox11.Text = "";
            }
            else
            {
                textBox11.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            }
            comboBox4.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox15.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            textBox14.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();

            if (Convert.ToString(dataGridView1.CurrentRow.Cells[13].Value) == string.Empty)
            {
                textBox13.Text = "";
            }
            else
            {
                textBox13.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            }

            if (Convert.ToString(dataGridView1.CurrentRow.Cells[14].Value) == string.Empty)
            {
                textBox12.Text = "";
            }
            else
            {
                textBox12.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            }
        }

        private void searchComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (searchComboBox.Text == "All")
            {
                searchTxtBox.Text = "";
                searchTxtBox.Enabled = false;
                GetItems();
            }
            else
            {
                searchTxtBox.Enabled = true;
            }
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            IM_Upload_data imup = new IM_Upload_data();
            imup.Show();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (saveBtn.Text == "Save")
            {
                if (textBox2.Text.Trim() != "")
                {
                    if (textBox3.Text.Trim() != "")
                    {
                        if (textBox6.Text.Trim() != "")
                        {
                            if (textBox7.Text.Trim() != "")
                            {
                                if (comboBox4.Text.Trim() != "")
                                {
                                    DialogResult dialog = MessageBox.Show("Are you sure you want to save Item?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dialog == DialogResult.Yes)
                                    {

                                        string xstatdesc = comboBox4.Text;
                                        int xstatid = 1;
                                        var statid = (from c in obj.WMS_TYPE_STAT
                                                      where c.stat_desc == xstatdesc
                                                      select c.stat_id).FirstOrDefault();

                                        xstatid = statid;

                                        var item = (from c in obj.WMS_INVTY_VIEW
                                                    where c.invty_id == textBox2.Text.Trim()
                                                    select c.invty_id).FirstOrDefault();

                                        var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                                        DateTime serverDate = dateQuery.AsEnumerable().First();

                                        if (item == null)
                                        {
                                            var xitem = obj.Set<WMS_MSTR_INVTY>();
                                            xitem.Add(new WMS_MSTR_INVTY
                                            {
                                                invty_id = textBox2.Text.Trim(),
                                                invty_desc = textBox3.Text.Trim(),
                                                invty_barcode = textBox4.Text.Trim(),
                                                invty_casecode = textBox5.Text.Trim(),
                                                invty_ppu = Convert.ToInt32(textBox6.Text.Trim()),
                                                invty_cat1 = textBox7.Text.Trim(),
                                                invty_cat2 = textBox8.Text.Trim(),
                                                invty_cat3 = textBox9.Text.Trim(),
                                                invty_cat4 = textBox10.Text.Trim(),
                                                invty_brand = textBox11.Text.Trim(),
                                                stat_id = xstatid,
                                                invty_datecrtd = serverDate,
                                                invty_crtdby = loggedin_user.userId

                                            });
                                            obj.SaveChanges();

                                            MessageBox.Show("Successfully saved Item.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            searchComboBox.Text = "Itemcode";
                                            searchTxtBox.Text = textBox2.Text.Trim();
                                            disableAddControls();

                                        }
                                        else
                                        {
                                            MessageBox.Show("'Itemcode' already exist.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            searchComboBox.Text = "Itemcode";
                                            searchTxtBox.Text = textBox2.Text.Trim();
                                        }
                                    }
                                    else if (dialog == DialogResult.No)
                                    {

                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Please select 'Item Status'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    comboBox4.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please fill up 'Item Category1'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBox7.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please fill up 'Item PPU'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox6.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please fill up 'Item Description'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox3.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please fill up 'Itemcode'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Focus();
                }


            }
            else if (saveBtn.Text == "Update")
            {
                if (textBox3.Text.Trim() != "")
                {
                    if (textBox6.Text.Trim() != "")
                    {
                        if (textBox7.Text.Trim() != "")
                        {
                            if (comboBox4.Text.Trim() != "")
                            {
                                DialogResult dialog = MessageBox.Show("Are you sure you want to update Item?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialog == DialogResult.Yes)
                                {
                                    string bcode = "";
                                    string ccode = "";
                                    string cat2 = "";
                                    string cat3 = "";
                                    string cat4 = "";
                                    string brand = "";

                                    if (textBox4.Text.Trim() == "")
                                    {
                                        bcode = null;
                                    }
                                    else
                                    {
                                        bcode = textBox4.Text.Trim();
                                    }

                                    if (textBox5.Text.Trim() == "")
                                    {
                                        ccode = null;
                                    }
                                    else
                                    {
                                        ccode = textBox5.Text.Trim();
                                    }

                                    if (textBox8.Text.Trim() == "")
                                    {
                                        cat2 = null;
                                    }
                                    else
                                    {
                                        cat2 = textBox8.Text.Trim();
                                    }

                                    if (textBox9.Text.Trim() == "")
                                    {
                                        cat3 = null;
                                    }
                                    else
                                    {
                                        cat3 = textBox9.Text.Trim();
                                    }

                                    if (textBox10.Text.Trim() == "")
                                    {
                                        cat4 = null;
                                    }
                                    else
                                    {
                                        cat4 = textBox10.Text.Trim();
                                    }

                                    if (textBox11.Text.Trim() == "")
                                    {
                                        brand = null;
                                    }
                                    else
                                    {
                                        brand = textBox11.Text.Trim();
                                    }

                                    string xstatdesc = comboBox4.Text;
                                    int xstatid = 1;
                                    var statid = (from c in obj.WMS_TYPE_STAT
                                                  where c.stat_desc == xstatdesc
                                                  select c.stat_id).FirstOrDefault();
                                    xstatid = statid;
                                    var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                                    DateTime serverDate = dateQuery.AsEnumerable().First();

                                    obj.WMS_MSTR_INVTY.Where(c => c.invty_id == textBox2.Text.Trim()).ToList().ForEach(x =>
                                    {
                                        x.invty_desc = textBox3.Text.Trim();
                                        x.invty_barcode = bcode;
                                        x.invty_casecode = ccode;
                                        x.invty_ppu = Convert.ToInt32(textBox6.Text.Trim());
                                        x.invty_cat1 = textBox7.Text.Trim();
                                        x.invty_cat2 = cat2;
                                        x.invty_cat3 = cat3;
                                        x.invty_cat4 = cat4;
                                        x.invty_brand = brand;
                                        x.stat_id = xstatid;
                                        x.invty_dateuptd = serverDate;
                                        x.invty_uptdby = loggedin_user.userId;

                                    });
                                    obj.SaveChanges();

                                    MessageBox.Show("Successfully updated Item.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    searchComboBox.Text = "Itemcode";
                                    searchTxtBox.Text = "";
                                    searchTxtBox.Text = textBox2.Text.Trim();
                                    disableAddControls();
                                }
                                else if (dialog == DialogResult.No)
                                {
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please select 'Item Status'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                comboBox4.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please fill up 'Item Category1'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox7.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please fill up 'Item PPU'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox6.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please fill up 'Item Description'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Focus();
                }
            }
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

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
