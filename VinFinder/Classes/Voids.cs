using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Collections.Specialized;
using System.Data.SqlClient;

namespace VinFinder
{
    public class Voids
    {
        public ToolStripLabel PrzekazanyToolStripLabel;
        public ToolStripProgressBar PrzekazanyToolStripProgressBar;

        public string fileID { get; set; }
        public string fileName { get; set; }
        public int fileSize { get; set; }
        public bool fileFind { get; set; }
        public System.IO.MemoryStream Stream = new System.IO.MemoryStream();

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\" + System.Environment.UserName + @"\Documents\Visual Studio 2017\Projects\VinFinder\VinFinder\Baza\Baza.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public void PobieranieLinkow(string keyword)
        {
            int iloscStron = 0;
            string ResultFromUrl = String.Empty;
            string uriString = "https://www.otomoto.pl/osobowe/";
            string keywordString = keyword.ToLower();
            uriString += "q-" + keywordString.Replace(" ", "-");

            System.Net.WebClient webClient = new System.Net.WebClient();

            NameValueCollection nameValueCollection = new NameValueCollection();
            nameValueCollection.Add("aaa", keywordString);

            webClient.QueryString.Add(nameValueCollection);
            ResultFromUrl = webClient.DownloadString(uriString);
            ResultFromUrl = ResultFromUrl.Replace('"', '`');
            string WhatToFind = uriString + @"/?aaa=" + keywordString.Replace(" ", "+") + @"&page=";
            int start = 0;
            int IloscStron = 0;
            bool end = false;
            do
            {
                if (ResultFromUrl.Contains(WhatToFind))
                {
                    start = ResultFromUrl.IndexOf(WhatToFind);
                    ResultFromUrl = ResultFromUrl.Substring(start + WhatToFind.Length, ResultFromUrl.Length - (start + WhatToFind.Length));
                    if (IloscStron == 4)
                    {
                        string strony = ResultFromUrl = ResultFromUrl.Substring(0, 3);
                        strony = strony.Replace("<", "");
                        strony = strony.Replace("/", "");
                        strony = strony.Replace("`", "");
                        strony = strony.Replace(">", "");
                        IloscStron = int.Parse(strony);
                        end = true;
                        iloscStron = IloscStron;
                    }
                    else IloscStron++;
                }
                else
                {
                    end = true;
                    iloscStron = IloscStron;
                }
            } while (!end);


            uriString += "q-" + keywordString.Replace(" ", "-");
            nameValueCollection.Clear();
            nameValueCollection.Add("aaa", keywordString);

            webClient.QueryString.Add(nameValueCollection);
            ResultFromUrl = webClient.DownloadString(uriString);

            List<string> Links = new List<string>();

            start = 0;
            ResultFromUrl = ResultFromUrl.Replace('"', '`');
            List<string> ListaLinkowPoj = new List<string>();
            int iloscLoop = iloscStron;
            iloscLoop++;
            //https://www.otomoto.pl/osobowe/q-grande-punto/?search%5Bfilter_enum_damaged%5D=0
            for (int i = 1; i < iloscLoop; i++)
            {
                for (int a = 0; a < 20; a++)
                {
                    if (ResultFromUrl.Contains("https://www.otomoto.pl/oferta/"))
                    {
                        start = ResultFromUrl.IndexOf("https://www.otomoto.pl/oferta/");
                        ResultFromUrl = ResultFromUrl.Substring(start, ResultFromUrl.Length - start);
                        start = ResultFromUrl.IndexOf(".html") + 5;
                        ListaLinkowPoj.Add(ResultFromUrl.Substring(0, start));
                        ResultFromUrl = ResultFromUrl.Substring(start, ResultFromUrl.Length - start - 1);
                    }
                }
                nameValueCollection.Clear();
                keywordString = @"https://www.otomoto.pl/osobowe/q-" + keyword.Replace(" ", "-") + "/?aaa=" + keyword.Replace(" ", "+") + "&page=" + (i + 1).ToString();
                nameValueCollection.Add("aaa", keywordString);

                webClient.QueryString.Add(nameValueCollection);
                ResultFromUrl = webClient.DownloadString(keywordString);

                start = 0;
                ResultFromUrl = ResultFromUrl.Replace('"', '`');
            }
            Links = ListaLinkowPoj.Distinct().ToList();
            ListaLinkowPoj.Clear();

            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            bool DoneStatement = false;
            do
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();
                    for (int i = 0; i < Links.Count; i++)
                    {
                        cmd.CommandText = "INSERT INTO TODO (LINK) VALUES ('" + Links[i] + "')";
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    DoneStatement = true;
                }
                else
                {
                    Thread.Sleep(5000);
                }
            } while (!DoneStatement);
        }

