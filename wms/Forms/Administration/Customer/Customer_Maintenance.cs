using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wms.Class;
using wms.Entity_Class;

namespace wms.Forms.Administration.Customer
{
    public partial class Customer_Maintenance : Form
    {

        wmsdb obj = new wmsdb(); 
        public Customer_Maintenance()
        {
            InitializeComponent();
        }
        public void getSalesman()
        {
            var salesman = (from c in obj.WMS_SLSMAN_VIEW
                            where c.salesman_type_id == 1
                            select new
                            {
                                c.salesman_id,
                                c.salesman_name,

                            }).OrderBy(c => new { c.salesman_id }).ToList();

            comboBox2.Items.Clear();

            if (salesman.Count != 0)
            {

                foreach (var row in salesman)
                {

                    comboBox2.Items.Add(row.salesman_id);

                }
                comboBox2.SelectedIndex = -1;
            }
            else
            {

            }
        }

        public void getStatus()
        {
            var status = (from c in obj.WMS_TYPE_STAT
                          select new
                          {
                              c.stat_id,
                              c.stat_desc,

                          }).OrderBy(c => new { c.stat_desc }).ToList();

            comboBox4.Items.Clear();

            if (status.Count != 0)
            {

                foreach (var row in status)
                {

                    comboBox4.Items.Add(row.stat_desc);

                }
                comboBox4.SelectedIndex = -1;
            }
            else
            {

            }
        }
        public void getSite()
        {
            var sites = (from c in obj.WMS_MSTR_SITE

                         select new
                         {
                             c.site_id,
                             c.site_name,

                         }).OrderBy(c => new { c.site_id }).ToList();

            comboBox3.Items.Clear();

            if (sites.Count != 0)
            {

                foreach (var row in sites)
                {

                    comboBox3.Items.Add(row.site_id);

                }
                comboBox3.SelectedIndex = -1;
            }
            else
            {

            }
        }
        private void Customer_Maintenance_Load(object sender, EventArgs e)
        {
            getSalesman();
            getSite();
            getStatus();
        }

        public string SalesmanName(string slsmancode)
        {
            string xslamanname;
            var cc = (from c in obj.WMS_SLSMAN_VIEW
                      where c.salesman_id == slsmancode
                      select new { c.salesman_name }).FirstOrDefault();
            if (cc == null)
            {

                xslamanname = null;

            }
            else
            {
                xslamanname = cc.salesman_name;

            }
            return xslamanname;
        }

        public string SiteName(string siteid)
        {
            string xsitename;
            var cc = (from c in obj.WMS_MSTR_SITE
                      where c.site_id == siteid
                      select new { c.site_name }).FirstOrDefault();
            if (cc == null)
            {

                xsitename = null;

            }
            else
            {
                xsitename = cc.site_name;

            }
            return xsitename;
        }

