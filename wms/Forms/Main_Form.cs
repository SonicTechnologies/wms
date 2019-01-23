using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wms.Forms.Administration.Modules;
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

        private void formMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            Form_Maintenance fm = new Form_Maintenance();
            fm.MdiParent = this;
            fm.Show();
        }
    }
}
