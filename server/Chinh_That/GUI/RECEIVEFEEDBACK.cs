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
using Chinh_That.BLL;

namespace Chinh_That
{
    public partial class RECEIVEFEEDBACK : Form
    {
        public RECEIVEFEEDBACK()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//tránh việc đụng độ khi sử dụng tài nguyên giữa các thread
            Connect();
        }

        IPEndPoint IP;
        Socket server;
        //khai báo 1 list các client
        List<Socket> clientList;
        List<List<PRIVATENEWS>> ListPNews;

        void Connect()
        {
            clientList = new List<Socket>();//khởi tạo 1 list nhiều client
            ListPNews = new List<List<PRIVATENEWS>>();
            //khởi tạo địa chỉ IP và socket để kết nối
            IP = new IPEndPoint(IPAddress.Any, 3434);
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
                        List<PRIVATENEWS> list = new List<PRIVATENEWS>();
                        ListPNews.Add(list);

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
                    IP = new IPEndPoint(IPAddress.Any, 3434);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            Listen.IsBackground = true;
            Listen.Start();
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
            if (client != null)
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
                    int i = 0;
                    for (i = 0; i < clientList.Count; i++)
                    {
                        if (clientList[i] != null && clientList[i] == client)
                        {
                            break;
                        }
                    }
                    IPEndPoint remoteEndPoint = (IPEndPoint)client.RemoteEndPoint;
                    string remoteIP = remoteEndPoint.Address.ToString();
                    int num = MayTinh_BLL.Instance.getComByIP(remoteIP);
                    int j = i + 1;
                    PRIVATENEWS pn = new PRIVATENEWS();
                    pn.panel1.BackColor = Color.DarkViolet;
                    pn.btnExit.BackColor = Color.DarkViolet;
                    pn.label2.Text = "Phản hồi";
                    pn.label1.Text = "Máy " + num.ToString() + " đã phải hồi về việc " + message + " !";
                    ListPNews[i].Add(pn);
                    Send(client, "YES");
                }
            }
            catch
            {
                for (int i = 0; i < clientList.Count; i++)
                    if (clientList[i] == client) clientList[i] = null;
                client.Close();
            }
        }

        public List<List<PRIVATENEWS>> getPNewsList()
        {
            return ListPNews;
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
    }
}
