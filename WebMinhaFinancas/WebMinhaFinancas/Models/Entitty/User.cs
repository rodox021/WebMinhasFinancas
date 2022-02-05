using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMinhaFinancas.Models.Entitty
{
    public class User :BaseEntity
    {
       
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Boolean Active { get; set; } = true;


    }
}
