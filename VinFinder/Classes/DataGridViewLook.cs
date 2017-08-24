using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VinFinder
{
    class DataGridViewLook
    {
        public void ChangeLookOfDataGridView(DataGridView tabela)
        {
            if (tabela.Columns.Contains("Lp."))
            {
                tabela.Columns["Lp."].HeaderText = "Lp.";
                tabela.Columns["Lp."].Width = 20;
            }
            if (tabela.Columns.Contains("TYTUL"))
            {
                tabela.Columns["TYTUL"].HeaderText = "Tytuł";
                tabela.Columns["TYTUL"].Width = 400;
            }
            if (tabela.Columns.Contains("LINK"))
            {
                tabela.Columns["LINK"].HeaderText = "Link";
                tabela.Columns["LINK"].Width = 400;
            }
        }
    }
}
