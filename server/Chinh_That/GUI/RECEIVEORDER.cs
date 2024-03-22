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
    public partial class RECEIVEORDER : Form
    {
        public RECEIVEORDER()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//tránh việc đụng độ khi sử dụng tài nguyên giữa các thread
            Connect();
        }
        Boolean down = false, enter = false;
        int X, Y, MX, MY;

        IPEndPoint IP;
        Socket server;
        //khai báo 1 list các client
        List<Socket> clientList;
        List<List<BILLS>> ListBills;
        
        DataTable dtOrder1;

        DataTable createDTorder()
        {
            DataTable dtOrder = new DataTable();
            dtOrder.Columns.Add("id", typeof(int));
            dtOrder.Columns.Add("prices", typeof(int));
            dtOrder.Columns.Add("quantity", typeof(int));
            return dtOrder;
        }

        public DataTable getDTorder()
        {
            return dtOrder1;
        }

        public void loadFLPFEEDBACK(List<List<PRIVATENEWS>> list)
        {
            flpfeedback1.flowLayoutPanel1.Controls.Clear();
            foreach(List<PRIVATENEWS> lpn in list)
            {
                foreach (PRIVATENEWS pn in lpn)
                {
                    flpfeedback1.flowLayoutPanel1.Controls.Add(pn);
                }
            }
        }
        //kết nối đến server
        void Connect()
        {
            ListBills = new List<List<BILLS>>();
            clientList = new List<Socket>();//khởi tạo 1 list nhiều client
            
            //khởi tạo địa chỉ IP và socket để kết nối
            IP = new IPEndPoint(IPAddress.Any, 7654);
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
                        
                        List<BILLS> list = new List<BILLS>();
                        ListBills.Add(list);
                        

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
                    IP = new IPEndPoint(IPAddress.Any, 7654);
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
                    DataTable dt = (DataTable)Deseriliaze(data);
                    
                    dtOrder1 = dt;
                    
                    //khi 1 client gửi thì cả server và các client (ngoại trừ thằng client vừa gửi) cùng nhận đc

                    BILLS bill = new BILLS();
                    foreach(DataRow dr in dtOrder1.Rows)
                    {
                        DataTable dataTable = new DataTable();
                        dataTable = PRODUCT_BLL.Instance.getProductByIDproduct(Convert.ToInt32(dr["id"]));
                        
                        foreach(DataRow row in dataTable.Rows)
                        {
                            CARTITEM ci = new CARTITEM();
                            if (row["id_product_category"].ToString() == "1")
                            {
                                ci.panel1.BackColor = Color.DarkOrange;
                                ci.btnExit.BackColor = Color.DarkOrange;
                            }
                            else if (row["id_product_category"].ToString() == "2")
                            {
                                ci.panel1.BackColor = Color.Gold;
                                ci.btnExit.BackColor = Color.Gold;
                            }
                            else if (row["id_product_category"].ToString() == "3")
                            {
                                ci.panel1.BackColor = Color.ForestGreen;
                                ci.btnExit.BackColor = Color.ForestGreen;
                            } 
                            ci.label1.Text = row["product_name"].ToString();
                            ci.txbSoLuong.Text = dr["quantity"].ToString();
                            if (row["product_name"].ToString() == "Nạp tự chọn")
                                ci.lbPrice.Text = dr["prices"].ToString();
                            else ci.lbPrice.Text = row["prices"].ToString();
                            ci.buttonAdd.Enabled = false;
                            ci.buttonSub.Enabled = false;
                            MemoryStream ms = new MemoryStream((byte[])row["image_url"]);
                            ci.pictureBox1.Image = Image.FromStream(ms);
                            bill.flowLayoutPanel1.Controls.Add(ci);
                            
                        }
                    }
                    for (int i = 0; i<clientList.Count; i++)
                    {
                        if (clientList[i] != null && clientList[i] == client) 
                        {
                            int j = i + 1;
                            IPEndPoint remoteEndPoint = (IPEndPoint)client.RemoteEndPoint;
                            string remoteIP = remoteEndPoint.Address.ToString();
                            int num = MayTinh_BLL.Instance.getComByIP(remoteIP);
                            bill.lbClient.Text = "Máy " + num.ToString();
                            bill.btnAccept.Click += BtnAccept_Click;
                            ListBills[i].Add(bill);
                            
                            break;
                        }
                    }

                    MessageBox.Show("Bạn có đơn hàng mới");
                    flpbills1.flowLayoutPanel1.Controls.Add(bill);
                    
                }
            }
            catch
            {
                
                for (int i = 0; i < clientList.Count; i++)
                    if (clientList[i] == client) clientList[i] = null;
                client.Close();
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            BILLS bi = (BILLS)bt.Parent;
            String[] str = bi.lbClient.Text.Split(' ');
            int cs = Convert.ToInt32(str[1]);
            bi.btnAccept.Enabled = false;
            Send(clientList[cs-1], "YES");
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
            stream.Position = 0;
            return formatter.Deserialize(stream);
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void buttonMini_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flpbills1.Visible= true;
            flpfeedback1.Visible= false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flpbills1.Visible = false;
            flpfeedback1.Visible = true;
        }

        private void RECEIVEORDER_Load(object sender, EventArgs e)
        {
            flpbills1.Visible = false;
            flpfeedback1.Visible = false;
        }

        

        private void buttonReload_Click(object sender, EventArgs e)
        {
            flpbills1.flowLayoutPanel1.Controls.Clear();
            foreach (List<BILLS> lb in ListBills)
            {
                foreach (BILLS bi in lb)
                {
                    flpbills1.flowLayoutPanel1.Controls.Add(bi);
                }
            }
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
