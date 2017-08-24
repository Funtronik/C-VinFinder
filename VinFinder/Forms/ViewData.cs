using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VinFinder.Forms
{
    public partial class ViewData : Form
    {
        Thread ShowStatus;
        StripStatusWorker StripStatusWorker = new StripStatusWorker();
        public ToolStripStatusLabel ToolStripStatusLabel;
        DataTable wyniki = new DataTable();
        DataTable OtomotoSearchResult = new DataTable();
        Voids Voids = new Voids();

        List<string> Links = new List<string>();

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\" + System.Environment.UserName + @"\Documents\Visual Studio 2017\Projects\VinFinder\VinFinder\Baza\Baza.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public ViewData()
        {
            InitializeComponent();
        }
    }
}
