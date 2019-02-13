using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vape.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int BoxModId { get; set; }
        public int FullVapeId { get; set; }
        public int MechModId { get; set; }
        public int FluidId { get; set; }
        public int DripId { get; set; }
        public int TankId { get; set; }
        public DateTime? Date { get; set; }
    }
}
