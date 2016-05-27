using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace Tester
{
    public partial class upload : Form
    {
        As3Editor ads;
        string ftpServerIP;
        string ftpUserID;
        string ftpPassword;
         public upload(As3Editor _form)
        {
            InitializeComponent();
            ads= _form;
        }
        public upload()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label3.Text = "URL:http://iaplle.esy.es/"+textBox1.Text+".html";
        }

        private void photoshop1_Load(object sender, EventArgs e)
        {
            ftpServerIP = "ftp.iaplle.esy.es";
            ftpUserID = "u949811289.include";
            ftpPassword = "asdf123";
        }
        string appPath = Path.GetDirectoryName(Application.ExecutablePath);

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
    As3Editor otherForm=new As3Editor();
        private void Upload(string filename)
        {
            FileInfo fileInf = new FileInfo(filename);
            string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;
            FtpWebRequest reqFTP;

            // Create FtpWebRequest object from the Uri provided
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + fileInf.Name));

            // Provide the WebPermission Credintials
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

            // By default KeepAlive is true, where the control connection is not closed
            // after a command is executed.
            reqFTP.KeepAlive = false;

            // Specify the command to be executed.
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            // Specify the data transfer type.
            reqFTP.UseBinary = true;

            // Notify the server about the size of the uploaded file
            reqFTP.ContentLength = fileInf.Length;

            // The buffer size is set to 2kb
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
            FileStream fs = fileInf.OpenRead();

            try
            {
                // Stream to which the file to be upload is written
                Stream strm = reqFTP.GetRequestStream();

                // Read from the file stream 2kb at a time
                contentLen = fs.Read(buff, 0, buffLength);

                // Till Stream content ends
                while (contentLen != 0)
                {
                    // Write Content from the file stream to the FTP Upload Stream
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }

                // Close the file stream and the Request Stream
                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Upload Error");
            }
        }
        private void jButton4_DoubleClick(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"C:\"+textBox1.Text+".html", false);
            sw.WriteLine("<!DOCTYPE html>"+@"<head><meta charset=""UTF-8"">​<title>삼정영 에디터 소스공유소</title></head>"+"<html>"+"<body>"+@"<span style=""font-family:고딕; font-size: 25pt; color: Blue"">AS3.0Editor </span> <span style=""font-family:고딕; font-size: 25pt; color: Black"">소스공유소</span><br><hr>"+"소스명:"+textBox1.Text+"   설명:"+textBox2.Text+"<br>"+"<div style=background:#B2A6A6; height: 50px;weigh:1px;>" + "</div>" + "<div style=background:#fafafa; height: 50px;weigh:1px;>"+ConvertRtbToHTML(otherForm.rtbText));
            sw.Close();
            sw.Dispose();
            Upload(@"C:\" + textBox1.Text + ".html");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
