using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeApp.DAL.Entities;

namespace Vape.DAL.Entities
{
    public class ImageBoxMod
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public string MimeType { get; set; }

        public int BoxModId { get; set; }
        public BoxMod BoxMod { get; set; }
    }
}
