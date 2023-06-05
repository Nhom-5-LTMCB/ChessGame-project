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
using Chess_Game_Project.classes;

namespace Chess_Game_Project
{
    public partial class ChangePasswordInterface : Form
    {
        public ChangePasswordInterface()
        {
            InitializeComponent();
            txtConfirmPassword.PasswordChar = '*';
            txtNewPassword.PasswordChar = '*';
        }

        private void ChangePasswordInterface_Load(object sender, EventArgs e)
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
        private string apiResetPassword = "https://chessmates.onrender.com/api/v1/auth/resetPassword";
        private void displayError(errorRegister errors)
        {
            errorNewPassword.Text = "";
            errorNewPassword.ForeColor = Color.Red;
            if (errorNewPassword.Text == "")
                if (errors.password != null)
                    foreach (string error in errors.password)
                        errorNewPassword.Text += error + "\n";
        }
        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text.Trim() == "") return;
            var data = new
            {
                password = txtNewPassword.Text.Trim()
            };

            string dataJson = JsonConvert.SerializeObject(data);
            HttpClient client = new HttpClient();
            // Gửi yêu cầu POST đến apiUrl với dữ liệu jsonData
            HttpResponseMessage response = await client.PostAsync(apiResetPassword, new StringContent(dataJson, Encoding.UTF8, "application/json"));
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (errorConfirmPassword.Text == "")
                {
                    MessageBox.Show("Đổi mật khẩu thành công");

                    this.Close();
                    Login.showFormAgain.Show();
                }
            }
            else
            {
                string responseData = await response.Content.ReadAsStringAsync();
                // Phân tích chuỗi JSON
                JObject jsonData = JObject.Parse(responseData);

                // Lấy giá trị của thuộc tính "data"
                JToken dataToken = jsonData["messageErrors"];
                JObject dataObject = dataToken.ToObject<JObject>();
                errorRegister errors = JsonConvert.DeserializeObject<errorRegister>(dataObject.ToString());
                //hiển thị lỗi lên trên giao diện
                displayError(errors);
                if (string.Equals(txtConfirmPassword.Text, txtNewPassword.Text))
                    errorConfirmPassword.Text = "";
                else
                {
                    errorConfirmPassword.ForeColor = Color.Red;
                    errorConfirmPassword.Text = "Mật khẩu không khớp";
                }
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.Equals(txtConfirmPassword.Text, txtNewPassword.Text))
                errorConfirmPassword.Text = "";
            else
            {
                errorConfirmPassword.ForeColor = Color.Red;
                errorConfirmPassword.Text = "Mật khẩu không khớp";
            }
        }
    }
}
