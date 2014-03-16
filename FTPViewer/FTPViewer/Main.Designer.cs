namespace FTPViewer
{
    partial class Main
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("FTP");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.treeViewFTP = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeViewLocal = new System.Windows.Forms.TreeView();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonOptions = new System.Windows.Forms.Button();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeViewFTP
            // 
            this.treeViewFTP.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeViewFTP.HideSelection = false;
            this.treeViewFTP.ImageIndex = 0;
            this.treeViewFTP.ImageList = this.imageList1;
            this.treeViewFTP.Indent = 27;
            this.treeViewFTP.ItemHeight = 24;
            this.treeViewFTP.Location = new System.Drawing.Point(8, 73);
            this.treeViewFTP.Name = "treeViewFTP";
            treeNode1.Name = "FTP";
            treeNode1.NodeFont = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            treeNode1.Text = "FTP";
            this.treeViewFTP.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeViewFTP.SelectedImageIndex = 0;
            this.treeViewFTP.Size = new System.Drawing.Size(425, 435);
            this.treeViewFTP.TabIndex = 0;
            this.treeViewFTP.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewFTP_NodeMouseClick);
            this.treeViewFTP.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewFTP_NodeMouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "root.jpg");
            this.imageList1.Images.SetKeyName(1, "folder.png");
            this.imageList1.Images.SetKeyName(2, "hard.png");
            this.imageList1.Images.SetKeyName(3, "file.jpg");
            // 
            // treeViewLocal
            // 
            this.treeViewLocal.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeViewLocal.HideSelection = false;
            this.treeViewLocal.ImageIndex = 2;
            this.treeViewLocal.ImageList = this.imageList1;
            this.treeViewLocal.Indent = 27;
            this.treeViewLocal.ItemHeight = 24;
            this.treeViewLocal.Location = new System.Drawing.Point(485, 73);
            this.treeViewLocal.Name = "treeViewLocal";
            this.treeViewLocal.SelectedImageIndex = 2;
            this.treeViewLocal.Size = new System.Drawing.Size(425, 435);
            this.treeViewLocal.TabIndex = 1;
            this.treeViewLocal.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewLocal_NodeMouseClick);
            this.treeViewLocal.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewLocal_NodeMouseDoubleClick);
            // 
            // buttonConnect
            // 
            this.buttonConnect.BackColor = System.Drawing.SystemColors.Window;
            this.buttonConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConnect.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConnect.Location = new System.Drawing.Point(29, 12);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(77, 35);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.TabStop = false;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = false;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.SystemColors.Window;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRefresh.Location = new System.Drawing.Point(137, 12);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(77, 35);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.TabStop = false;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonOptions
            // 
            this.buttonOptions.BackColor = System.Drawing.SystemColors.Window;
            this.buttonOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOptions.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOptions.Location = new System.Drawing.Point(247, 12);
            this.buttonOptions.Name = "buttonOptions";
            this.buttonOptions.Size = new System.Drawing.Size(77, 35);
            this.buttonOptions.TabIndex = 4;
            this.buttonOptions.TabStop = false;
            this.buttonOptions.Text = "Options";
            this.buttonOptions.UseVisualStyleBackColor = false;
            this.buttonOptions.Click += new System.EventHandler(this.buttonOptions_Click);
            // 
            // buttonUpload
            // 
            this.buttonUpload.BackColor = System.Drawing.SystemColors.Window;
            this.buttonUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpload.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUpload.Location = new System.Drawing.Point(439, 135);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(40, 34);
            this.buttonUpload.TabIndex = 5;
            this.buttonUpload.TabStop = false;
            this.buttonUpload.Text = "UP";
            this.buttonUpload.UseVisualStyleBackColor = false;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // buttonDownload
            // 
            this.buttonDownload.BackColor = System.Drawing.SystemColors.Window;
            this.buttonDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDownload.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDownload.Location = new System.Drawing.Point(439, 225);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(40, 34);
            this.buttonDownload.TabIndex = 6;
            this.buttonDownload.TabStop = false;
            this.buttonDownload.Text = "D";
            this.buttonDownload.UseVisualStyleBackColor = false;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.SystemColors.Window;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelete.Location = new System.Drawing.Point(439, 322);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(40, 34);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.TabStop = false;
            this.buttonDelete.Text = "D";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(919, 516);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.buttonUpload);
            this.Controls.Add(this.buttonOptions);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.treeViewLocal);
            this.Controls.Add(this.treeViewFTP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FTPViewer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewFTP;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView treeViewLocal;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonOptions;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.Button buttonDelete;
    }
}

