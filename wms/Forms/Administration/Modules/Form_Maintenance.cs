using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wms.Forms.Administration.Modules
{
    public partial class Form_Maintenance : Form
    {

        public Form_Maintenance()
        {
            InitializeComponent();
        }

        private void Form_Maintenance_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_List fl = new Form_List();
            fl.Show();
        }
    }
}
