using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMinhaFinancas.Data;
using WebMinhaFinancas.Models.Entitty;

namespace WebMinhaFinancas.Service
{
    public class TypeFixedBillsService
    {
        private readonly WebMinhaFinancasContext _context;

        public TypeFixedBillsService(WebMinhaFinancasContext context)
        {
            _context = context;
        }

        public List<TypeFixedBill> FindAll()
        {
            return _context.TypeFixedBill.ToList();
        }
    }
}
