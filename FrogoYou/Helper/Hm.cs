using FrogoYou.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrogoYou.Helper
{
    public class Hm
    {
        // private readonly StoreDetailContext _context;
        public ItemDetail IDs = new ItemDetail();
        public void Hms(String URL, string WantedPrice, string Itemname, string currentPrice, string wantedprice)
        {
            HtmlWeb web = new HtmlWeb();

            //   web.LoadFromBrowser(URL);
            //  web.StreamBufferSize = 0;


            var htmlDoc = web.Load(URL);

            
            var scriptElements = htmlDoc.DocumentNode.SelectSingleNode("//script[@type=\"application/ld+json\"]");


            string jsonGet = "";

            jsonGet = scriptElements.InnerText.ToString();

            //string currentTitle;
            //string delims = "[,]";
            char[] delims = { ',' };
            //  int gettitle = Itemname.IndexOf("-");

            // string FinalTitle = Itemname.Substring(0, gettitle);

            String[] tokens = jsonGet.Split(delims);

            for (int i = 0; i < tokens.Length; i++)
            {
                Console.WriteLine(tokens[i]);

                if (tokens[i].Contains("price"))
                {

                    int found = tokens[i].IndexOf(": ");
                    currentPrice = tokens[i].Substring(found + 2);
                    Console.WriteLine(currentPrice);

                }

                
                if (tokens[i].Contains("name") && Itemname == "")
                {

                    int found = tokens[i].IndexOf(": ");
                    Itemname = tokens[i].Substring(found + 2);
                    //Console.WriteLine(currentPrice);


                }
              



            }
            string StorName = "HM";
     

            IDs.ItemUrl = URL;
            IDs.ItemStore = StorName;
            IDs.ItemWantedPrice = wantedprice;
            IDs.ItemCurrentPrice = currentPrice.Substring(1, currentPrice.Length - 2);
            IDs.ItemName = Itemname.Substring(1, Itemname.Length - 2); ;






        }

        public ItemDetail RetunA()
        {
            return IDs;
        }
    }
}