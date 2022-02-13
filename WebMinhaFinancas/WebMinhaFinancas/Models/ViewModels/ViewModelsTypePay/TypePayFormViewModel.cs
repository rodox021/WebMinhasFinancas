using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMinhaFinancas.Models.Entitty;

namespace WebMinhaFinancas.Models.ViewModels.ViewModelsTypePay
{
    public class TypePayFormViewModel
    {
        public TypePay TypePay { get; set; }
        public ICollection<Icon> Icon { get; set; }

    }
}
