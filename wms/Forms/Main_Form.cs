using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wms.Forms.Administration.Item;
using wms.Forms.Administration.Customer;
using wms.Forms.Administration.SALESMAN;

namespace wms
{
    public partial class Main_Form : Form
    {
        public static Main_Form MainFormInstance = null;
        public Main_Form()
        {
            InitializeComponent();
        }

        public static Main_Form GetInstance()
        {
            if (Main_Form.MainFormInstance == null)
            {
                Main_Form.MainFormInstance = new Main_Form();
                Main_Form.MainFormInstance.FormClosed += new FormClosedEventHandler(MainFormInstance_FormClosed);
            }
            return Main_Form.MainFormInstance;
        }



        static void MainFormInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main_Form.MainFormInstance = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 30)
            {
                panel1.Width = 330;
                button1.Text = "<<";
            }
            else
            {
                panel1.Width = 30;
                button1.Text = ">>";
            }
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {

        }

        private void customerMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer_Maintenance cm = new Customer_Maintenance();
            cm.MdiParent = this;
            cm.Show();
        }

        private void itemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Item_Maintenance newform = new Item_Maintenance();
            newform.MdiParent = this;
            newform.Show();
        }

        private void bookingSalesmToolStripMenuItem_Click(object sender, EventArgs e)
        {
           SM_Booking booking = new SM_Booking();
            booking.MdiParent = this;
            booking.Show();

        }

        private void deliverySalesmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SM_Delivery delivery = new SM_Delivery();
            delivery.MdiParent = this;
            delivery.Show();
        }
    }
}
