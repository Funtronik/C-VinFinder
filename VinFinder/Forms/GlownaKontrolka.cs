using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Customsearch.v1.Data;
using System.Threading;
using System.Net;
using System.Collections.Specialized;
using System.Data.SqlClient;
using VinFinder.Classes;
namespace VinFinder
{
    public partial class OnceForm : Form
    {
        Thread ShowStatus;
        StripStatusWorker StripStatusWorker = new StripStatusWorker();
        public ToolStripStatusLabel ToolStripStatusLabel;
        DataTable wyniki = new DataTable();
        DataTable OtomotoSearchResult = new DataTable();
        Voids Voids = new Voids();
        
        List<string> Links = new List<string>();

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\"+System.Environment.UserName+@"\Documents\Visual Studio 2017\Projects\VinFinder\VinFinder\Baza\Baza.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public OnceForm()
        {
            InitializeComponent();
            wyniki.Columns.Add("Lp.");
            wyniki.Columns.Add("TYTUL");
            wyniki.Columns.Add("LINK");

            string[] tabele = new string[] { "TODO", "DOING", "SAMOCHODY"};
            string[] IlosciWTabelach = new string[] { };
            IlosciWTabelach = Voids.Actualstate(tabele);

            Dictionary<int, Label> LabeleDoPodmianyWartosci= new Dictionary<int, Label>();
            LabeleDoPodmianyWartosci.Add(0, label3);
            LabeleDoPodmianyWartosci.Add(1, label4);
            LabeleDoPodmianyWartosci.Add(2, label5);
            for (int i =0; i<IlosciWTabelach.Count();i++)
            {
                
                {
                    LabeleDoPodmianyWartosci[i].Text = IlosciWTabelach[i].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text.Length < 10)
            {
                MessageBox.Show("Nie podałeś dobrego VIN'u");
                return;
            }

            var vinSamochodu = textBox1.Text.ToString();
            var query = vinSamochodu;
            StripStatusWorker.PrzekazanyToolStripLabel = ToolStripStatusLabel;
            ShowStatus = new Thread(StripStatusWorker.SearchingVin);
            ShowStatus.Start();
            var results = GoogleSearch.Search(query);
            var LP = 1;
            try { int check = results.Count; }
            catch
            {
                StripStatusWorker.PrzekazanyToolStripLabel = ToolStripStatusLabel;
                StripStatusWorker.ResultsCount = 0;
                ShowStatus = new Thread(StripStatusWorker.FinishSearchingVin);
                ShowStatus.Start();
                return;
            }
            foreach (Result result in results)
            {
                wyniki.Rows.Add(LP.ToString(), result.Title, result.Link);
                LP++;
            }
            StripStatusWorker.PrzekazanyToolStripLabel = ToolStripStatusLabel;
            StripStatusWorker.ResultsCount = results.Count;
            ShowStatus = new Thread(StripStatusWorker.FinishSearchingVin);
            ShowStatus.Start();

            dataGridView1.DataSource = wyniki;
            DataGridViewLook Changer = new DataGridViewLook();
            Changer.ChangeLookOfDataGridView(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Voids.PobieranieLinkow(textBox2.Text.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Voids.Przerzucanie();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Voids.Obrobka();
        }
    }
}
