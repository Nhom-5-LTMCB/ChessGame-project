using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace ServerChessGame
{
    internal class Program
    {
        private static TcpListener server = null;
        private static TcpClient client = null;
        private static Thread manageClientThread = null;
        private static Hashtable clients = new Hashtable(); //chứa danh sách client
        private static Hashtable manageChatThread = new Hashtable();
        private static Thread acceptClientThread = null;
        private static NetworkStream stream = null;

        static void acceptClient()
        {
            while (true)
            {
                client = server.AcceptTcpClient();
                //khi login vào
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024 * 500];
                int length = stream.Read(buffer, 0, buffer.Length);
                string userName = Encoding.UTF8.GetString(buffer, 0, length);
                if (clients.ContainsKey(userName))
                {
                    clients.Remove(userName);
                    Console.WriteLine("Da xoa: " + userName);
                }
                clients.Add(userName, client);

                //khởi chạy toàn bộ luồng dữ liệu
                manageClientThread = new Thread(new ParameterizedThreadStart(rcvData));
                if (manageChatThread.ContainsKey(userName))
                {
                    manageChatThread.Remove(userName);
                    Console.WriteLine("Luong cua: " + userName + " da bi xoa");
                }
                manageChatThread.Add(userName, manageClientThread);

                Thread thread = (Thread)manageChatThread[userName];
                thread.Start(client);
            }
        }
        static void rcvData(object cl)
        {
            try
            {
                TcpClient client = (TcpClient)cl;
                while (true)
                {
                    stream = client.GetStream();
                    byte[] buffer = new byte[1024 * 500];
                    int length = stream.Read(buffer, 0, buffer.Length);
                    string message = Encoding.UTF8.GetString(buffer, 0, length);
                    //phân loại dữ liệu
                    string[] listMsg = message.Split('*');

                    switch (int.Parse(listMsg[0]))
                    {
                        case 0: //cập nhật lại danh sách phòng chơi
                            foreach (string key in clients.Keys)
                            {
                                if (key != listMsg[1])
                                {
                                    TcpClient client1 = (TcpClient)clients[key];
                                    stream = client1.GetStream();
                                    byte[] buffer2 = Encoding.UTF8.GetBytes(message);
                                    stream.Write(buffer2, 0, buffer2.Length);
                                }
                            }
                            break;
                        case 1:
                            string[] lst = listMsg[1].Split(':');

                            TcpClient clientRcv = (TcpClient)clients[lst[0]];
                            if (clientRcv != null)
                            {
                                stream = clientRcv.GetStream();
                                byte[] buffer1 = Encoding.UTF8.GetBytes(message);
                                stream.Write(buffer1, 0, buffer1.Length);
                            }
                            break;
                        case 2:
                            TcpClient clientRcv1 = (TcpClient)clients[listMsg[1]];
                            if (clientRcv1 != null)
                            {
                                stream = clientRcv1.GetStream();
                                byte[] buffer1 = Encoding.UTF8.GetBytes(message);
                                stream.Write(buffer1, 0, buffer1.Length);
                            }
                            break;
                        case 3:
                            TcpClient clientRcv2 = (TcpClient)clients[listMsg[1]];
                            if (clientRcv2 != null)
                            {
                                stream = clientRcv2.GetStream();
                                byte[] buffer1 = Encoding.UTF8.GetBytes(message);
                                stream.Write(buffer1, 0, buffer1.Length);
                            }
                            break;
                        case 4: //dùng để tạo ra các luồng chat 1-1
                            string[] lstInfo = listMsg[1].Split(":");
                            TcpClient currentClient = (TcpClient)clients[lstInfo[3]];
                            if (currentClient != null)
                            {
                                stream = currentClient.GetStream();
                                byte[] buffer1 = Encoding.UTF8.GetBytes(message);
                                stream.Write(buffer1, 0, buffer1.Length);
                            }

                            break;
                        case 5:
                            //tách lấy ra username
                            string[] strs = listMsg[1].Split(":");
                            string userName = strs[0].Substring(0, strs[0].Length - 3);
                            //tiến hành gửi dữ liệu về cho những user còn lại
                            foreach (string key in clients.Keys)
                            {
                                if (key != userName)
                                {
                                    TcpClient client1 = (TcpClient)clients[key];
                                    stream = client1.GetStream();
                                    byte[] buffer2 = Encoding.UTF8.GetBytes(message);
                                    stream.Write(buffer2, 0, buffer2.Length);
                                }
                            }
                            break;
                        case 6: //xử lý logout
                            string[] msgs = listMsg[1].Split(",");
                            //gửi dữ liệu đến các client còn lại
                            foreach (string key in clients.Keys)
                            {
                                if (key != msgs[0])
                                {
                                    TcpClient currentCl = (TcpClient)clients[key];
                                    if (currentCl != null)
                                    {
                                        stream = currentCl.GetStream();
                                        byte[] buffer2 = Encoding.UTF8.GetBytes(message);
                                        stream.Write(buffer2, 0, buffer2.Length);
                                    }
                                }
                            }
                            //đóng kết nối của client này
                            TcpClient currentCl1 = (TcpClient)clients[msgs[0]];
                            if (currentCl1 != null)
                                currentCl1.Close();
                            clients.Remove(msgs[0]);
                            foreach (string key in manageChatThread.Keys)
                            {
                                if (key == msgs[0])
                                {
                                    manageChatThread.Remove(key);
                                    return;
                                }
                            }
                            break;
                        case 7:
                            string[] lst1 = listMsg[1].Split(':');
                            TcpClient clientRcv3 = (TcpClient)clients[lst1[0]];
                            if (clientRcv3 != null)
                            {
                                stream = clientRcv3.GetStream();
                                byte[] buffer1 = Encoding.UTF8.GetBytes(message);
                                stream.Write(buffer1, 0, buffer1.Length);
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        static void Main(string[] args)
        {
            //server = new TcpListener(System.Net.IPAddress.Any, 8081);
            //server.Start();


            //acceptClientThread = new Thread(new ThreadStart(acceptClient));
            //acceptClientThread.Start();
        }
    }
}