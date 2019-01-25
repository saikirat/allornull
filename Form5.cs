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
using System.Xml.Serialization;

namespace DeveloperHelper
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            test test = new test();
            test.Test();
        }
    }
    public class test
    {

        public void Test()
        {
            List<Integration> list = new List<Integration>();
            list.Add(new Integration() { Code = "AON.businesslogc.Customer1.Save", SqlKey = "getcustomerxml1", ApiAddress = "http://localhost:1232/api/Customer1" });
            list.Add(new Integration() { Code = "AON.businesslogc.Customer2.Save", SqlKey = "getcustomerxml2", ApiAddress = "http://localhost:1232/api/Customer2" });
            list.Add(new Integration() { Code = "AON.businesslogc.Customer3.Save", SqlKey = "getcustomerxml3", ApiAddress = "http://localhost:1232/api/Customer3" });
            list.Add(new Integration() { Code = "AON.businesslogc.Customer4.Save", SqlKey = "getcustomerxml4", ApiAddress = "http://localhost:1232/api/Customer4" });
            list.Add(new Integration() { Code = "AON.businesslogc.Customer5.Save", SqlKey = "getcustomerxml5", ApiAddress = "http://localhost:1232/api/Customer5" });

            //XmlSerializer ser = new XmlSerializer(typeof(Dictionary<string, Integration>));
            XmlSerializer ser = new XmlSerializer(typeof(List<Integration>));
            //Serialize
            Stream filestream = File.Create("Integrations.xml");
            ser.Serialize(filestream, list);
            filestream.Flush();
            filestream.Close();

            //Deserialize
            Stream filestream2 = File.OpenRead("Integrations.xml");
            list = ser.Deserialize(filestream2) as List<Integration>;
            filestream2.Close();


        }


    }
    public class Integration
    {
        [XmlAttribute]
        public string Code { get; set; }
        [XmlAttribute]
        public string SqlKey { get; set; }
        [XmlAttribute]
        public string ApiAddress { get; set; }
    }
}
