﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMinhaFinancas.Models.Entitty;

namespace WebMinhaFinancas.Data
{
    public class SeedingService
    {
        private WebMinhaFinancasContext _context;

        public SeedingService(WebMinhaFinancasContext conext)
        {
            _context = conext;
        }

        // metodo para popular um banco de dados caso esteja vázio
        public void Seed()
        {

            // primeiro temos que testar para saber se o bd está vazio caso não esteja, não fazer nada
            if (_context.Icon.Any())
            {
                return;
            }

            Icon icon1 = new Icon("MASTERCARD", "fab fa-cc-mastercard");
            Icon icon2 = new Icon("VISA", "fab fa-cc-visa");
            Icon icon3 = new Icon("AMERICAM EXPRESS", "fab fa-cc-amex");
            Icon icon4 = new Icon("DÉBITO", "fas fa-credit-card");
            Icon icon5 = new Icon("CASH", "far fa-money-bill-alt");
            Icon icon6 = new Icon("PayPal", "fab fa-paypal");
            Icon icon7 = new Icon("DEFAULT", "far fa-credit-card");


            _context.Icon.AddRange(icon1, icon2, icon3, icon4, icon5, icon6, icon7);
            _context.SaveChanges();
        }
    }
}