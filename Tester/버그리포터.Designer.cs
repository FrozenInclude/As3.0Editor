namespace Tester
{
    partial class 버그리포터
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(버그리포터));
            this.photoshop1 = new Photoshop();
            this.jButton4 = new JButton.JButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.photoshop1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // photoshop1
            // 
            this.photoshop1.Controls.Add(this.jButton4);
            this.photoshop1.Controls.Add(this.label1);
            this.photoshop1.Controls.Add(this.textBox1);
            this.photoshop1.Controls.Add(this.label3);
            this.photoshop1.Controls.Add(this.pictureBox1);
            this.photoshop1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoshop1.Location = new System.Drawing.Point(0, 0);
            this.photoshop1.Name = "photoshop1";
            this.photoshop1.Sizable = false;
            this.photoshop1.Size = new System.Drawing.Size(467, 581);
            this.photoshop1.TabIndex = 0;
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
            this.jButton4.Location = new System.Drawing.Point(378, 549);
            this.jButton4.Mode = JButton.JButton.ControlMode.Default;
            this.jButton4.Name = "jButton4";
            this.jButton4.Size = new System.Drawing.Size(75, 26);
            this.jButton4.Style = JButton.JButton.StyleMode.Default;
            this.jButton4.TabIndex = 33;
            this.jButton4.Text = "리포트";
            this.jButton4.TextColor = System.Drawing.Color.Black;
            this.jButton4.Click += new System.EventHandler(this.button1_Click);
            this.jButton4.DoubleClick += new System.EventHandler(this.jButton4_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "버그내용:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 275);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(429, 268);
            this.textBox1.TabIndex = 8;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(22, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(401, 36);
            this.label3.TabIndex = 7;
            this.label3.Text = "프로그램의 문제가 생겨 종료해야합니다. 아래의 빈칸에 버그를 써주시면 \r\n\r\n좀더 좋은 프로그램을 만드는데 도움이됩니다. 감사합니다.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(443, 158);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // 버그리포터
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 581);
            this.Controls.Add(this.photoshop1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "버그리포터";
            this.Text = "버그리포터";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.photoshop1.ResumeLayout(false);
            this.photoshop1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Photoshop photoshop1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private JButton.JButton jButton4;
    }
}