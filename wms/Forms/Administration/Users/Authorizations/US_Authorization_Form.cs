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

        public static int userId;
        public void GetUserAll()
        {
            if (comboBox1.Text == "All")
            {
                var users = (from c in obj.WMS_MSTR_USRS
                             join o in obj.WMS_TYPE_USRS on c.usr_type_id equals o.usr_type_id
                             join s in obj.WMS_TYPE_STAT on c.stat_id equals s.stat_id
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

                        dataGridView4.Rows.Add(
                                 row.usr_id,
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

        public void searchUser()
        {
            textBox7.Focus();
            if (comboBox1.Text == "User ID")
            {
                var userID = textBox7.Text.Trim();
                var users = (from c in obj.WMS_MSTR_USRS
                             join o in obj.WMS_TYPE_USRS on c.usr_type_id equals o.usr_type_id
                             join s in obj.WMS_TYPE_STAT on c.stat_id equals s.stat_id
                             where c.usr_id.ToString()==(userID)
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

                        dataGridView4.Rows.Add(
                                 row.usr_id,
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

            else if (comboBox1.Text == "Username")
            {
                var userName = textBox7.Text.Trim();
                var users = (from c in obj.WMS_MSTR_USRS
                             join o in obj.WMS_TYPE_USRS on c.usr_type_id equals o.usr_type_id
                             join s in obj.WMS_TYPE_STAT on c.stat_id equals s.stat_id
                             where c.usr_username.ToString().StartsWith(userName)
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

                        dataGridView4.Rows.Add(
                                 row.usr_id,
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

            else if (comboBox1.Text == "First Name")
            {
                var userName = textBox7.Text.Trim();
                var users = (from c in obj.WMS_MSTR_USRS
                             join o in obj.WMS_TYPE_USRS on c.usr_type_id equals o.usr_type_id
                             join s in obj.WMS_TYPE_STAT on c.stat_id equals s.stat_id
                             where (c.usr_fname).StartsWith(userName)
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

                        dataGridView4.Rows.Add(
                                 row.usr_id,
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
            else if (comboBox1.Text == "Last Name")
            {
                var userName = textBox7.Text.Trim();
                var users = (from c in obj.WMS_MSTR_USRS
                             join o in obj.WMS_TYPE_USRS on c.usr_type_id equals o.usr_type_id
                             join s in obj.WMS_TYPE_STAT on c.stat_id equals s.stat_id
                             where (c.usr_lname).StartsWith(userName)
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

                        dataGridView4.Rows.Add(
                                 row.usr_id,
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

            else if (comboBox1.Text == "All" && textBox7.Text.Trim()=="")
            {
                var userName = textBox7.Text.Trim();
                var users = (from c in obj.WMS_MSTR_USRS
                             join o in obj.WMS_TYPE_USRS on c.usr_type_id equals o.usr_type_id
                             join s in obj.WMS_TYPE_STAT on c.stat_id equals s.stat_id
                          
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

                        dataGridView4.Rows.Add(
                                 row.usr_id,
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



            else
            {
                ClearData();
               

            }
        }
        private void togglelvl1()
        {
            if (panel7.Height == 200)
            {

            }
            else
            {
                panel7.Height = 200;
            }
        }
        public void ClearData()
        {
            dataGridView4.Rows.Clear();
            dataGridView4.ColumnHeadersVisible = false;
            textBox1.Text= "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            togglelvl1();
            panel7.Height = 0;
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView2.Rows.Clear();
            dataGridView2.ColumnHeadersVisible = false;
            dataGridView3.Rows.Clear();
            dataGridView3.ColumnHeadersVisible = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;


        }

        public void getModuleId()
        {
            var items = (from c in obj.WMS_MSTR_MODULE
                         join m in obj.WMS_MSTR_LVL1M on c.mod_id equals m.mod_id
                         
                         where c.mod_name == textBox8.Text.Trim() && c.stat_id == 1

                         select new
                         {
                             m.mod_id,
           

                         }).ToList();


        }

        public void listItem()
        {


                  userId = Convert.ToInt32(textBox1.Text.Trim());

                    var items = (from c in obj.WMS_MSTR_LVL1M
                                 join m in obj.WMS_MSTR_MODULE on c.mod_id equals m.mod_id
                                 where c.usr_id == userId && m.stat_id == 1

                                 select new
                                 {
                                     m.mod_id,
                                     m.mod_name,
                                     m.mod_datecrtd,
                                     c.lvl1mod_id,


                                 }).OrderBy(c => new { c.mod_id }).ToList();

                    dataGridView1.Rows.Clear();

                    if (items.Count != 0)
                    {
                        dataGridView1.ColumnHeadersVisible = true;
                        foreach (var row in items)
                        {

                            dataGridView1.Rows.Add(row.mod_id,
                                                   row.mod_name,
                                                   row.mod_datecrtd,
                                                   row.lvl1mod_id);

                        }
               
                    }
                    else
                    {
                        dataGridView1.ColumnHeadersVisible = false;
                    }
                

    
                    var items1 = (from c in obj.WMS_MSTR_S1MODULE
                                 join o in obj.WMS_MSTR_LVL2M on c.s1mod_id equals o.s1mod_id
                                 join m in obj.WMS_MSTR_MODULE on c.mod_id equals m.mod_id
                                 where o.usr_id == userId && c.stat_id==1 && m.stat_id==1 && m.mod_name== textBox8.Text.Trim()
                                 

                                 select new
                                 {
                                     c.s1mod_id,
                                     m.mod_id,
                                     m.mod_name,
                                     c.s1mod_name,
                                     c.s1mod_datecrtd,
                                     o.lvl2mod_id,


                                 }).OrderBy(c => new { c.s1mod_id }).ToList();

                    dataGridView2.Rows.Clear();

                    if (items1.Count != 0)
                    {
                        dataGridView2.ColumnHeadersVisible = true;
                        foreach (var row in items1)
                        {

                            dataGridView2.Rows.Add(
                                     row.s1mod_id,
                                     row.mod_id,
                                     row.mod_name,
                                     row.s1mod_name,
                                     row.s1mod_datecrtd,
                                     row.lvl2mod_id);

                        }
                    }
                    else
                    {
                        dataGridView2.ColumnHeadersVisible = false;
                    }



                    var items2 = (from m in obj.WMS_MSTR_LVL3M
                                 join c in obj.WMS_MSTR_S2MODULE on  m.s2mod_id equals c.s2mod_id
                                 join o in obj.WMS_MSTR_S1MODULE on c.s1mod_id equals o.s1mod_id
                                 join module1 in obj.WMS_MSTR_MODULE on o.mod_id equals module1.mod_id
                                 where m.usr_id == userId &&  c.stat_id==1 && o.stat_id==1 && module1.stat_id==1 && o.s1mod_name == textBox9.Text.Trim()

                                 select new
                                 {
                                     c.s2mod_id,
                                     o.s1mod_id,
                                     o.s1mod_name,
                                     c.s2mod_name,
                                     c.s2mod_form_name,
                                     c.s2mod_datecrtd,
                                     m.lvl3mod_id

                                 }).OrderBy(c => new { c.s2mod_id }).ToList();

                    dataGridView3.Rows.Clear();

                    if (items2.Count != 0)
                    {
                        dataGridView3.ColumnHeadersVisible = true;
                        foreach (var row in items2)
                        {

                            dataGridView3.Rows.Add(
                                     row.s2mod_id,
                                     row.s1mod_id,
                                     row.s1mod_name,
                                     row.s2mod_name,
                                     row.s2mod_form_name,
                                     row.s2mod_datecrtd,
                                     row.lvl3mod_id);

                        }
                    }
                    else
                    {
                        dataGridView3.ColumnHeadersVisible = false;
                    }
   
                tabControl1.Refresh();
        

     

        }


        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            togglelvl1();
            textBox1.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView4.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView4.CurrentRow.Cells[5].Value.ToString();

        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listItem();
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb != null)
            {
                tb.BackColor = Color.Orange;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb != null)
            {
                tb.BackColor = System.Drawing.SystemColors.Info;
            }
        }

 

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
     

          searchUser();
 
        }

     
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                ClearData();
            }
           
            else
            {
                listItem();
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Add_Lvl1_Module alm = new Add_Lvl1_Module();
            alm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Lv2_Module Addlvl2 = new Add_Lv2_Module();
            Addlvl2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Lv3_Module Addlvl3 = new Add_Lv3_Module();
            Addlvl3.Show();
        }


        private void Lvl1DeleteModule()
        {
            userId = Convert.ToInt32(textBox1.Text.Trim());


            int lvl1modId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            
            obj.WMS_MSTR_LVL1M.RemoveRange(from lvl1 in obj.WMS_MSTR_LVL1M

                                           where lvl1.mod_id == lvl1modId && lvl1.usr_id == userId
                                           select lvl1);

            obj.WMS_MSTR_LVL2M.RemoveRange(from lvl in obj.WMS_MSTR_LVL2M
                                           join lvl2 in obj.WMS_LVL2M_VIEW on lvl.s1mod_id equals lvl2.s1mod_id
                                           join lvl1 in obj.WMS_LVL1M_VIEW on lvl2.mod_id equals lvl1.mod_id
                                           where lvl1.mod_id == lvl1modId && lvl1.usr_id== userId
                                           select lvl);

            obj.WMS_MSTR_LVL3M.RemoveRange(from lvl in obj.WMS_MSTR_LVL3M
                                           join lvl3 in obj.WMS_LVL3M_VIEW on lvl.s2mod_id equals lvl3.s2mod_id
                                           join lvl2 in obj.WMS_LVL2M_VIEW on lvl3.s1mod_id equals lvl2.s1mod_id
                                           join lvl1 in obj.WMS_LVL1M_VIEW on lvl2.mod_id equals lvl1.mod_id
                                           where lvl1.mod_id == lvl1modId && lvl1.usr_id == userId
                                           select lvl);

            obj.SaveChanges();
        }


        private void Lvl2DeleteModule()
        {
            //int s1mod_id = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value.ToString());


            //obj.WMS_MSTR_LVL2M.RemoveRange(from lvl2 in obj.WMS_MSTR_LVL2M
                                           
            //                               where lvl2.s1mod_id == s1mod_id
            //                               select lvl2);

            //obj.WMS_MSTR_LVL3M.RemoveRange(from lvl3 in obj.WMS_MSTR_LVL3M
            //                               join  lvl2View in obj.WMS_LVL2M_VIEW on lvl3.s2mod_id equals lvl2View.
            //                               join lvl2 in obj.WMS_LVL2M_VIEW on lvl3.s2mod_id equals lvl2.
            //                               where lvl2.lvl2mod_id == lvl2modId
            //                               select lvl3);
            //obj.SaveChanges();

        }


        private void Lvl3DeleteModule()
        {
            //int lvl3modId = Convert.ToInt32(dataGridView3.CurrentRow.Cells[6].Value.ToString());


            //obj.WMS_MSTR_LVL3M.RemoveRange(from lvl3 in obj.WMS_MSTR_LVL3M
                                         
            //                               where lvl3.lvl3mod_id == lvl3modId
            //                               select lvl3);

            //obj.SaveChanges();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==4)
            {

                DialogResult dialog = MessageBox.Show("Are you sure you want to remove " + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "?" , "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {

                    Lvl1DeleteModule();

                    MessageBox.Show("Successfully removed " + dataGridView1.CurrentRow.Cells[1].Value.ToString() + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    listItem();
                }
                else
                {

                }
         

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==6)
            {
                DialogResult dialog = MessageBox.Show("Are you sure you want to remove " + dataGridView2.CurrentRow.Cells[3].Value.ToString() + "? ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {

                    Lvl2DeleteModule();

                    MessageBox.Show("Successfully removed " + dataGridView2.CurrentRow.Cells[3].Value.ToString() + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    listItem();
                }
                else
                {

                }
    

            }

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 7)
            {
                DialogResult dialog = MessageBox.Show("Are you sure you want to remove " + dataGridView3.CurrentRow.Cells[3].Value.ToString() + "? ", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {

                    Lvl3DeleteModule();

                    MessageBox.Show("Successfully removed " + dataGridView3.CurrentRow.Cells[3].Value.ToString() + ".", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    listItem();
                }
                else
                {

                }


            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            searchUser();
        }

 
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string ModuleName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox8.Text = ModuleName;
            TabPage tabpage2 = tabControl1.TabPages[1];
            tabControl1.SelectedTab = tabpage2;

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string ModuleName = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            textBox9.Text = ModuleName;
            TabPage tabpage3 = tabControl1.TabPages[2];
            tabControl1.SelectedTab = tabpage3;
        }
    }
}
