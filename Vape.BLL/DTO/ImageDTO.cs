﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vape.BLL.DTO
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public string MimeType { get; set; }
        public int FullVapeId { get; set; }
    }
}
