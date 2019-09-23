using FrogoYou.Model;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrogoYou.Helper
{
    public class Bonobos
    {
        // private readonly StoreDetailContext _context;
        public ItemDetail IDs = new ItemDetail();
        public void Bonoboss(String URL, string WantedPrice, string Itemname, string currentPrice, string wantedprice)
        {

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(URL);

         
            var scriptElementswithID = htmlDoc.DocumentNode.SelectSingleNode("//script [@id='{ __NEXT_DATA__ }']");
            var getElement = htmlDoc.GetElementbyId("__NEXT_DATA__");

            string GetInnerText = getElement.InnerText.ToString();


            dynamic GetProperties = JsonConvert.DeserializeObject(GetInnerText);

          // currentPrice = GetProperties.props.pageProps.initialReduxState.productDetail.analytics.price.fullPrice;


            Itemname = GetProperties.props.pageProps.initialReduxState.productDetail.analytics.selectedVariant.name;

            string finalSale = GetProperties.props.pageProps.initialReduxState.productDetail.analytics.selectedVariant.finalSale;
            if (finalSale == "true")
            {
                currentPrice = GetProperties.props.pageProps.initialReduxState.productDetail.analytics.price.price;
            }
            else
            {
                currentPrice = GetProperties.props.pageProps.initialReduxState.productDetail.analytics.price.fullprice;
            }
          

           

           String StorName = "Bonobos";

            IDs.ItemCurrentPrice = currentPrice;
            IDs.ItemName = Itemname;
            IDs.ItemUrl = URL;
            IDs.ItemWantedPrice = WantedPrice;
            IDs.ItemStore = StorName;
        }


        public ItemDetail RetunA()
        {
            return IDs;
        }

    }
}


