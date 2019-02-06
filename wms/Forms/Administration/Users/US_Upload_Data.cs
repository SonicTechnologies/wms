using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wms.Entity_Class;

namespace wms.Forms.Administration.Users
{
    public partial class US_Upload_Data : Form
    {
        public US_Upload_Data()
        {
            InitializeComponent();
        }

        OleDbCommand cmd1 = new OleDbCommand();
        OleDbConnection con1 = new OleDbConnection();

        DataTable dt1 = new DataTable();
        OleDbDataAdapter adapt1 = new OleDbDataAdapter();
 
        wmsdb obj = new wmsdb();

        string strConnectionString;

        int max;

        int TranCounter1;

        int inserted;

        int updated;

        private void US_Upload_Data_Load(object sender, EventArgs e)
        {
            Main_Form.GetInstance().Enabled = false;
        }
    }
}
