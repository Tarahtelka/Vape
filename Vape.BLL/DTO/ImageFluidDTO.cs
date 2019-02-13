using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vape.DAL.Entities
{
    public class ImageFluidDTO
    {    
        public int Id { get; set; }
        public byte[] Data { get; set; }

        public string MimeType { get; set; }

        public int FluidId { get; set; }
    }
}
