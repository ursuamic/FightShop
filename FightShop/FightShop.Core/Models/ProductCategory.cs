﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightShop.Core.Models
{
    public class ProductCategory : BaseEntity
    {
        public string Category { get; set; }
    }
}
