using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;

namespace Chess_Game_Project.ContainUserControls
{
    public partial class userControlContentChatMessage : UserControl
    {
        public string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        public userControlContentChatMessage()
        {
            InitializeComponent();
        }
        public void addUsernameAndImage(string linkAvt, string username, string mainUsername)
        {
            ptvAvatar.Image = Image.FromFile(linkAvt);
            ptvAvatar.SizeMode = PictureBoxSizeMode.StretchImage;

            if(username == mainUsername) lbUserName.ForeColor = Color.Red;
            else lbUserName.ForeColor = Color.Black;    

            lbUserName.Text = username; 
        }
        public void addMesageIntoFrame(int userControlWidth)
        {
            txtContent.ScrollBars = ScrollBars.None;
            txtContent.Text = _content;
            txtContent.AutoSize = true;
            txtContent.Multiline = false;

            using (Graphics g2 = txtContent.CreateGraphics())
            {
                Size size = TextRenderer.MeasureText(g2, txtContent.Text + 50, txtContent.Font);
                txtContent.Width = size.Width;

                txtContent.Invalidate();
            }

            if (txtContent.Width > userControlWidth)
            {
                txtContent.Width = userControlWidth;
                txtContent.Multiline = true;
                txtContent.WordWrap = true;

                int marginLeft = 3, marginTop = 4, marginRight = 3, marginBottom = 4;

                int contentWidth = txtContent.Width - marginLeft - marginRight;
                int contentHeight = txtContent.Height - marginTop - marginBottom;
                using (Graphics g = txtContent.CreateGraphics())
                {
                    Size textSize = TextRenderer.MeasureText(g, txtContent.Text, txtContent.Font, new Size(contentWidth, contentHeight), TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);
                    int textHeight = textSize.Height;
                    txtContent.Height = textHeight + marginTop + marginBottom + 10;
                }
                txtContent.ReadOnly = true;
            }
            txtContent.Height -= 5;
        }

    }
}
