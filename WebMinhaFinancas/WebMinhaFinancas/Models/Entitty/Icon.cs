using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMinhaFinancas.Models.Entitty
{
    public class Icon
    {
       

        public int Id { get; set; }

        [Display(Name = "Bandeira")]
        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        [StringLength(50, ErrorMessage = "máximo de {1} caracateres permitido")]
        public string IconName { get; set; }



        [Display(Name = "Icon")]
        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        public string IconClass { get; set; }
        public List<TypePay> LTPay { get; set; } = new List<TypePay>();

        public Icon() { }
        public Icon( string iconName, string icon)
        {
           
            this.IconName = iconName;
            this.IconClass = icon;
        }
    }
}
