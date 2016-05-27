namespace JButton
{
    partial class JButton
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // JButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Name = "JButton";
            this.Size = new System.Drawing.Size(94, 29);
            this.Load += new System.EventHandler(this.JButton_Load);
            this.Click += new System.EventHandler(this.JButton_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserControl1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JButton_MouseDown);
            this.MouseLeave += new System.EventHandler(this.JButton_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.JButton_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.JButton_MouseUp);
            this.Resize += new System.EventHandler(this.UserControl1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

    }
}
