using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Game_Project.ContainUserControls
{
    public partial class userControlChatIconRight : UserControl
    {
        public userControlChatIconRight()
        {
            InitializeComponent();
        }
        public void addUsernameAndImage(string linkAvt, string username, System.Drawing.Image img, string mainUsername)
        {
            if (username == mainUsername) lbUserName.ForeColor = Color.Red;
            else lbUserName.ForeColor = Color.Black;

            ptbAvatar.Image = Image.FromFile(linkAvt);
            ptbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbIcon.Image = img;
            ptbIcon.SizeMode = PictureBoxSizeMode.Zoom;
            lbUserName.Text = username;
            lbUserName.Location = new Point(lbUserName.Location.X + 5, lbUserName.Location.Y);
            ptbAvatar.Location = new Point(ptbAvatar.Location.X, ptbAvatar.Location.Y);
        }
    }
}
