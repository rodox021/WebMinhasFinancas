using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMinhaFinancas.Models.Entitty
{
    public class User :BaseEntity
    {
        
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage ="Campo {0} é Obrigatório")]
        [StringLength(100, ErrorMessage = "máximo de {1} caracateres")]
        public string FullName { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        [StringLength(70, ErrorMessage = "máximo de {1} caracateres")]
        [EmailAddress(ErrorMessage = "Email Inválido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo {0} é Obrigatório")]
        //[StringLength(70, ErrorMessage = "máximo de {1} caracateres")]
        //[EmailAddress(ErrorMessage = "Email Inválido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Boolean Active { get; set; } = true;
        public List<TypePay> LTyoePay { get; set; }



    }
}
