using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeApp.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Sum { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public int FullVapeId { get; set; }
        public FullVape FullVape { get; set; }

        public int MechModId { get; set; }
        public MechMod MechMod { get; set; }
        
        public int BoxModId { get; set; }
        public BoxMod BoxMod { get; set; }

        public int FluidId { get; set; }
        public Fluid Fluid { get; set; }

        public int DripId { get; set; }
        public Drip Drip { get; set; }

        public int TankId { get; set; }
        public Tank Tank { get; set; }

        public DateTime Date { get; set; }
    }
}
