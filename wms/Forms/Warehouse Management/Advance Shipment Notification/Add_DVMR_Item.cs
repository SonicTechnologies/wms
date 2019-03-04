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

namespace wms.Forms.Warehouse_Management.Advance_Shipment_Notification
{
    public partial class Add_DVMR_Item : Form
    {
     
        wmsdb obj = new wmsdb();
        public Add_DVMR_Item()
        { 
            InitializeComponent();
          
        }

        private void Add_DVMR_Item_Load(object sender, EventArgs e)
        {
            Main_Form.GetInstance().Enabled = false;
            searchUser();



        }

        public void getDetails()
        {
            DVMR_Data dvmr = new DVMR_Data();

          
        }

        private void Add_DVMR_Item_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main_Form.GetInstance().Enabled = true;
        }


        public void searchUser()
        {
            textBox3.Focus();
            if (comboBox1.Text == "Inventory ID")
            {
                var invtyID = textBox3.Text.Trim();
                var invty = (from c in obj.WMS_MSTR_INVTY

                             where c.invty_id == (invtyID) && c.stat_id == 1
                             select new
                             {
                                 c.invty_id,
                                 c.invty_desc,
                                 c.invty_cat1,
                                 c.invty_cat2,
                                 c.invty_cat3,
                                 c.invty_cat4,
                                 c.invty_brand,


                             }).OrderBy(c => new { c.invty_id }).ToList();

                dataGridView4.Rows.Clear();

                if (invty.Count != 0)
                {
                    dataGridView4.ColumnHeadersVisible = true;
                    foreach (var row in invty)
                    {

                        dataGridView4.Rows.Add(
                                 row.invty_id,
                                 row.invty_desc,
                                 row.invty_cat1,
                                 row.invty_cat2,
                                 row.invty_cat3,
                                 row.invty_cat4,
                                 row.invty_brand
                                    );
                    }
                }
                else
                {
                    dataGridView4.ColumnHeadersVisible = false;
                }
            }

            else if (comboBox1.Text == "Inventory Description")
            {
                var invtyDesc = textBox3.Text.Trim();
                var invty1 = (from c in obj.WMS_MSTR_INVTY

                              where  c.invty_desc == (invtyDesc) && c.stat_id == 1
                              select new
                              {
                                  c.invty_id,
                                  c.invty_desc,
                                  c.invty_cat1,
                                  c.invty_cat2,
                                  c.invty_cat3,
                                  c.invty_cat4,
                                  c.invty_brand,


                              }).OrderBy(c => new { c.invty_id }).ToList();

                dataGridView4.Rows.Clear();

                if (invty1.Count != 0)
                {
                    dataGridView4.ColumnHeadersVisible = true;
                    foreach (var row in invty1)
                    {

                        dataGridView4.Rows.Add(
                                 row.invty_id,
                                 row.invty_desc,
                                 row.invty_cat1,
                                 row.invty_cat2,
                                 row.invty_cat3,
                                 row.invty_cat4,
                                 row.invty_brand
                                    );
                    }
                }
                else
                {
                    dataGridView4.ColumnHeadersVisible = false;
                }


            }
            else if (comboBox1.Text == "ALL" && textBox3.Text=="")
            {
                var invtyDesc = textBox3.Text.Trim();
                var invty2 = (from c in obj.WMS_MSTR_INVTY

                              where  c.stat_id == 1
                              select new
                              {
                                  c.invty_id,
                                  c.invty_desc,
                                  c.invty_cat1,
                                  c.invty_cat2,
                                  c.invty_cat3,
                                  c.invty_cat4,
                                  c.invty_brand,


                              }).OrderBy(c => new { c.invty_id }).ToList();

                dataGridView4.Rows.Clear();

                if (invty2.Count != 0)
                {
                    dataGridView4.ColumnHeadersVisible = true;
                    foreach (var row in invty2)
                    {

                        dataGridView4.Rows.Add(
                                 row.invty_id,
                                 row.invty_desc,
                                 row.invty_cat1,
                                 row.invty_cat2,
                                 row.invty_cat3,
                                 row.invty_cat4,
                                 row.invty_brand
                                    );
                    }
                }
                else
                {
                    dataGridView4.ColumnHeadersVisible = false;
                }
            }

          
            else
            {
    


            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            searchUser();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchUser();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox13.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView4.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView4.CurrentRow.Cells[5].Value.ToString();
            textBox8.Text = dataGridView4.CurrentRow.Cells[6].Value.ToString();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("Please fill in the empty box", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                var invtyID = textBox13.Text.Trim();

                var invty1 = (from c in obj.WMS_MSTR_DVMR

                              where c.dvmr_billdoc == DVMR_Data.BillDoc && c.invty_id == invtyID
                              select c).ToList();

                if (invty1.Count > 0)
                {
                    MessageBox.Show("Item Already Existed ! ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            else
                { 
                DialogResult dialog = MessageBox.Show("Are you sure you want to Add " + textBox13.Text + "?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                 

                        var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                        DateTime serverDate = dateQuery.AsEnumerable().First();

                        var dvmr = obj.Set<WMS_MSTR_DVMR>();
                        dvmr.Add(new WMS_MSTR_DVMR
                        {
                            dvmr_load_date = Convert.ToDateTime(DVMR_Data.LoadDate),
                            site_code = DVMR_Data.SiteCode,
                            dvmr_customer = DVMR_Data.Customer,
                            dvmr_rdd = Convert.ToDateTime(DVMR_Data.RDD),
                            dvmr_shipment = DVMR_Data.Shipment,
                            dvmr_shipping_line = DVMR_Data.ShippingLine,
                            dvmr_truck_no = DVMR_Data.TruckNo,
                            dvmr_cvan = DVMR_Data.Cvan,
                            dvmr_salesdoc = DVMR_Data.SalesDoc,
                            dvmr_po_number = DVMR_Data.PoNo,
                            dvmr_billdoc = DVMR_Data.BillDoc,
                            dvmr_category = textBox5.Text,
                            invty_id = textBox13.Text,
                            dvmr_qty = Convert.ToInt32(textBox9.Text),
                            dvmr_date_added = serverDate,



                        });
                        obj.SaveChanges();
                        MessageBox.Show("Successfully saved Inventory  :" + textBox13.Text + "\n" + textBox2.Text + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var uaf = Application.OpenForms.OfType<DVMR_Data>().Single();
                        uaf.searchItem();
                     
                    
                }
                else
                {

                }

                }
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb != null)
            {
                tb.BackColor = System.Drawing.SystemColors.Info;
            }
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {

            var tb = sender as TextBox;
            if (tb != null)
            {
                tb.BackColor = Color.Orange;
            }
        }
    }
}
 