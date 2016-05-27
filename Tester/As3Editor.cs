using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.Text.RegularExpressions;
using AutocompleteMenuNS;
using System.Runtime.InteropServices;
using Tester;
//using cSoundProj;
using System.Threading;
using Microsoft.Win32;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Net;
using System.Net.Sockets;
using System.Drawing.Printing;

namespace Tester
{
    public partial class As3Editor : Form
    {
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int system(string cmd);
        private Socket m_ClientSocket;
        public string ca;
        bool socketC = true;
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);
        public static void Associate(string extension,
         string progID, string description, string icon, string application)
        {
            Registry.ClassesRoot.CreateSubKey(extension).SetValue("", progID);
            if (progID != null && progID.Length > 0)
                using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(progID))
                {
                    if (description != null)
                        key.SetValue("", description);
                    if (icon != null)
                        key.CreateSubKey("DefaultIcon").SetValue("", ToShortPathName(icon));
                    if (application != null)
                        key.CreateSubKey(@"Shell\Open\Command").SetValue("",
                                    ToShortPathName(application) + " \"%1\"");
                }
        }
        why asdf;
        public As3Editor(why _form)
        {
            InitializeComponent();
            asdf = _form;
        }
        // Return true if extension already associated in registry
        public static bool IsAssociated(string extension)
        {
            return (Registry.ClassesRoot.OpenSubKey(extension, false) != null);
        }

        [DllImport("Kernel32.dll")]
        private static extern uint GetShortPathName(string lpszLongPath,
            [Out] StringBuilder lpszShortPath, uint cchBuffer);

        // Return short path format of a file name
        private static string ToShortPathName(string longName)
        {
            StringBuilder s = new StringBuilder(1000);
            uint iSize = (uint)s.Capacity;
            uint iRet = GetShortPathName(longName, s, iSize);
            return s.ToString();
        }

        public As3Editor()
        {
            InitializeComponent();
            BuildAutocompleteMenu();
            this.notifyIcon1.DoubleClick += notifyIcon1_DoubleClick;
            if (!As3Editor.IsAssociated(".as"))
                Associate(".as", "ClassID.ProgID", "ext File", "YourIcon.ico", @"C:\Users\Administrator\Desktop\As3Editor\Tester\bin\Release\Tester.exe");
        }
        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string str in file)
                {
                    this.textBox1.Text += str + "\r" + "\n";
                }
            }
        }
        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy | DragDropEffects.Scroll;
            }
        }



        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            char[] param = { '\n' };

            if (printDialog1.PrinterSettings.PrintRange == PrintRange.Selection)
            {
                lines = rtbText.SelectedText.Split(param);
            }
            else
            {
                lines = rtbText.Text.Split(param);
            }

            int i = 0;
            char[] trimParam = { '\r' };
            foreach (string s in lines)
            {
                lines[i++] = s.TrimEnd(trimParam);
            }
        }
        private int linesPrinted;
        private string[] lines;
        private void OnPrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            Brush brush = new SolidBrush(rtbText.ForeColor);

            while (linesPrinted < lines.Length)
            {
                e.Graphics.DrawString(lines[linesPrinted++],
                    rtbText.Font, brush, x, y);
                y += 15;
                if (y >= e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            linesPrinted = 0;
            e.HasMorePages = false;
        }





        public string localmusic = @"Music\DeMoSong.mp3";
        public Regex keyWordsGreenComment = new Regex(@"//[\[\]$$/=+_\-\%!,:\(\)\?\. ㄱ-힣0-9a-zA-Z]{1,200}");
        public Regex redsa = new Regex(@"not_set_yet");
        //public Regex keyWor = new Regex("\"[A-Za-z0-9_]{1,200}\"|\"\"|\'[A-Za-z0-9_]{1,200}\'");
        //public Regex keyWorkor = new Regex("\"[9ㄱ-ㅎ|가-힣|a-z|A-Z|0-]{1,200}\"|\"\"|\'[ㄱ-ㅎ|가-힣|a-z|A-Z|0-9]{1,200}\'");
        public Regex wordRed = new Regex(@"flash.display|flash.display3D|flash.display3D.textures|flash.errors|flash.events|flash.external|flash.filesystem|flash.filters|flash.geom|flash.globalization|flash.html|flash.media|flash.net|flash.net.dns|flash.net.drm|flash.notifications|flash.printing|flash.profiler|flash.sampler|flash.security|flash.sensors|flash.system|flash.text|flash.text.engine|flash.text.ime|flash.ui");
        public Regex keyWorkor = new Regex(@"'[\[\]$$/=+_\-\%!,:\(\)\?\.ㄱ-ㅎ|가-힣|a-z|A-Z|0-9|\s]{1,200}'|''");
        public Regex keyWor = new Regex(@"""[\[\]$$/=+_\-\%!,:\(\)\?\.ㄱ-ㅎ|가-힣|a-z|A-Z|0-9|\s]{1,200}""|""");
        public Regex keyWors = new Regex(@"/[A-Za-z0-9_\s]/{1,200}");
        public Regex keyWordsPurple = new Regex(@"var\s|try|catch|return\s|private\s|class\s|public\s|new\s|package|function |extends\s|import|is\|void|static|if[()]|then|else|true|while[()]|for[()]|do{|done|set|export|Boolean|break|case|<|>|<=|>=|!=");
        public Regex keyWordsConst = new Regex(@"mouseX|mouseY|ENTER_FRAME|MOUSE_DOWN|MOUSE_UP|NaN|undefined|Event[\s|)|.]|MouseEvent[\s|.|)]|class(.*|{)");
        public Regex keyWordsBlack = new Regex("var[A-Za-z0-9_]|try[A-Za-z0-9_]|catch[A-Za-z0-9_]|return[A-Za-z0-9_]|private[A-Za-z0-9_]|class[A-Za-z0-9_]|public[A-Za-z0-9_]|new[A-Za-z0-9_]|package[A-Za-z0-9_]|extends[A-Za-z0-9_]|import[A-Za-z0-9_]|function[A-Za-z0-9_]");
        public Regex keyWordsBlue = new Regex(@"[:|\s]+int[;|=]|[:|\s]+Number[;|=]|[:|\s]+uint[;|=]|[:|\s]+String[;|=|\s]|this|trace|addEventListener[()]|dispatchEvent[()]|removeEventlistener[()]|[:|\s]+Array[;|=|\s|(]|MovieClip|root|flash|display|const|stage|toString|true|false|Math|Namespace|object|Sprite|[:]+void|[.]+text|[.]+autoSize|[:]+TextField|TextField|addChild[()]|[.]+x|[.]+y|random[()]|alpha|rotation|scaleX|scaleY|removeEventListener[()]|null|[.]+graphics|[.]+lineto");
        private void ApplySyntaxHighlighting()
        {
            // Select all and set to black so that it's 'clean'

            rtbText.SelectAll();
            rtbText.SelectionColor = Color.Black;

            // Then unselect and scroll to the end of the file
            rtbText.ScrollToCaret();
            rtbText.Select(rtbText.Text.Length, 1);

            // Start applying the highlighting... Set a value to selPos
            int selPos = rtbText.SelectionStart;

            foreach (Match keyWordMatch in keyWordsBlue.Matches(rtbText.Text))
            {
                // Select the word..
                rtbText.Select(keyWordMatch.Index, keyWordMatch.Length);
                // Change it to blue
                rtbText.SelectionColor = Color.DeepSkyBlue;
                // Set it to bold for this example

                //  cuMoversor back to where it was
                rtbText.SelectionStart = selPos;
                // Change the default font color back to black.
                rtbText.SelectionColor = Color.Black;
            }
            foreach (Match keyWordMatch in keyWordsConst.Matches(rtbText.Text))
            {
                // Select the word..
                rtbText.Select(keyWordMatch.Index, keyWordMatch.Length);
                // Change it to blue
                rtbText.SelectionColor = Color.DeepSkyBlue;
                // Set it to bold for this example

                //  cuMoversor back to where it was
                rtbText.SelectionStart = selPos;
                // Change the default font color back to black.
                rtbText.SelectionColor = Color.Black;
            }
            foreach (Match keyWordMatch in redsa.Matches(rtbText.Text))
            {
                // Select the word..
                rtbText.Select(keyWordMatch.Index, keyWordMatch.Length);
                // Change it to blue
                rtbText.SelectionColor = Color.Red;
                // Set it to bold for this example

                //  cuMoversor back to where it was
                rtbText.SelectionStart = selPos;
                // Change the default font color back to black.
                rtbText.SelectionColor = Color.Black;
            }
            foreach (Match keyWordMatch in keyWordsBlack.Matches(rtbText.Text))
            {
                // Select the word..
                rtbText.Select(keyWordMatch.Index, keyWordMatch.Length);
                // Change it to blue
                rtbText.SelectionColor = Color.Black;
                // Set it to bold for this example

                //  cuMoversor back to where it was
                rtbText.SelectionStart = selPos;
                // Change the default font color back to black.
                rtbText.SelectionColor = Color.Black;
            }

            foreach (Match keyWordMatch in wordRed.Matches(rtbText.Text))
            {
                // Select the word..
                rtbText.Select(keyWordMatch.Index, keyWordMatch.Length);
                // Change it to blue
                rtbText.SelectionColor = Color.DeepSkyBlue;
                // Set it to bold for this example

                // Move cursor back to where it was
                rtbText.SelectionStart = selPos;
                // Change the default font color back to black.
                rtbText.SelectionColor = Color.Black;
            }




            foreach (Match keyWordMatch in keyWordsGreenComment.Matches(rtbText.Text))
            {
                // Select the word..
                rtbText.Select(keyWordMatch.Index, keyWordMatch.Length);
                // Change it to blue
                rtbText.SelectionColor = Color.Green;
                // Set it to bold for this example

                // Move cursor back to where it was
                rtbText.SelectionStart = selPos;
                // Change the default font color back to black.
                rtbText.SelectionColor = Color.Black;
            }
            foreach (Match keyWordMatch in keyWor.Matches(rtbText.Text))
            {
                // Select the word..
                rtbText.Select(keyWordMatch.Index, keyWordMatch.Length);
                // Change it to blue
                rtbText.SelectionColor = Color.Red;
                // Set it to bold for this example

                // Move cursor back to where it was
                rtbText.SelectionStart = selPos;
                // Change the default font color back to black.
                rtbText.SelectionColor = Color.Black;
            }
            foreach (Match keyWordMatch in keyWors.Matches(rtbText.Text))
            {
                // Select the word..
                rtbText.Select(keyWordMatch.Index, keyWordMatch.Length);
                // Change it to blue
                rtbText.SelectionColor = Color.Green;
                // Set it to bold for this example

                // Move cursor back to where it was
                rtbText.SelectionStart = selPos;
                // Change the default font color back to black.
                rtbText.SelectionColor = Color.Black;
            }

            foreach (Match keyWordMatch in keyWorkor.Matches(rtbText.Text))
            {
                // Select the word..
                rtbText.Select(keyWordMatch.Index, keyWordMatch.Length);
                // Change it to blue
                rtbText.SelectionColor = Color.Red;
                // Set it to bold for this example

                // Move cursor back to where it was
                rtbText.SelectionStart = selPos;
                // Change the default font color back to black.
                rtbText.SelectionColor = Color.Black;
            }



            foreach (Match keyWordMatch in keyWordsPurple.Matches(rtbText.Text))
            {
                // Select the word..
                rtbText.Select(keyWordMatch.Index, keyWordMatch.Length);
                // Change it to blue
                rtbText.SelectionColor = Color.DeepPink;
                // Set it to bold for this example
                // Move cursor back to where it was
                rtbText.SelectionStart = selPos;
                // Change the default font color back to black.
                rtbText.SelectionColor = Color.Black;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ca = ConvertRtbToHTML(rtbText);
            numberLable.Font = new Font(rtbText.Font.FontFamily, rtbText.Font.Size + 1.019f);
            label1.Text = "문자수:" + Convert.ToString(rtbText.TextLength);
            label2.Text = "줄:" + Convert.ToString(rtbText.Lines.Length);
            rtbText.Text = textBox1.Text;
            ApplySyntaxHighlighting();

        }


        private void rtbText_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void 제작자블로그ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", "http://blog.naver.com/abc6271416");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void 불러오기ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(label3.Text + "를 저장하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    FileStream fs = new FileStream(df, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(textBox1.Text); // 파일 저장
                    label3.Text = Path.GetFileName(sfd.FileName);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
            }
            catch (System.ArgumentException E)
            {
                string dir = "";

                sfd.Filter = "ActionScript 파일(*.as)|무제.as";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    dir = sfd.FileName;
                    FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(textBox1.Text); // 파일 저장
                    label3.Text = Path.GetFileName(sfd.FileName);
                    df = sfd.FileName;
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
            }
            OpenFileDialog openPanel = new OpenFileDialog();
            openPanel.InitialDirectory = "C:\\";
            openPanel.DefaultExt = "*.as";
            openPanel.Filter = "ActionScript 파일(*.as)|*.as";
            if (openPanel.ShowDialog() == DialogResult.OK)
            {
                string ProgramPath = openPanel.FileName;
                //열기한 파일의 전체 경로를 반환한다.
                label3.Text = openPanel.SafeFileName;
                TextReader tr = new StreamReader(openPanel.FileName); //파일 읽기
                textBox1.Text = tr.ReadToEnd(); ;
            }
        }

        private void updateNumberLabel()
        {
            //we get index of first visible char and number of first visible line
            Point pos = new Point(0, 0);
            int firstIndex = rtbText.GetCharIndexFromPosition(pos);
            int firstLine = rtbText.GetLineFromCharIndex(firstIndex);

            //now we get index of last visible char and number of last visible line
            pos.X = ClientRectangle.Width;
            pos.Y = ClientRectangle.Height;
            int lastIndex = rtbText.GetCharIndexFromPosition(pos);
            int lastLine = rtbText.GetLineFromCharIndex(lastIndex);

            //this is point position of last visible char, we'll use its Y value for calculating numberLabel size
            pos = rtbText.GetPositionFromCharIndex(lastIndex);


            //finally, renumber label
            numberLable.Text = "";
            for (int i = firstLine; i <= lastLine + 1; i++)
            {
                numberLable.Text += i + 1 + "\n";
            }

        }

        private void textBox1_VScroll(object sender, EventArgs e)
        {
            //move location of numberLabel for amount of pixels caused by scrollbar
            int d = rtbText.GetPositionFromCharIndex(0).Y % (rtbText.Font.Height + 1);
            numberLable.Location = new Point(0, d);
            updateNumberLabel();

            int nPos = GetScrollPos(textBox1.Handle, (int)ScrollBarType.SbVert);
            nPos <<= 16;
            uint wParam = (uint)ScrollBarCommands.SB_THUMBPOSITION | (uint)nPos;
            SendMessage(rtbText.Handle, (int)Message.WM_VSCROLL, new IntPtr(wParam), new IntPtr(0));
        }
        private void textBox1_Resize(object sender, EventArgs e)
        {
            textBox1_VScroll(null, null);
        }

        private void textBox1_FontChanged(object sender, EventArgs e)
        {
            updateNumberLabel();
            textBox1_VScroll(null, null);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        string df;
        SaveFileDialog sfd = new SaveFileDialog();
        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dir = "";

            sfd.Filter = "ActionScript 파일(*.as)|무제.as";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                dir = sfd.FileName;
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(textBox1.Text); // 파일 저장
                label3.Text = Path.GetFileName(sfd.FileName);
                df = sfd.FileName;
                sw.Flush();
                sw.Close();
                fs.Close();
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            rtbText.Text = textBox1.Text;
            label1.Text = "문자수:" + Convert.ToString(rtbText.TextLength);
            label2.Text = "줄:" + Convert.ToString(rtbText.Lines.Length);
        }
        string[] keywords = { "Event.ENTER_FRAME", "MouseEvent.MOUSE_DOWN|MOUSE_UP", "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "sprite", "is", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while", "add", "alias", "ascending", "descending", "dynamic", "from", "get", "global", "group", "into", "join", "let", "orderby", "partial", "remove", "select", "set", "value", "var", "where", "yield", "import", "import adobe.utils;", "import air.desktop;", "import air.net;", "패키지다적을려면자살충동", "import air.update;", "import air.update.events;", "import com.adobe.viewsource;", "import fl.accessibility;", "import fl.containers;", "import fl.controls;", "import fl.controls.dataGridClasses;", "import fl.controls.listClasses;", "import fl.controls.progressBarClasses;", "import fl.core;", "import fl.data;", "import fl.display;", "import fl.events;", "import fl.ik;", "import fl.lang;", "import fl.livepreview;", "import fl.managers;", "import fl.motion;", "import fl.motion.easing;", "import fl.rsl;", "import fl.text;", "import fl.transitions;", "import fl.transitions.easing;", "import fl.video;", "import flash.accessibility;", "import flash.concurrent;", "import flash.crypto;", "import flash.data;", "import flash.desktop;", "import flash.display;", "import flash.display3D;", "import flash.display3D.textures;", "import flash.errors;", "import flash.events;", "import flash.external;", "import flash.filesystem;", "import flash.filters;", "import flash.geom;", "import flash.globalization;", "import flash.html;", "import flash.media;", "import flash.net;", "import flash.net.dns;", "import flash.net.drm;", "import flash.notifications;", "import flash.printing;", "import flash.profiler;", "import flash.sampler;", "import flash.security;", "import flash.sensors;", "import flash.system;", "import flash.text;", "import flash.text.engine;", "import flash.text.ime;", "import flash.ui;", "import flash.utils;", "import flash.xml;", "import flashx.textLayout;", "import flashx.textLayout.compose;", "import flashx.textLayout.container;", "import flashx.textLayout.conversion;", "import flashx.textLayout.edit;", "import flashx.textLayout.elements;", "import flashx.textLayout.events;", "import flashx.textLayout.factory;", "import flashx.textLayout.formats;", "import flashx.textLayout.operations;" };
        string[] methods = { "toString(^)", "trace(^)" };
        string[] snippets = { @"if(^)\r\n{\r\n}", "if(^)\r\n{\r\n}\r\nelse\r\n{\r\n}", "for(^;;)\r\n{\r\n}", "while(^)\r\n{\r\n}", "do${\r\n^}while();", "switch(^)\r\n{\r\n\tcase : break;\r\n}", "trace(^);", "removeEventListener(^)", "addEventListener(^)", "toString()", "var", "var ^:int", "var ^:String", "var ^:uint", @"var [a-zA-Z_$][a-zA-Z1-9_$]*:[^\s]" };
        string[] declarationSnippets = { 
               "public class ^\n{\n}", "private class ^\n{\n}", "internal class ^\n{\n}",
               "public struct ^\n{\n}", "private struct ^\n{\n}", "internal struct ^\n{\n}",
               "public void ^()\n{\n}", "private void ^()\n{\n}", "internal void ^()\n{\n}", "protected void ^()\n{\n}",
               "public ^{ get; set; }", "private ^{ get; set; }", "internal ^{ get; set; }", "protected ^{ get; set; }","(^)","{^}","[^]"
               };
        private void BuildAutocompleteMenu()
        {
            var items = new List<AutocompleteItem>();

            foreach (var item in snippets)
                items.Add(new SnippetAutocompleteItem(item) { ImageIndex = 1 });
            foreach (var item in declarationSnippets)
                items.Add(new DeclarationSnippet(item) { ImageIndex = 0 });
            foreach (var item in methods)
                items.Add(new MethodAutocompleteItem(item) { ImageIndex = 2 });
            foreach (var item in keywords)
                items.Add(new AutocompleteItem(item));

            items.Add(new InsertSpaceSnippet());
            items.Add(new InsertSpaceSnippet(@"^(\w+)([=<>!:]+)(\w+)$"));
            items.Add(new InsertEnterSnippet());

            //set as autocomplete source
            autocompleteMenu1.SetAutocompleteItems(items);
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            // rtbText.ScrollBars=
            rtbText.Text = textBox1.Text;
            label1.Text = "문자수:" + Convert.ToString(rtbText.TextLength);
            label2.Text = "줄:" + Convert.ToString(rtbText.Lines.Length);
            if (checkBox1.Checked)
            {
                try
                {

                    FileStream fs = new FileStream(df, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(textBox1.Text); // 파일 저장
                    label3.Text = Path.GetFileName(sfd.FileName);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }

                catch (System.ArgumentException ex)
                {
                    string dir = "";
                    checkBox1.Checked = false;
                    sfd.Filter = "ActionScript 파일(*.as)|무제.as";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        dir = sfd.FileName;
                        FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fs);
                        sw.WriteLine(textBox1.Text); // 파일 저장
                        label3.Text = Path.GetFileName(sfd.FileName);
                        df = sfd.FileName;
                        sw.Flush();
                        sw.Close();
                        fs.Close();
                    }
                }
            }
        }
        string first;
        private void As3Editor_Load(object sender, EventArgs e)
        {
            textBox1.AllowDrop = true;
            //Thread time = new Thread(GetTime);
            //time.IsBackground = true;
            //time.Start();
            //CheckForIllegalCrossThreadCalls = false;
            if (checkBox2.Checked == true)
            {
                ApplySyntaxHighlighting();
            }
            first = textBox1.Text;
            label4.Text = DateTime.Now.ToString("HH:MM:SS");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //rtbText.SelectionStart = rtbText.Text.Length;
            // rtbText.ScrollToCaret();
            rtbText.Select(rtbText.TextLength - 1, rtbText.TextLength);
            rtbText.ScrollToCaret();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }



        public enum ScrollBarType : uint
        {
            SbHorz = 0,
            SbVert = 1,
            SbCtl = 2,
            SbBoth = 3
        }

        public enum Message : uint
        {
            WM_VSCROLL = 0x0115
        }

        public enum ScrollBarCommands : uint
        {
            SB_THUMBPOSITION = 4
        }

        [DllImport("User32.dll")]
        public extern static int GetScrollPos(IntPtr hWnd, int nBar);

        [DllImport("User32.dll")]
        public extern static int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        private void 샌드박스ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", "http://cafe.naver.com/sdbx");
        }

        private void 쉬프트ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", "http://cafe.naver.com/shiftouch");
        }

        private void mKProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", "http://cafe.naver.com/rnalghrhfl");
        }

        private void 새파일ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {

                FileStream fs = new FileStream(df, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(textBox1.Text); // 파일 저장
                label3.Text = Path.GetFileName(sfd.FileName);
                sw.Flush();
                sw.Close();
                fs.Close();
            }

            catch (System.ArgumentException ex)
            {
                string dir = "";

                sfd.Filter = "ActionScript 파일(*.as)|무제.as";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    dir = sfd.FileName;
                    FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(textBox1.Text); // 파일 저장
                    label3.Text = Path.GetFileName(sfd.FileName);
                    df = sfd.FileName;
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
            }


        }

        private void toolStripLabel4_Click_1(object sender, EventArgs e)
        {

        }

        private void newProjectToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(label3.Text + "를 저장하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    FileStream fs = new FileStream(df, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(textBox1.Text); // 파일 저장
                    //label3.Text = Path.GetFileName(sfd.FileName);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                    textBox1.Text = first;
                    label3.Text = "무제.as";
                }
                else
                {
                    textBox1.Text = first;
                    label3.Text = "무제.as";
                }
            }
            catch (System.Exception Ex)
            {
                string dir = "";

                sfd.Filter = "ActionScript 파일(*.as)|무제.as";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    dir = sfd.FileName;
                    FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(textBox1.Text); // 파일 저장
                    label3.Text = Path.GetFileName(sfd.FileName);
                    df = sfd.FileName;
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
            }
        }


        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {

        }


        private void 재생ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                mciSendString("open \"" + localmusic + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);
                mciSendString("play MediaFile", null, 0, IntPtr.Zero);
                //label3.Text = localmusic;
            }
            catch (FileNotFoundException ed)
            {
                MessageBox.Show("프로그램의 오류가 발생하였습니다.\n\n오류유형:FileNotFoundException", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose(true);
                버그리포터 a = new 버그리포터();
                a.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString("HH:MM:SS");
        }
        /*
        public void GetTime()
        {
            while (true)
            {
                label4.Text = DateTime.Now.ToString("HH:MM:SS");
            }
        }*/


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void numberLable_Click(object sender, EventArgs e)
        {

        }


        private void formEnd_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void start()
        {

            //Network 변수
            StreamWriter DosWriter;
            StreamReader DosRedaer;
            StreamReader ErrorReader;

            //프로세스 생성및 초기화
            Process DosPr = new Process();

            ProcessStartInfo psI = new ProcessStartInfo("cmd");
            psI.UseShellExecute = false;
            psI.RedirectStandardInput = true;
            psI.RedirectStandardOutput = true;
            psI.RedirectStandardError = true;
            psI.CreateNoWindow = true;


            //명령 실행
            DosPr.StartInfo = psI;
            DosPr.Start();
            DosWriter = DosPr.StandardInput;
            DosRedaer = DosPr.StandardOutput;
            ErrorReader = DosPr.StandardError;

            DosWriter.AutoFlush = true;
            if (okok == true && comboBox1.SelectedText == "AS3.0")
            {
                DosWriter.WriteLine(GetFullPathWithoutExtension(sfd.FileName) + ".swf");
                DosWriter.WriteLine("mxmlc " + Path.GetFullPath(sfd.FileName));
                DosWriter.Close();
                textBox2.Text = DosRedaer.ReadToEnd();
                textBox2.Text += ErrorReader.ReadToEnd();
            }
            else if (okok == false)
            {
                MessageBox.Show(".파일을먼저저장시켜주세요!!");
            }
        }
        public static String GetFullPathWithoutExtension(String path)
        {
            return System.IO.Path.Combine(System.IO.Path.GetDirectoryName(path), System.IO.Path.GetFileNameWithoutExtension(path));
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.start();
            //system("mxmlc "+Path.GetFullPath(sfd.FileName));
            //System.Diagnostics.Process.Start("cmd.exe",Path.GetFullPath(sfd.FileName) + ".swf");
            //System.Diagnostics.Process.Start("cmd.exe",Path.GetFullPath(sfd.FileName) + ".swf");
            //label3.Text = Path.GetFullPath(sfd.FileName) + ".swf";
            //system(Path.GetFileNameWithoutExtension(sfd.FileName) + ".swf");
            //System.Diagnostics.Process.Start(Path.GetFileNameWithoutExtension(sfd.FileName));
            //System.Diagnostics.Process.Start(Path.GetFileNameWithoutExtension(sfd.FileName)+".swf");
            //system("mxmlc" + sfd.);
            //MessageBox.Show("Flex sdk가 없어 컴파일을 할수없습니다.\n설치해주세요", "SDK Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //MessageBox.Show("프로그램에 끝이 없습니다.", "구문오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void abc6271416ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            Browser A = new Browser();

            // Show the settings form
            A.Show();

        }
        private void Receive_Completed(object sender, SocketAsyncEventArgs e)
        {
            Socket ClientSocket = (Socket)sender;
            if (ClientSocket.Connected && e.BytesTransferred > 0)
            {
                byte[] szData = e.Buffer;    // 데이터 수신
                string sData = Encoding.Unicode.GetString(szData);

                string Test = sData.Replace("\0", "").Trim();
                SetText(Test);
                for (int i = 0; i < szData.Length; i++)
                {
                    szData[i] = 0;
                }
                e.SetBuffer(szData, 0, 1024);
                m_ClientSocket.ReceiveAsync(e);
            }
            else
            {
                m_ClientSocket.Disconnect(false);
                m_ClientSocket.Dispose();
            }
        }
        private delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            if (textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                textBox1.Text = text;
                textBox1.ScrollToCaret();
            }
        }
        public string html
        {
            get { return ConvertRtbToHTML(rtbText); }
        }  
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ca = ConvertRtbToHTML(rtbText);
            rtbText.Text = textBox1.Text;
            updateNumberLabel();
           if (checkBox2.Checked == false)
            {
                rtbText.SelectAll();
                rtbText.SelectionColor = Color.Black;
            }
            else
            {
                ApplySyntaxHighlighting();
            }
            label1.Text = "문자수:" + Convert.ToString(rtbText.TextLength);
            int Line = textBox1.GetLineFromCharIndex(textBox1.GetFirstCharIndexOfCurrentLine()) + 1;

            label2.Text = "줄:" + Line;
            if (자동저장ToolStripMenuItem.Checked)
            {
                try
                {

                    FileStream fs = new FileStream(df, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(textBox1.Text); // 파일 저장
                    label3.Text = Path.GetFileName(sfd.FileName);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }

                catch (System.ArgumentException ex)
                {
                    string dir = "";
                    checkBox1.Checked = false;
                    sfd.Filter = "ActionScript 파일(*.as)|무제.as";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        dir = sfd.FileName;
                        FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fs);
                        sw.WriteLine(textBox1.Text); // 파일 저장
                        label3.Text = Path.GetFileName(sfd.FileName);
                        df = sfd.FileName;
                        sw.Flush();
                        sw.Close();
                        fs.Close();
                    }
                }
            }
        }
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int Line = textBox1.GetLineFromCharIndex(textBox1.GetFirstCharIndexOfCurrentLine()) + 1;
            label2.Text = "줄:" + Line;
            //string a=Convert.ToString(textBox1.GetLineFromCharIndex(textBox1.GetFirstCharIndexOfCurrentLine()+1));
            //MessageBox.Show(a);
        }
        private void rtbText_TextChanged_1(object sender, EventArgs e)
        {
            updateNumberLabel();
            rtbText.Text = textBox1.Text;
            if (checkBox1.Checked)
            {
                try
                {

                    FileStream fs = new FileStream(df, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(textBox1.Text); // 파일 저장
                    label3.Text = Path.GetFileName(sfd.FileName);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }

                catch (System.ArgumentException ex)
                {
                    string dir = "";
                    checkBox1.Checked = false;
                    sfd.Filter = "ActionScript 파일(*.as)|무제.as";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        dir = sfd.FileName;
                        FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fs);
                        sw.WriteLine(textBox1.Text); // 파일 저장
                        label3.Text = Path.GetFileName(sfd.FileName);
                        df = sfd.FileName;
                        sw.Flush();
                        sw.Close();
                        fs.Close();
                    }
                }
            }
        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            Clipboard.SetText(rtbText.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtbText.Text);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                rtbText.SelectAll();
                rtbText.SelectionColor = Color.Black;
            }
            else
            {
                ApplySyntaxHighlighting();
            }


        }

        private void photoshop1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }


        private void 저장ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void photoshop1_Load_1(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(label3.Text + "를 저장하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    FileStream fs = new FileStream(df, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(textBox1.Text); // 파일 저장
                    //label3.Text = Path.GetFileName(sfd.FileName);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                    textBox1.Text = first;
                    label3.Text = "무제.as";
                }
                else
                {
                    textBox1.Text = first;
                    label3.Text = "무제.as";
                }
            }
            catch (System.Exception Ex)
            {
                string dir = "";

                sfd.Filter = "ActionScript 파일(*.as)|무제.as";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    dir = sfd.FileName;
                    FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(textBox1.Text); // 파일 저장
                    label3.Text = Path.GetFileName(sfd.FileName);
                    df = sfd.FileName;
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
            }
        }
        bool okok = false;
        private void 새파일ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                okok = true;
                FileStream fs = new FileStream(df, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(textBox1.Text); // 파일 저장
                label3.Text = Path.GetFileName(sfd.FileName);
                sw.Flush();
                sw.Close();
                fs.Close();
            }

            catch (System.ArgumentException ex)
            {
                string dir = "";

                sfd.Filter = "ActionScript 파일(*.as)|무제.as";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    dir = sfd.FileName;
                    FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(textBox1.Text); // 파일 저장
                    label3.Text = Path.GetFileName(sfd.FileName);
                    df = sfd.FileName;
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                    okok = true;
                }
            }
        }

        private void 불러오기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                okok = true;
                if (MessageBox.Show(label3.Text + "를 저장하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    FileStream fs = new FileStream(df, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(textBox1.Text); // 파일 저장
                    label3.Text = Path.GetFileName(sfd.FileName);
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
            }
            catch (System.ArgumentException E)
            {
                string dir = "";
                okok = true;
                sfd.Filter = "ActionScript 파일(*.as)|무제.as";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    dir = sfd.FileName;
                    FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(textBox1.Text); // 파일 저장
                    label3.Text = Path.GetFileName(sfd.FileName);
                    df = sfd.FileName;
                    sw.Flush();
                    sw.Close();
                    fs.Close();
                }
            }
            OpenFileDialog openPanel = new OpenFileDialog();
            openPanel.InitialDirectory = "C:\\";
            openPanel.DefaultExt = "*.as";
            openPanel.Filter = "ActionScript 파일(*.as)|*.as";
            if (openPanel.ShowDialog() == DialogResult.OK)
            {
                string ProgramPath = openPanel.FileName;
                //열기한 파일의 전체 경로를 반환한다.
                label3.Text = openPanel.SafeFileName;
                TextReader tr = new StreamReader(openPanel.FileName); //파일 읽기
                textBox1.Text = tr.ReadToEnd(); ;
            }
        }

        private void 저장ToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            string dir = "";

            sfd.Filter = "ActionScript 파일(*.as)|무제.as";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                okok = true;
                dir = sfd.FileName;
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(textBox1.Text); // 파일 저장
                label3.Text = Path.GetFileName(sfd.FileName);
                df = sfd.FileName;
                sw.Flush();
                sw.Close();
                fs.Close();
            }
        }
        Browser a;
        public As3Editor(Browser _form)
        {
            InitializeComponent();
            a = _form;
        }
        public void 제작자블로그ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Browser asd = new Browser(this);
            asd.Show();
            asd.webBrowser1.Navigate("http://blog.naver.com/abc6271416");
            //System.Diagnostics.Process.Start("explorer", "http://blog.naver.com/abc6271416");
            //Browser ExecapeAction = new Browser();
            //ExecapeAction.Show();
            //ExecapeAction.button1.Navigate("naver.com");
        }


        private void 재생ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                mciSendString("open \"" + localmusic + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);
                mciSendString("play MediaFile", null, 0, IntPtr.Zero);
                //label3.Text = localmusic;
            }
            catch (FileNotFoundException ed)
            {
                MessageBox.Show("프로그램의 오류가 발생하였습니다.\n\n오류유형:FileNotFoundException", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clipboard.SetText("www.AsEditor.esy.es");
            }
        }

        public RichTextBox TextBox1
        {
            get
            {
                return rtbText;
            }
        }

        private void toolStripLabel3_Click_1(object sender, EventArgs e)
        {
            Browser A = new Browser();

            // Show the settings form
            A.Show();
        }
        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string dir = "";
            okok = true;
            sfd.Filter = "ActionScript 파일(*.as)|무제.as";
            if (MessageBox.Show(label3.Text + "를 저장하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    dir = sfd.FileName;
                    FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(textBox1.Text); // 파일 저장
                    label3.Text = Path.GetFileName(sfd.FileName);
                    df = sfd.FileName;
                    sw.Flush();
                    sw.Close();
                    fs.Close();

                }
                Application.Exit();
            }
            Application.Exit();
        }
  
        private void photoshop1_Load_2(object sender, EventArgs e)
        {
            label2.Text = "줄:" + textBox1.Lines.Length;
            mciSendString("open \"" + @"Data\LB\started.wav" + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);
            mciSendString("play MediaFile", null, 0, IntPtr.Zero);
            updateNumberLabel();
        }




        private void numberLable_Click_1(object sender, EventArgs e)
        {

        }

        private void abc6271416ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void mouse_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                EventHandler eh = new EventHandler(MenuClick);
                MenuItem[] ami = {
                    new MenuItem("추가",eh),
                    new MenuItem("삭제",eh),
                    new MenuItem("변경",eh),
                    new MenuItem("-",eh),
                    new MenuItem("프로그램 종료",eh),
                };
                ContextMenu = new System.Windows.Forms.ContextMenu(ami);
            }
        }


        void MenuClick(object obj, EventArgs ea)
        {
            MenuItem mI = (MenuItem)obj;
            String str = mI.Text;
            if (str == "추가")
                MessageBox.Show("프로그램을 추가하였습니다");
            if (str == "삭제")
                MessageBox.Show("프로그램을 삭제하였습니다");
            if (str == "변경")
                MessageBox.Show("프로그램을 변경하였습니다");
            if (str == "프로그램 종료")
                Close();
        }
        public string ConvertRtbToHTML(RichTextBox rtb)
        {
            if (rtb.Text.Length == 0) return null;

            string html = "";
            string color;
            string strChar;
            bool isBold;
            bool isItalic;
            string fontName;
            short size;
            int originStart = 0;
            int originLength = rtb.Text.Length;
            int count = 0;


            rtb.Select(0, 1);

            color = ColorTranslator.ToHtml(rtb.SelectionColor);
            isBold = rtb.SelectionFont.Bold;
            isItalic = rtb.SelectionFont.Italic;
            fontName = rtb.SelectionFont.FontFamily.Name;
            size = (short)rtb.SelectionFont.Size;


            html += "<span style=\"font-family: " + fontName +
             "; font-size: " + size + "pt; color: "
                             + color + "\">";

            if (isBold == true)
                html += "<b>";


            if (isItalic == true)
                html += "<i>";


            html += rtb.Text.Substring(0, 1);


            for (count = 2; count <= rtb.Text.Length; count++)
            {

                rtb.Select(count - 1, 1);

                strChar = rtb.Text.Substring(count - 1, 1);

                switch (strChar)
                {
                    case "\n":

                        html += "<br>";
                        break;
                    case "\t":
                        html += "&nbsp;&nbsp;&nbsp;&nbsp;";
                        strChar = "";
                        break;
                    case " ":
                        html += "&nbsp;";
                        strChar = "";
                        break;
                    case "<":
                        html += "&lt;";
                        strChar = "";
                        break;
                    case ">":
                        html += "&gt;";
                        strChar = "";
                        break;
                    case "&":
                        html += "&amp;";
                        strChar = "";
                        break;
                }



                if (rtb.SelectionColor.ToKnownColor().ToString() != color ||
                   rtb.SelectionFont.FontFamily.Name != fontName || rtb.SelectionFont.Size != size)
                    html += "</span><span style=\"font-family: "
                      + rtb.SelectionFont.FontFamily.Name +
                      "; font-size: " + rtb.SelectionFont.Size +
                      "pt; color: " +
                      rtb.SelectionColor.ToKnownColor().ToString() + "\">";

                if (rtb.SelectionFont.Bold != isBold)
                {
                    if (rtb.SelectionFont.Bold == false)
                        html += "</b>";
                    else
                        html += "<b>";
                }


                if (rtb.SelectionFont.Italic != isItalic)
                {
                    if (rtb.SelectionFont.Italic == false)
                        html += "</i>";
                    else
                        html += "<i>";
                }

                // Add the actual character
                html += strChar; //box.Text.Substring(intCount-1, 1);

                // Update variables with current style

                color = rtb.SelectionColor.ToKnownColor().ToString();
                isBold = rtb.SelectionFont.Bold;
                isItalic = rtb.SelectionFont.Italic;
                fontName = rtb.SelectionFont.FontFamily.Name;
                size = (short)rtb.SelectionFont.Size;
            }

            // Close off any open bold/italic tags
            if (isBold == true) html += "";
            if (isItalic == true) html += "";

            // Terminate outstanding HTML tags
            html += "</span>"; //</html>";
            // Restore original RichTextBox selection
            rtb.Select(originStart, originLength);

            //' Return HTML
            return html;
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 복사ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void allCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtbText.Text);
        }

        private void contextMenuStrip1_Opening_1(object sender, CancelEventArgs e)
        {

        }

        private void allDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText = Clipboard.GetText();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText = "";
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.SelectedText);
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label3_Changed(object sender, EventArgs e)
        {
            //Panel1.AutoSize();
        }

        private void toolStripLabel7_Click(object sender, EventArgs e)
        {
            teamchat open = new teamchat();
            open.Show();
        }

        private void findStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            find asd = new find(this);
            asd.Show();
        }

        private void rtbText_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Browser asd = new Browser(this);
            asd.Show();
            asd.webBrowser1.Navigate("http://include.esy.es/as3.0/help.html");
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void 자동저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        const string ahs = @"<b>Colored by as3.0 Editor</b><br>";
        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("<div style=background:#B2A6A6; height: 50px;weigh:1px;>" + "</div>" + "<div style=background:#fafafa; height: 50px;weigh:1px;>" + ConvertRtbToHTML(rtbText) + ahs);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripLabel8_Click(object sender, EventArgs e)
        {
            upload adf = new upload();
            adf.Show();
        }

        private void toolStrip1_ItemClicked_2(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripLabel5_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            rtbText.Select(rtbText.TextLength - 1, rtbText.TextLength);
            rtbText.ScrollToCaret();
        }

        private void iAPPLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Browser asd = new Browser(this);
            asd.Show();
            asd.webBrowser1.Navigate("http://iaplle.esy.es");
        }

        private void textBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Browser asd = new Browser(this);
            asd.Show();
            asd.webBrowser1.Navigate(e.LinkText);
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true; // 폼의 표시
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal; // 최소화를 멈춘다 
            this.Activate(); // 폼을 활성화 시킨다
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            this.Visible = true; // 폼의 표시
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal; // 최소화를 멈춘다 
            this.Activate(); // 폼을 활성화 시킨다
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                ApplySyntaxHighlighting();
            }
        }

        private void jButton3_DoubleClick(object sender, EventArgs e)
        {

        }
        public Regex love = new Regex(@"_root|_stage|_Xscale|_Yscale|_parent|_object|hitTest|_x|_y|onClipEvent(enterFrame)");
        private void porting30ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
            textBox1.SelectionColor = Color.Black;
            // Then unselect and scroll to the end of the file
            textBox1.ScrollToCaret();
            textBox1.Select(textBox1.Text.Length, 1);

            // Start applying the highlighting... Set a value to selPos
            int selPos = textBox1.SelectionStart;

            foreach (Match keyWordMatch in love.Matches(textBox1.Text))
            {
                textBox1.Select(keyWordMatch.Index, keyWordMatch.Length);
                // Change it to blueBox1.Select(keyWordMatch.Index, 
                // Set it to bold for this example
                textBox1.Select(keyWordMatch.Index, keyWordMatch.Length);
                if (textBox1.SelectedText == "_root")
                {
                    textBox1.SelectedText = "root";
                }
                else if (textBox1.SelectedText == "_parent")
                {
                    textBox1.SelectedText = "parent";
                }
                else if (textBox1.SelectedText == "_Xscale")
                {
                    textBox1.SelectedText = "scaleX";
                }
                else if (textBox1.SelectedText == "_Yscale")
                {
                    textBox1.SelectedText = "scaleY";
                }
                else if (textBox1.SelectedText == "hitTest")
                {
                    textBox1.SelectedText = "hitTestObject";
                }
                else if (textBox1.SelectedText == "_rotation")
                {
                    textBox1.SelectedText = "rotation";
                }
                else if (textBox1.SelectedText == "onClipEvent(enterFrame)")
                {
                    textBox1.SelectedText = "addEventListener(Event.ENTER_FRAME,function(e:Event):void{";
                }
                else if (textBox1.SelectedText == "onEnterFrame=function()")
                {
                    textBox1.SelectedText = "addEventListener(Event.ENTER_FRAME,function(e:Event):void{";
                }
            }
            textBox1.Text = "package{\n" + "public class Main extends MovieClip{\npublic function Main(){\n" + textBox1.Text + "\n}" + "\n}" + "\n}";
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            
        }

        class DeclarationSnippet : SnippetAutocompleteItem
        {
            public static string RegexSpecSymbolsPattern = @"[\^\$\[\]\(\)\.\\\*\+\|\?\{\}]";

            public DeclarationSnippet(string snippet)
                : base(snippet)
            {
            }

            public override CompareResult Compare(string fragmentText)
            {
                var pattern = Regex.Replace(fragmentText, RegexSpecSymbolsPattern, "\\$0");
                if (Regex.IsMatch(Text, "\\b" + pattern, RegexOptions.IgnoreCase))
                    return CompareResult.Visible;
                return CompareResult.Hidden;
            }
        }

        /// <summary>
        /// Divides numbers and words: "123AND456" -> "123 AND 456"
        /// Or "i=2" -> "i = 2"
        /// </summary>
        class InsertSpaceSnippet : AutocompleteItem
        {
            string pattern;

            public InsertSpaceSnippet(string pattern)
                : base("")
            {
                this.pattern = pattern;
            }

            public InsertSpaceSnippet()
                : this(@"^(\d+)([a-zA-Z_]+)(\d*)$")
            {
            }

            public override CompareResult Compare(string fragmentText)
            {
                if (Regex.IsMatch(fragmentText, pattern))
                {
                    Text = InsertSpaces(fragmentText);
                    if (Text != fragmentText)
                        return CompareResult.Visible;
                }
                return CompareResult.Hidden;
            }

            public string InsertSpaces(string fragment)
            {
                var m = Regex.Match(fragment, pattern);
                if (m.Groups[1].Value == "" && m.Groups[3].Value == "")
                    return fragment;
                return (m.Groups[1].Value + " " + m.Groups[2].Value + " " + m.Groups[3].Value).Trim();
            }

            public override string ToolTipTitle
            {
                get
                {
                    return Text;
                }
            }
        }

        /// <summary>
        /// Inerts line break after '}'
        /// </summary>
        class InsertEnterSnippet : AutocompleteItem
        {
            int enterPlace = 0;

            public InsertEnterSnippet()
                : base("[Line break]")
            {
            }

            public override CompareResult Compare(string fragmentText)
            {
                var tb = Parent.TargetControlWrapper;

                var text = tb.Text;
                for (int i = Parent.Fragment.Start - 1; i >= 0; i--)
                {
                    if (text[i] == '\n')
                        break;
                    if (text[i] == '}')
                    {
                        enterPlace = i;
                        return CompareResult.Visible;
                    }
                }

                return CompareResult.Hidden;
            }

            public override string GetTextForReplace()
            {
                var tb = Parent.TargetControlWrapper;

                //insert line break
                tb.SelectionStart = enterPlace + 1;
                tb.SelectedText = "\n";
                Parent.Fragment.Start += 1;
                Parent.Fragment.End += 1;
                return Parent.Fragment.Text;
            }

            public override string ToolTipTitle
            {
                get
                {
                    return "Insert line break after '}'";
                }
            }

        }

        private void newProjectToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 보안ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void jButton2_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}



  


   