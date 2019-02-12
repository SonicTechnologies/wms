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

namespace wms.Forms.Administration.SALESMAN
{
    public partial class SM_Booking : Form
    {
        public SM_Booking()
        {
            InitializeComponent();
        }
        wmsdb obj = new wmsdb();
        private void SM_Booking_Load(object sender, EventArgs e)
        {
            getSite();

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

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "All")
            {
                textBox1.Text = "";
                textBox1.Enabled = false;
                GetSalesman();
            }
            else
            {
                textBox1.Enabled = true;
            }
        }
        public void GetSalesman()
        {
            var salesman = (from c in obj.WMS_SLSMAN_VIEW
                            where c.salesman_type_id == 1
                            select new
                            {
                                c.salesman_id,
                                c.salesman_name,
                                c.salesman_type_id,
                                c.salesman_type_name,
                                c.site_id,
                                c.site_name,
                                c.salesman_datecrtd,
                                c.salesman_crtdby,
                                c.salesman_dateuptd,
                                c.salesman_uptdby

                            }).OrderBy(c => new { c.salesman_name }).ToList();

            dataGridView1.Rows.Clear();

            if (salesman.Count != 0)
            {
                dataGridView1.ColumnHeadersVisible = true;
                foreach (var row in salesman)
                {

                    dataGridView1.Rows.Add(row.salesman_id,
                                           row.salesman_name,
                                           row.salesman_type_name,
                                           row.site_id,
                                           row.site_name,
                                           row.salesman_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.salesman_crtdby,
                                           row.salesman_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.salesman_uptdby);

                }
            }
            else
            {
                dataGridView1.ColumnHeadersVisible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SB_Booking_Upload_Data smup = new SB_Booking_Upload_Data();
            smup.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
            button4.Text = "Save";
            enableAddControls();
            textBox2.Focus();
        }
        public void enableAddControls()
        {

            textBox2.Text = "";
            textBox3.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            textBox5.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";

            textBox2.Enabled = true;
            textBox3.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            panel77.Visible = true;

        }

        public void disableAddControls()
        {

            textBox2.Text = "";
            textBox3.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            textBox5.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";

            textBox2.Enabled = false;
            textBox3.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            panel77.Visible = false;
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox5.Text = SiteName(comboBox3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Save")
            {
                if (textBox2.Text.Trim() != "")
                {
                    if (textBox3.Text.Trim() != "")
                    {
                        if (comboBox2.Text.Trim() != "")
                        {
                            if (comboBox3.Text.Trim() != "")
                            {
                                DialogResult dialog = MessageBox.Show("Are you sure you want to save Salesman?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialog == DialogResult.Yes)
                                {
                                    var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                                    DateTime serverDate = dateQuery.AsEnumerable().First();

                                    string xslsmantype = comboBox2.Text;
                                    int xslsmantypeid = 1;
                                    var slsmantypeid = (from c in obj.WMS_TYPE_SLSMAN
                                                        where c.salesman_type_name == xslsmantype
                                                        select c.salesman_type_id).FirstOrDefault();

                                    xslsmantypeid = slsmantypeid;

                                    var salesmanid = (from c in obj.WMS_SLSMAN_VIEW
                                                      where c.salesman_id == textBox2.Text.Trim()
                                                      select c.salesman_id).FirstOrDefault();
                                    if (salesmanid == null)
                                    {
                                        var salesman = obj.Set<WMS_MSTR_SLSMAN>();
                                        salesman.Add(new WMS_MSTR_SLSMAN
                                        {
                                            salesman_id = textBox2.Text.Trim(),
                                            salesman_name = textBox3.Text.Trim(),
                                            salesman_type_id = xslsmantypeid,
                                            site_id = comboBox3.Text,
                                            salesman_datecrtd = serverDate,
                                            salesman_crtdby = loggedin_user.userId

                                        });
                                        obj.SaveChanges();
                                        MessageBox.Show("Successfully saved Salesman.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        comboBox1.Text = "Salesman ID";
                                        textBox1.Text = textBox2.Text.Trim();
                                        disableAddControls();


                                    }
                                    else
                                    {
                                        MessageBox.Show("'Salesman ID' already exist.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        comboBox1.Text = "Salesman ID";
                                        textBox1.Text = textBox2.Text.Trim();
                                    }

                                }
                                else if (dialog == DialogResult.No)
                                {

                                }
                            }
                            else
                            {
                                MessageBox.Show("Please select 'Salesman Site'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                comboBox3.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select 'Salesman Type'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            comboBox2.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please fill up 'Salesman Name'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox3.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please fill up 'Salesman Code'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Focus();
                }
            }
            else if (button4.Text == "Update")
            {
                if (textBox3.Text.Trim() != "")
                {
                    if (comboBox2.Text.Trim() != "")
                    {
                        if (comboBox3.Text.Trim() != "")
                        {
                            DialogResult dialog = MessageBox.Show("Are you sure you want to update Salesman?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialog == DialogResult.Yes)
                            {
                                var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                                DateTime serverDate = dateQuery.AsEnumerable().First();

                                string xslsmantype = comboBox2.Text;
                                int xslsmantypeid = 1;
                                var slsmantypeid = (from c in obj.WMS_TYPE_SLSMAN
                                                    where c.salesman_type_name == xslsmantype
                                                    select c.salesman_type_id).FirstOrDefault();

                                xslsmantypeid = slsmantypeid;

                                obj.WMS_MSTR_SLSMAN.Where(c => c.salesman_id == textBox2.Text.Trim()).ToList().ForEach(x =>
                                {
                                    x.salesman_name = textBox3.Text.Trim();
                                    x.salesman_type_id = xslsmantypeid;
                                    x.site_id = comboBox3.Text;
                                    x.salesman_dateuptd = serverDate;
                                    x.salesman_uptdby = loggedin_user.userId;

                                });
                                obj.SaveChanges();
                                MessageBox.Show("Successfully updated Salesman.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                comboBox1.Text = "Salesman ID";
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
                            MessageBox.Show("Please select 'Salesman Site'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            comboBox3.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select 'Salesman Type'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        comboBox2.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please fill up 'Salesman Name'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Focus();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchSalesman();
        }
        public void searchSalesman()
        {
            if (textBox1.Text.Trim() == "")
            {
                dataGridView1.ColumnHeadersVisible = false;
                dataGridView1.Rows.Clear();
            }
            else
            {

                if (comboBox1.Text == "Salesman ID")
                {

                    var slsmancode = textBox1.Text.Trim();
                    var salesman = (from c in obj.WMS_SLSMAN_VIEW
                                    where c.salesman_id == slsmancode
                                    select new
                                    {
                                        c.salesman_id,
                                        c.salesman_name,
                                        c.salesman_type_id,
                                        c.salesman_type_name,
                                        c.site_id,
                                        c.site_name,
                                        c.salesman_datecrtd,
                                        c.salesman_crtdby,
                                        c.salesman_dateuptd,
                                        c.salesman_uptdby

                                    }).OrderBy(c => new { c.salesman_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (salesman.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in salesman)
                        {

                            dataGridView1.Rows.Add(row.salesman_id,
                                                   row.salesman_name,
                                                   row.salesman_type_name,
                                                   row.site_id,
                                                   row.site_name,
                                                   row.salesman_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.salesman_crtdby,
                                                   row.salesman_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.salesman_uptdby);

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
                    var salesman = (from c in obj.WMS_SLSMAN_VIEW
                                    where c.salesman_name.Contains(slsmanname)
                                    select new
                                    {
                                        c.salesman_id,
                                        c.salesman_name,
                                        c.salesman_type_id,
                                        c.salesman_type_name,
                                        c.site_id,
                                        c.site_name,
                                        c.salesman_datecrtd,
                                        c.salesman_crtdby,
                                        c.salesman_dateuptd,
                                        c.salesman_uptdby

                                    }).OrderBy(c => new { c.salesman_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (salesman.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in salesman)
                        {

                            dataGridView1.Rows.Add(row.salesman_id,
                                                   row.salesman_name,
                                                   row.salesman_type_name,
                                                   row.site_id,
                                                   row.site_name,
                                                   row.salesman_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.salesman_crtdby,
                                                   row.salesman_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.salesman_uptdby);

                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }

                }
                else if (comboBox1.Text == "Salesman Type")
                {

                    var salesmantype = textBox1.Text.Trim();
                    var salesman = (from c in obj.WMS_SLSMAN_VIEW
                                    where c.salesman_type_name.StartsWith(salesmantype)
                                    select new
                                    {
                                        c.salesman_id,
                                        c.salesman_name,
                                        c.salesman_type_id,
                                        c.salesman_type_name,
                                        c.site_id,
                                        c.site_name,
                                        c.salesman_datecrtd,
                                        c.salesman_crtdby,
                                        c.salesman_dateuptd,
                                        c.salesman_uptdby

                                    }).OrderBy(c => new { c.salesman_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (salesman.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in salesman)
                        {

                            dataGridView1.Rows.Add(row.salesman_id,
                                                   row.salesman_name,
                                                   row.salesman_type_name,
                                                   row.site_id,
                                                   row.site_name,
                                                   row.salesman_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.salesman_crtdby,
                                                   row.salesman_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.salesman_uptdby);

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
                    var salesman = (from c in obj.WMS_SLSMAN_VIEW
                                    where c.site_id == siteid
                                    select new
                                    {
                                        c.salesman_id,
                                        c.salesman_name,
                                        c.salesman_type_id,
                                        c.salesman_type_name,
                                        c.site_id,
                                        c.site_name,
                                        c.salesman_datecrtd,
                                        c.salesman_crtdby,
                                        c.salesman_dateuptd,
                                        c.salesman_uptdby

                                    }).OrderBy(c => new { c.salesman_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (salesman.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in salesman)
                        {

                            dataGridView1.Rows.Add(row.salesman_id,
                                                   row.salesman_name,
                                                   row.salesman_type_name,
                                                   row.site_id,
                                                   row.site_name,
                                                   row.salesman_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.salesman_crtdby,
                                                   row.salesman_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.salesman_uptdby);

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
                    var salesman = (from c in obj.WMS_SLSMAN_VIEW
                                    where c.site_name.Contains(sitename)
                                    select new
                                    {
                                        c.salesman_id,
                                        c.salesman_name,
                                        c.salesman_type_id,
                                        c.salesman_type_name,
                                        c.site_id,
                                        c.site_name,
                                        c.salesman_datecrtd,
                                        c.salesman_crtdby,
                                        c.salesman_dateuptd,
                                        c.salesman_uptdby

                                    }).OrderBy(c => new { c.salesman_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (salesman.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in salesman)
                        {

                            dataGridView1.Rows.Add(row.salesman_id,
                                                   row.salesman_name,
                                                   row.salesman_type_name,
                                                   row.site_id,
                                                   row.site_name,
                                                   row.salesman_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.salesman_crtdby,
                                                   row.salesman_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.salesman_uptdby);

                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "All" && textBox1.Text.Trim() == "")
            {
                GetSalesman();
            }
            else
            {
                if (comboBox1.Text == "" && textBox1.Text.Trim() != "")
                {

                }
                else
                {
                    searchSalesman();
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            disableAddControls();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button4.Text = "Update";
            enableAddControls();
            textBox2.Enabled = false;
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            if (Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value) == string.Empty)
            {
                textBox11.Text = "";
            }
            else
            {
                textBox11.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            }

            if (Convert.ToString(dataGridView1.CurrentRow.Cells[8].Value) == string.Empty)
            {
                textBox12.Text = "";
            }
            else
            {
                textBox12.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            }
        }
    }
}
