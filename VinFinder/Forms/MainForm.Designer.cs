namespace VinFinder
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backgroundWorkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findVINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authorizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendFileToGDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadFileFromGDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getInfoFromGDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.viewTableDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundWorkerToolStripMenuItem,
            this.findVINToolStripMenuItem,
            this.viewTableDataToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(750, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // backgroundWorkerToolStripMenuItem
            // 
            this.backgroundWorkerToolStripMenuItem.Name = "backgroundWorkerToolStripMenuItem";
            this.backgroundWorkerToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.backgroundWorkerToolStripMenuItem.Text = "BackgroundWorker";
            // 
            // findVINToolStripMenuItem
            // 
            this.findVINToolStripMenuItem.Name = "findVINToolStripMenuItem";
            this.findVINToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.findVINToolStripMenuItem.Text = "Find VIN";
            this.findVINToolStripMenuItem.Click += new System.EventHandler(this.findVINToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authorizationToolStripMenuItem,
            this.sendFileToGDToolStripMenuItem,
            this.downloadFileFromGDToolStripMenuItem,
            this.getInfoFromGDToolStripMenuItem,
            this.testSearchToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // authorizationToolStripMenuItem
            // 
            this.authorizationToolStripMenuItem.Name = "authorizationToolStripMenuItem";
            this.authorizationToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.authorizationToolStripMenuItem.Text = "Authorization";
            this.authorizationToolStripMenuItem.Click += new System.EventHandler(this.authorizationToolStripMenuItem_Click);
            // 
            // sendFileToGDToolStripMenuItem
            // 
            this.sendFileToGDToolStripMenuItem.Name = "sendFileToGDToolStripMenuItem";
            this.sendFileToGDToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.sendFileToGDToolStripMenuItem.Text = "Send file to GD";
            this.sendFileToGDToolStripMenuItem.Click += new System.EventHandler(this.sendFileToGDToolStripMenuItem_Click);
            // 
            // downloadFileFromGDToolStripMenuItem
            // 
            this.downloadFileFromGDToolStripMenuItem.Name = "downloadFileFromGDToolStripMenuItem";
            this.downloadFileFromGDToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.downloadFileFromGDToolStripMenuItem.Text = "Download file from GD";
            this.downloadFileFromGDToolStripMenuItem.Click += new System.EventHandler(this.downloadFileFromGDToolStripMenuItem_Click);
            // 
            // getInfoFromGDToolStripMenuItem
            // 
            this.getInfoFromGDToolStripMenuItem.Name = "getInfoFromGDToolStripMenuItem";
            this.getInfoFromGDToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.getInfoFromGDToolStripMenuItem.Text = "Get info from GD";
            this.getInfoFromGDToolStripMenuItem.Click += new System.EventHandler(this.getInfoFromGDToolStripMenuItem_Click);
            // 
            // testSearchToolStripMenuItem
            // 
            this.testSearchToolStripMenuItem.Name = "testSearchToolStripMenuItem";
            this.testSearchToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.testSearchToolStripMenuItem.Text = "Test Search";
            this.testSearchToolStripMenuItem.Click += new System.EventHandler(this.testSearchToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 274);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(750, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(40, 17);
            this.toolStripStatusLabel1.Text = "LABEL";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar1.Visible = false;
            // 
            // viewTableDataToolStripMenuItem
            // 
            this.viewTableDataToolStripMenuItem.Name = "viewTableDataToolStripMenuItem";
            this.viewTableDataToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.viewTableDataToolStripMenuItem.Text = "View Table Data";
            this.viewTableDataToolStripMenuItem.Click += new System.EventHandler(this.viewTableDataToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 296);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backgroundWorkerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findVINToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authorizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendFileToGDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadFileFromGDToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem getInfoFromGDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewTableDataToolStripMenuItem;
    }
}

