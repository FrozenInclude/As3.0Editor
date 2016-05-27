namespace Tester
{
    partial class Browser
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.photoshop1 = new Photoshop();
            this.jButton4 = new JButton.JButton();
            this.jButton1 = new JButton.JButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.photoshop1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.jButton1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(4, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1145, 40);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1050, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "http://www.adobe.com/devnet/flash.html";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(10, 77);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(1137, 621);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.jButton4);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(8, 704);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1139, 42);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "옵션";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(292, 14);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(148, 16);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "자바스크립트 오류무시";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "네이버",
            "구글"});
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "네이버",
            "구글",
            "다음",
            "네이트",
            "없음"});
            this.comboBox1.Location = new System.Drawing.Point(165, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Tag = "ㅛㅗ";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "검색엔진:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 15);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(100, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "검색엔진 사용";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // photoshop1
            // 
            this.photoshop1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.photoshop1.Controls.Add(this.groupBox2);
            this.photoshop1.Controls.Add(this.groupBox1);
            this.photoshop1.Controls.Add(this.webBrowser1);
            this.photoshop1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoshop1.Location = new System.Drawing.Point(0, 0);
            this.photoshop1.Name = "photoshop1";
            this.photoshop1.Sizable = false;
            this.photoshop1.Size = new System.Drawing.Size(1161, 760);
            this.photoshop1.TabIndex = 3;
            this.photoshop1.Load += new System.EventHandler(this.photoshop1_Load);
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
            this.jButton4.Location = new System.Drawing.Point(1058, 12);
            this.jButton4.Mode = JButton.JButton.ControlMode.Default;
            this.jButton4.Name = "jButton4";
            this.jButton4.Size = new System.Drawing.Size(75, 26);
            this.jButton4.Style = JButton.JButton.StyleMode.Default;
            this.jButton4.TabIndex = 33;
            this.jButton4.Text = "종료";
            this.jButton4.TextColor = System.Drawing.Color.Black;
            this.jButton4.Click += new System.EventHandler(this.button2_Click);
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
            this.jButton1.Location = new System.Drawing.Point(1064, 10);
            this.jButton1.Mode = JButton.JButton.ControlMode.Default;
            this.jButton1.Name = "jButton1";
            this.jButton1.Size = new System.Drawing.Size(75, 26);
            this.jButton1.Style = JButton.JButton.StyleMode.Default;
            this.jButton1.TabIndex = 34;
            this.jButton1.Text = "검색";
            this.jButton1.TextColor = System.Drawing.Color.Black;
            this.jButton1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1161, 760);
            this.ControlBox = false;
            this.Controls.Add(this.photoshop1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Browser";
            this.Text = "Web Viewer";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.Load += new System.EventHandler(this.Browser_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.photoshop1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox2;
     //   private Photoshop photoshop1;
        private JButton.JButton jButton1;
        private JButton.JButton jButton4;
    }
}