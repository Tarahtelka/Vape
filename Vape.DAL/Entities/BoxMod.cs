using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vape.DAL.Entities;

namespace VapeApp.DAL.Entities
{
    public class BoxMod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Accumulator { get; set; }
        public string Contry { get; set; }
        public string Company { get; set; }
        public int Outturn { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }

        public ICollection<ImageBoxMod> ImageBoxMods { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
