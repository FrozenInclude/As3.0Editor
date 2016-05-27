using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Tester
{
    public partial class find : Form
    {
        As3Editor a;
        public find()
        {
            InitializeComponent();
        }
        public find(As3Editor _form)
        {
            InitializeComponent();
            a = _form;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Regex aa = new Regex(textBox1.Text);
                a.textBox1.SelectAll();
                a.textBox1.SelectionColor = Color.Black;
                // Then unselect and scroll to the end of the file
                a.textBox1.ScrollToCaret();
                a.textBox1.Select(a.textBox1.Text.Length, 1);

                // Start applying the highlighting... Set a value to selPos
                int selPos = a.textBox1.SelectionStart;

                foreach (Match keyWordMatch in aa.Matches(a.textBox1.Text))
                {
                   a.textBox1.Select(keyWordMatch.Index, keyWordMatch.Length);
                    // Change it to blueBox1.Select(keyWordMatch.Index, 
                    a.textBox1.SelectionColor = Color.Red;
                    // Set it to bold for this example
                    if (textBox2.Text != "")
                    {
                        a.textBox1.Select(keyWordMatch.Index, keyWordMatch.Length);
                        a.textBox1.SelectedText = textBox2.Text;
                    }
                    a.textBox1.SelectionFont = new Font(a.textBox1.SelectionFont, FontStyle.Regular);
                    //  cuMoversor back to where it was
                    a.textBox1.SelectionStart = selPos; 
                    // Change the default font color back to black.
                    a.textBox1.SelectionColor = Color.Black;
                     if (textBox2.Text!="")
                     {
                     a.textBox1.SelectedText = textBox2.Text;
                     }
                }
            }
            else
            {
                MessageBox.Show("찾을문자열을 입력해주세요!");
            }
        }

        private void photoshop1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
