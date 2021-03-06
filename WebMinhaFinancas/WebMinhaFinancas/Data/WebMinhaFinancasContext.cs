using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMinhaFinancas.Models.Entitty;

namespace WebMinhaFinancas.Data
{
    public class WebMinhaFinancasContext : DbContext
    {
        public WebMinhaFinancasContext (DbContextOptions<WebMinhaFinancasContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<TypePay> TypePay { get; set; }
        public DbSet<Icon> Icon { get; set; }
        public DbSet<TypeFixedBill> TypeFixedBill { get; set; }




    }
}
