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
    public partial class DVMR_Add_Qty : Form
    {
        wmsdb obj = new wmsdb();
        public DVMR_Add_Qty()
        {
            InitializeComponent();
        }

 

        private void Add_Qty_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main_Form.GetInstance().Enabled = true;
        }

        private void Add_Qty_Load(object sender, EventArgs e)
        {
            GetData();
            getUnit();
            Main_Form.GetInstance().Enabled = false;
        }

        public void GetData()

        {
            textBox2.Text = DVMR_Data.Invty;
            textBox3.Text = DVMR_Data.Desc;

        }

        private void textBox4_Enter(object sender, EventArgs e)
        {

            var tb = sender as TextBox;
            if (tb != null)
            {
                tb.BackColor = Color.Orange;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb != null)
            {
                tb.BackColor = System.Drawing.SystemColors.Info;
            }
        }
        private void getUnit()
        {
            comboBox1.ValueMember = "uom_id";
            comboBox1.DisplayMember = "uom_desc";
            comboBox1.DataSource = obj.WMS_TYPE_UOM.ToList();

        }
        private void saveBtn_Click_1(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Input Quantity", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if( textBox4.Text =="0")
            {
                MessageBox.Show("Cannot input 0 quantity", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Are you sure you want to update the quantity of " + textBox2.Text + "\n " + textBox3.Text + "?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    var result = obj.WMS_MSTR_DVMR.SingleOrDefault(b => b.dvmr_billdoc == DVMR_Data.BillDoc && b.invty_id == DVMR_Data.Invty);


                    if (result != null)
                    {

                        result.dvmr_qty = Convert.ToInt32(textBox4.Text);
                        result.uom_id =Convert.ToInt32( comboBox1.SelectedValue);
                        obj.SaveChanges();

                        var uaf = Application.OpenForms.OfType<DVMR_Data>().Single();
                        uaf.searchItem();


                    }

                }
            }
        }
    }
}
