using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMinhaFinancas.Data;
using WebMinhaFinancas.Models.Entitty;

namespace WebMinhaFinancas.Service
{
    public class IconService
    {
        private readonly WebMinhaFinancasContext _context;

        public IconService(WebMinhaFinancasContext context)
        {
            _context = context;
        }

        public List<Icon> FindAll()
        {
            return _context.Icon.OrderBy(x => x.IconName).ToList();

        }
    }
}
