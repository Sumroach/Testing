using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BytesRoad.Net.Ftp;

namespace FTPViewer
{
    public class FTP
    {
        private FtpClient client = new FtpClient();

        private int _timeoutFTP;
        private string _ftpServer;     			//ФТП сервер
        private int _ftpPort = 21;              //порт для передачи данных
        private string _ftpLogin;               //логин на ФТП
        private string _ftpPassword;            //пароль на ФТП

        public bool IsServerConnect { get; set; }

        public FTP(int timeoutFTP, string ftpServer, int ftpPort, string ftpLogin, string ftpPassword)
        {
            client.PassiveMode = true;      //Включаем пассивный режим ФТП

            _timeoutFTP = timeoutFTP;
            _ftpServer = ftpServer;
            _ftpPort = ftpPort;
            _ftpLogin = ftpLogin;
            _ftpPassword = ftpPassword;
        }
                    
        public string connect()
        {
            try
            {
                client.Connect(_timeoutFTP, _ftpServer, _ftpPort);
                client.Login(_timeoutFTP, _ftpLogin, _ftpPassword);
                IsServerConnect = true;
                return "Successfully connected to " + _ftpServer;
            }
            catch (Exception ex)
            {
                IsServerConnect = false;
                return ex.Message;
            }
        }

        public string disconnect()
        {
            try
            {
                client.Disconnect(_timeoutFTP);
                IsServerConnect = false;
                return "Successfylly disconnected";
            }
            catch (Exception ex)
            {
                IsServerConnect = true;
                return ex.Message;
            }
        }

        public FtpItem[] getFileList()
        {
            try
            {
                return client.GetDirectoryList(_timeoutFTP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FtpItem[] getFileList(string folder)
        {
            try
            {
                return client.GetDirectoryList(_timeoutFTP, folder);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string downloadFile(string srcPath, string savePath)
        {
            try
            {
                client.GetFile(_timeoutFTP, savePath, srcPath);
                return "File successfully downloaded at location:\n" + savePath;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string uploadFile(string srcPath, string savePath)
        {
            try
            {
                client.PutFile(_timeoutFTP, savePath, srcPath);
                return "File successfully uploaded at location:\n" + savePath;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string toFtpString(string str)
        {
            return str.Replace("FTP", "").Replace("\\\\", "\\").Replace("\\", "//");
        }

        public void DeleteFile(string path)
        {
            client.DeleteFile(_timeoutFTP, path);
        }

        public string getFileInfo(string path)
        {
            FtpItem item = client.GetDirectoryList(_timeoutFTP, path)[0];
            return item.Name + "~" + item.Size + "~" + item.Date.ToShortDateString();
        }
    }
}
