using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinh_That
{
    public partial class CHATFORM : Form
    {
        public CHATFORM()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//tránh việc đụng độ khi sử dụng tài nguyên giữa các thread
            Connect();
        }
        Boolean down = false, enter = false;
        int X, Y, MX, MY;
        private void btnSend_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            CHATBOX bc = (CHATBOX)btn.Parent;
            String[] str = bc.lbClient.Text.Split(' ');
            int cs = Convert.ToInt32(str[1]);
            Send(clientList[cs - 1], "Server: " + bc.txbMessage.Text);
            bc.AddMessage("Server: " + bc.txbMessage.Text);
            bc.txbMessage.Clear();
        }
        IPEndPoint IP;
        Socket server;
        //khai báo 1 list các client
        List<Socket> clientList;
        List<ButtonClient> Listbuttons;
        List<CHATBOX> ListBoxChat;
        int dem = 0;
        int dem1 = 0;

        //kết nối đến server
        void Connect()
        {
            clientList = new List<Socket>();//khởi tạo 1 list nhiều client
            Listbuttons = new List<ButtonClient>();
            ListBoxChat = new List<CHATBOX>();
            //khởi tạo địa chỉ IP và socket để kết nối
            IP = new IPEndPoint(IPAddress.Any, 5656);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            //đợi kết nối từ client
            server.Bind(IP);
            //tạo 1 luồng lăng nghe từ client
            Thread Listen = new Thread(() => {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();//nếu lăng nghe thành công thì server chấp nhận kết nối
                        clientList.Add(client);//thêm các client được server accept vào list'
                       
                        dem++;
                        
                        CHATBOX bc = new CHATBOX();
                        bc.lbClient.Text = "Client " + dem.ToString();
                        ListBoxChat.Add(bc);
                        //MessageBox.Show("Co " + ListBoxChat.Count.ToString() + " phan tu trong ListBoxChat");
                        ButtonClient buttonClient = new ButtonClient();
                        buttonClient.button1.Text = "Client " + dem.ToString();
                        Listbuttons.Add(buttonClient);
                        //MessageBox.Show("Co " + Listbuttons.Count.ToString() + " phan tu trong Listbuttons");
                        bc.btnSend.Click += btnSend_Click;
                        buttonClient.button1.Click += ButtonClient_Click;

                        //tạo luồng nhận thông tin từ client
                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                /*khi kết nối đến n client mà có 1 client disconnect thì server sẽ chạy vòng lặp while liên tục để
                 chương trình ko bị crash*/
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 5656);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            Listen.IsBackground = true;
            Listen.Start();
        }
        void LoadFlowLayoutPanel(List<ButtonClient> buttonLists)
        {
            flowLayoutPanel1.Controls.Clear();
            
            foreach (ButtonClient buttonClient in buttonLists)
            {
                flowLayoutPanel1.Controls.Add(buttonClient);
            }
        }

        private void ButtonClient_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            String[] str = bt.Text.Split(' ');
            int cs = Convert.ToInt32(str[1]);
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.Controls.Add(ListBoxChat[cs - 1]);
        }

        //đóng kết nối đến server
        public void Close()
        {
            server.Close();
        }

        //gửi dữ liệu
        void Send(Socket client, string s)
        {
            //nếu textboc khác rỗng thì mới gửi tin
            if ((client != null) && (s != string.Empty))
            {
                client.Send(Serialize(s));
            }
        }

        //nhận dữ liệu
        void Receive(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    //khởi tạo mảng byte để nhận dữ liệu
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    //chuyển data từ dạng byte sang dạng string
                    string message = (string)Deseriliaze(data);

                    //khi 1 client gửi thì cả server và các client (ngoại trừ thằng client vừa gửi) cùng nhận đc

                    for (int i = 0; i < clientList.Count; i++)
                    {
                        if (clientList[i] != null && clientList[i] == client)
                        {
                            ListBoxChat[i].AddMessage(message);
                        }
                    }


                }
            }
            catch
            {
                for (int i = 0; i < clientList.Count; i++)
                    if (clientList[i] == client) clientList[i] = null;
                client.Close();
            }
        }




        //Hàm phân mảnh dữ liệu cần gửi từ dạng string sang dạng byte để gửi đi
        byte[] Serialize(object obj)
        {
            //khởi tạo stream để lưu các byte phân mảnh
            MemoryStream stream = new MemoryStream();
            //khởi tạo đối tượng BinaryFormatter để phân mảnh dữ liệu sang kiểu byte
            BinaryFormatter formatter = new BinaryFormatter();
            //phân mảnh rồi ghi vào stream
            formatter.Serialize(stream, obj);
            //từ stream chuyển các các byte thành dãy rồi cbi gửi đi
            return stream.ToArray();
        }

        //Hàm gom mảnh các byte nhận được rồi chuyển sang kiểu string để hiện thị lên màn hình
        object Deseriliaze(byte[] data)
        {
            //khởi tạo stream đọc kết quả của quá trình phân mảnh 
            MemoryStream stream = new MemoryStream(data);
            //khởi tạo đối tượng chuyển đổi
            BinaryFormatter formatter = new BinaryFormatter();
            //chuyển đổi dữ liệu và lưu lại kết quả 
            return formatter.Deserialize(stream);
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadFlowLayoutPanel(Listbuttons);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*if (dem1 != dem)
            {
                LoadFlowLayoutPanel(Listbuttons);
                dem1 = dem;
            }*/
            LoadFlowLayoutPanel(Listbuttons);
        }

        

        private void buttonReload_Click(object sender, EventArgs e)
        {
            LoadFlowLayoutPanel(Listbuttons);
        }

        private void buttonMini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void Form1_MouseDown_1(object sender, MouseEventArgs e)
        {
            down = true;
            MX = e.X;
            MY = e.Y;
            X = this.Location.X;
            Y = this.Location.Y;
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            enter = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            down = false;
        }

        private void Form1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (enter && down)
            {
                this.Location = new Point(X + (e.X - MX), Y + (e.Y - MY));
                this.BringToFront();
            }
        }
    }
}
