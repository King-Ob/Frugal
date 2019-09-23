using FrogoYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrogoYou.Helper
{
    public enum Stores { Zara, Bonobos, saksfifthavenue, bananarepublic, Hm, Jcrew,
       
    }
    public class StoreInfo
    {
        private ItemDetail itemDetail = new ItemDetail();
        
        public string getStore(string Url, string a)
        {
           // string currentstore = "";
           //foreach(var s in Enum.GetNames(typeof(Stores)))
           // {
           //     if (Url.Contains(s))
           //     {
           //           s = currentstore;
           //     }
           // }

            if( Url.Contains("zara"))
            {
                Zara z = new Zara();

              
                z.Zaras(Url,a,"","","");

            }

            return null;
            
        }
    }
}
