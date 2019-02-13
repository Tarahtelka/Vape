using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeApp.DAL.Entities
{
    public class Drip
    {
        public int Id { get; set; }
        public int Diameter { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Contry { get; set; }
        public decimal Price { get; set; }
        public int Racks { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
