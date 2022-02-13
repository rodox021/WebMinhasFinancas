using System;
using System.Collections.Generic;
using System.Linq;
using WebMinhaFinancas.Data;
using WebMinhaFinancas.Models.Entitty;

namespace WebMinhaFinancas.Service
{
    public class TypePayService
    {
        private readonly WebMinhaFinancasContext _context;
        public TypePayService(WebMinhaFinancasContext context)
        {
            _context = context;
        }


        public List<TypePay> FindAll()
        {

            List<TypePay> tps = new List<TypePay>();

            var list = _context.TypePay.OrderBy(x => x.Flag).ToList();
            var icons = _context.Icon.ToList();

            //// ----fazendo join com ForEach---
            //foreach (var item in list)
            //{
            //    var tp = _context.Icon.FirstOrDefault(t => t.Id == item.IconId);
            //    item.IconFont = tp;
            //    tps.Add(item);
            //}

            //fazendo join com consulta LINQ
            var res = from tp in list
                      join i in icons on tp.IconId equals i.Id
                      select new TypePay
                      {
                          Id = tp.Id,
                          CreateAt = tp.CreateAt,
                          Flag = tp.Flag,
                          IconId = tp.IconId,
                          User = tp.User,
                          IconFont = i

                      };


            //.FirstOrDefaultAsync(m => m.Id == id);


            return res.OrderBy(x => x.Flag).ToList();
        }
        //----------------------------------------------------------------------------------------------
        public void Insert(TypePay tp)
        {
            tp.CreateAt = tp.CreateAt == null ? DateTime.Now : tp.CreateAt;
            _context.Add(tp);
            _context.SaveChanges();

        }
        //----------------------------------------------------------------------------------------------
        public void Delete(int? id)
        {
            if (id == null)
            {
                return;
            }

            var tp = _context.TypePay.FirstOrDefault(t => t.Id == id);

            if (tp.Id == null)
            {
                return;
            }

            _context.TypePay.Remove(tp);
            _context.SaveChanges();
        }
    }
}
