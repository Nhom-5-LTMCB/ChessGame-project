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
    public partial class InputTokenForm1 : Form
    {
        private string userName;
        private string gmail;
        private string apiInputToken = "https://chessmates.onrender.com/api/v1/auth/getToken/";
        private string apiAuthAccount = "https://chessmates.onrender.com/api/v1/auth/forgotPassword";
        public InputTokenForm1()
        {
            InitializeComponent();
        }
        public InputTokenForm1(string userName, string gmail) : this()
        {
            this.userName = userName;
            this.gmail = gmail;
            btnSendTokenAgain.Enabled = false;
        }
        private async void btnSendTokenAgain_Click(object sender, EventArgs e)
        {
            var data = new
            {
                userName,
                gmail
            };
            string dataJson = JsonConvert.SerializeObject(data);
            HttpClient client = new HttpClient();
            await client.PostAsync(apiAuthAccount, new StringContent(dataJson, Encoding.UTF8, "application/json"));
            btnSendTokenAgain.Enabled = false;
            MessageBox.Show("Vui lòng kiểm tra email của bạn");
        }
        private void InputTokenForm1_Load(object sender, EventArgs e)
        {
            handleLoadInterface.loadInterFace(this, null, pnlContent);
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAuth.Text.Trim())) return;
            HttpClient client = new HttpClient();
            string api = apiInputToken + txtAuth.Text.Trim();
            HttpResponseMessage response = await client.PostAsync(api, new StringContent("", Encoding.UTF8, "application/json"));
            string responseJson = await response.Content.ReadAsStringAsync();
            JObject dataObj = JObject.Parse(responseJson);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show(dataObj["notify"].ToString());
                ChangePasswordInterface pw = new ChangePasswordInterface();
                pw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(dataObj["notify"].ToString());
                btnSendTokenAgain.Enabled = true;
                txtAuth.Clear();
            }
        }
    }
}
