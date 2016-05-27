using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Tester
{
    public partial class 버그리포터 : Form
    {
        public 버그리포터()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                MessageBox.Show("내용을 입력해주세요!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else if (textBox1.Text!="")
            {
              string result;
            string id = textBox1.Text+"@naver.com";
           SmtpClient client = new SmtpClient("smtp.naver.com",587);
           client.UseDefaultCredentials = false;
           client.EnableSsl = true; 
           client.DeliveryMethod = SmtpDeliveryMethod.Network;
           client.Credentials = new System.Net.NetworkCredential("abc6271416","programming");
           MailAddress from = new MailAddress("abc6271416@naver.com","[As3.0Editor]버그리포트", System.Text.Encoding.UTF8);
           MailAddress to = new MailAddress("abc6271416@naver.com");
           MailMessage message = new MailMessage(from, to);
           message.Subject ="[As3.0Editor]버그리포트";
           message.Body = "버그내용:"+textBox1.Text;
           message.SubjectEncoding = System.Text.Encoding.UTF8;
           message.BodyEncoding = System.Text.Encoding.UTF8;
           //MessageBox.Show("로그인 실패");
            try
            {
          
                client.Send(message);
              
                message.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (MessageBox.Show("버그리포트가 완료되었습니다!.", "감사합니다.", MessageBoxButtons.OK,MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
            }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        private void jButton4_DoubleClick(object sender, EventArgs e)
        {

        }
        }
    }

