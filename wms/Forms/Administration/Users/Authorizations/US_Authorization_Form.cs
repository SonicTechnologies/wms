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

namespace wms.Forms.Administration.Users.Authorizations
{
    public partial class US_Authorization_Form : Form
    {
        public US_Authorization_Form()
        {
            InitializeComponent();
        }

        wmsdb obj = new wmsdb();

        public void searchUser()
        {
            textBox7.Focus();

            if (textBox7.Text != "")
            {
                int userID = Convert.ToInt32(textBox7.Text);
                var users = (from c in obj.WMS_MSTR_USRS
                             join o  in obj.WMS_TYPE_USRS on c.usr_type_id equals o.usr_type_id
                             join s in obj.WMS_TYPE_STAT on c.stat_id equals s.stat_id
                             where c.usr_id == userID
                             select new
                             {
                                 c.usr_id,
                                 c.usr_username,        
                                 c.usr_fname,
                                 c.usr_lname,
                                 o.usr_type_name,
                                 s.stat_desc,

                             }).OrderBy(c => new { c.usr_id }).ToList();

                dataGridView4.Rows.Clear();

                if (users.Count != 0)
                {
                    dataGridView4.ColumnHeadersVisible = true;
                    foreach (var row in users)
                    {

                        dataGridView4.Rows.Add(row.usr_id,
                          
                                 row.usr_username,
                                 row.usr_fname,
                                 row.usr_lname,
                                 row.usr_type_name,
                                 row.stat_desc
                                    );
                    }
                }
                else
                {
                    dataGridView4.ColumnHeadersVisible = false;
                }
            }
        }


        public void listItem()
        {

            if (tabControl1.SelectedTab == tabPage1)
            {
                var items = (from c in obj.WMS_MSTR_MODULE

                             select new
                             {
                                 c.mod_id,
                                 c.mod_name,
                                 c.mod_datecrtd,

                             }).OrderBy(c => new { c.mod_id }).ToList();

                dataGridView1.Rows.Clear();

                if (items.Count != 0)
                {
                    dataGridView1.ColumnHeadersVisible = true;
                    foreach (var row in items)
                    {

                        dataGridView1.Rows.Add(row.mod_id,
                                               row.mod_name,
                                               row.mod_datecrtd   );

                    }
                }
                else
                {
                    dataGridView1.ColumnHeadersVisible = false;
                }

            }

            else if (tabControl1.SelectedTab == tabPage2)
            {


                var itemcode = textBox1.Text.Trim();
                var items = (from c in obj.WMS_MSTR_S1MODULE
                             join o in obj.WMS_MSTR_MODULE on c.mod_id equals o.mod_id

                             select new
                             {
                                 c.s1mod_id,
                                 o.mod_id,
                                 o.mod_name,
                                 c.s1mod_name,
                                 c.s1mod_datecrtd,

                                  
                             }).OrderBy(c => new { c.s1mod_id }).ToList();

                dataGridView2.Rows.Clear();
             
                if (items.Count != 0)
                {
                    dataGridView2.ColumnHeadersVisible = true;
                    foreach (var row in items)
                    {

                        dataGridView2.Rows.Add(
                                 row.s1mod_id,
                                 row.mod_id,
                                 row.mod_name,
                                 row.s1mod_name,
                                 row.s1mod_datecrtd  );

                    }
                }
                else
                {
                    dataGridView2.ColumnHeadersVisible = false;
                }

            }

            else if (tabControl1.SelectedTab == tabPage3)
            {

                var items = (from c in obj.WMS_MSTR_S2MODULE
                             join o in obj.WMS_MSTR_S1MODULE on c.s1mod_id equals o.s1mod_id

                             select new
                             {
                                 c.s2mod_id,
                                 o.s1mod_id,
                                 o.s1mod_name,
                                 c.s2mod_name,
                                 c.s2mod_form_name,
                                 c.s2mod_datecrtd

                             }).OrderBy(c => new { c.s2mod_id }).ToList();

                dataGridView3.Rows.Clear();

                if (items.Count != 0)
                {
                    dataGridView3.ColumnHeadersVisible = true;
                    foreach (var row in items)
                    {

                        dataGridView3.Rows.Add(
                                 row.s2mod_id,
                                 row.s1mod_id,
                                 row.s1mod_name,
                                 row.s2mod_name,
                                 row.s2mod_form_name,
                                 row.s2mod_datecrtd );

                    }
                }
                else
                {
                    dataGridView3.ColumnHeadersVisible = false;
                }

            }

        }

