using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace JButton
{

    /* Coded and Designed by jn4kim @Team Developert
     * For more informations, please visit http://developert.com/jbutton
     * 자세한 설명과 사용법을 보시려면 위 주소로 접속해주세요!*/

    /*
     * This work is licensed under the Creative Commons Attribution-ShareAlike 3.0 Unported License. 
     * To view a copy of this license, visit http://creativecommons.org/licenses/by-sa/3.0/.
     * 
     * 이 저작물에는 크리에이티브 커먼즈 저작자표시-동일조건변경허락 3.0 Unported 라이선스가 적용 되어 있습니다. 
     * 이 라이선스의 설명을 보고 싶으시면 http://creativecommons.org/licenses/by-sa/3.0/ 를 참조하세요.
     */



    [DefaultEvent("DoubleClick")]
    public partial class JButton : UserControl
    {
        #region - Mode -
        public enum StyleMode
        {
            Default,
            ImageOnly,
            ImageRollover,
        }

        public enum ControlMode
        {
            Default,
            Checkbox,
            Radiobutton,
        }
        #endregion

        #region - Variables -

        bool _isClicked = false;
        bool _isMouseIn = false;
        int _iStatus = 0;
        int _iPreStatus = -1;

        #endregion

        #region - Properties -

        String _Text = "JButton";

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text
        {
            get { return _Text; }
            set
            {
                _Text = value;
                this.Invalidate();
            }
        }

        Font _Font = UserControl.DefaultFont;
        [Description("Sets the font of the button caption")]
        public override Font Font
        {
            get { return _Font; }
            set { _Font = base.Font = value; }
        }


        Color c = Color.FromArgb(100, 100, 100);

        public Color ButtonColor
        {
            get { return c; }
            set
            {
                c = value;
                this.Invalidate();
            }
        }

        Color fc = Color.White;

        public Color TextColor
        {
            get { return fc; }
            set
            {
                fc = value;
                this.Invalidate();
            }
        }

        Color cc = Color.LightGreen;

        public Color CheckedColor
        {
            get { return cc; }
            set
            {
                cc = value;
                this.Invalidate();
            }
        }

        Color cfc = Color.Black;

        public Color CheckedTextColor
        {
            get { return cfc; }
            set
            {
                cfc = value;
                this.Invalidate();
            }
        }

        public int b;
        /// <summary>
        /// Brightness of Upper Color of Gradience
        /// </summary>
        public int Brightness
        {
            get { return b; }
            set
            {
                b = s(value);
                this.Invalidate();
            }
        }

        StyleMode _style = StyleMode.Default;
        public StyleMode Style
        {
            get { return _style; }
            set
            {
                if (_image == null)
                    value = StyleMode.Default;
                _style = value;
                this.Invalidate();
            }
        }

        ControlMode _mode = ControlMode.Default;
        public ControlMode Mode
        {
            get { return _mode; }
            set
            {
                _mode = value;
                this.Invalidate();
            }
        }

        bool _checked = false;
        public bool Checked
        {
            get { return _checked; }
            set
            {
                if (Mode == ControlMode.Default)
                {
                    value = false;
                }
                _checked = value;
                this.Invalidate();
            }
        }

        Image _image = null;
        public Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
                this.Invalidate();
            }
        }

        #endregion

        public JButton()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Stabilize the integer,if it is negative, sets it zero.
        /// if it is over 255, sets it 255.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        int s(int i)
        {
            if (i < 0)
                i = 0;

            if (i > 255)
                i = 255;

            return i;

        }

        void Draw()
        {
            if (_isMouseIn && _isClicked)
                _iStatus = 2;
            else if (_isMouseIn && !_isClicked)
                _iStatus = 1;
            else
                _iStatus = 0;

            if (_iStatus != _iPreStatus)
            {
                this.Invalidate();
            }

            _iPreStatus = _iStatus;


        }
        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {

            //BufferedGraphics buff = BufferedGraphicsManager.Current.Allocate(e.Graphics, this.ClientRectangle);
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            Graphics buff = Graphics.FromImage(bmp);

            buff.Clear(Color.FromArgb(0, 0, 0, 0));

            Pen p;
            Brush brGradient;

            Color FontColor;

            if (Checked)
                FontColor = CheckedTextColor;
            else
                FontColor = TextColor;

            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            Brush TextBrush = new SolidBrush(FontColor);

            if (_iStatus == 0)
            {
                if (this.Checked)
                {
                    p = new Pen(Color.FromArgb(s(cc.R - 40), s(cc.G - 40), s(cc.B - 40)), 1);
                    buff.DrawRectangle(p, 0, 0, Width - 1, Height - 1);

                    brGradient = new LinearGradientBrush(new Rectangle(1, 1, Width - 2, Height - 2), Color.FromArgb(s(cc.R + 20 + b), s(cc.G + 20 + b), s(cc.B + 20 + b)), Color.FromArgb(s(cc.R - 20), s(cc.G - 20), s(cc.B - 20)), 90, false);
                    buff.FillRectangle(brGradient, 1, 1, Width - 2, Height - 2);

                    p = new Pen(Color.FromArgb(50, 255, 255, 255), 1);
                    buff.DrawRectangle(p, 1, 1, Width - 3, Height - 3);
                }
                else
                {
                    p = new Pen(Color.FromArgb(s(c.R - 40), s(c.G - 40), s(c.B - 40)), 1);
                    buff.DrawRectangle(p, 0, 0, Width - 1, Height - 1);

                    brGradient = new LinearGradientBrush(new Rectangle(1, 1, Width - 2, Height - 2), Color.FromArgb(s(c.R + 20 + b), s(c.G + 20 + b), s(c.B + 20 + b)), Color.FromArgb(s(c.R - 20), s(c.G - 20), s(c.B - 20)), 90, false);
                    buff.FillRectangle(brGradient, 1, 1, Width - 2, Height - 2);

                    p = new Pen(Color.FromArgb(50, 255, 255, 255), 1);
                    buff.DrawRectangle(p, 1, 1, Width - 3, Height - 3);
                }


                if (Style == StyleMode.ImageRollover)
                {
                    buff.DrawImage(_image, new Rectangle(this.Width / 2 - _image.Width / 2, this.Height / 2 - _image.Height / 2, _image.Width, _image.Height));
                }


            }
            else if (_iStatus == 1)
            {
                if (this.Checked)
                {
                    p = new Pen(Color.FromArgb(s(cc.R - 40), s(cc.G - 40), s(cc.B - 40)), 1);
                    buff.DrawRectangle(p, 0, 0, Width - 1, Height - 1);

                    brGradient = new LinearGradientBrush(new Rectangle(1, 1, Width - 2, Height - 2), Color.FromArgb(s(cc.R + 40 + b), s(cc.G + 40 + b), s(cc.B + 40 + b)), Color.FromArgb(s(cc.R), s(cc.G), s(cc.B)), 90, false);
                    buff.FillRectangle(brGradient, 1, 1, Width - 2, Height - 2);

                    p = new Pen(Color.FromArgb(50, 255, 255, 255), 1);
                    buff.DrawRectangle(p, 1, 1, Width - 3, Height - 3);
                }
                else
                {
                    p = new Pen(Color.FromArgb(s(c.R - 40), s(c.G - 40), s(c.B - 40)), 1);
                    buff.DrawRectangle(p, 0, 0, Width - 1, Height - 1);

                    brGradient = new LinearGradientBrush(new Rectangle(1, 1, Width - 2, Height - 2), Color.FromArgb(s(c.R + 40 + b), s(c.G + 40 + b), s(c.B + 40 + b)), Color.FromArgb(s(c.R), s(c.G), s(c.B)), 90, false);
                    buff.FillRectangle(brGradient, 1, 1, Width - 2, Height - 2);

                    p = new Pen(Color.FromArgb(50, 255, 255, 255), 1);
                    buff.DrawRectangle(p, 1, 1, Width - 3, Height - 3);
                }

                if (Style == StyleMode.ImageRollover)
                {
                    buff.DrawString(this.Text, this.Font, TextBrush, ClientRectangle, sf);
                }
            }
            else if (_iStatus == 2)
            {
                if (Checked)
                {
                    p = new Pen(Color.FromArgb(s(cc.R - 40), s(cc.G - 40), s(cc.B - 40)), 1);
                    buff.DrawRectangle(p, 0, 0, Width - 1, Height - 1);


                    brGradient = new LinearGradientBrush(new Rectangle(1, 1, Width - 2, Height - 2), Color.FromArgb(s(cc.R - 10 + b), s(cc.G - 10 + b), s(cc.B - 10 + b)), Color.FromArgb(s(cc.R - 50), s(cc.G - 50), s(cc.B - 50)), 90, false);
                    buff.FillRectangle(brGradient, 1, 1, Width - 2, Height - 2);


                    p = new Pen(Color.FromArgb(50, 255, 255, 255), 1);
                    buff.DrawRectangle(p, 1, 1, Width - 3, Height - 3);
                }
                else
                {
                    p = new Pen(Color.FromArgb(s(c.R - 40), s(c.G - 40), s(c.B - 40)), 1);
                    buff.DrawRectangle(p, 0, 0, Width - 1, Height - 1);


                    brGradient = new LinearGradientBrush(new Rectangle(1, 1, Width - 2, Height - 2), Color.FromArgb(s(c.R - 10 + b), s(c.G - 10 + b), s(c.B - 10 + b)), Color.FromArgb(s(c.R - 50), s(c.G - 50), s(c.B - 50)), 90, false);
                    buff.FillRectangle(brGradient, 1, 1, Width - 2, Height - 2);


                    p = new Pen(Color.FromArgb(50, 255, 255, 255), 1);
                    buff.DrawRectangle(p, 1, 1, Width - 3, Height - 3);
                }

                if (Style == StyleMode.ImageRollover)
                {
                    buff.DrawString(this.Text, this.Font, TextBrush, ClientRectangle, sf);
                }

            }


            if (Style == StyleMode.Default)
            {
                if (_image != null)
                {
                    //중간 - (내 높이 + 픽셀 + 2)/2
                    buff.DrawImage(_image, new Rectangle(this.Width / 2 - _image.Width / 2, this.Height / 2 - (_image.Height + (int)(Font.Size * 4 / 3) + 2) / 2, _image.Width, _image.Height));
                    buff.DrawString(this.Text, this.Font, TextBrush, this.Width / 2, this.Height / 2 - (_image.Height + (int)(Font.Size * 4 / 3) + 2) / 2 + _image.Height + 5 + (Font.Size * 4 / 3) / 2, sf);
                }
                else
                {

                    buff.DrawString(this.Text, this.Font, TextBrush, ClientRectangle, sf);
                }
            }
            else if (Style == StyleMode.ImageOnly)
            {
                buff.DrawImage(_image, new Rectangle(this.Width / 2 - _image.Width / 2, this.Height / 2 - _image.Height / 2, _image.Width, _image.Height));
            }

            e.Graphics.DrawImage(bmp, 0, 0);
            buff.Dispose();
            bmp.Dispose();
        }

        private void UserControl1_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void JButton_MouseUp(object sender, MouseEventArgs e)
        {
            _isClicked = false;
            Draw();
        }

        private void JButton_MouseLeave(object sender, EventArgs e)
        {
            _isMouseIn = false;
            Draw();
        }

        private void JButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isClicked = true;
                Draw();
            }
        }

        private void JButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 0 || e.Y < 0 || e.X > Width || e.Y > Height)
                _isMouseIn = false;
            else
                _isMouseIn = true;
            Draw();
        }

        private void JButton_Load(object sender, EventArgs e)
        {

        }

        private void JButton_Click(object sender, EventArgs e)
        {
            if (Mode == ControlMode.Checkbox)
            {
                if (this.Checked)
                    Checked = false;
                else
                    Checked = true;
            }
            else if (Mode == ControlMode.Radiobutton)
            {
                Checked = true;
                if (this.Checked)
                    foreach (JButton bt in Parent.Controls)
                        if (bt.Mode == ControlMode.Radiobutton && !bt.Equals(this))
                            bt.Checked = false;
            }
        }
    }
}
