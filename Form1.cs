using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DeveloperHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(textBox1.Text);
            var list = new List<KeyValuePair<string, string>>();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["UserInfoContext"]);
            SqlCommand com = new SqlCommand("SELECT distinct  path   FROM  bilmEventDim where EventID = 1 and IsActive = 1", con);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            var result = com.ExecuteReader();
            var dt = new DataTable();
            dt.Load(result);
            List<string> listing = dt.AsEnumerable()
                            .Select(r => r.Field<string>("path"))
                            .ToList();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            foreach (string str in listing)
            {
                if (xml.SelectSingleNode(str) != null)
                {
                    list.Add(new KeyValuePair<string, string>(xml.SelectSingleNode(str).Name, xml.SelectSingleNode(str).Value));
                }
                else {
                    break;
                }
            }

            List<string> allKeys = (from kvp in list select kvp.Key).Distinct().ToList();
            List<string> allValues = (from kvp in list select kvp.Value).Distinct().ToList();
            int i = 0;
            foreach (string str in allKeys)
            {
                textBox2.Text += str + "=" + allValues[i].ToString() + Environment.NewLine;

                i++;
            }
            dataGridView1.DataSource = list;

        }
    }
}
