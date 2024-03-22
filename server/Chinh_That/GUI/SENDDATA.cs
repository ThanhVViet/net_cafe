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
    public partial class SENDDATA : Form
    {
        public SENDDATA()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//tránh việc đụng độ khi sử dụng tài nguyên giữa các thread
            Connect();
        }
        IPEndPoint IP;
        Socket server;
        //khai báo 1 list các client
        List<Socket> clientList;


        void Connect()
        {
            clientList = new List<Socket>();//khởi tạo 1 list nhiều client
            //khởi tạo địa chỉ IP và socket để kết nối
            IP = new IPEndPoint(IPAddress.Any, 5555);
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
                        client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer, 16384);
                        clientList.Add(client);//thêm các client được server accept vào list'

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
                    IP = new IPEndPoint(IPAddress.Any, 5555);
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
        void Send(Socket client, DataTable dt)
        {
            //nếu textboc khác rỗng thì mới gửi tin
            if (client != null)
            {
                client.Send(Serialize(dt));
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
                    DataTable dt = new DataTable();
                    /*IPEndPoint remoteEndPoint = (IPEndPoint)client.RemoteEndPoint;
                    string remoteIP = remoteEndPoint.Address.ToString();*/
                    if (message == "User")
                    {
                        //MessageBox.Show("User");
                        dt = CLIENTDATA_BLL.Instance.getAllUser();
                        Send(client, dt);
                    }
                    else if (message == "Customer")
                    {
                        //MessageBox.Show("Customer");
                        dt = CLIENTDATA_BLL.Instance.getAllCustomer();
                        Send(client, dt);
                    }
                    else if (message == "UserRole")
                    {
                        //MessageBox.Show("UserRole");
                        dt = CLIENTDATA_BLL.Instance.getAllUserRole();
                        Send(client, dt);
                    }
                    else if (message == "Product")
                    {
                        //MessageBox.Show("Product");
                        dt = CLIENTDATA_BLL.Instance.getAllProduct();
                        Send(client, dt);
                    }
                    else if (message == "Game")
                    {
                        //MessageBox.Show("Game");
                        dt = CLIENTDATA_BLL.Instance.getAllGame();
                        Send(client, dt);
                    }
                    else if (message == "News")
                    {
                        //MessageBox.Show("News");
                        dt = CLIENTDATA_BLL.Instance.getAllNews();
                        Send(client, dt);
                    }
                    else if (message == "End")
                    {
                        //MessageBox.Show("Hoàn tất gửi dữ liệu");
                        clientList.Remove(client);
                        client.Close();
                    }
                }
            }
            catch
            {
                clientList.Remove(client);
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
    }
}