        public void GetCustomers()
        {
            var customers = (from c in obj.WMS_CUST_VIEW
                             select new
                             {
                                 c.cust_id,
                                 c.cust_name,
                                 c.cust_address,
                                 c.salesman_id,
                                 c.salesman_name,
                                 c.site_id,
                                 c.site_name,
                                 c.cust_latitude,
                                 c.cust_longitude,
                                 c.stat_id,
                                 c.stat_desc,
                                 c.cust_datecrtd,
                                 c.crtdby,
                                 c.cust_dateuptd,
                                 c.uptdby

                             }).OrderBy(c => new { c.cust_name }).ToList();

            dataGridView1.Rows.Clear();

            if (customers.Count != 0)
            {
                dataGridView1.ColumnHeadersVisible = true;
                foreach (var row in customers)
                {

                    dataGridView1.Rows.Add(row.cust_id,
                                           row.cust_name,
                                           row.cust_address,
                                           row.salesman_id,
                                           row.salesman_name,
                                           row.site_id,
                                           row.site_name,
                                           row.stat_desc,
                                           row.cust_latitude,
                                           row.cust_longitude,
                                           row.cust_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.crtdby,
                                           row.cust_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.uptdby);

                }
            }
            else
            {
                dataGridView1.ColumnHeadersVisible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "All" && textBox1.Text.Trim() == "")
            {
                GetCustomers();
            }
            else
            {
                if (comboBox1.Text == "" && textBox1.Text.Trim() != "")
                {

                }
                else
                {
                    searchCust();
                }

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchCust();
        }



        public void searchCust()
        {
            if (textBox1.Text.Trim() == "")
            {
                dataGridView1.ColumnHeadersVisible = false;
                dataGridView1.Rows.Clear();
            }
            else
            {

                if (comboBox1.Text == "Customer ID")
                {
                    var custid = textBox1.Text.Trim();
                    var customers = (from c in obj.WMS_CUST_VIEW
                                     where c.cust_id == custid
                                     select new
                                     {
                                         c.cust_id,
                                         c.cust_name,
                                         c.cust_address,
                                         c.salesman_id,
                                         c.salesman_name,
                                         c.site_id,
                                         c.site_name,
                                         c.cust_latitude,
                                         c.cust_longitude,
                                         c.stat_id,
                                         c.stat_desc,
                                         c.cust_datecrtd,
                                         c.crtdby,
                                         c.cust_dateuptd,
                                         c.uptdby

                                     }).OrderBy(c => new { c.cust_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (customers.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in customers)
                        {

                            dataGridView1.Rows.Add(row.cust_id,
                                           row.cust_name,
                                           row.cust_address,
                                           row.salesman_id,
                                           row.salesman_name,
                                           row.site_id,
                                           row.site_name,
                                           row.stat_desc,
                                           row.cust_latitude,
                                           row.cust_longitude,
                                           row.cust_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.crtdby,
                                           row.cust_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.uptdby);

                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }

                }
                else if (comboBox1.Text == "Customer Name")
                {
                    var custname = textBox1.Text.Trim();
                    var customers = (from c in obj.WMS_CUST_VIEW
                                     where c.cust_name.StartsWith(custname)
                                     select new
                                     {
                                         c.cust_id,
                                         c.cust_name,
                                         c.cust_address,
                                         c.salesman_id,
                                         c.salesman_name,
                                         c.site_id,
                                         c.site_name,
                                         c.cust_latitude,
                                         c.cust_longitude,
                                         c.stat_id,
                                         c.stat_desc,
                                         c.cust_datecrtd,
                                         c.crtdby,
                                         c.cust_dateuptd,
                                         c.uptdby

                                     }).OrderBy(c => new { c.cust_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (customers.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in customers)
                        {

                            dataGridView1.Rows.Add(row.cust_id,
                                           row.cust_name,
                                           row.cust_address,
                                           row.salesman_id,
                                           row.salesman_name,
                                           row.site_id,
                                           row.site_name,
                                           row.stat_desc,
                                           row.cust_latitude,
                                           row.cust_longitude,
                                           row.cust_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.crtdby,
                                           row.cust_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.uptdby);

                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }

                }
                else if (comboBox1.Text == "Customer Address")
                {
                    var custaddress = textBox1.Text.Trim();
                    var customers = (from c in obj.WMS_CUST_VIEW
                                     where c.cust_address.Contains(custaddress)
                                     select new
                                     {
                                         c.cust_id,
                                         c.cust_name,
                                         c.cust_address,
                                         c.salesman_id,
                                         c.salesman_name,
                                         c.site_id,
                                         c.site_name,
                                         c.cust_latitude,
                                         c.cust_longitude,
                                         c.stat_id,
                                         c.stat_desc,
                                         c.cust_datecrtd,
                                         c.crtdby,
                                         c.cust_dateuptd,
                                         c.uptdby

                                     }).OrderBy(c => new { c.cust_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (customers.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in customers)
                        {

                            dataGridView1.Rows.Add(row.cust_id,
                                           row.cust_name,
                                           row.cust_address,
                                           row.salesman_id,
                                           row.salesman_name,
                                           row.site_id,
                                           row.site_name,
                                           row.stat_desc,
                                           row.cust_latitude,
                                           row.cust_longitude,
                                           row.cust_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.crtdby,
                                           row.cust_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.uptdby);

                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }

                }
                else if (comboBox1.Text == "Salesman ID")
                {
                    var slsmanid = textBox1.Text.Trim();
                    var customers = (from c in obj.WMS_CUST_VIEW
                                     where c.salesman_id == slsmanid
                                     select new
                                     {
                                         c.cust_id,
                                         c.cust_name,
                                         c.cust_address,
                                         c.salesman_id,
                                         c.salesman_name,
                                         c.site_id,
                                         c.site_name,
                                         c.cust_latitude,
                                         c.cust_longitude,
                                         c.stat_id,
                                         c.stat_desc,
                                         c.cust_datecrtd,
                                         c.crtdby,
                                         c.cust_dateuptd,
                                         c.uptdby

                                     }).OrderBy(c => new { c.cust_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (customers.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in customers)
                        {

                            dataGridView1.Rows.Add(row.cust_id,
                                           row.cust_name,
                                           row.cust_address,
                                           row.salesman_id,
                                           row.salesman_name,
                                           row.site_id,
                                           row.site_name,
                                           row.stat_desc,
                                           row.cust_latitude,
                                           row.cust_longitude,
                                           row.cust_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.crtdby,
                                           row.cust_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.uptdby);
                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }

                }
                else if (comboBox1.Text == "Salesman Name")
                {
                    var slsmanname = textBox1.Text.Trim();
                    var customers = (from c in obj.WMS_CUST_VIEW
                                     where c.salesman_name.Contains(slsmanname)
                                     select new
                                     {
                                         c.cust_id,
                                         c.cust_name,
                                         c.cust_address,
                                         c.salesman_id,
                                         c.salesman_name,
                                         c.site_id,
                                         c.site_name,
                                         c.cust_latitude,
                                         c.cust_longitude,
                                         c.stat_id,
                                         c.stat_desc,
                                         c.cust_datecrtd,
                                         c.crtdby,
                                         c.cust_dateuptd,
                                         c.uptdby

                                     }).OrderBy(c => new { c.cust_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (customers.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in customers)
                        {

                            dataGridView1.Rows.Add(row.cust_id,
                                           row.cust_name,
                                           row.cust_address,
                                           row.salesman_id,
                                           row.salesman_name,
                                           row.site_id,
                                           row.site_name,
                                           row.stat_desc,
                                           row.cust_latitude,
                                           row.cust_longitude,
                                           row.cust_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.crtdby,
                                           row.cust_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.uptdby);
                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }

                }
                else if (comboBox1.Text == "Site ID")
                {
                    var siteid = textBox1.Text.Trim();
                    var customers = (from c in obj.WMS_CUST_VIEW
                                     where c.site_id == siteid
                                     select new
                                     {
                                         c.cust_id,
                                         c.cust_name,
                                         c.cust_address,
                                         c.salesman_id,
                                         c.salesman_name,
                                         c.site_id,
                                         c.site_name,
                                         c.cust_latitude,
                                         c.cust_longitude,
                                         c.stat_id,
                                         c.stat_desc,
                                         c.cust_datecrtd,
                                         c.crtdby,
                                         c.cust_dateuptd,
                                         c.uptdby

                                     }).OrderBy(c => new { c.cust_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (customers.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in customers)
                        {

                            dataGridView1.Rows.Add(row.cust_id,
                                           row.cust_name,
                                           row.cust_address,
                                           row.salesman_id,
                                           row.salesman_name,
                                           row.site_id,
                                           row.site_name,
                                           row.stat_desc,
                                           row.cust_latitude,
                                           row.cust_longitude,
                                           row.cust_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.crtdby,
                                           row.cust_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.uptdby);
                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }

                }
                else if (comboBox1.Text == "Site Name")
                {
                    var sitename = textBox1.Text.Trim();
                    var customers = (from c in obj.WMS_CUST_VIEW
                                     where c.site_name.Contains(sitename)
                                     select new
                                     {
                                         c.cust_id,
                                         c.cust_name,
                                         c.cust_address,
                                         c.salesman_id,
                                         c.salesman_name,
                                         c.site_id,
                                         c.site_name,
                                         c.cust_latitude,
                                         c.cust_longitude,
                                         c.stat_id,
                                         c.stat_desc,
                                         c.cust_datecrtd,
                                         c.crtdby,
                                         c.cust_dateuptd,
                                         c.uptdby

                                     }).OrderBy(c => new { c.cust_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (customers.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in customers)
                        {

                            dataGridView1.Rows.Add(row.cust_id,
                                           row.cust_name,
                                           row.cust_address,
                                           row.salesman_id,
                                           row.salesman_name,
                                           row.site_id,
                                           row.site_name,
                                           row.stat_desc,
                                           row.cust_latitude,
                                           row.cust_longitude,
                                           row.cust_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.crtdby,
                                           row.cust_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.uptdby);
                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }

                }
                else if (comboBox1.Text == "Customer Status")
                {
                    var status = textBox1.Text.Trim();
                    var customers = (from c in obj.WMS_CUST_VIEW
                                     where c.stat_desc == status
                                     select new
                                     {
                                         c.cust_id,
                                         c.cust_name,
                                         c.cust_address,
                                         c.salesman_id,
                                         c.salesman_name,
                                         c.site_id,
                                         c.site_name,
                                         c.cust_latitude,
                                         c.cust_longitude,
                                         c.stat_id,
                                         c.stat_desc,
                                         c.cust_datecrtd,
                                         c.crtdby,
                                         c.cust_dateuptd,
                                         c.uptdby

                                     }).OrderBy(c => new { c.cust_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (customers.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in customers)
                        {

                            dataGridView1.Rows.Add(row.cust_id,
                                           row.cust_name,
                                           row.cust_address,
                                           row.salesman_id,
                                           row.salesman_name,
                                           row.site_id,
                                           row.site_name,
                                           row.stat_desc,
                                           row.cust_latitude,
                                           row.cust_longitude,
                                           row.cust_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.crtdby,
                                           row.cust_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.uptdby);
                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }

                }
                else
                {

                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "All")
            {
                textBox1.Text = "";
                textBox1.Enabled = false;
                GetCustomers();
            }
            else
            {
                textBox1.Enabled = true;
            }
        }



        public void enableAddControls()
        {

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox2.SelectedIndex = -1;
            textBox5.Text = "";
            comboBox3.SelectedIndex = -1;
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox4.SelectedIndex = -1;
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";

            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            comboBox4.Enabled = true;
            panel77.Visible = true;

        }

        public void disableAddControls()
        {

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox2.SelectedIndex = -1;
            textBox5.Text = "";
            comboBox3.SelectedIndex = -1;
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox4.SelectedIndex = -1;
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";

            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            comboBox4.Enabled = false;
            panel77.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button4.Text = "Save";
            enableAddControls();
            textBox2.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            disableAddControls();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CM_Upload_Data cmup = new CM_Upload_Data();
            cmup.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button4.Text = "Update";
            enableAddControls();
            textBox2.Enabled = false;
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            comboBox4.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

            textBox9.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();

            if (Convert.ToString(dataGridView1.CurrentRow.Cells[12].Value) == string.Empty)
            {
                textBox11.Text = "";
            }
            else
            {
                textBox11.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            }

            if (Convert.ToString(dataGridView1.CurrentRow.Cells[13].Value) == string.Empty)
            {
                textBox12.Text = "";
            }
            else
            {
                textBox12.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox5.Text = SalesmanName(comboBox2.Text);
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox6.Text = SiteName(comboBox3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (button4.Text == "Save")
            {
                if (textBox2.Text.Trim() != "")
                {
                    if (textBox3.Text.Trim() != "")
                    {
                        if (textBox4.Text.Trim() != "")
                        {
                            if (comboBox2.Text != "")
                            {
                                if (comboBox3.Text != "")
                                {
                                    if (comboBox4.Text != "")
                                    {
                                        DialogResult dialog = MessageBox.Show("Are you sure you want to save Customer?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (dialog == DialogResult.Yes)
                                        {
                                            Double xlat = 0;
                                            Double xlong = 0;

                                            if (textBox7.Text.Trim() != "")
                                            {
                                                xlat = Convert.ToDouble(textBox7.Text);
                                            }
                                            if (textBox8.Text.Trim() != "")
                                            {
                                                xlong = Convert.ToDouble(textBox8.Text);
                                            }

                                            string xstatdesc = comboBox4.Text;
                                            int xstatid = 1;
                                            var statid = (from c in obj.WMS_TYPE_STAT
                                                          where c.stat_desc == xstatdesc
                                                          select c.stat_id).FirstOrDefault();

                                            xstatid = statid;

                                            var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                                            DateTime serverDate = dateQuery.AsEnumerable().First();

                                            var cust = (from c in obj.WMS_CUST_VIEW
                                                        where c.cust_id == textBox2.Text.Trim()
                                                        select c.cust_id).FirstOrDefault();
                                            if (cust == null)
                                            {
                                                var customer = obj.Set<WMS_MSTR_CUST>();
                                                customer.Add(new WMS_MSTR_CUST
                                                {
                                                    cust_id = textBox2.Text.Trim(),
                                                    cust_name = textBox3.Text.Trim(),
                                                    cust_address = textBox4.Text.Trim(),
                                                    salesman_id = comboBox2.Text,
                                                    site_id = comboBox3.Text,
                                                    cust_latitude = xlat,
                                                    cust_longitude = xlong,
                                                    stat_id = xstatid,
                                                    cust_datecrtd = serverDate,
                                                    cust_crtdby = loggedin_user.userId

                                                });
                                                obj.SaveChanges();
                                                MessageBox.Show("Successfully saved Customer.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                comboBox1.Text = "Customer ID";
                                                textBox1.Text = textBox2.Text.Trim();
                                                disableAddControls();


                                            }
                                            else
                                            {
                                                MessageBox.Show("'Customer ID' already exist.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                comboBox1.Text = "Customer ID";
                                                textBox1.Text = "";
                                                textBox1.Text = textBox2.Text.Trim();
                                            }


                                        }
                                        else if (dialog == DialogResult.No)
                                        {

                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("Please select 'Customer Status'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        comboBox4.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please select 'Customer Site'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    comboBox3.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please select 'Customer Salesman'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                comboBox2.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please fill up 'Customer Address'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox4.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please fill up 'Customer Name'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox3.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please fill up 'Customer ID'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Focus();
                }
            }
            else if (button4.Text == "Update")
            {
                if (textBox3.Text.Trim() != "")
                {

                    if (textBox4.Text.Trim() != "")
                    {
                        DialogResult dialog = MessageBox.Show("Are you sure you want to update Customer?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {

                            Double xlat = 0;
                            Double xlong = 0;

                            if (textBox7.Text.Trim() != "")
                            {
                                xlat = Convert.ToDouble(textBox7.Text);
                            }
                            if (textBox8.Text.Trim() != "")
                            {
                                xlong = Convert.ToDouble(textBox8.Text);
                            }

                            string xstatdesc = comboBox4.Text;
                            int xstatid = 1;
                            var statid = (from c in obj.WMS_TYPE_STAT
                                          where c.stat_desc == xstatdesc
                                          select c.stat_id).FirstOrDefault();

                            xstatid = statid;

                            var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                            DateTime serverDate = dateQuery.AsEnumerable().First();

                            obj.WMS_MSTR_CUST.Where(c => c.cust_id == textBox2.Text.Trim()).ToList().ForEach(x =>
                            {
                                x.cust_name = textBox3.Text.Trim();
                                x.cust_address = textBox4.Text.Trim();
                                x.salesman_id = comboBox2.Text;
                                x.site_id = comboBox3.Text;
                                x.cust_latitude = xlat;
                                x.cust_longitude = xlong;
                                x.stat_id = xstatid;
                                x.cust_dateuptd = serverDate;
                                x.cust_uptdby = loggedin_user.userId;

                            });
                            obj.SaveChanges();
                            MessageBox.Show("Successfully updated Customer.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            comboBox1.Text = "Customer ID";
                            textBox1.Text = "";
                            textBox1.Text = textBox2.Text.Trim();
                            disableAddControls();

                        }
                        else if (dialog == DialogResult.No)
                        {

                        }


                    }
                    else
                    {
                        MessageBox.Show("Please fill up 'Customer Address'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox4.Focus();
                    }


                }
                else
                {
                    MessageBox.Show("Please fill up 'Customer Name'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Focus();
                }
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

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-';
        }
    }
}
