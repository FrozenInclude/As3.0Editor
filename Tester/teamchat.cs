using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Threading;
namespace Tester
{
    public partial class teamchat : Form
    {
        TcpClient Client;   // 서버+클라이언트기능을 하기위해서
        StreamReader Reader; //스트림 값을 읽어오기 위해서
        StreamWriter Writer; //스트림 값을 쓰기위해서
        NetworkStream stream; //네트워크스트림 연결을 위해서
        Thread ReceiveThread; //멀티쓰레드를 위해서
        bool Connected;  // 연결상태확인
        private delegate void AddTextDelegate(string strText); //Cross-Thread 호출을 실행하기 위해 사용함.
        public teamchat()
        {
            InitializeComponent();
        }
        private void teamchat_FormClosing(object sender, FormClosedEventArgs e) //종료버튼을 눌렀을때
        {
            Connected = false;

            if (Reader != null)
                Reader.Close();

            if (Writer != null)
                Writer.Close();

            if (Client != null)
                Client.Close();

            if (ReceiveThread != null)
                ReceiveThread.Abort();
        }

        private void photoshop1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.AppendText("나:" + textBox3.Text + "\r\n"); // 이쪽 : 블라블라~
            Writer.WriteLine(textBox3.Text);  //작성한 글을 읽어서 씀 
            Writer.Flush();                  //전송하고 비움.

            textBox3.Clear(); // 글을 작성하는 부분 클리어
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") //ip 않적고 눌르면
            {
                MessageBox.Show("서버IP 주소를 입력해 주세요", "", MessageBoxButtons.OK, MessageBoxIcon.Error); //에러 창 뜨게하기
            }

            try
            {

                String IP = textBox1.Text; // ip쓰는 창에서 IP값 바다오기
                int port = 8080; //포트설정

                Client = new TcpClient();  //클라이언트 생성
                Client.Connect(IP, port);  //클라이언트 서버에 연결

                stream = Client.GetStream(); // 클라이언트의 스트림값 받아오기
                Connected = true; // 서버연결성공시 true
                textBox2.AppendText("서버와 연결되었습니다" + "\r\n");

                Reader = new StreamReader(stream);  // 스트림값을 읽어드리기
                Writer = new StreamWriter(stream);  // 스트림값을 쓰기

                ReceiveThread = new Thread(new ThreadStart(Receive)); //클래스를 통해서 값을 받는다.
                ReceiveThread.Start(); // 값을 받는 스레드 실행
            }
            catch(Exception ConnE)
            {
                textBox2.AppendText("서버에 연결할 수 없습니다." + "\r\n");
            }
        }
        private void Receive()
        {
            AddTextDelegate AddText = new AddTextDelegate(textBox2.AppendText); // 메소드 등록

            try
            {

                while (Connected)
                {
                    Thread.Sleep(1); //Windows 시스템은 거의 정확한 sleep 시간을 보장한다. 즉, 1ms에 거의 유사한 sleep 시간을 제공한다.

                    if (stream.CanRead) // 스트림을 읽을 수 있다면...
                    {
                        string tempStr = Reader.ReadLine(); // 값을 일어와서

                        if (tempStr.Length > 0) // 문자 길이가 0이 아니라면
                        {
                            Invoke(AddText, "팀원: " + tempStr + "\r\n"); // 출력
                           // Panel_1.Text = "메시지도착시간: " + DateTime.Now; // 메시지도착시간 출력

                        }


                    }

                }

            }
            catch (Exception e)
            {
                this.Dispose(true);
            }

        }


    }
}
