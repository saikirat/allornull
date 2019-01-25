using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeveloperHelper
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "";
           foreach(var file in System.IO.Directory.EnumerateFiles(@""))
            {
                str = str + ExtractHtmlInnerText(File.ReadAllText(file)) + Environment.NewLine + Environment.NewLine + "*********************" + Environment.NewLine + Environment.NewLine;

            }
        }
        public static string ExtractHtmlInnerText(string htmlText)
            {
                //Match any Html tag (opening or closing tags) 
                // followed by any successive whitespaces
                //consider the Html text as a single line

                Regex regex = new Regex("(<.*?>\\s*)+", RegexOptions.Singleline);

                // replace all html tags (and consequtive whitespaces) by spaces
                // trim the first and last space

                string resultText = regex.Replace(htmlText, Environment.NewLine+Environment.NewLine).Trim();

                return resultText;
            }
    }
}