        public void Przerzucanie()
        {
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            bool DoneStatement = false;
            do
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();
                    cmd.CommandText = ("SELECT TOP 50 * FROM TODO");
                    DataTable DataToProcess = new DataTable();
                    DataToProcess.Columns.Add("LINK");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            foreach (var data in reader)
                                DataToProcess.Rows.Add(reader["LINK"]);
                        }
                        else break;
                    }
                    foreach (DataRow row in DataToProcess.Rows)
                    {
                        cmd.CommandText = "INSERT INTO DOING (LINK) VALUES ('" + row[0] + "')";
                        cmd.ExecuteNonQuery();
                    }

                    cmd.CommandText = ("DELETE TOP (50) FROM TODO");
                    cmd.ExecuteNonQuery();

                    con.Close();
                    DoneStatement = true;
                }
                else
                {
                    Thread.Sleep(5000);
                }
            } while (!DoneStatement);
        }

        public void Obrobka()
        {
            string stanSamochodu = string.Empty;
            int howMouchToDo = 2;

            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            bool DoneStatement = false;

            do
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();
                    cmd.CommandText = ("SELECT COUNT(*) FROM DOING"); //check what to do
                    int countTODO = 0;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            countTODO = int.Parse(reader[0].ToString());
                        }
                    }
                    if (countTODO < 1) // nothing to do
                    {
                        con.Close();
                        break;
                    }

                    cmd.CommandText = ("SELECT TOP " + howMouchToDo + " * FROM DOING"); //have something to do
                    DataTable DataToProcess = new DataTable();
                    DataToProcess.Columns.Add("LINK");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            foreach (var data in reader)
                                DataToProcess.Rows.Add(reader["LINK"]);
                        }
                        else
                        {
                            con.Close();
                            break;
                        }
                    }

                    cmd.CommandText = ("DELETE TOP (" + (howMouchToDo - 1) + ") FROM DOING");
                    cmd.ExecuteNonQuery();

                    con.Close();
                    foreach (DataRow row in DataToProcess.Rows) // process data
                    {
                        string ResultFromUrl = String.Empty;
                        System.Net.WebClient webClient = new System.Net.WebClient();
                        string uriString = DataToProcess.Rows[0][0].ToString();

                        ResultFromUrl = webClient.DownloadString(uriString);
                        ResultFromUrl = ResultFromUrl.Replace('"', '`');

                        String findStr = "googletag.pubads().setTargeting('"; // DATA
                        int start, stop = 0;
                        start = ResultFromUrl.IndexOf(findStr, 0);
                        findStr = "googletag.pubads().enableAsyncRendering();";
                        stop = ResultFromUrl.IndexOf(findStr, 0);
                        string ResultFromUrlData = ResultFromUrl.Substring(start, (stop - start));
                        List<string> Pozycje = new List<string>();
                        ResultFromUrlData = ResultFromUrlData.Replace("\n                                        ", "");
                        ResultFromUrlData = ResultFromUrlData.Replace("\n                                ", "");
                        ResultFromUrlData = ResultFromUrlData.Replace("googletag.pubads().setTargeting(", "");
                        ResultFromUrlData = ResultFromUrlData.Replace(")", "");
                        ResultFromUrlData = ResultFromUrlData.Replace("`", "");
                        ResultFromUrlData = ResultFromUrlData.Replace("[", "");
                        ResultFromUrlData = ResultFromUrlData.Replace("]", "");
                        ResultFromUrlData = ResultFromUrlData.Replace("'", "");
                        Pozycje = ResultFromUrlData.Split(';').ToList();

                        string marka, model, rok, pojemnosc, vin, link, sciezka, cena, stan, przebieg, kategoria, kolor, drzwi, skrzynia, nadwozie, paliwo, moc = "";
                        marka = model = rok = pojemnosc = vin = link = sciezka = cena = stan = przebieg = kategoria = kolor = drzwi = skrzynia = nadwozie = paliwo = moc;
                        DataTable Data = new DataTable();
                        Data.Columns.Add("warunek");
                        Data.Columns.Add("wartosc");
                        for (int i = 0; i < Pozycje.Count - 1; i++)
                        {
                            int lenghtSplit = Pozycje[i].Split(',').Length;
                            string wartosc = "";
                            for (int a = 1; a < lenghtSplit; a++)
                            {
                                wartosc += Pozycje[i].Split(',')[a];
                            }
                            Data.Rows.Add(Pozycje[i].Split(',')[0], wartosc);
                        }
                        for (int i = 0; i < Data.Rows.Count; i++)
                        {
                            switch (Data.Rows[i][0].ToString())
                            {
                                case "category":
                                    {
                                        kategoria = Data.Rows[i][1].ToString();
                                        break;
                                    }
                                case "make":
                                    {
                                        marka = Data.Rows[i][1].ToString();
                                        break;
                                    }
                                case "model":
                                    {
                                        model = Data.Rows[i][1].ToString();
                                        break;
                                    }
                                case "year":
                                    {
                                        rok = Data.Rows[i][1].ToString();
                                        break;
                                    }
                                case "mileage":
                                    {
                                        przebieg = Data.Rows[i][1].ToString();
                                        break;
                                    }
                                case "engine_capacity":
                                    {
                                        pojemnosc = Data.Rows[i][1].ToString();
                                        break;
                                    }
                                case "gearbox":
                                    {
                                        skrzynia = Data.Rows[i][1].ToString();
                                        break;
                                    }
                                case "fuel_type":
                                    {
                                        paliwo = Data.Rows[i][1].ToString();
                                        break;
                                    }
                                case "engine_power":
                                    {
                                        moc = Data.Rows[i][1].ToString();
                                        break;
                                    }
                                case "body_type":
                                    {
                                        nadwozie = Data.Rows[i][1].ToString();
                                        break;
                                    }
                                case "door_count":
                                    {
                                        drzwi = Data.Rows[i][1].ToString();
                                        break;
                                    }
                                case "color":
                                    {
                                        kolor = Data.Rows[i][1].ToString();
                                        break;
                                    }
                                case "price_raw":
                                    {
                                        cena = Data.Rows[i][1].ToString();
                                        break;
                                    }
                                case "vin":
                                    {
                                        vin = Data.Rows[i][1].ToString();
                                        break;
                                    }
                            }
                        }

                        link = uriString;
                        if (ResultFromUrl.Contains("filter_enum_damaged%5D%5B0%5D=1")) // D=damaged N=Normal U=Unknown
                        {
                            stan = "D";
                        }
                        else
                            stan = "N";

                        string insert = @"INSERT INTO SAMOCHODY VALUES ('" + marka + "','" + model + "','" + pojemnosc + "','" + vin + "','" + link + "','" + sciezka + "','" + cena + "','" + stan + "','" + przebieg + "','" + kategoria + "','" + kolor + "','" + drzwi + "','" + skrzynia + "','" + nadwozie + "','" + moc + "','" + paliwo + "','" + rok + "')";
                        bool wrzucone = false;
                        do
                        {
                            if (con.State.ToString() != "Open")
                            {
                                con.Open();
                                cmd.CommandText = insert;
                                cmd.ExecuteNonQuery();
                                con.Close();
                                wrzucone = true;
                            }
                        } while (!wrzucone);

                        /////////////////////////////////////////////// tutaj kurwa
                    }
                    DoneStatement = true;
                }
                else
                {
                    Thread.Sleep(5000);
                }
            } while (!DoneStatement);
        }

        public void DownloadInfoAboutFileFromGD(bool download)
        {
            GoogleDrive googleDrive = new GoogleDrive();
            googleDrive.Authorization();
            var Uprequest = googleDrive.Service.Files.List();
            Uprequest.Q = "mimeType='text/txt'";
            Uprequest.Spaces = "drive";
            Uprequest.Fields = "nextPageToken, files(name, id, size)";
            var result = Uprequest.Execute();
            bool FindDataTxt = false;
            foreach (var file in result.Files)
            {
                if (file.Name == "data.txt")
                {
                    FindDataTxt = true;
                    break;
                }
            }
            if (!FindDataTxt)
            {
                fileFind = false;
            }
            else
            {
                fileFind = true;
                fileID = result.Files[0].Id.ToString();
                fileSize = (int)result.Files[0].Size;
                if (download)
                {
                    var request = googleDrive.Service.Files.Get(fileID);
                    request.Download(Stream);
                    FileStream file = new FileStream("files/data.txt", FileMode.Create, FileAccess.Write);
                    Stream.WriteTo(file);
                }
            }
        }
    }
}
