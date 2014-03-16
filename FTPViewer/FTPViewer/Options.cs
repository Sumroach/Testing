using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FTPViewer
{
    public partial class Options : Form
    {
        public int Timeout { get { return timeout; } }
        public string FtpServer { get { return _ftpServer; } }
        public int FtpPort { get { return _ftpPort; } }
        public string FtpLogin { get { return _ftpLogin; } }
        public string FtpPassword { get { return _ftpPassword; } }

        private int timeout = 1000;
        private string _ftpServer;
        private int _ftpPort = 21;
        private string _ftpLogin;
        private string _ftpPassword;

        public Options()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                timeout = (int)numericUpDown1.Value * 1000;
                _ftpServer = textBoxAddress.Text;
                _ftpPort = Convert.ToInt32(textBoxPort.Text);
                _ftpLogin = textBoxLogin.Text;
                _ftpPassword = textBoxPass.Text;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { this.Close(); }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FSettings_Load(object sender, EventArgs e)
        {
            this.numericUpDown1.Value = Timeout / 1000;
            this.textBoxAddress.Text = FtpServer;
            this.textBoxPort.Text = FtpPort.ToString();
            this.textBoxLogin.Text = FtpLogin;
            this.textBoxPass.Text = FtpPassword;
        }
    }
}
