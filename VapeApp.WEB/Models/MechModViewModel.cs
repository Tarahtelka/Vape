using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VapeApp.WEB.Models
{
    public class MechModViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Contry { get; set; }
        public string Company { get; set; }
        public int Outturn { get; set; }
        public decimal Price { get; set; }
        public int Racks { get; set; }
        public string TypeButton { get; set; }
        public string Accumulator { get; set; }

    }
}