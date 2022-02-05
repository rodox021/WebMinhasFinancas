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

        public DbSet<WebMinhaFinancas.Models.Entitty.User> User { get; set; }
    }
}
