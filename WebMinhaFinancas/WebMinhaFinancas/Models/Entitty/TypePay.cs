﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMinhaFinancas.Models.Entitty
{
    public class TypePay: BaseEntity
    {
        public string Flag { get; set; }
        public string Icon { get; set; }
        public Icon IconFont { get; set; }
        public User User { get; set; }



    }
}
