using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace VinFinder
{
    public class StripStatusWorker : Voids
    {
        public ToolStripLabel PrzekazanyToolStripLabel;
        public ToolStripProgressBar PrzekazanyToolStripProgressBar;
        public int GdFileSize;
        public int ResultsCount;
        public void ErrorWhileSendFile()
        {
            PrzekazanyToolStripLabel.Text = "An error accured while sending a file to Google Drive";
            PrzekazanyToolStripLabel.Visible = true;
            Thread.Sleep(5000);
            PrzekazanyToolStripLabel.Visible = false;
            PrzekazanyToolStripLabel.Text = "LABEL";
        }
        public void ErrorCantFindDataTxt()
        {
            PrzekazanyToolStripLabel.Text = "Program Can't find file data.txt on Google Drive";
            PrzekazanyToolStripLabel.Visible = true;
            Thread.Sleep(5000);
            PrzekazanyToolStripLabel.Visible = false;
            PrzekazanyToolStripLabel.Text = "LABEL";
        }
        public void SuccesfullyAythorized()
        {
            PrzekazanyToolStripLabel.Text = "Succesfully Aythorized";
            PrzekazanyToolStripLabel.Visible = true;
            Thread.Sleep(5000);
            PrzekazanyToolStripLabel.Visible = false;
            PrzekazanyToolStripLabel.Text = "LABEL";
        }
        public void ErrorWhileAuthorization()
        {
            PrzekazanyToolStripLabel.Text = "Problem accured while authorization";
            PrzekazanyToolStripLabel.Visible = true;
            Thread.Sleep(5000);
            PrzekazanyToolStripLabel.Visible = false;
            PrzekazanyToolStripLabel.Text = "LABEL";
        }
        public void ShowStatusAboutFile()
        {
            PrzekazanyToolStripLabel.Text = "I have found file. Name : data.txt Size: " + (GdFileSize / 1000).ToString() + "KB";
            PrzekazanyToolStripLabel.Visible = true;
            Thread.Sleep(5000);
            PrzekazanyToolStripLabel.Visible = false;
            PrzekazanyToolStripLabel.Text = "LABEL";
        }
        public void FileSuccesfullyDownloaded()
        {
            PrzekazanyToolStripLabel.Text = "Program successfully downloaded file data.txt";
            PrzekazanyToolStripLabel.Visible = true;
            Thread.Sleep(5000);
            PrzekazanyToolStripLabel.Visible = false;
            PrzekazanyToolStripLabel.Text = "LABEL";
        }
        public void FileSuccesfullyUploaded()
        {
            PrzekazanyToolStripLabel.Text = "Program successfully uploaded file data.txt";
            PrzekazanyToolStripLabel.Visible = true;
            Thread.Sleep(5000);
            PrzekazanyToolStripLabel.Visible = false;
            PrzekazanyToolStripLabel.Text = "LABEL";
        }
        public void FileDownloading()
        {
            PrzekazanyToolStripLabel.Text = "Downloading...";
            PrzekazanyToolStripLabel.Visible = true;
        }
        public void SearchingVin()
        {
            PrzekazanyToolStripLabel.Text = "Searching...";
            PrzekazanyToolStripLabel.Visible = true;
        }
        public void FinishSearchingVin()
        {
            if (ResultsCount > 0) PrzekazanyToolStripLabel.Text = "I Have found " + ResultsCount.ToString() + " results";
            else PrzekazanyToolStripLabel.Text = "I can't find any results";
            PrzekazanyToolStripLabel.Visible = true;
            Thread.Sleep(5000);
            PrzekazanyToolStripLabel.Visible = false;
            PrzekazanyToolStripLabel.Text = "LABEL";
        }
    }
}
