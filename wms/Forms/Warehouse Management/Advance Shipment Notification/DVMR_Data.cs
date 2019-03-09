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
    public partial class DVMR_Data : Form
    {
        wmsdb obj = new wmsdb();
        public DVMR_Data()
        {
            InitializeComponent();
        }
        public static string BillDoc = "";
        public static string LoadDate = "";
        public static string SiteCode = "";
        public static string SiteName = "";
        public static string Customer = "";
        public static string RDD = "";
        public static string Shipment = "";
        public static string ShippingLine = "";
        public static string TruckNo = "";
        public static string Cvan = "";
        public static string SalesDoc = "";
        public static string PoNo = "";
        public static string Category = "";
        public static string Invty = "";
        public static string Desc = "";
        public static string Qty = "";
        public static DateTime? scheduleDate ;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {


        }

        public void ClearItems()
        {
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox1.Text = "";
            textBox15.Text = "";
            label19.Text = "";
            textBox13.Text = "";
            textBox12.Text = "";
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Rows.Clear();
        }
        public void searchItem()
        {
            if (textBox2.Text.Trim() == "")
            {
                ClearItems();
            }
            else
            {              
                    var dvmr = textBox2.Text.Trim();

                    var xdvmr = (from c in obj.WMS_MSTR_DVMR
                                 join d in obj.WMS_MSTR_SITE on c.site_code equals d.site_code
                                 where c.dvmr_billdoc == dvmr
                                 select new
                                 {
                                     c.dvmr_load_date,
                                     c.site_code,       
                                     c.dvmr_customer,
                                     c.dvmr_rdd,
                                     c.dvmr_shipment,
                                     c.dvmr_shipping_line,
                                     c.dvmr_truck_no,
                                     c.dvmr_cvan,
                                     c.dvmr_salesdoc,
                                     c.dvmr_po_number,
                                     c.dvmr_category,
                                     c.invty_id,
                                     c.dvmr_qty,
                                     c.dvmr_date_added,
                                     d.site_name,
                                     c.dvmr_schedule_date
                                 
                                 }).OrderBy(c => new { c.dvmr_load_date }).Distinct().ToList();     

                    if (xdvmr.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in xdvmr)
                        {

                        textBox3.Text = row.dvmr_load_date.ToString("MM-dd-yyyy");
                        textBox4.Text = row.site_name;
                        textBox12.Text = row.site_code;
                        textBox5.Text = row.dvmr_customer;
                        textBox6.Text = row.dvmr_rdd.ToString("MM-dd-yyyy");
                        textBox13.Text = row.dvmr_schedule_date?.ToString("MM-dd-yyyy") ?? "";
                        textBox7.Text = row.dvmr_shipment;
                        textBox8.Text = row.dvmr_shipping_line;
                        textBox9.Text = row.dvmr_truck_no;
                        textBox10.Text = row.dvmr_cvan;
                        textBox11.Text = row.dvmr_salesdoc;
                        textBox1.Text = row.dvmr_po_number;
                        textBox15.Text = row.dvmr_category;
                       


                         }

                    }


                var xdvmrDGV = (from c in obj.WMS_MSTR_DVMR
                                join d in obj.WMS_MSTR_INVTY on c.invty_id equals d.invty_id
                                join b in obj.WMS_TYPE_UOM on c.uom_id equals b.uom_id
                                 where c.dvmr_billdoc == dvmr
                             select new
                             {
                                 c.dvmr_load_date,
                                 c.site_code,
                                 c.dvmr_customer,
                                 c.dvmr_rdd,
                                 c.dvmr_shipment,
                                 c.dvmr_shipping_line,
                                 c.dvmr_truck_no,
                                 c.dvmr_cvan,
                                 c.dvmr_salesdoc,
                                 c.dvmr_po_number,
                                 c.dvmr_category,
                                 c.invty_id,
                                 c.dvmr_qty,
                                 c.dvmr_date_added,
                                 d.invty_desc,
                                 c.dvmr_schedule_date,
                                 b.uom_desc,
                             }).OrderBy(c => new { c.dvmr_load_date }).ToList();
                dataGridView1.Rows.Clear();
                if (xdvmrDGV.Count != 0)
                {
                    dataGridView1.ColumnHeadersVisible = true;
                    foreach (var row in xdvmrDGV)
                    {

                        dataGridView1.Rows.Add(row.invty_id,
                                            row.invty_desc,
                                            row.dvmr_qty,
                                            row.uom_desc,
                                          row.dvmr_schedule_date?.ToString("MM-dd-yyyy") ?? ""
                                          );

                    }
                    

                    label19.Text = dataGridView1.Rows.Count.ToString();
                }
             


            }
     
        }
      


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            searchItem();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Provide Bill Doc to Add Item(s)", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBox7.Text=="")
            {
                MessageBox.Show("Bill Doc is not existed in Database", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SetData();

                DVMR_Add_Item upload = new DVMR_Add_Item();
                upload.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {

                DialogResult dialog = MessageBox.Show("Are you sure you want to remove " + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {

                    DeleteInvty();
                    searchItem();
                }
                else
                {

                }


            }

            if (e.ColumnIndex == 5)
            {
                SetData();
                DVMR_Add_Qty aq = new DVMR_Add_Qty();
                aq.Show();
            }
        }

        private void DeleteInvty()
        {
           
            string invty = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string billdoc = textBox2.Text.ToString();

            obj.WMS_MSTR_DVMR.RemoveRange(from dvmr in obj.WMS_MSTR_DVMR
                                           where dvmr.invty_id == invty && dvmr.dvmr_billdoc == billdoc
                                           select dvmr);


            obj.SaveChanges();

            MessageBox.Show("Successfully removed " + dataGridView1.CurrentRow.Cells[0].Value.ToString() + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        public void SetData()
        {
            getData();
            if (BillDoc == "")
            {
                MessageBox.Show("Provide Bill Doc to add Item(s)","", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                getData();
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb != null)
            {
                tb.BackColor = Color.Orange;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb != null)
            {
                tb.BackColor = System.Drawing.SystemColors.Info;
            }
        }

        public void getData()
        {
            BillDoc = textBox2.Text;
            LoadDate = textBox3.Text;
            SiteName = textBox4.Text;
            SiteCode = textBox12.Text;
            Customer = textBox5.Text;
            RDD = textBox6.Text;
            Shipment = textBox7.Text;
            ShippingLine = textBox8.Text;
            TruckNo = textBox9.Text;
            Cvan = textBox10.Text;
            SalesDoc = textBox11.Text;
            PoNo = textBox1.Text;
            Category = textBox15.Text;
            Invty = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Desc = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            if (textBox13.Text == "")
            {
                   scheduleDate = null;
    }
            else
            {

                scheduleDate = Convert.ToDateTime(textBox13.Text.ToString());
            }
        }

        private void uploadBtn_Click_1(object sender, EventArgs e)
        {
            Dvmr_Uploading_Data upload = new Dvmr_Uploading_Data();
            upload.Show();
        }

    

        private void button2_Click_1(object sender, EventArgs e)
        {
            ClearItems();
            textBox2.Text = "";
        }

        private void DVMR_Data_Load(object sender, EventArgs e)
        {

        }
    }
}
