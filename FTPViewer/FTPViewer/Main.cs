using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using BytesRoad.Net.Ftp;

namespace FTPViewer
{
    public partial class Main : Form
    {
        private FTP ftp;
        private TreeNode clickNode;
        private Options opt;
        
        public Main()
        {
            InitializeComponent();

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this.buttonConnect, "Connect");
            toolTip.SetToolTip(this.buttonUpload, "Upload");
            toolTip.SetToolTip(this.buttonDownload, "Download");
            toolTip.SetToolTip(this.buttonRefresh, "Refresh");
            toolTip.SetToolTip(this.buttonOptions, "Options");
            toolTip.SetToolTip(this.buttonDelete, "Delete");
            fillLocalTree();
            treeViewFTP.Nodes[0].ImageIndex = 0;
            treeViewFTP.Nodes[0].SelectedImageIndex = 0;
            opt = new Options();
        }

        private void fillLocalTree()
        {
            string[] drives = Environment.GetLogicalDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                treeViewLocal.Nodes.Add(drives[i]);
                treeViewLocal.Nodes[i].ImageIndex = 2;
                treeViewLocal.Nodes[i].SelectedImageIndex = 2;
            }
        }

        private void fillNode(FtpItem[] entries, TreeNode node)
        {
            List<string> folders = new List<string>();
            List<string> files = new List<string>();
            foreach (FtpItem item in entries)
            {
                if (item.ItemType == FtpItemType.Directory)
                {
                    if ((item.Name != "..") && (item.Name != "."))
                    folders.Add(item.Name);
                }
                if (item.ItemType == FtpItemType.File)
                {
                    files.Add(item.Name);
                }
            }
            for (int i = 0; i < folders.Count; i++)
            {
                node.Nodes.Add(folders[i]);
                node.Nodes[i].ImageIndex = 1;
                node.Nodes[i].SelectedImageIndex = 1;
            }
            for (int i = 0; i < files.Count; i++)
            {
                node.Nodes.Add(files[i]);
                //string extension = files[i].Split('.').Last();
                //if (!imageList1.Images.ContainsKey(extension.ToUpper()))
                //{
                //    imageList1.Images.Add(extension.ToUpper(), FileIconLoader.GetFileIcon(files[i]));
                //}
                //node.Nodes[i + folders.Count].ImageKey = extension.ToUpper();
                //node.Nodes[i + folders.Count].SelectedImageKey = extension.ToUpper();
            }
            node.Expand();
        }

        private void fillNode(string path, TreeNode node)
        {
            try
            {
                string[] folders = Directory.GetDirectories(path);
                for (int i = 0; i < folders.Length; i++)
                {
                    folders[i] = folders[i].Split('\\').Last();
                }
                string[] files = Directory.GetFiles(path);
                for (int i = 0; i < files.Length; i++)
                {
                    files[i] = files[i].Split('\\').Last();
                }
                for (int i = 0; i < folders.Length; i++)
                {
                    node.Nodes.Add(folders[i]);
                    node.Nodes[i].ImageIndex = 1;
                    node.Nodes[i].SelectedImageIndex = 1;
                }
                for (int i = 0; i < files.Length; i++)
                {
                    node.Nodes.Add(files[i]);
                    //string extension = files[i].Split('.').Last();
                    //if (!imageList1.Images.ContainsKey(extension.ToUpper()))
                    //{
                    //    imageList1.Images.Add(extension.ToUpper(), FileIconLoader.GetFileIcon(files[i]));
                    //}
                    //node.Nodes[i + folders.Length].ImageKey = extension.ToUpper();
                    //node.Nodes[i + folders.Length].SelectedImageKey = extension.ToUpper();
                }
                node.Expand();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonOptions_Click(object sender, EventArgs e)
        {
             if (opt.ShowDialog() == DialogResult.OK)
                 ftp = new FTP(opt.Timeout, opt.FtpServer, opt.FtpPort, opt.FtpLogin, opt.FtpPassword);
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (ftp == null)
            {
                MessageBox.Show("You should choose connection settings before trying to connect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (opt.ShowDialog() == DialogResult.OK)
                    ftp = new FTP(opt.Timeout, opt.FtpServer, opt.FtpPort, opt.FtpLogin, opt.FtpPassword);
            }
            try
            {
                MessageBox.Show(ftp.connect());
                treeViewFTP.Nodes[0].Nodes.Clear();
                fillNode(ftp.getFileList(), treeViewFTP.Nodes[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            if (ftp == null)
            {
                MessageBox.Show("You should choose connection settings before trying to refresh.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (opt.ShowDialog() == DialogResult.OK)
                    ftp = new FTP(opt.Timeout, opt.FtpServer, opt.FtpPort, opt.FtpLogin, opt.FtpPassword);
                    MessageBox.Show(ftp.connect());
            }
            try
            {
                treeViewFTP.Nodes[0].Nodes.Clear();
                if (ftp.IsServerConnect)
                {
                    fillNode(ftp.getFileList(), treeViewFTP.Nodes[0]);
                }
                treeViewLocal.Nodes.Clear();
                fillLocalTree();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void treeViewFTP_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (clickNode.ImageIndex == 1 && clickNode.Nodes.Count == 0)
            {
                try
                {
                    fillNode(ftp.getFileList(FTP.toFtpString(clickNode.FullPath)), clickNode);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "fillNode");
                }
            }
            if (clickNode.ImageIndex == -1)
            {
                try
                {
                    string path = FTP.toFtpString(treeViewFTP.SelectedNode.FullPath);
                    string[] info = ftp.getFileInfo(path).Split('~');
                    MessageBox.Show("Name: " + info[0].Replace("/", "") + "\nSize: " + info[1] + " bytes\nDate: " + info[2], "File info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "fillNode");
                }
            }

        }

  

        private void buttonUpload_Click(object sender, EventArgs e)
        {
            if (treeViewLocal.SelectedNode == null)
            {
                MessageBox.Show("Select source path for file.", "Error");
                return;
            }
            if (!File.Exists(treeViewLocal.SelectedNode.FullPath))
            {
                MessageBox.Show("Folder upload/download functionality not supported yet.", "Error");
                return;
            }
            if (treeViewFTP.SelectedNode.ImageIndex == -1)
            {
                treeViewFTP.SelectedNode = treeViewFTP.SelectedNode.Parent;
            }
            try
            {
                ftp.uploadFile(FTP.toFtpString(treeViewLocal.SelectedNode.FullPath), FTP.toFtpString(treeViewFTP.SelectedNode.FullPath) + "//" + treeViewLocal.SelectedNode.Text);
                treeViewFTP.SelectedNode.Nodes.Clear();
                fillNode(ftp.getFileList(FTP.toFtpString(treeViewFTP.SelectedNode.FullPath)), treeViewFTP.SelectedNode);
                foreach (TreeNode node in treeViewFTP.SelectedNode.Nodes)
                {
                    if (node.Text == treeViewLocal.SelectedNode.Text)
                        treeViewFTP.SelectedNode = node;
                }
                clickNode = treeViewFTP.SelectedNode;
                treeViewFTP.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            if (treeViewLocal.SelectedNode == null)
            {
                MessageBox.Show("Select download path.", "Error");
                return;
            }
            if (treeViewFTP.SelectedNode.ImageIndex != -1 || treeViewFTP.SelectedNode.Parent == null)
            {
                MessageBox.Show("Folder upload/download functionality not supported yet.", "Error");
                return;
            }
            if (!Directory.Exists(treeViewLocal.SelectedNode.FullPath))
            {
                treeViewLocal.SelectedNode = treeViewLocal.SelectedNode.Parent;
            }
            try
            {
                ftp.downloadFile(FTP.toFtpString(treeViewFTP.SelectedNode.FullPath), FTP.toFtpString(treeViewLocal.SelectedNode.FullPath + "\\" + treeViewFTP.SelectedNode.Text));
                treeViewLocal.SelectedNode.Nodes.Clear();
                fillNode(treeViewLocal.SelectedNode.FullPath, treeViewLocal.SelectedNode);
                foreach (TreeNode node in treeViewLocal.SelectedNode.Nodes)
                {
                    if (node.Text == treeViewFTP.SelectedNode.Text)
                        treeViewLocal.SelectedNode = node;
                }
                clickNode = treeViewLocal.SelectedNode;
                treeViewLocal.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void treeViewLocal_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            clickNode = e.Node;
        }

        private void treeViewFTP_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            clickNode = e.Node;
        }

        private void treeViewLocal_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (clickNode.ImageIndex >= 1 && clickNode.Nodes.Count == 0)
            {
                try
                {
                    fillNode(clickNode.FullPath, clickNode);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "fillNode");
                }
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (clickNode != null && clickNode.TreeView == treeViewLocal)
            {
                if (!File.Exists(treeViewLocal.SelectedNode.FullPath))
                    MessageBox.Show("No files selected.", "Error");
                else
                {
                    if (MessageBox.Show("You sure you want delete this file?\n" + clickNode.FullPath, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
                        return;
                    try
                    {
                        File.Delete(treeViewLocal.SelectedNode.FullPath);
                        treeViewLocal.SelectedNode = treeViewLocal.SelectedNode.Parent;
                        treeViewLocal.SelectedNode.Nodes.Clear();
                        fillNode(treeViewLocal.SelectedNode.FullPath, treeViewLocal.SelectedNode);
                        treeViewLocal.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
            }
            if (clickNode != null && clickNode.TreeView == treeViewFTP)
            {
                if (treeViewFTP.SelectedNode.ImageIndex != -1 || treeViewFTP.SelectedNode.Parent == null)
                    MessageBox.Show("No files selected.", "Error");
                else
                {
                    if (MessageBox.Show("You sure you want delete this file?\n" + clickNode.FullPath, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
                        return;
                    try
                    {
                        ftp.DeleteFile(FTP.toFtpString(treeViewFTP.SelectedNode.FullPath));
                        treeViewFTP.SelectedNode = treeViewFTP.SelectedNode.Parent;
                        treeViewFTP.SelectedNode.Nodes.Clear();
                        fillNode(ftp.getFileList(FTP.toFtpString(treeViewFTP.SelectedNode.FullPath)), treeViewFTP.SelectedNode);
                        treeViewFTP.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
            }
        }







    }
}
