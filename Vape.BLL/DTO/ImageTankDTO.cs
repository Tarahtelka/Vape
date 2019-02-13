using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vape.DAL.Entities
{
    public class ImageTankDTO
    {
            
        public int Id { get; set; }
        public byte[] Data { get; set; }

        public string MimeType { get; set; }

        public int TankId { get; set; }
    }
}
