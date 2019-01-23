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
    public partial class Form_List : Form
    {
        public Form_List()
        {
            InitializeComponent();
        }

        private void Form_List_Load(object sender, EventArgs e)
        {
            ScanForms();
        }

        private void ScanForms()
        {
            System.Reflection.Assembly myProj = System.Reflection.Assembly.GetExecutingAssembly();
            Type[] xforms = myProj.GetTypes();

            if (xforms.Count() > 0)
            {
                foreach (Type frm in xforms)
                {
                    dataGridView1.ColumnHeadersVisible = true;
                    if (frm.BaseType.ToString().ToUpper() == "SYSTEM.WINDOWS.FORMS.FORM")
                    {                      
                        dataGridView1.Rows.Add(frm.Name);
                    }
                    else
                    {

                    }

                }
            }
            else
            {
                dataGridView1.ColumnHeadersVisible = false;
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
