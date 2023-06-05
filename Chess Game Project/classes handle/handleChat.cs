using Chess_Game_Project.classes;
using Chess_Game_Project.ContainUserControls;
using Chess_Game_Project.Properties;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Chess_Game_Project.classes_handle
{
    internal class handleChat
    {
        private static button btn = new button();
        public static List<Button> buttonListIcons = new List<Button>();
        public static Button oldButton = new Button()
        {
            Height = 0,
            Width = 0
        };
        public static int iconNumbers = 29;

        public static void sendData(TcpClient client, string msg)
        {
            try
            {
                if (client != null)
                {
                    NetworkStream stream = client.GetStream();
                    byte[] data = Encoding.UTF8.GetBytes(msg);
                    stream.Write(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi sendData: " + ex.Message);
            }
        }
        public static void writeData(Image imgContent, string linkAvt, string msg, int mode, string userName, Guna2Panel pnl, Form form, int posY, string owner, string pathImages, Panel pnlContainsIcon)
        {
            try
            {
                if (mode == 1)
                {
                    if (msg.Trim() == "")
                        return;
                    MethodInvoker invoker = new MethodInvoker(delegate
                    {
                        pnl.AutoScroll = false;
                        userControlContentChatMessage userControl = new userControlContentChatMessage();
                        userControl.addUsernameAndImage($"{pathImages}\\{linkAvt}", userName, owner);
                        int userControlWidth = pnl.Width * 70 / 100;
                        userControl.Location = new System.Drawing.Point(0, posY);
                        userControl.Size = new System.Drawing.Size(userControlWidth, userControl.Height);
                        pnl.Controls.Add(userControl);
                        userControl.content = msg;
                        userControl.addMesageIntoFrame(userControlWidth);
                        LobbyInterface.posY += userControl.Height;
                        pnl.ScrollControlIntoView(userControl);
                        pnl.AutoScroll = true;
                        pnl.HorizontalScroll.Visible = false;
                    });
                    form.Invoke(invoker);
                }
                else
                {
                    MethodInvoker invoker = new MethodInvoker(delegate
                    {
                        pnl.AutoScroll = false;
                        userControlContentChatIcon userControl = new userControlContentChatIcon();
                        userControl.addUsernameAndImage($"{pathImages}\\{linkAvt}", userName, imgContent, owner);
                        userControl.Location = new System.Drawing.Point(0, posY);
                        pnl.Controls.Add(userControl);
                        LobbyInterface.posY += userControl.Height;
                        pnl.ScrollControlIntoView(userControl);

                        pnlContainsIcon.Hide();
                        buttonListIcons.Clear();

                        pnl.AutoScroll = true;
                        pnl.HorizontalScroll.Visible = false;
                    });
                    form.Invoke(invoker);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public static void writeDataChatOne(Image imgContent, string linkAvt, string msg, int mode, string userName, Guna2Panel pnl, Form form, int posY, string owner, string pathImages, userControlChatOne chat)
        {
            try
            {
                if (mode == 1)
                {
                    if (msg.Trim() == "")
                        return;
                    MethodInvoker invoker = new MethodInvoker(delegate
                    {
                        pnl.AutoScroll = false;
                        userControlContentChatMessage userControl = new userControlContentChatMessage();
                        userControl.addUsernameAndImage($"{pathImages}\\{linkAvt}", userName, owner);
                        int userControlWidth = pnl.Width * 70 / 100;
                        userControl.Location = new System.Drawing.Point(0, posY);
                        userControl.Size = new System.Drawing.Size(userControlWidth, userControl.Height);
                        pnl.Controls.Add(userControl);
                        userControl.content = msg;
                        userControl.addMesageIntoFrame(userControlWidth);
                        pnl.ScrollControlIntoView(userControl);
                        posY += userControl.Height;
                        chat.pos = posY;
                        pnl.VerticalScroll.Value = pnl.VerticalScroll.Maximum;
                        pnl.AutoScroll = true;
                        pnl.HorizontalScroll.Visible = false;
                    });
                    form.Invoke(invoker);
                }
                else
                {
                    MethodInvoker invoker = new MethodInvoker(delegate
                    {
                        pnl.AutoScroll = false;
                        userControlContentChatIcon userControl = new userControlContentChatIcon();
                        userControl.addUsernameAndImage($"{pathImages}\\{linkAvt}", userName, imgContent, owner);
                        userControl.Location = new System.Drawing.Point(0, posY);
                        pnl.Controls.Add(userControl);
                        posY += userControl.Height;
                        pnl.ScrollControlIntoView(userControl);
                        chat.pos = posY;
                        //pnlContainsIcon.Hide();
                        buttonListIcons.Clear();

                        pnl.AutoScroll = true;
                        pnl.HorizontalScroll.Visible = false;
                    });
                    form.Invoke(invoker);
                }
            }
            catch (Exception ex)
            {

            }
        }
        public static void displayListIconsIntoInterface(Panel containsIcon, int numberPerRow)
        {
            if (containsIcon.Visible)
            {
                containsIcon.Hide();
                buttonListIcons.Clear();
            }
            else
            {
                //xóa hết các phần tử bên trong panel
                containsIcon.Controls.Clear();
                containsIcon.Padding = new Padding(0);
                for (int i = 0; i < iconNumbers; i++)
                {
                    System.Windows.Forms.Button btnChatOne = null;
                    if (buttonListIcons.Count % numberPerRow == 0)
                    {
                        if (buttonListIcons.Count != 0)
                            oldButton.Location = new System.Drawing.Point(0, 30 + oldButton.Location.Y + 10);
                        btnChatOne = btn.createButton(oldButton, containsIcon, System.Drawing.Image.FromFile($"Resources\\{i + 1}.png"), Convert.ToString($"Resources\\{i + 1}.png"), true);
                    }
                    else
                    {
                        btnChatOne = btn.createButton(buttonListIcons[buttonListIcons.Count - 1], containsIcon, System.Drawing.Image.FromFile($"Resources\\{i + 1}.png"), Convert.ToString($"Resources\\{i + 1}.png"), true);
                    }
                    buttonListIcons.Add(btnChatOne);
                }
                oldButton.Location = new System.Drawing.Point(0, 0);
                containsIcon.Show();
            }
        }
    }
}
