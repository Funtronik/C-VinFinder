using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace VinFinder
{
    public partial class MainForm : Form
    {
        Thread ShowStatus;
        StripStatusWorker StripStatusWorker = new StripStatusWorker();

        public MainForm()
        {
            InitializeComponent();
            StripStatusWorker.PrzekazanyToolStripLabel = this.toolStripStatusLabel1;
        }

        private void findVINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VinFinder.OnceForm OnceForm = new OnceForm();
            OnceForm.MdiParent = this;
            OnceForm.WindowState = FormWindowState.Maximized;
            OnceForm.Show();
            OnceForm.ToolStripStatusLabel = this.toolStripStatusLabel1;
        }

        private void authorizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var googleDrive = new GoogleDrive();
            googleDrive.Authorization();
            if (!googleDrive.UdaloSie)
            {
                ShowStatus = new Thread(StripStatusWorker.ErrorWhileAuthorization);
                ShowStatus.Start();
            }
            else
            {
                ShowStatus = new Thread(StripStatusWorker.SuccesfullyAythorized);
                ShowStatus.Start();
            }
        }

        private void sendFileToGDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GoogleDrive googleDrive = new GoogleDrive();
                googleDrive.Authorization();
                var fileMetadata = new File()
                {
                    Name = "data.txt"
                };
                FilesResource.CreateMediaUpload request;
                using (var stream = new System.IO.FileStream("files/data.txt",
                                        System.IO.FileMode.Open))
                {
                    request = googleDrive.Service.Files.Create(
                        fileMetadata, stream, "text/txt");
                    request.Fields = "id";
                    request.Upload();
                }
                var file = request.ResponseBody;
                ShowStatus = new Thread(StripStatusWorker.FileSuccesfullyUploaded);
                ShowStatus.Start();
            }
            catch
            {
                ShowStatus = new Thread(StripStatusWorker.ErrorWhileSendFile);
                ShowStatus.Start();
            }
        }

        private void downloadFileFromGDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowStatus = new Thread(StripStatusWorker.FileDownloading);
            ShowStatus.Start();
            Voids Info = new Voids();
            Info.DownloadInfoAboutFileFromGD(true);

            if (!Info.fileFind)
            {
                ShowStatus = new Thread(StripStatusWorker.ErrorCantFindDataTxt);
                ShowStatus.Start();
            }
            else
            {
                ShowStatus = new Thread(StripStatusWorker.FileSuccesfullyDownloaded);
                ShowStatus.Start();
            }
        }

        private void getInfoFromGDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Voids Voids = new Voids();
            Voids.DownloadInfoAboutFileFromGD(false);

            if (!Voids.fileFind)
            {
                ShowStatus = new Thread(StripStatusWorker.ErrorCantFindDataTxt);
                ShowStatus.Start();
            }
            else
            {
                StripStatusWorker.GdFileSize = Voids.fileSize;
                ShowStatus = new Thread(StripStatusWorker.ShowStatusAboutFile);
                ShowStatus.Start();
            }
        }

        private void testSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewTableDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VinFinder.Forms.ViewData ViewData = new VinFinder.Forms.ViewData();
            ViewData.MdiParent = this;
            ViewData.WindowState = FormWindowState.Maximized;
            ViewData.Show();
            ViewData.ToolStripStatusLabel = this.toolStripStatusLabel1;
        }
    }
}
