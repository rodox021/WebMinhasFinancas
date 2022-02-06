using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMinhaFinancas.Models.Entitty
{
    public class Icon
    {
       

        public int Id { get; set; }
        public string iconName { get; set; }
        public string icon { get; set; }
        public List<TypePay> LTPay { get; set; } = new List<TypePay>();

        public Icon() { }
        public Icon( string iconName, string icon)
        {
           
            this.iconName = iconName;
            this.icon = icon;
        }
    }
}
