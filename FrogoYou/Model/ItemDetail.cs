using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrogoYou.Model
{
    public class ItemDetail
    {
        [Key]
        public int Id { get; set; }

        public string ItemName { get; set; }

        public string  ItemUrl { get; set; }

        public string  ItemCurrentPrice { get; set; }

        public string ItemSalesPrice { get; set; }

        public string ItemStore { get; set; }

        public int UserId { get; set; }

        public string ItemWantedPrice { get; set; }

    }
}
