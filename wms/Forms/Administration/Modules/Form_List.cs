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
            AcceptButton = button1;
            searchComboBox.SelectedIndex = 0;
        }

        private void ScanFormsAll()
        {
            System.Reflection.Assembly myProj = System.Reflection.Assembly.GetExecutingAssembly();
            Type[] xforms = myProj.GetTypes();

            if (xforms.Count() > 0)
            {
                foreach (Type frm in xforms)
                {
                    dataGridView1.ColumnHeadersVisible = true;
                    try
                    {
                        if (frm.BaseType.ToString().ToUpper() == "SYSTEM.WINDOWS.FORMS.FORM")
                        {
                            dataGridView1.Rows.Add(frm.Name,frm.Namespace.ToUpper(),"Choose");
                        }
                        else
                        {

                        }
                    }
                    catch
                    {

                    }
                    

                }
            }
            else
            {
                dataGridView1.ColumnHeadersVisible = false;
            }
            dataGridView1.Focus();
        }

        private void ScanFormsFormName()
        {
            dataGridView1.Rows.Clear();
            System.Reflection.Assembly myProj = System.Reflection.Assembly.GetExecutingAssembly();
            Type[] xforms = myProj.GetTypes();

            if (xforms.Count() > 0)
            {
                foreach (Type frm in xforms)
                {
                    dataGridView1.ColumnHeadersVisible = true;
                    try
                    {
                        if (frm.BaseType.ToString().ToUpper() == "SYSTEM.WINDOWS.FORMS.FORM")
                        {
                            if (frm.Name.ToLower().Contains(textBox2.Text.ToLower()))
                            {
                                dataGridView1.Rows.Add(frm.Name, frm.Namespace.ToUpper(),"Choose");
                            }
                            
                        }
                        else
                        {

                        }
                    }
                    catch
                    {

                    }


                }
            }
            else
            {
                dataGridView1.ColumnHeadersVisible = false;
            }
            dataGridView1.Focus();
        }

        private void ScanFormsNamespace()
        {
            dataGridView1.Rows.Clear();
            System.Reflection.Assembly myProj = System.Reflection.Assembly.GetExecutingAssembly();
            Type[] xforms = myProj.GetTypes();

            if (xforms.Count() > 0)
            {
                foreach (Type frm in xforms)
                {
                    dataGridView1.ColumnHeadersVisible = true;
                    try
                    {
                        if (frm.BaseType.ToString().ToUpper() == "SYSTEM.WINDOWS.FORMS.FORM")
                        {
                            if (frm.Namespace.ToLower().Contains(textBox2.Text.ToLower()))
                            {
                                dataGridView1.Rows.Add(frm.Name, frm.Namespace.ToUpper(),"Choose");
                            }

                        }
                        else
                        {

                        }
                    }
                    catch
                    {

                    }


                }
            }
            else
            {
                dataGridView1.ColumnHeadersVisible = false;
            }
            dataGridView1.Focus();
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb != null)
            {
                tb.BackColor = Color.Orange;
            }

            AcceptButton = button1;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb != null)
            {
                tb.BackColor = System.Drawing.SystemColors.Info;
            }
        }

        private void searchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchComboBox.Text == "All")
            {
                textBox2.Enabled = false;
                button1.Enabled = false;
                ScanFormsAll();
            }
            else
            {
                textBox2.Enabled = true;
                textBox2.Focus();
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (searchComboBox.Text == "Form Name")
            {
                ScanFormsFormName();
            }
            else if (searchComboBox.Text == "Namespace")
            {
                ScanFormsNamespace();
            }
            else
            {

            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            var dgv = sender as DataGridView;

            if (e.ColumnIndex == 2)
            {
                var mm = Application.OpenForms.OfType<Module_Maintenance>().Single();
                mm.placeFormName(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                this.Close();            
            }
            else
            {

            }
  
        }

        private void Form_List_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                var mm = Application.OpenForms.OfType<Module_Maintenance>().Single();
                mm.placeFormName(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                this.Close();
            }
            else
            {

            }
        }
    }
}
