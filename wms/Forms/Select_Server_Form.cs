using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;

namespace wms.Forms
{
    public partial class Select_Server_Form : Form
    {
        private DataTable serverList = new DataTable();
        private DataTable preserverList = new DataTable();
        private System.Data.Sql.SqlDataSourceEnumerator servers = System.Data.Sql.SqlDataSourceEnumerator.Instance;
        DataRow xrow;
        int dbcount;

        private static string default_server_file = "";

        public static string xip;
        public static string xserver_name;
        public static string xdbname;
        public static string xuser;
        public static string xpass;

        public static string dbconn;

        private static string x_ip
        {
            get { return xip; }
            set { xip = value; }

        }

        private static string x_servername
        {
            get { return xserver_name; }
            set { xserver_name = value; }

        }

        private static string x_dbname
        {
            get { return xdbname; }
            set { xdbname = value; }

        }

        private static string x_user
        {
            get { return xuser; }
            set { xuser = value; }

        }

        private static string x_xpass
        {
            get { return xpass; }
            set { xpass = value; }

        }

        private static string x_dbconn
        {
            get { return dbconn; }
            set { dbconn = value; }

        }
        public Select_Server_Form()
        {
            InitializeComponent();
        }

        private void Select_Server_Form_Load(object sender, EventArgs e)
        {
            Execute();
        }

        private void Select_Server_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login_Form.GetInstance().get_server();
            Login_Form.GetInstance().Show();
        }

        public static void setdbconn()
        {
            dbconn = "metadata=res://*/Entity Class.wmsdb.csdl|res://*/Entity Class.wmsdb.ssdl|res://*/Entity Class.wmsdb.msl;" +
                   "provider=System.Data.SqlClient;provider connection string='data source=" + xip + ",1433;" +
                   "initial catalog=" + xdbname + ";user id=" + xuser + ";password=" + xpass + ";MultipleActiveResultSets=True;App=EntityFramework'";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Execute()
        {
            //this.dataGridView1.Rows.Clear();
            //this.dataGridView1.Rows.Add("Obtaining server list.. Please wait..");
            this.dataGridView1.Rows.Clear();
            label1.Text = "Obtaining feeder database(s).. Please wait..";
            dbcount = 0;
            preserverList.Reset();
            preserverList.Columns.Add("ip");
            preserverList.Columns.Add("server");
            preserverList.Columns.Add("dbname");
            preserverList.Columns.Add("user");
            preserverList.Columns.Add("pass");

            BGworker1.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Execute();
        }

        public static void read_default_server()
        {

            if (Environment.Is64BitProcess)
            {
                default_server_file = @"C:\\Program Files\Sonic Sales & Distribution Inc\wms\default_server.txt";
            }
            else
            {
                default_server_file = @"C:\\Program Files (x86)\\Sonic Sales & Distribution Inc\\wms\\default_server.txt";
            }


            var data = File
                     .ReadAllLines(default_server_file)
                     .Select(x => x.Split('='))
                     .Where(x => x.Length > 1)
                     .ToDictionary(x => x[0].Trim(), x => x[1]);

            xip = data["1ip"].ToString().Trim();
            xserver_name = data["1server"].ToString().Trim();
            xdbname = data["1dbname"].ToString().Trim();
            xuser = data["1user"].ToString().Trim();
            xpass = data["1pass"].ToString().Trim();

        }

        private void BGworker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //serverList.Reset();
            //serverList = servers.GetDataSources();

            int scount;
            dbcount = 0;
            var data = File
                     .ReadAllLines(default_server_file)
                     .Select(x => x.Split('='))
                     .Where(x => x.Length > 1)
                     .ToDictionary(x => x[0].Trim(), x => x[1]);
            //MessageBox.Show("Main Server:\n\n" + "ip: " + data["mip"].ToString().Trim() + "\n" + "name: " + data["mserver"].ToString().Trim());
            //MessageBox.Show("Test Server:\n\n" + "ip: " + data["tip"].ToString().Trim() + "\n" + "name: " + data["tserver"].ToString().Trim());
            scount = data.Count / 5;

            for (int i = 1; i <= scount; i++)
            {

                Microsoft.SqlServer.Management.Smo.Server server = new Microsoft.SqlServer.Management.Smo.Server(data[i.ToString() + "server"].ToString().Trim());

                //MessageBox.Show(data[i.ToString() + "ip"].ToString().Trim() + "\n"
                //+ data[i.ToString() + "server"].ToString().Trim() + "\n"
                //+ data[i.ToString() + "user"].ToString().Trim() + "\n"
                //+ data[i.ToString() + "pass"].ToString().Trim());

                server.ConnectionContext.LoginSecure = false;
                server.ConnectionContext.Login = data[i.ToString() + "user"].ToString().Trim();
                server.ConnectionContext.Password = data[i.ToString() + "pass"].ToString().Trim();

                foreach (Microsoft.SqlServer.Management.Smo.Database db in server.Databases)
                {

                    if (db.Name.Contains("WMS"))
                    {


                        xrow = preserverList.NewRow();
                        xrow["ip"] = data[i.ToString() + "ip"].ToString().Trim();
                        xrow["server"] = data[i.ToString() + "server"].ToString().Trim();
                        xrow["dbname"] = db.Name;
                        xrow["user"] = data[i.ToString() + "user"].ToString().Trim();
                        xrow["pass"] = data[i.ToString() + "pass"].ToString().Trim();
                        //this.dataGridView1.Rows.Add(data[i.ToString() + "ip"].ToString().Trim(),
                        //data[i.ToString() + "server"].ToString().Trim(), db.Name,
                        //data[i.ToString() + "user"].ToString().Trim(),
                        //data[i.ToString() + "pass"].ToString().Trim());
                        dbcount = dbcount + 1;
                        preserverList.Rows.Add(xrow);

                    }

                    else
                    {

                    }

                }
            }
        }

        private void BGworker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            label1.Text = "Found Database (" + dbcount.ToString() + "):";



            foreach (DataRow rowServer in preserverList.Rows)
            {
                this.dataGridView1.Rows.Add(rowServer["ip"].ToString(),
                                            rowServer["server"].ToString(),
                                            rowServer["dbname"].ToString(),
                                            rowServer["user"].ToString(),
                                            rowServer["pass"].ToString());
            }

            //foreach (DataRow rowServer in serverList.Rows)
            //{
            //IPHostEntry host;
            //host = Dns.GetHostEntry(rowServer["ServerName"].ToString());

            //foreach (IPAddress ip in host.AddressList)
            //{
            //if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            //{

            //this.dataGridView1.Rows.Add(ip.ToString() + " - " + rowServer["ServerName"].ToString());

            //}
            //else
            //{

            //}

            //}

            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setserverproperties();
            this.Close();
        }

        private void setserverproperties()
        {
            xip = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            xserver_name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            xdbname = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            xuser = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            xpass = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
