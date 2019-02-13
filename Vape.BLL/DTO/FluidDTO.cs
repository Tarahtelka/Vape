using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vape.BLL.DTO
{
    public class FluidDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Contry { get; set; }
        public string Flavor { get; set; }
        public string Company { get; set; }
        public int PG { get; set; }
        public int VG { get; set; }
        public decimal Price { get; set; }
    }
}
