using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSSenderFinal
{
    public partial class UI : Form
    {
        public UI()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                try
                {
                    string url = "http://smsc.vianett.no/v3/send.ashx?" +
                        "src=" + "919000951873" + "&" +
                        "dst=" + txtPhoneNumber.Text + "&" +
                        "msg=" + System.Web.HttpUtility.UrlEncode(txtMessage.Text, System.Text.Encoding.GetEncoding("ISO-8859-1")) + "&" +
                        "username=" + System.Web.HttpUtility.UrlEncode(txtUsername.Text) + "&" +
                        "password=" + System.Web.HttpUtility.UrlEncode(txtPassword.Text);
                    string result = client.DownloadString(url);
                    //remember to add System.web reference (right click on  "Reference" in the Solution Explorer to do so)
                    if (result.Contains("OK"))
                        MessageBox.Show("Message Sent", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Message could not be sent", "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
    }
}
