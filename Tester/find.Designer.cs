namespace Tester
{
    partial class find
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
            this.label1 = new System.Windows.Forms.Label();
            this.photoshop1 = new Photoshop();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.jButton4 = new JButton.JButton();
            this.photoshop1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "찾기:";
            // 
            // photoshop1
            // 
            this.photoshop1.Controls.Add(this.jButton4);
            this.photoshop1.Controls.Add(this.label2);
            this.photoshop1.Controls.Add(this.textBox2);
            this.photoshop1.Controls.Add(this.textBox1);
            this.photoshop1.Controls.Add(this.label1);
            this.photoshop1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.photoshop1.Location = new System.Drawing.Point(0, 0);
            this.photoshop1.Name = "photoshop1";
            this.photoshop1.Sizable = true;
            this.photoshop1.Size = new System.Drawing.Size(406, 159);
            this.photoshop1.TabIndex = 3;
            this.photoshop1.Load += new System.EventHandler(this.photoshop1_Load);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("나눔고딕코딩", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "바꾸기:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(56, 78);
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox2.Size = new System.Drawing.Size(335, 21);
            this.textBox2.TabIndex = 4;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(56, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox1.Size = new System.Drawing.Size(335, 21);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
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
            this.jButton4.Location = new System.Drawing.Point(161, 121);
            this.jButton4.Mode = JButton.JButton.ControlMode.Default;
            this.jButton4.Name = "jButton4";
            this.jButton4.Size = new System.Drawing.Size(75, 26);
            this.jButton4.Style = JButton.JButton.StyleMode.Default;
            this.jButton4.TabIndex = 34;
            this.jButton4.Text = "확인";
            this.jButton4.TextColor = System.Drawing.Color.Black;
            this.jButton4.Click += new System.EventHandler(this.button1_Click);
            // 
            // find
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 159);
            this.Controls.Add(this.photoshop1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "find";
            this.Text = "search strings";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.photoshop1.ResumeLayout(false);
            this.photoshop1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
       // private //Photoshop photoshop1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private JButton.JButton jButton4;
    }
}