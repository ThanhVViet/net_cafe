using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Chinh_That.DTO;
using Chinh_That.BLL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Chinh_That
{
    public partial class RECEIVERMTIME : Form
    {
        public RECEIVERMTIME()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//tránh việc đụng độ khi sử dụng tài nguyên giữa các thread
            Connect();
        }

        IPEndPoint IP;
        Socket server;
        //khai báo 1 list các client
        int dem = 0;
        int dem1 = 0;
        List<Socket> clientList;
        List<String> username;


        void Connect()
        {
            clientList = new List<Socket>();//khởi tạo 1 list nhiều client
            username = new List<String>();
            //khởi tạo địa chỉ IP và socket để kết nối
            IP = new IPEndPoint(IPAddress.Any, 8989);
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
                    IP = new IPEndPoint(IPAddress.Any, 8989);
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
        public void Send(string user_name, string s)
        {
            
            int i = 0;
            for (i=0;i<username.Count;i++)
            {
                if (username[i] == user_name) break;
            }
            if (clientList[i] != null)
            {
                clientList[i].Send(Serialize(s));
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
                    

                    string[] str = message.Split(' ');
                    
                    int id = ACCOUNT_BLL.Instance.getAccountID(str[0]);
                    
                    if (str[1] == "Start")
                    {
                        username.Add(str[0]);
                        ACCOUNT_BLL.Instance.updateState(id, true);
                        IPEndPoint remoteEndPoint = (IPEndPoint)client.RemoteEndPoint;
                        string remoteIP = remoteEndPoint.Address.ToString();
                        int ID = MayTinh_BLL.Instance.getIDByIP(remoteIP);
                        MayTinh_BLL.Instance.UpdateStatus(ID, true);
                        MayTinh_BLL.Instance.UpdateUser(ID, str[0]);

                    }
                    if (str[1] == "End")
                    {
                        IPEndPoint remoteEndPoint = (IPEndPoint)client.RemoteEndPoint;
                        string remoteIP = remoteEndPoint.Address.ToString();
                        int ID = MayTinh_BLL.Instance.getIDByIP(remoteIP);
                        ACCOUNT_BLL.Instance.updateState(id, false);
                        MayTinh_BLL.Instance.UpdateStatus(ID, false);
                        MayTinh_BLL.Instance.UpdateUser(ID, "");
                    }
                    else if (str[1] == "0:0:0")
                    {
                        IPEndPoint remoteEndPoint = (IPEndPoint)client.RemoteEndPoint;
                        string remoteIP = remoteEndPoint.Address.ToString();
                        int ID = MayTinh_BLL.Instance.getIDByIP(remoteIP);
                        MayTinh_BLL.Instance.UpdateStatus(ID, false);
                        ACCOUNT_BLL.Instance.updateState(id, false);
                        ACCOUNT_BLL.Instance.updateReminingtime(id, str[1]);
                        MayTinh_BLL.Instance.UpdateUser(ID, "");
                    }
                    else if (str[1] == "resetpass")
                    {
                        ACCOUNT_BLL.Instance.resetPASS(str[2], str[0]);
                    }
                    else ACCOUNT_BLL.Instance.updateReminingtime(id, str[1]);

                }
            }
            catch
            {
                int i;
                for (i = 0; i<clientList.Count;i++)
                {
                    if (clientList[i] != null && clientList[i] == client) break;
                    
                }
                clientList.Remove(clientList[i]);
                if (i<username.Count) username.Remove(username[i]);
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
