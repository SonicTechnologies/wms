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

namespace wms.Forms.Warehouse_Management.Stock_Receiving_Plan
{
    public partial class SRP_Item_Details : Form
    {
        private wmsdb obj;
        public static string vanNo;
        public static string category;

        private static string x_vanNo
        {
            get { return vanNo; }
            set { vanNo = value; }
        }

        private static string x_category
        {
            get { return category; }
            set { category = value; }
        }

        public SRP_Item_Details()
        {
            InitializeComponent();
        }

        private void getItems()
        {
            textBox1.Text = vanNo;
            textBox2.Text = category;
            wmsdb obj = new wmsdb();
            var itemlist = (from c in obj.WMS_MSTR_DVMR                      
                            join s in obj.WMS_MSTR_INVTY on c.invty_id equals s.invty_id
                            where c.dvmr_cvan == vanNo && c.dvmr_category == category
                            group c by new { c.invty_id, s.invty_desc, c.dvmr_category} into z
                            select new
                            {
                            z.Key.invty_id,
                            z.Key.invty_desc,
                            z.Key.dvmr_category,
                            tqty = z.Sum(d => d.dvmr_qty)

                            }).OrderBy(c => new { c.invty_desc }).ToList();

            dataGridView4.Rows.Clear();
            int tcases = 0;
            if (itemlist.Count != 0)
            {
                dataGridView4.ColumnHeadersVisible = true;
                
                foreach (var row in itemlist)
                {
                    tcases = tcases + row.tqty;
                    dataGridView4.Rows.Add(row.invty_id,row.invty_desc,row.dvmr_category,row.tqty);

                }
                
            }
            else
            {
                dataGridView4.ColumnHeadersVisible = false;
            }
            textBox3.Text = tcases.ToString();
            dataGridView4.ClearSelection();
        }

        private void SRP_Item_Details_Load(object sender, EventArgs e)
        {
            getItems();
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
    }
}
