using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wms.Forms.Administration.Customer;
using wms.Forms.Administration.SALESMAN;
using wms.Forms.Administration.SITE;

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

            Form xcm = Application.OpenForms[cm.Name];
            if (xcm != null)
            {

            }
            else
            {
                cm.MdiParent = this;
                cm.Show();
            }
        }

        private void siteMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Site_Maintenance stm = new Site_Maintenance();

            Form xstm = Application.OpenForms[stm.Name];
            if (xstm != null)
            {

            }
            else
            {
                stm.MdiParent = this;
                stm.Show();
            }
        }

        private void bookingSalesmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SM_Booking smb = new SM_Booking();

            Form xsmb = Application.OpenForms[smb.Name];
            if (xsmb != null)
            {

            }
            else
            {
                smb.MdiParent = this;
                smb.Show();
            }
        }

        private void deliverySalesmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SM_Delivery smd = new SM_Delivery();

            Form xsmd = Application.OpenForms[smd.Name];
            if (xsmd != null)
            {

            }
            else
            {
                smd.MdiParent = this;
                smd.Show();
            }
        }
    }
}
