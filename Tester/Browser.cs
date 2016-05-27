using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tester;
namespace Tester
{
    public partial class Browser : Form
    {
       As3Editor a;
        public Browser(As3Editor _form)
        {
            InitializeComponent();
            a = _form;
        }
        public Browser()
        {
            InitializeComponent();
        }

        public void Browser_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.adobe.com/devnet/flash.html");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            textBox1.Text = webBrowser1.Url.ToString();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked==true)
            {
                webBrowser1.ScriptErrorsSuppressed = true;
            } 
            else
            {
                webBrowser1.ScriptErrorsSuppressed = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }
        public void photoshop1_Load(object sender, EventArgs e)
        {

        }
    }
}
