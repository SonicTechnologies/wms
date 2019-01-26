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
using wms.Class;
using wms.Forms.Administration.Item;
using wms.Forms.Administration.SALESMAN;
using wms.Forms.Administration.SITE;
using wms.Forms.Administration.Customer;

namespace wms
{
    public partial class Main_Form : Form
    {
        public static Main_Form MainFormInstance = null;
        wmsdb obj = new wmsdb();

        public Main_Form()
        {
            InitializeComponent();
            AddItemsToModule();
        }

        void AddItemsToModule()
        {
            var modules = (from m in obj.WMS_LVL1M_VIEW where m.usr_id == loggedin_user.userId select new { m.mod_name, m.stat_desc });
            int i = 0;
            foreach (var mod in modules)
            {
                if (mod.stat_desc == "Active")
                {
                    modulesToolStripMenuItem.DropDownItems.Add(mod.mod_name);
                    modulesToolStripMenuItem.DropDownItems[i].Click += Main_Form_Click_Active;
                }
                else
                {
                    modulesToolStripMenuItem.DropDownItems.Add(mod.mod_name);
                    modulesToolStripMenuItem.DropDownItems[i].Click += Main_Form_Click_Inactive;
                }
                i = i + 1;
            }
        }

        private void Main_Form_Click_Active(object sender, EventArgs e)
        {
            if (sender.ToString().Contains("Inactive"))
            {
                MessageBox.Show("Inactive Module");
            }
            else
            {
                togglemenu();
                var xmod = sender as ToolStripMenuItem;
                getlvl1Node(xmod.Text);
            }
        }

        private void Main_Form_Click_Inactive(object sender, EventArgs e)
        {
            MessageBox.Show("Inactive Module");
       
        }

        public static Main_Form GetInstance()
        {
            if (Main_Form.MainFormInstance == null)
            {
                Main_Form.MainFormInstance = new Main_Form();
                Main_Form.MainFormInstance.FormClosed += new FormClosedEventHandler(MainFormInstance_FormClosed);
            }
            return Main_Form.MainFormInstance;
        }



        static void MainFormInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main_Form.MainFormInstance = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            togglemenu();
        }

        private void togglemenu()
        {
            if (panel1.Width == 30)
            {
                panel1.Width = 330;
                button1.Text = "<<";
            }
            else
            {
                panel1.Width = 30;
                button1.Text = ">>";
            }
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
        }

        private void Main_Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                togglemenu();
            }
            else if (e.KeyCode == Keys.Down)
            {
                
            }
        }

        private void getlvl1Node(string nodelvl1)
        {
            TreeNode main_node_lvl1;
            TreeNode child_node_lvl2;
            TreeNode child_node_lvl3;

            treeView1.Nodes.Clear();

            main_node_lvl1 = treeView1.Nodes.Add(nodelvl1.ToString().Replace("&",""));

            int lvl1nodeid = getlvl1id(nodelvl1.Replace("&", ""));

            var lvl2nodes = (from c in obj.WMS_MSTR_S1MODULE
                             where c.mod_id == lvl1nodeid
                             select new
                             {
                                 c.s1mod_id,
                                 c.s1mod_name

                             }).OrderBy(c => new { c.s1mod_id }).ToList();
            if (lvl2nodes.Count != 0)
            {

                foreach (var xnode1 in lvl2nodes)
                {
                    child_node_lvl2 = main_node_lvl1.Nodes.Add(xnode1.s1mod_name);
                    
                    int lvl2nodeid = getlvl2id(xnode1.s1mod_name);

                    var lvl3nodes = (from c in obj.WMS_MSTR_S2MODULE
                                     where c.s1mod_id == lvl2nodeid
                                     select new
                                     {
                                         c.s2mod_id,
                                         c.s2mod_name

                                     }).OrderBy(c => new { c.s2mod_id }).ToList();
                    if (lvl3nodes.Count != 0)
                    {

                        foreach (var xnode2 in lvl3nodes)
                        {
                            child_node_lvl3 = child_node_lvl2.Nodes.Add(xnode2.s2mod_name);
                            child_node_lvl3.NodeFont = new Font("Segoe UI", 8.75F, FontStyle.Regular);

                        }
                    }
                }
            }
        }

        private int getlvl1id(string nodelvl1)
        {   
            var lvl1nodeid = (from c in obj.WMS_MSTR_MODULE
                          where c.mod_name == nodelvl1
                          select c.mod_id).FirstOrDefault();
            return lvl1nodeid;
        }

        private int getlvl2id(string nodelvl2)
        {
            var lvl2nodeid = (from c in obj.WMS_MSTR_S1MODULE
                          where c.s1mod_name == nodelvl2
                          select c.s1mod_id).FirstOrDefault();
            return lvl2nodeid;
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            
            var xformname = (from c in obj.WMS_MSTR_S2MODULE
                             where c.s2mod_name == treeView1.SelectedNode.Text
                             select new
                             {
                                 c.s2mod_form_name,
                                 c.stat_id

                             }).OrderBy(c => new { c.s2mod_form_name }).ToList();
            if (xformname.Count != 0)
            {
                foreach (var xform in xformname)
                {
                    if (xform.stat_id == 1)
                    {
                        OpenForm(xform.s2mod_form_name);
                    }
                    else
                    {
                        MessageBox.Show("Module access: " + treeView1.SelectedNode.Text + " under maintenance", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
               
            }
        }

        private void OpenForm(String form_name)
        {
            if (form_name == "")
            {

            }
            else
            {
                Type xform;
                try
                {
                    System.Reflection.Assembly MyAssembly = System.Reflection.Assembly.LoadFrom(Application.ExecutablePath);
                    foreach (Type xforms in MyAssembly.GetTypes())
                    {
                        if (xforms.Name == form_name)
                        {
                            xform = xforms;

                            if (xform != null)
                            {
                                if (xform.BaseType == typeof(Form))
                                {
                                    Form frm = (Form)Activator.CreateInstance(xform);
                                    frm.MdiParent = this;
                                    frm.Show();
                                }
                            }
                        }
                    }
                }
                catch
                {

                }
            }
        }
    }
}
