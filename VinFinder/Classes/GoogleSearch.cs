using System;
using System.Collections.Generic;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;
using System.Windows.Forms;

namespace VinFinder
{
    public class GoogleSearch
    {
        //API Key
        private static string API_KEY = "AIzaSyAQXTMMlCRoxdHZcMqBlkMEZSHCv_ZzowE";

        //The custom search engine identifier
        private static string cx = "018029759955463431283:s8ihhut0fx0";

        public static CustomsearchService Service = new CustomsearchService(
            new BaseClientService.Initializer
            {
                ApplicationName = "VINSEARCH",
                ApiKey = API_KEY,
            });

        public static IList<Result> Search(string query)
        {
            CseResource.ListRequest listRequest = Service.Cse.List(query);
            listRequest.Cx = cx;

            Search search = listRequest.Execute();
            return search.Items;
        }
    }
}