        private void US_Authorization_From_Load(object sender, EventArgs e)
        {
            AcceptButton = button1;
            listItem();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchUser();
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView4.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView4.CurrentRow.Cells[5].Value.ToString();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (textBox1.Text != "")
            {
                int userId = Convert.ToInt32(textBox1.Text);
            int modId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var  user = (from c in obj.WMS_MSTR_LVL1M
                                where c.usr_id == userId &&
                                c.mod_id == modId
                                select c.usr_id).FirstOrDefault();
          
                if (user == null)
                {
                    DialogResult dialog = MessageBox.Show("Are you sure you want to add " + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {

                        var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                        DateTime serverDate = dateQuery.AsEnumerable().First();



                        var customer = obj.Set<WMS_MSTR_LVL1M>();
                        customer.Add(new WMS_MSTR_LVL1M
                        {
                            usr_id = Convert.ToInt32(textBox1.Text.Trim()),
                            mod_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()),
                            date_added = serverDate,
                            added_by = loggedin_user.userId

                        });
                        obj.SaveChanges();
                        MessageBox.Show("Successfully saved " + dataGridView1.CurrentRow.Cells[1].Value.ToString() + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
                else
                {
                    MessageBox.Show("" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + " already added.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            { 

            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listItem();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (textBox1.Text != "")
            {
                int userId = Convert.ToInt32(textBox1.Text);
                int modId = Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value.ToString());
                var UserValidation = (from c in obj.WMS_MSTR_LVL1M
                                      where c.usr_id == userId &&
                                      c.mod_id == modId
                                      select c.usr_id).FirstOrDefault();


                if (UserValidation != null)
                {
                    int s1mod_id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                    var user = (from c in obj.WMS_MSTR_LVL2M
                                where c.usr_id == userId &&
                                c.s1mod_id == s1mod_id
                                select c.usr_id).FirstOrDefault();



                    if (user == null)
                    {
                        DialogResult dialog = MessageBox.Show("Are you sure you want to add " + dataGridView2.CurrentRow.Cells[2].Value.ToString() + "?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {

                            var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                            DateTime serverDate = dateQuery.AsEnumerable().First();



                            var customer = obj.Set<WMS_MSTR_LVL2M>();
                            customer.Add(new WMS_MSTR_LVL2M
                            {
                                usr_id = Convert.ToInt32(textBox1.Text.Trim()),
                                s1mod_id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString()),
                                date_added = serverDate,
                                added_by = loggedin_user.userId

                            });
                            obj.SaveChanges();
                            MessageBox.Show("Successfully saved " + dataGridView2.CurrentRow.Cells[3].Value.ToString() + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        }
                    }
                    else
                    {
                        MessageBox.Show("" + dataGridView2.CurrentRow.Cells[3].Value.ToString() + " already added .", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("" + dataGridView2.CurrentRow.Cells[3].Value.ToString() + " cannot be added .Register First the "+ dataGridView2.CurrentRow.Cells[2].Value.ToString() + " Module", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                }
            
            else
            {

            }
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (textBox1.Text != "")
            {

                int userId = Convert.ToInt32(textBox1.Text);
                int S1modId = Convert.ToInt32(dataGridView3.CurrentRow.Cells[1].Value.ToString());
                var UserValidation1 = (from c in obj.WMS_MSTR_LVL2M
                                      where c.usr_id == userId &&
                                      c.s1mod_id == S1modId
                                      select c.usr_id).FirstOrDefault();

                if (UserValidation1 != null)
                { 
                int s2mod_id = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value.ToString());
                var user = (from c in obj.WMS_MSTR_LVL3M
                            where c.usr_id == userId &&
                            c.s2mod_id == s2mod_id
                            select c.usr_id).FirstOrDefault();

                    if (user == null)
                    {
                        DialogResult dialog = MessageBox.Show("Are you sure you want to add " + dataGridView3.CurrentRow.Cells[3].Value.ToString() + "?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {

                            var dateQuery = obj.Database.SqlQuery<DateTime>("SELECT getdate()");
                            DateTime serverDate = dateQuery.AsEnumerable().First();

                            var customer = obj.Set<WMS_MSTR_LVL3M>();
                            customer.Add(new WMS_MSTR_LVL3M
                            {
                                usr_id = Convert.ToInt32(textBox1.Text.Trim()),
                                s2mod_id = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value.ToString()),
                                date_added = serverDate,
                                added_by = loggedin_user.userId

                            });
                            obj.SaveChanges();
                            MessageBox.Show("Successfully saved " + dataGridView3.CurrentRow.Cells[3].Value.ToString() + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        }
                    }

                    else
                    {
                        MessageBox.Show("" + dataGridView3.CurrentRow.Cells[3].Value.ToString() + " already added.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
              
                  else
                    {
                    MessageBox.Show("" + dataGridView3.CurrentRow.Cells[3].Value.ToString() + " cannot be added .Register First the " + dataGridView3.CurrentRow.Cells[2].Value.ToString() + " Module", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {

            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
        }
    }
}
