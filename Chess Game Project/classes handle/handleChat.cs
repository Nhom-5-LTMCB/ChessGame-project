using Chess_Game_Project.ContainUserControls;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Game_Project.classes_handle
{
    public class handleChat
    {
        static int posY = 0;
        static public void writeData(System.Drawing.Image imgContent, string linkAvt, string msg, int mode, string userName, string mainUsername, Guna2Panel pnl)
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
                        userControl.addUsernameAndImage(linkAvt, userName, mainUsername);
                        int userControlWidth = pnl.Width * 70 / 100;
                        userControl.Location = new Point(0, posY);
                        userControl.Size = new Size(userControlWidth, userControl.Height);
                        pnl.Controls.Add(userControl);
                        userControl.content = msg;
                        userControl.addMesageIntoFrame(userControlWidth);
                        posY += userControl.Height;
                        pnl.ScrollControlIntoView(userControl);
                        pnl.AutoScroll = true;
                        pnl.HorizontalScroll.Visible = false;
                    });
                    Invoke(invoker);
                }
                else
                {
                    MethodInvoker invoker = new MethodInvoker(delegate
                    {
                        pnl.AutoScroll = false;
                        userControlContentChatIcon userControl = new userControlContentChatIcon();
                        userControl.addUsernameAndImage($"{parentDirectory}\\{linkAvt}", userName, imgContent, user.userName);
                        userControl.Location = new Point(0, posY);
                        pnl.Controls.Add(userControl);
                        posY += userControl.Height;
                        pnl.ScrollControlIntoView(userControl);

                        pnlContainsIcon.Hide();
                        buttonListIcons.Clear();

                        pnl.AutoScroll = true;
                        pnl.HorizontalScroll.Visible = false;
                    });
                    this.Invoke(invoker);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
