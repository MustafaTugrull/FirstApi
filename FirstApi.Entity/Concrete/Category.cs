﻿using FirstApi.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApi.Entity.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
