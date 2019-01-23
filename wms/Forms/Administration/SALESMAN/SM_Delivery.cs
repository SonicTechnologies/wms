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
    public partial class SM_Delivery : Form
    {
        public SM_Delivery()
        {
            InitializeComponent();
        }
        wmsdb obj = new wmsdb();

        private void SM_Delivery_Load(object sender, EventArgs e)
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
            var salesman = (from c in obj.WMS_JRSLSMAN_VIEW
                            where c.salesman_type_id == 2
                            select new
                            {
                                c.drvr_id,
                                c.drvr_name,
                                c.salesman_type_id,
                                c.salesman_type_name,
                                c.site_id,
                                c.site_name,
                                c.drvr_plate,
                                c.usr_id,
                                c.usr_username,
                                c.drvr_datecrtd,
                                c.crtdby,
                                c.drvr_dateuptd,
                                c.uptdby

                            }).OrderBy(c => new { c.drvr_name }).ToList();

            dataGridView1.Rows.Clear();

            if (salesman.Count != 0)
            {
                dataGridView1.ColumnHeadersVisible = true;
                foreach (var row in salesman)
                {

                    dataGridView1.Rows.Add(row.drvr_id,
                                           row.drvr_name,
                                           row.salesman_type_name,
                                           row.site_id,
                                           row.site_name,
                                           row.usr_id,
                                           row.usr_username,
                                           row.drvr_plate,
                                           row.drvr_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.crtdby,
                                           row.drvr_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.uptdby);

                }
            }
            else
            {
                dataGridView1.ColumnHeadersVisible = false;
            }
        }

        public void enableAddControls()
        {

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            textBox5.Text = "";

            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";

            textBox2.Enabled = false;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            textBox5.Enabled = true;
            panel77.Visible = true;

        }

        public void disableAddControls()
        {

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox2.SelectedIndex = -1;
            textBox5.Text = "";

            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";

            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            comboBox2.Enabled = false;
            textBox5.Enabled = false;
            panel77.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            button4.Text = "Save";
            enableAddControls();
            textBox3.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            disableAddControls();
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

                    var slsmancode = Convert.ToInt32(textBox1.Text.Trim());
                    var salesman = (from c in obj.WMS_JRSLSMAN_VIEW
                                    where c.drvr_id == slsmancode
                                    select new
                                    {
                                        c.drvr_id,
                                        c.drvr_name,
                                        c.salesman_type_id,
                                        c.salesman_type_name,
                                        c.drvr_plate,
                                        c.usr_id,
                                        c.usr_username,
                                        c.drvr_datecrtd,
                                        c.crtdby,
                                        c.drvr_dateuptd,
                                        c.uptdby,
                                        c.site_id,
                                        c.site_name

                                    }).OrderBy(c => new { c.drvr_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (salesman.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in salesman)
                        {

                            dataGridView1.Rows.Add(row.drvr_id,
                                           row.drvr_name,
                                           row.salesman_type_name,
                                           row.site_id,
                                           row.site_name,
                                           row.usr_id,
                                           row.usr_username,
                                           row.drvr_plate,
                                           row.drvr_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.crtdby,
                                           row.drvr_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
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
                    var salesman = (from c in obj.WMS_JRSLSMAN_VIEW
                                    where c.drvr_name.Contains(slsmanname)
                                    select new
                                    {
                                        c.drvr_id,
                                        c.drvr_name,
                                        c.salesman_type_id,
                                        c.salesman_type_name,
                                        c.drvr_plate,
                                        c.usr_id,
                                        c.usr_username,
                                        c.drvr_datecrtd,
                                        c.crtdby,
                                        c.drvr_dateuptd,
                                        c.uptdby,
                                        c.site_id,
                                        c.site_name

                                    }).OrderBy(c => new { c.drvr_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (salesman.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in salesman)
                        {

                            dataGridView1.Rows.Add(row.drvr_id,
                                           row.drvr_name,
                                           row.salesman_type_name,
                                           row.site_id,
                                           row.site_name,
                                           row.usr_id,
                                           row.usr_username,
                                           row.drvr_plate,
                                           row.drvr_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.crtdby,
                                           row.drvr_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.uptdby);

                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }

                }
                else if (comboBox1.Text == "Salesman Type")
                {

                    var slsmantype = textBox1.Text.Trim();
                    var salesman = (from c in obj.WMS_JRSLSMAN_VIEW
                                    where c.salesman_type_name.StartsWith(slsmantype)
                                    select new
                                    {
                                        c.drvr_id,
                                        c.drvr_name,
                                        c.salesman_type_id,
                                        c.salesman_type_name,
                                        c.drvr_plate,
                                        c.usr_id,
                                        c.usr_username,
                                        c.drvr_datecrtd,
                                        c.crtdby,
                                        c.drvr_dateuptd,
                                        c.uptdby,
                                        c.site_id,
                                        c.site_name

                                    }).OrderBy(c => new { c.drvr_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (salesman.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in salesman)
                        {

                            dataGridView1.Rows.Add(row.drvr_id,
                                           row.drvr_name,
                                           row.salesman_type_name,
                                           row.site_id,
                                           row.site_name,
                                           row.usr_id,
                                           row.usr_username,
                                           row.drvr_plate,
                                           row.drvr_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.crtdby,
                                           row.drvr_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
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
                    var salesman = (from c in obj.WMS_JRSLSMAN_VIEW
                                    where c.site_id == siteid
                                    select new
                                    {
                                        c.drvr_id,
                                        c.drvr_name,
                                        c.salesman_type_id,
                                        c.salesman_type_name,
                                        c.drvr_plate,
                                        c.usr_id,
                                        c.usr_username,
                                        c.drvr_datecrtd,
                                        c.crtdby,
                                        c.drvr_dateuptd,
                                        c.uptdby,
                                        c.site_id,
                                        c.site_name

                                    }).OrderBy(c => new { c.drvr_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (salesman.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in salesman)
                        {

                            dataGridView1.Rows.Add(row.drvr_id,
                                           row.drvr_name,
                                           row.salesman_type_name,
                                           row.site_id,
                                           row.site_name,
                                           row.usr_id,
                                           row.usr_username,
                                           row.drvr_plate,
                                           row.drvr_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.crtdby,
                                           row.drvr_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
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
                    var salesman = (from c in obj.WMS_JRSLSMAN_VIEW
                                    where c.site_name.Contains(sitename)
                                    select new
                                    {
                                        c.drvr_id,
                                        c.drvr_name,
                                        c.salesman_type_id,
                                        c.salesman_type_name,
                                        c.drvr_plate,
                                        c.usr_id,
                                        c.usr_username,
                                        c.drvr_datecrtd,
                                        c.crtdby,
                                        c.drvr_dateuptd,
                                        c.uptdby,
                                        c.site_id,
                                        c.site_name

                                    }).OrderBy(c => new { c.drvr_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (salesman.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in salesman)
                        {

                            dataGridView1.Rows.Add(row.drvr_id,
                                           row.drvr_name,
                                           row.salesman_type_name,
                                           row.site_id,
                                           row.site_name,
                                           row.usr_id,
                                           row.usr_username,
                                           row.drvr_plate,
                                           row.drvr_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.crtdby,
                                           row.drvr_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.uptdby);

                        }
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }

                }
                else if (comboBox1.Text == "Plate No.")
                {

                    var slsmanplate = textBox1.Text.Trim();
                    var salesman = (from c in obj.WMS_JRSLSMAN_VIEW
                                    where c.drvr_plate.Contains(slsmanplate)
                                    select new
                                    {
                                        c.drvr_id,
                                        c.drvr_name,
                                        c.salesman_type_id,
                                        c.salesman_type_name,
                                        c.drvr_plate,
                                        c.usr_id,
                                        c.usr_username,
                                        c.drvr_datecrtd,
                                        c.crtdby,
                                        c.drvr_dateuptd,
                                        c.uptdby,
                                        c.site_id,
                                        c.site_name

                                    }).OrderBy(c => new { c.drvr_name }).ToList();

                    dataGridView1.Rows.Clear();

                    if (salesman.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in salesman)
                        {

                            dataGridView1.Rows.Add(row.drvr_id,
                                           row.drvr_name,
                                           row.salesman_type_name,
                                           row.site_id,
                                           row.site_name,
                                           row.usr_id,
                                           row.usr_username,
                                           row.drvr_plate,
                                           row.drvr_datecrtd.ToString("yyyy-MM-dd hh:mm:ss tt"),
                                           row.crtdby,
                                           row.drvr_dateuptd?.ToString("yyyy-MM-dd hh:mm:ss tt"),
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            button4.Text = "Update";
            enableAddControls();
            textBox2.Enabled = false;
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            textBox9.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

            if (Convert.ToString(dataGridView1.CurrentRow.Cells[8].Value) == string.Empty)
            {
                textBox11.Text = "";
            }
            else
            {
                textBox11.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            }

            if (Convert.ToString(dataGridView1.CurrentRow.Cells[9].Value) == string.Empty)
            {
                textBox12.Text = "";
            }
            else
            {
                textBox12.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Save")
            {

                if (textBox3.Text.Trim() != "")
                {
                    if (comboBox2.Text.Trim() != "")
                    {
                        if (comboBox3.Text.Trim() != "")
                        {
                            if (textBox6.Text.Trim() != "")
                            {

                                if (textBox5.Text.Trim() != "")
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

                                        var xsalesmanid = (from c in obj.WMS_JRSLSMAN_VIEW
                                                           where c.drvr_name == textBox3.Text.Trim()
                                                           select c.drvr_id).ToList();
                                        if (xsalesmanid.Count == 0)
                                        {
                                            var salesman = obj.Set<WMS_MSTR_JRSLSMAN>();
                                            salesman.Add(new WMS_MSTR_JRSLSMAN
                                            {
                                                drvr_name = textBox3.Text.Trim(),
                                                salesman_type_id = xslsmantypeid,
                                                drvr_plate = textBox5.Text.Trim(),
                                                usr_id = Convert.ToInt32(textBox4.Text),
                                                drvr_datecrtd = serverDate,
                                                drvr_crtdby = loggedin_user.userId,
                                                site_id = comboBox3.Text

                                            });
                                            obj.SaveChanges();
                                            MessageBox.Show("Successfully saved Salesman.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            comboBox1.Text = "Salesman Name";
                                            textBox1.Text = textBox3.Text.Trim();
                                            disableAddControls();
                                        }
                                        else
                                        {
                                            MessageBox.Show("'Salesman Name' already exist.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            comboBox1.Text = "Salesman Name";
                                            textBox1.Text = textBox3.Text.Trim();
                                        }

                                    }
                                    else if (dialog == DialogResult.No)
                                    {

                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Please fill up 'Plate No'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    textBox5.Focus();
                                }

                            }
                            else
                            {
                                MessageBox.Show("Please fill up 'User ID'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBox4.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select 'Site'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else if (button4.Text == "Update")
            {
                if (textBox3.Text.Trim() != "")
                {
                    if (comboBox2.Text.Trim() != "")
                    {
                        if (textBox6.Text.Trim() != "")
                        {
                            if (textBox5.Text.Trim() != "")
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
                                    int drvrid = Convert.ToInt32(textBox2.Text.Trim());
                                    obj.WMS_MSTR_JRSLSMAN.Where(c => c.drvr_id == drvrid).ToList().ForEach(x =>
                                    {
                                        x.drvr_name = textBox3.Text.Trim();
                                        x.salesman_type_id = xslsmantypeid;
                                        x.usr_id = Convert.ToInt32(textBox4.Text.Trim());
                                        x.drvr_plate = textBox5.Text.Trim();
                                        x.drvr_dateuptd = serverDate;
                                        x.drvr_uptdby = loggedin_user.userId;

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
                                textBox5.Focus();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Please select 'User ID'.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox4.Focus();
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
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = "";
            if (textBox4.Text.Trim() != "")
            {

                int userid = Convert.ToInt32(textBox4.Text.Trim());
                var username = (from c in obj.WMS_MSTR_USRS
                                where c.usr_id == userid
                                select c.usr_username).FirstOrDefault();

                textBox6.Text = username;
            }
            else
            {

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SD_Delivery_Upload_Data smup = new SD_Delivery_Upload_Data();
            smup.Show();
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox7.Text = SiteName(comboBox3.Text);
        }
    }
}
