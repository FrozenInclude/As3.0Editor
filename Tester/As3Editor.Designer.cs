namespace Tester
{
    partial class As3Editor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (m_ClientSocket != null)
            {
                if (m_ClientSocket.Connected)
                    m_ClientSocket.Disconnect(false);
                m_ClientSocket.Dispose();
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
      }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(As3Editor));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porting30ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numberLable = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.formEnd = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.불러오기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.자동저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.새파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.abc6271416ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.제작자블로그ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iAPPLEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
            this.photoshop1 = new Photoshop();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.jButton4 = new JButton.JButton();
            this.jButton3 = new JButton.JButton();
            this.jButton2 = new JButton.JButton();
            this.jButton1 = new JButton.JButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.RichTextBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.autocompleteMenu1 = new AutocompleteMenuNS.AutocompleteMenu();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.photoshop1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "script_16x16.png");
            this.imageList1.Images.SetKeyName(1, "app_16x16.png");
            this.imageList1.Images.SetKeyName(2, "1302166543_virtualbox.png");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.AllowDrop = true;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.allCopyToolStripMenuItem,
            this.allDeleteToolStripMenuItem,
            this.findStringToolStripMenuItem,
            this.printToolStripMenuItem,
            this.porting30ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 180);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening_1);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.copyToolStripMenuItem.Text = "copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.pasteToolStripMenuItem.Text = "paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.deleteToolStripMenuItem.Text = "delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // allCopyToolStripMenuItem
            // 
            this.allCopyToolStripMenuItem.Name = "allCopyToolStripMenuItem";
            this.allCopyToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.allCopyToolStripMenuItem.Text = "All copy";
            this.allCopyToolStripMenuItem.Click += new System.EventHandler(this.allCopyToolStripMenuItem_Click);
            // 
            // allDeleteToolStripMenuItem
            // 
            this.allDeleteToolStripMenuItem.Name = "allDeleteToolStripMenuItem";
            this.allDeleteToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.allDeleteToolStripMenuItem.Text = "All delete";
            this.allDeleteToolStripMenuItem.Click += new System.EventHandler(this.allDeleteToolStripMenuItem_Click);
            // 
            // findStringToolStripMenuItem
            // 
            this.findStringToolStripMenuItem.Name = "findStringToolStripMenuItem";
            this.findStringToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.findStringToolStripMenuItem.Text = "search string";
            this.findStringToolStripMenuItem.Click += new System.EventHandler(this.findStringToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.printToolStripMenuItem.Text = "print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // porting30ToolStripMenuItem
            // 
            this.porting30ToolStripMenuItem.Name = "porting30ToolStripMenuItem";
            this.porting30ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.porting30ToolStripMenuItem.Text = "2.0 Porting 3.0";
            this.porting30ToolStripMenuItem.Click += new System.EventHandler(this.porting30ToolStripMenuItem_Click);
            // 
            // rtbText
            // 
            this.autocompleteMenu1.SetAutocompleteMenu(this.rtbText, null);
            this.rtbText.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtbText.Font = new System.Drawing.Font("나눔고딕코딩", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rtbText.ForeColor = System.Drawing.Color.Black;
            this.rtbText.Location = new System.Drawing.Point(27, 64);
            this.rtbText.Name = "rtbText";
            this.rtbText.Size = new System.Drawing.Size(571, 401);
            this.rtbText.TabIndex = 25;
            this.rtbText.Text = "package {\n    public class 무제{\n        var str:String = \"\";\n        var num:int=5" +
    ";\n       var a:Array=new Array();\n        trace( str + num ); \n    }\n}";
            this.rtbText.TextChanged += new System.EventHandler(this.rtbText_TextChanged_2);
            // 
            // textBox2
            // 
            this.autocompleteMenu1.SetAutocompleteMenu(this.textBox2, null);
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(6, 13);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(1161, 163);
            this.textBox2.TabIndex = 0;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel1.Location = new System.Drawing.Point(27, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(86, 20);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = " 무제.as";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Changed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(982, 476);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "줄:8";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1064, 476);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "문자수:154";
            // 
            // numberLable
            // 
            this.numberLable.AutoSize = true;
            this.numberLable.BackColor = System.Drawing.Color.Transparent;
            this.numberLable.Font = new System.Drawing.Font("맑은 고딕", 9.5F);
            this.numberLable.ForeColor = System.Drawing.Color.White;
            this.numberLable.Location = new System.Drawing.Point(7, 66);
            this.numberLable.Name = "numberLable";
            this.numberLable.Size = new System.Drawing.Size(15, 119);
            this.numberLable.TabIndex = 13;
            this.numberLable.Text = "1\r\n\r\n2\r\n\r\n3\r\n\r\n4";
            this.numberLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.numberLable.Click += new System.EventHandler(this.numberLable_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(612, 719);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "clean";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(882, 563);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "자동저장";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1128, -43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "label4";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // formEnd
            // 
            this.formEnd.Location = new System.Drawing.Point(839, -29);
            this.formEnd.Name = "formEnd";
            this.formEnd.Size = new System.Drawing.Size(75, 23);
            this.formEnd.TabIndex = 18;
            this.formEnd.Text = "button3";
            this.formEnd.UseVisualStyleBackColor = true;
            this.formEnd.Click += new System.EventHandler(this.formEnd_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(612, -88);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "코드 복사";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBox2.ForeColor = System.Drawing.Color.White;
            this.checkBox2.Location = new System.Drawing.Point(27, 475);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(126, 19);
            this.checkBox2.TabIndex = 24;
            this.checkBox2.Text = "실시간 하이라이팅";
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.DimGray;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.toolStripLabel3,
            this.toolStripLabel6,
            this.toolStripLabel7,
            this.toolStripLabel8});
            this.toolStrip1.Location = new System.Drawing.Point(0, 684);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1193, 25);
            this.toolStrip1.TabIndex = 25;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked_2);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.저장ToolStripMenuItem,
            this.불러오기ToolStripMenuItem,
            this.자동저장ToolStripMenuItem,
            this.새파일ToolStripMenuItem,
            this.newProjectToolStripMenuItem});
            this.toolStripLabel1.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel1.Text = "파일";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click_1);
            // 
            // 저장ToolStripMenuItem
            // 
            this.저장ToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.저장ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.저장ToolStripMenuItem.Name = "저장ToolStripMenuItem";
            this.저장ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.저장ToolStripMenuItem.Text = "다른이름으로 저장";
            this.저장ToolStripMenuItem.Click += new System.EventHandler(this.저장ToolStripMenuItem_Click_2);
            // 
            // 불러오기ToolStripMenuItem
            // 
            this.불러오기ToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.불러오기ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.불러오기ToolStripMenuItem.Name = "불러오기ToolStripMenuItem";
            this.불러오기ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.불러오기ToolStripMenuItem.Text = "불러오기";
            this.불러오기ToolStripMenuItem.Click += new System.EventHandler(this.불러오기ToolStripMenuItem_Click);
            // 
            // 자동저장ToolStripMenuItem
            // 
            this.자동저장ToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.자동저장ToolStripMenuItem.Checked = true;
            this.자동저장ToolStripMenuItem.CheckOnClick = true;
            this.자동저장ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.자동저장ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.자동저장ToolStripMenuItem.Name = "자동저장ToolStripMenuItem";
            this.자동저장ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.자동저장ToolStripMenuItem.Text = "자동저장";
            this.자동저장ToolStripMenuItem.Click += new System.EventHandler(this.자동저장ToolStripMenuItem_Click);
            // 
            // 새파일ToolStripMenuItem
            // 
            this.새파일ToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.새파일ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.새파일ToolStripMenuItem.Name = "새파일ToolStripMenuItem";
            this.새파일ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.새파일ToolStripMenuItem.Text = "저장";
            this.새파일ToolStripMenuItem.Click += new System.EventHandler(this.새파일ToolStripMenuItem_Click);
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.newProjectToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.newProjectToolStripMenuItem.Text = "new class";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abc6271416ToolStripMenuItem});
            this.toolStripLabel2.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel2.Text = "저작권";
            // 
            // abc6271416ToolStripMenuItem
            // 
            this.abc6271416ToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.abc6271416ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.제작자블로그ToolStripMenuItem,
            this.iAPPLEToolStripMenuItem});
            this.abc6271416ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.abc6271416ToolStripMenuItem.Name = "abc6271416ToolStripMenuItem";
            this.abc6271416ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.abc6271416ToolStripMenuItem.Text = "abc6271416";
            this.abc6271416ToolStripMenuItem.Click += new System.EventHandler(this.abc6271416ToolStripMenuItem_Click_1);
            // 
            // 제작자블로그ToolStripMenuItem
            // 
            this.제작자블로그ToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.제작자블로그ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.제작자블로그ToolStripMenuItem.Name = "제작자블로그ToolStripMenuItem";
            this.제작자블로그ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.제작자블로그ToolStripMenuItem.Text = "제작자블로그";
            this.제작자블로그ToolStripMenuItem.Click += new System.EventHandler(this.제작자블로그ToolStripMenuItem_Click_1);
            // 
            // iAPPLEToolStripMenuItem
            // 
            this.iAPPLEToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.iAPPLEToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.iAPPLEToolStripMenuItem.Name = "iAPPLEToolStripMenuItem";
            this.iAPPLEToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.iAPPLEToolStripMenuItem.Text = "IAPPLE";
            this.iAPPLEToolStripMenuItem.Click += new System.EventHandler(this.iAPPLEToolStripMenuItem_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(90, 22);
            this.toolStripLabel3.Text = "Web Browser";
            this.toolStripLabel3.Click += new System.EventHandler(this.toolStripLabel3_Click_1);
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripLabel7
            // 
            this.toolStripLabel7.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel7.Name = "toolStripLabel7";
            this.toolStripLabel7.Size = new System.Drawing.Size(43, 22);
            this.toolStripLabel7.Text = "팀회의";
            this.toolStripLabel7.Click += new System.EventHandler(this.toolStripLabel7_Click);
            // 
            // toolStripLabel8
            // 
            this.toolStripLabel8.ForeColor = System.Drawing.Color.White;
            this.toolStripLabel8.Name = "toolStripLabel8";
            this.toolStripLabel8.Size = new System.Drawing.Size(55, 22);
            this.toolStripLabel8.Text = "소스공유";
            this.toolStripLabel8.Click += new System.EventHandler(this.toolStripLabel8_Click);
            // 
            // photoshop1
            // 
            this.photoshop1.BackColor = System.Drawing.Color.DimGray;
            this.photoshop1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.photoshop1.Controls.Add(this.comboBox1);
            this.photoshop1.Controls.Add(this.jButton4);
            this.photoshop1.Controls.Add(this.jButton3);
            this.photoshop1.Controls.Add(this.jButton2);
            this.photoshop1.Controls.Add(this.jButton1);
            this.photoshop1.Controls.Add(this.groupBox1);
            this.photoshop1.Controls.Add(this.panel1);
            this.photoshop1.Controls.Add(this.checkBox2);
            this.photoshop1.Controls.Add(this.label1);
            this.photoshop1.Controls.Add(this.label2);
            this.photoshop1.Controls.Add(this.button2);
            this.photoshop1.Controls.Add(this.checkBox1);
            this.photoshop1.Controls.Add(this.button3);
            this.photoshop1.Controls.Add(this.textBox1);
            this.photoshop1.Controls.Add(this.numberLable);
            this.photoshop1.Controls.Add(this.rtbText);
            this.photoshop1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoshop1.Location = new System.Drawing.Point(0, 0);
            this.photoshop1.Name = "photoshop1";
            this.photoshop1.Sizable = false;
            this.photoshop1.Size = new System.Drawing.Size(1193, 709);
            this.photoshop1.TabIndex = 26;
            this.photoshop1.Load += new System.EventHandler(this.photoshop1_Load_2);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "c#",
            "AS3.0"});
            this.comboBox1.Location = new System.Drawing.Point(1207, 474);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 22);
            this.comboBox1.TabIndex = 33;
            this.comboBox1.Text = "AS3.0";
            // 
            // jButton4
            // 
            this.jButton4.Brightness = 0;
            this.jButton4.ButtonColor = System.Drawing.Color.White;
            this.jButton4.Checked = false;
            this.jButton4.CheckedColor = System.Drawing.Color.LightGreen;
            this.jButton4.CheckedTextColor = System.Drawing.Color.Black;
            this.jButton4.Font = new System.Drawing.Font("나눔고딕", 9F);
            this.jButton4.Image = null;
            this.jButton4.Location = new System.Drawing.Point(717, 471);
            this.jButton4.Mode = JButton.JButton.ControlMode.Default;
            this.jButton4.Name = "jButton4";
            this.jButton4.Size = new System.Drawing.Size(75, 26);
            this.jButton4.Style = JButton.JButton.StyleMode.Default;
            this.jButton4.TabIndex = 32;
            this.jButton4.Text = "도움말";
            this.jButton4.TextColor = System.Drawing.Color.Black;
            this.jButton4.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // jButton3
            // 
            this.jButton3.Brightness = 0;
            this.jButton3.ButtonColor = System.Drawing.Color.White;
            this.jButton3.Checked = false;
            this.jButton3.CheckedColor = System.Drawing.Color.LightGreen;
            this.jButton3.CheckedTextColor = System.Drawing.Color.Black;
            this.jButton3.Font = new System.Drawing.Font("나눔고딕", 9F);
            this.jButton3.Image = null;
            this.jButton3.Location = new System.Drawing.Point(612, 471);
            this.jButton3.Mode = JButton.JButton.ControlMode.Default;
            this.jButton3.Name = "jButton3";
            this.jButton3.Size = new System.Drawing.Size(75, 26);
            this.jButton3.Style = JButton.JButton.StyleMode.Default;
            this.jButton3.TabIndex = 31;
            this.jButton3.Text = "컴파일";
            this.jButton3.TextColor = System.Drawing.Color.Black;
            this.jButton3.Click += new System.EventHandler(this.pictureBox1_Click);
            this.jButton3.DoubleClick += new System.EventHandler(this.jButton3_DoubleClick);
            // 
            // jButton2
            // 
            this.jButton2.Brightness = 0;
            this.jButton2.ButtonColor = System.Drawing.Color.White;
            this.jButton2.Checked = false;
            this.jButton2.CheckedColor = System.Drawing.Color.LightGreen;
            this.jButton2.CheckedTextColor = System.Drawing.Color.Black;
            this.jButton2.Font = new System.Drawing.Font("나눔고딕", 9F);
            this.jButton2.Image = null;
            this.jButton2.Location = new System.Drawing.Point(399, 471);
            this.jButton2.Mode = JButton.JButton.ControlMode.Default;
            this.jButton2.Name = "jButton2";
            this.jButton2.Size = new System.Drawing.Size(89, 26);
            this.jButton2.Style = JButton.JButton.StyleMode.Default;
            this.jButton2.TabIndex = 30;
            this.jButton2.Text = "HTML로 복사";
            this.jButton2.TextColor = System.Drawing.Color.Black;
            this.jButton2.Click += new System.EventHandler(this.button4_Click);
            this.jButton2.DoubleClick += new System.EventHandler(this.jButton2_DoubleClick);
            // 
            // jButton1
            // 
            this.jButton1.Brightness = 0;
            this.jButton1.ButtonColor = System.Drawing.Color.White;
            this.jButton1.Checked = false;
            this.jButton1.CheckedColor = System.Drawing.Color.LightGreen;
            this.jButton1.CheckedTextColor = System.Drawing.Color.Black;
            this.jButton1.Font = new System.Drawing.Font("나눔고딕", 9F);
            this.jButton1.Image = null;
            this.jButton1.Location = new System.Drawing.Point(518, 471);
            this.jButton1.Mode = JButton.JButton.ControlMode.Default;
            this.jButton1.Name = "jButton1";
            this.jButton1.Size = new System.Drawing.Size(80, 26);
            this.jButton1.Style = JButton.JButton.StyleMode.Default;
            this.jButton1.TabIndex = 29;
            this.jButton1.Text = "Down Scroll";
            this.jButton1.TextColor = System.Drawing.Color.Black;
            this.jButton1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(10, 494);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1173, 185);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "출력";
            // 
            // textBox1
            // 
            this.autocompleteMenu1.SetAutocompleteMenu(this.textBox1, this.autocompleteMenu1);
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.Font = new System.Drawing.Font("나눔고딕코딩", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(612, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(571, 401);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "package {\n    public class 무제{\n        var str:String = \"\";\n        var num:int=5" +
    ";\n       var a:Array=new Array();\n        trace( str + num ); \n    }\n}";
            this.textBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.textBox1_LinkClicked);
            this.textBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "C:\\Users\\Administrator\\Desktop\\sssfsfs.htm";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.OnPrintPage);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "As3.0Editor";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick_1);
            // 
            // autocompleteMenu1
            // 
            this.autocompleteMenu1.AllowsTabKey = true;
            this.autocompleteMenu1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.autocompleteMenu1.ImageList = this.imageList1;
            this.autocompleteMenu1.Items = new string[0];
            this.autocompleteMenu1.SearchPattern = "[\\w\\.:=!<>]";
            this.autocompleteMenu1.TargetControlWrapper = null;
            // 
            // As3Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1193, 709);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.formEnd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.photoshop1);
            this.Font = new System.Drawing.Font("굴림", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "As3Editor";
            this.Text = "AS3.0Editor";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.As3Editor_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.photoshop1.ResumeLayout(false);
            this.photoshop1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AutocompleteMenuNS.AutocompleteMenu autocompleteMenu1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.RichTextBox textBox1;
        private System.Windows.Forms.Label numberLable;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button formEnd;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripLabel1;
        private System.Windows.Forms.ToolStripMenuItem 저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 불러오기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 새파일ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripLabel2;
        private System.Windows.Forms.ToolStripMenuItem abc6271416ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 제작자블로그ToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripLabel3;
        //private Photoshop photoshop1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allCopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allDeleteToolStripMenuItem;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel7;
        private System.Windows.Forms.ToolStripMenuItem findStringToolStripMenuItem;
        public System.Windows.Forms.RichTextBox rtbText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolStripMenuItem 자동저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel8;
        private System.Windows.Forms.ToolStripMenuItem iAPPLEToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private JButton.JButton jButton1;
        private JButton.JButton jButton3;
        private JButton.JButton jButton2;
        private JButton.JButton jButton4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem porting30ToolStripMenuItem;
    }
}