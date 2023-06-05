using Chess_Game_Project.classes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Game_Project
{
    public partial class InfoUserInterface : Form
    {
        private string preUserame;
        private string preEmail;
        private infoUser user;
        private string apiGetUser = "https://chessmates.onrender.com/api/v1/users/edit/";
        private string directoryImagePath;
        private string pathImage;
        private string preLinkAvatar;
        private bool checkModify;
        public InfoUserInterface()
        {
            InitializeComponent();
        }

        public InfoUserInterface(infoUser user, bool checkModify) : this()
        {
            try
            {
                //đếm số trận thắng và số trận thua
                int numberOfWins = 0, numberOfLosses = 0;
                foreach (match item in user.matches)
                {
                    if (string.Equals(item.status, "finished"))
                    {
                        foreach (matchPlayer player in item.players)
                        {
                            if (string.Equals(player.user, user.id))
                            {
                                if (string.Equals(player.resultMatch.ToLower(), "win"))
                                    numberOfWins++;
                                else
                                    numberOfLosses++;
                            }
                        }
                    }
                }

                directoryImagePath = Directory.GetParent(Application.StartupPath)?.Parent?.FullName + "\\Images";
                this.checkModify = checkModify;
                if (checkModify)
                {
                    btnChangeImage.Enabled = false;
                    btnSaveInfo.Enabled = false;
                }
                else
                {
                    btnChangeImage.Visible = false;
                    btnSaveInfo.Visible = false;
                    btnEditInfo.Visible = false;
                }
                this.user = user;

                //hiển thị hình ảnh lên giao diện
                ptboxAvatar.Image = Image.FromFile($"{directoryImagePath}\\" + user.linkAvatar);
                ptboxAvatar.SizeMode = PictureBoxSizeMode.Zoom;

                txtDefeats.Text = numberOfLosses.ToString();
                txtWins.Text = numberOfWins.ToString();
                txtUsername.Text = user.userName;
                txtEmail.Text = user.gmail;
                txtID.Text = user.id;
                preLinkAvatar = user.linkAvatar;
                //lưu lại thông tin trước đó
                preEmail = user.gmail;
                preUserame = user.userName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void InfoUserInterface_Load(object sender, EventArgs e)
        {
            
        }
        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            
        }
        private void addImageIntoPath(string directoryPath, string fileImage)
        {
            
        }
        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
           
        }
        private void btnChangeImage_Click(object sender, EventArgs e)
        {
           
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
           
        }
    }
}
