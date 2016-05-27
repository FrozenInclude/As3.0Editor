namespace Tester
{
    partial class upload
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
            this.components = new System.ComponentModel.Container();
            this.photoshop1 = new Photoshop();
            this.jButton4 = new JButton.JButton();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.photoshop1.SuspendLayout();
            this.SuspendLayout();
            // 
            // photoshop1
            // 
            this.photoshop1.Controls.Add(this.jButton4);
            this.photoshop1.Controls.Add(this.label3);
            this.photoshop1.Controls.Add(this.textBox2);
            this.photoshop1.Controls.Add(this.label2);
            this.photoshop1.Controls.Add(this.textBox1);
            this.photoshop1.Controls.Add(this.label1);
            this.photoshop1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoshop1.Location = new System.Drawing.Point(0, 0);
            this.photoshop1.Name = "photoshop1";
            this.photoshop1.Sizable = true;
            this.photoshop1.Size = new System.Drawing.Size(284, 262);
            this.photoshop1.TabIndex = 0;
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
            this.jButton4.Location = new System.Drawing.Point(104, 224);
            this.jButton4.Mode = JButton.JButton.ControlMode.Default;
            this.jButton4.Name = "jButton4";
            this.jButton4.Size = new System.Drawing.Size(75, 26);
            this.jButton4.Style = JButton.JButton.StyleMode.Default;
            this.jButton4.TabIndex = 35;
            this.jButton4.Text = "업로드";
            this.jButton4.TextColor = System.Drawing.Color.Black;
            this.jButton4.DoubleClick += new System.EventHandler(this.jButton4_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(262, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "url:http://iaplle.esy.es/Editor/code/나비.html";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(68, 90);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(204, 93);
            this.textBox2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(32, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "할말:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(68, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "소스이름:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // upload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.photoshop1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "upload";
            this.Text = "upload";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.photoshop1.ResumeLayout(false);
            this.photoshop1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Photoshop photoshop1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private JButton.JButton jButton4;
        private System.Windows.Forms.Timer timer1;
    }
}