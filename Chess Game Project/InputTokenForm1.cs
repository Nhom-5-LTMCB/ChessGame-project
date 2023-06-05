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

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
