using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrogoYou.Model
{
    public class StoreDetailContext:DbContext
    {
        public StoreDetailContext(DbContextOptions<StoreDetailContext> options)
                : base(options)
        {
            
        }
        public DbSet<ItemDetail> ItemDetails { get; set; }
    }
}
