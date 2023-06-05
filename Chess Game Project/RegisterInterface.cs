using Chess_Game_Project.classes;
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

namespace Chess_Game_Project
{
    public partial class RegisterInterface : Form
    {
        public RegisterInterface()
        {
            InitializeComponent();
        }
        public string apiUrlRegister = "https://chessmates.onrender.com/api/v1/auth/register";
        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.Equals(txtConfirmPassword.Text, txtPassword.Text))
            {
                errorConfirmPasswordLabel.Text = "";
            }
            else
            {
                errorConfirmPasswordLabel.ForeColor = Color.Red;
                errorConfirmPasswordLabel.Text = "Mật khẩu không khớp";
            }

        }
        private void displayError(errorRegister errors)
        {
            errorUserNameLabel.Text = "";
            errorPasswordLabel.Text = "";
            errorEmailLabel.Text = "";
            errorUserNameLabel.ForeColor = Color.Red;
            errorPasswordLabel.ForeColor = Color.Red;
            errorEmailLabel.ForeColor = Color.Red;

            if (errorUserNameLabel.Text == "")
                if (errors.userName != null)
                    foreach (string error in errors.userName)
                        errorUserNameLabel.Text += error + "\n";
            if (errorPasswordLabel.Text == "")
                if (errors.password != null)
                    foreach (string error in errors.password)
                        errorPasswordLabel.Text += error + "\n";
            if (errorEmailLabel.Text == "")
                if (errors.gmail != null)
                    foreach (string error in errors.gmail)
                        errorEmailLabel.Text += error + "\n";

        }
        private async void btnRegister_Click(object sender, EventArgs e)
        {

            try
            {
                string userName = txtUserName.Text.Trim();
                string gmail = txtEmail.Text.Trim();
                string password = txtPassword.Text.Trim();
                string confirmPassowrd = txtConfirmPassword.Text.Trim();
                if (userName == "" || gmail == "" || password == "" || confirmPassowrd == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi bấm nút đăng ký");
                    return;
                }
                var data = new
                {
                    userName,
                    gmail,
                    password
                };
                string dataJson = JsonConvert.SerializeObject(data);
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PostAsync(apiUrlRegister, new StringContent(dataJson, Encoding.UTF8, "application/json"));

                //thực hiện đăng ký thành công
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    if (errorConfirmPasswordLabel.Text == "")
                    {
                        MessageBox.Show("Đăng ký thành công");
                        //đóng form register
                        this.Close();

                        //mở lại form login
                        Login.showFormAgain.Show();
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký thất bại, vui lòng kiểm tra lại");
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
                    if (string.Equals(txtConfirmPassword.Text, txtPassword.Text))
                        errorConfirmPasswordLabel.Text = "";
                    else
                    {
                        errorConfirmPasswordLabel.ForeColor = Color.Red;
                        errorConfirmPasswordLabel.Text = "Mật khẩu không khớp";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình đăng ký, vui lòng thực hiện lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            }

        }

        private void btnComeback_Click(object sender, EventArgs e)
        {
            //đóng form register
            this.Close();

            //mở lại form login
            Login.showFormAgain.Show();
        }

        private void RegisterInterface_Load(object sender, EventArgs e)
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

        private void btnComeback_Click_1(object sender, EventArgs e)
        {

        }
    }
}
