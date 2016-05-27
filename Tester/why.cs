using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;


namespace Tester
{
    public partial class why : Form
    {

        private const int SC_CLOSE = 0xF060;
        private const int MF_ENABLED = 0x0;
        private const int MF_GRAYED = 0x1;
        private const int MF_DISABLED = 0x2;

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        private static extern int EnableMenuItem(IntPtr hMenu, int wIDEnableItem, int wEnable);
        public why()
        {
            InitializeComponent();

        }

        private void why_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Dispose(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose(true);
            //As3Editor set = new As3Editor();
            //set.Show();
            //this.Controls.Remove(this);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("bof!", "bufger danger expection active carsloin", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
        private void listBox1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        private void listBox1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
                listBox1.Items.Add(s[i]);
        }
        private void photoshop1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseDoubleClick(object sender, EventArgs e)
        {
            As3Editor asd = new As3Editor(this);
            string dir = "";
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.GetSelected(i) == false)
                    MessageBox.Show("파일을선택해주세요!", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    asd.Show();
                    string ProgramPath =listBox1.SelectedItem.ToString();
                    //열기한 파일의 전체 경로를 반환한다.
                    asd.label3.Text =listBox1.SelectedItem.ToString();
                    TextReader tr = new StreamReader(listBox1.SelectedItem.ToString()); //파일 읽기
                    asd.textBox1.Text = tr.ReadToEnd(); ;
                }
            }
        }
    }
}