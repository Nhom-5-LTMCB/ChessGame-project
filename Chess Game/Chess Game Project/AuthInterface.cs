using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Chess_Game_Project.classes_handle;

namespace Chess_Game_Project
{
    public partial class AuthInterface : Form
    {
        public AuthInterface()
        {
            InitializeComponent();
        }

        private string apiAuthAccount = "https://chessmates.onrender.com/api/v1/auth/forgotPassword";
        private async void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAuthEmail.Text.Trim() == "" || txtAuthUserName.Text.Trim() == "")
                    return;
                string userName = txtAuthUserName.Text.Trim();
                string gmail = txtAuthEmail.Text.Trim();
                var data = new
                {
                    userName,
                    gmail
                };

                JToken tkData = await manageApi.callApiUsingMethodPost(data, apiAuthAccount);
                if (tkData != null)
                {
                    MessageBox.Show("Vui lòng kiểm tra hộp thư để lấy mã");
                    //chuyển qua form nhập mã xác thực
                    InputTokenForm1 token = new InputTokenForm1(userName, gmail);
                    token.Show();

                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("Tài khoản này không hợp lệ, vui lòng nhập lại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi, vui lòng thực hiện lại");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Login.showFormAgain.Show();
            this.Close();
        }

        private void AuthInterface_Load(object sender, EventArgs e)
        {
            // Thiết lập kích thước form
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int formWidth = (int)(screenWidth * 0.8);
            int formHeight = (int)(screenHeight * 0.8);
            this.Size = new Size(formWidth, formHeight);

            // Đặt vị trí của form để nằm chính giữa màn hình
            int left = (screenWidth - formWidth) / 2;
            int top = (screenHeight - formHeight) / 2;
            this.Location = new Point(left, top);

            // Đưa Panel vào chính giữa màn hình
            pnlContent.Location = new Point((this.Width - pnlContent.Width) / 2,
                                        (this.Height - pnlContent.Height) / 2);
            pnlContent.Parent = this;
        }
    }
}
