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

namespace wms.Forms.Administration.SITE
{
    public partial class Site_Maintenance : Form
    {
        wmsdb obj = new wmsdb();

        public Site_Maintenance()
        {
            InitializeComponent();
        }

        public void enableAddControls()
        {

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";

            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            panel77.Visible = true;

        }

        public void disableAddControls()
        {

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";

            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "All" && textBox1.Text.Trim() == "")
            {
                GetSite();
            }
            else
            {
                if (comboBox1.Text == "" && textBox1.Text.Trim() != "")
                {

                }
                else
                {
                    searchSite();
                }

            }
        }
        public void GetSite()
        {
            var sites = (from c in obj.WMS_SITE_VIEW
                         select new
                         {
                             c.site_id,
                             c.site_name,
                             c.site_code,
                             c.site_datecrtd,
                             c.crtdby,
                             c.site_dateuptd,
                             c.uptdby

                         }).OrderBy(c => new { c.site_name }).ToList();

            dataGridView1.Rows.Clear();

            if (sites.Count != 0)
            {
                dataGridView1.ColumnHeadersVisible = true;
                foreach (var row in sites)
                {

                    dataGridView1.Rows.Add(row.site_id,
                                                   row.site_name,
                                                   row.site_code,
                                                   row.site_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.crtdby,
                                                   row.site_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.uptdby);

                }
            }
            else
            {
                dataGridView1.ColumnHeadersVisible = false;
            }
        }

        public void searchSite()
        {
            if (textBox1.Text.Trim() == "")
            {
                dataGridView1.ColumnHeadersVisible = false;
                dataGridView1.Rows.Clear();
            }
            else
            {

                if (comboBox1.Text == "Site ID")
                {

                    var siteid = textBox1.Text.Trim();
                    var xsiteid = (from c in obj.WMS_SITE_VIEW
                                   where c.site_id == siteid
                                   select new
                                   {
                                       c.site_id,
                                       c.site_name,
                                       c.site_code,
                                       c.site_datecrtd,
                                       c.crtdby,
                                       c.site_dateuptd,
                                       c.uptdby

                                   }).OrderBy(c => new { c.site_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (xsiteid.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in xsiteid)
                        {

                            dataGridView1.Rows.Add(row.site_id,
                                                   row.site_name,
                                                   row.site_code,
                                                   row.site_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.crtdby,
                                                   row.site_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
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
                    var xsitename = (from c in obj.WMS_SITE_VIEW
                                     where c.site_name.Contains(sitename)
                                     select new
                                     {
                                         c.site_id,
                                         c.site_name,
                                         c.site_code,
                                         c.site_datecrtd,
                                         c.crtdby,
                                         c.site_dateuptd,
                                         c.uptdby

                                     }).OrderBy(c => new { c.site_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (xsitename.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in xsitename)
                        {

                            dataGridView1.Rows.Add(row.site_id,
                                                   row.site_name,
                                                   row.site_code,
                                                   row.site_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.crtdby,
                                                   row.site_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.uptdby);

                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }

                }
                else if (comboBox1.Text == "Site Code")
                {
                    var sitecode = textBox1.Text.Trim();
                    var xsitecode = (from c in obj.WMS_SITE_VIEW
                                     where c.site_code == sitecode
                                     select new
                                     {
                                         c.site_id,
                                         c.site_name,
                                         c.site_code,
                                         c.site_datecrtd,
                                         c.crtdby,
                                         c.site_dateuptd,
                                         c.uptdby

                                     }).OrderBy(c => new { c.site_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (xsitecode.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in xsitecode)
                        {

                            dataGridView1.Rows.Add(row.site_id,
                                                   row.site_name,
                                                   row.site_code,
                                                   row.site_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.crtdby,
                                                   row.site_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                                   row.uptdby);

                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }

                }
            }

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "All")
            {
                textBox1.Text = "";
                textBox1.Enabled = false;
                GetSite();
            }
            else
            {
                textBox1.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchSite();
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
                            DialogResult dialog = MessageBox.Show("Are you sure you want to save Site?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialog == DialogResult.Yes)
                            {

                                var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                                DateTime serverDate = dateQuery.AsEnumerable().First();

                                var xsite = (from c in obj.WMS_MSTR_SITE
                                             where c.site_id == textBox2.Text.Trim()
                                             select c.site_id).ToList();
                                if (xsite.Count == 0)
                                {
                                    var salesman = obj.Set<WMS_MSTR_SITE>();
                                    salesman.Add(new WMS_MSTR_SITE
                                    {
                                        site_id = textBox2.Text.Trim(),
                                        site_name = textBox3.Text.Trim(),
                                        site_code = textBox4.Text.Trim(),
                                        site_datecrtd = serverDate,
                                        site_crtdby = loggedin_user.userId
                                    });
                                    obj.SaveChanges();
                                    MessageBox.Show("Successfully saved Site.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    comboBox1.Text = "Site ID";
                                    textBox1.Text = textBox2.Text.Trim();
                                    disableAddControls();
                                }
                                else
                                {
                                    MessageBox.Show("'Site ID' already exist.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    comboBox1.Text = "Site ID";
                                    textBox1.Text = textBox2.Text.Trim();
                                }

                            }
                            else if (dialog == DialogResult.No)
                            {

                            }
                        }
                        else
                        {
                            MessageBox.Show("Please fill up 'Site Code'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox4.Focus();
                        }                         
                    }
                    else
                    {
                        MessageBox.Show("Please fill up 'Site Name'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox3.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please fill up 'Site ID'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Focus();
                }
            }
            else
            {
                if (textBox2.Text.Trim() != "")
                {
                    if (textBox3.Text.Trim() != "")
                    {

                        DialogResult dialog = MessageBox.Show("Are you sure you want to update Site?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {
                            var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                            DateTime serverDate = dateQuery.AsEnumerable().First();

                            obj.WMS_MSTR_SITE.Where(c => c.site_id == textBox2.Text.Trim()).ToList().ForEach(x =>
                            {
                                x.site_name = textBox3.Text.Trim();
                                x.site_code = textBox4.Text.Trim();
                                x.site_dateuptd = serverDate;
                                x.site_uptdby = loggedin_user.userId;
                            });
                            obj.SaveChanges();

                            MessageBox.Show("Successfully updated Site.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            comboBox1.Text = "Site ID";
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
                        MessageBox.Show("Please fill up 'Site Name'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox3.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please fill up 'Site ID'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Focus();
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            button4.Text = "Update";
            enableAddControls();
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            if (Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value) == string.Empty)
            {
                textBox11.Text = "";
            }
            else
            {
                textBox11.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }

            if (Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value) == string.Empty)
            {
                textBox12.Text = "";
            }
            else
            {
                textBox12.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ST_Upload_Data stup = new ST_Upload_Data();
            stup.Show();
        }

       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
