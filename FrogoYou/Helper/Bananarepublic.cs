using FrogoYou.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrogoYou.Helper
{
    public class Bananarepublic
    {
        // private readonly StoreDetailContext _context;
        public ItemDetail IDs = new ItemDetail();
        public void Bananarepublics(String URL, string WantedPrice, string Itemname, string currentPrice, string wantedprice)
        {
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(URL);

            var scriptElements = htmlDoc.DocumentNode.SelectSingleNode("//script[@type=\"application/ld+json\"]");


            string jsonGet = "";

            jsonGet = scriptElements.InnerText.ToString();

            char[] delims = { ',' };
            

            String[] tokens = jsonGet.Split(delims);

            for (int i = 0; i < tokens.Length; i++)
            {
                Console.WriteLine(tokens[i]);

                if (tokens[i].Contains("price") && currentPrice == "")
                {

                    int found = tokens[i].IndexOf(":",2);
                    currentPrice = tokens[i].Substring(found + 2);
                    Console.WriteLine(currentPrice);

                }

                if (tokens[i].Contains("name") && Itemname == "")
                {

                    int found = tokens[i].IndexOf(":",2);
                    Itemname = tokens[i].Substring(found + 2);
                   

                }



            }

          

          

            string StorName = "Banana Republic";

            IDs.ItemUrl = URL;
            IDs.ItemStore = StorName;
            IDs.ItemWantedPrice = WantedPrice;
            IDs.ItemCurrentPrice = currentPrice.Substring(0, currentPrice.Length - 2);
            IDs.ItemName = Itemname.Substring(0, Itemname.Length - 1);






        }

        public ItemDetail RetunA()
        {
            return IDs;
        }
    }
}