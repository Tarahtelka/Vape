﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vape.BLL.DTO
{
    public class DripDTO
    {
        public int Id { get; set; }
        public int Diameter { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Company { get; set; }
        public string Contry { get; set; }
        public decimal Price { get; set; }
        public int Racks { get; set; }
    }
}
