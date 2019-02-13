using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VapeApp.WEB.Models
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public string MimeType { get; set; }
        public int FullVapeId { get; set; }
    }
}