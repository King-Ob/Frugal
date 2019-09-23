using FrogoYou.Model;
using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrogoYou.Helper
{
    public class Zara
    {
       // private readonly StoreDetailContext _context;
        public ItemDetail IDs = new ItemDetail();
        public void Zaras(String URL, string WantedPrice, string Itemname, string currentPrice, string wantedprice)
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
               

                if (tokens[i].Contains("price"))
                {

                    int found = tokens[i].IndexOf(": ");
                    currentPrice= tokens[i].Substring(found + 2);
                    Console.WriteLine(currentPrice);

                }

                if (tokens[i].Contains("name"))
                {

                    int found = tokens[i].IndexOf(": ");
                    Itemname = tokens[i].Substring(found + 2);
                   

                }



            }

            string StorName = "Zara";
           
           

            IDs.ItemUrl = URL;
            IDs.ItemStore = StorName;
            IDs.ItemWantedPrice= WantedPrice;
            IDs.ItemCurrentPrice= currentPrice.Substring(1,currentPrice.Length-2);
            IDs.ItemName = Itemname.Substring(1, Itemname.Length - 2);

 
           

        }
        
        public ItemDetail RetunA()
        {
             return IDs;
        }
        
       


        

      
    }
    }
