using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Vape.BLL.DTO;
using Vape.BLL.Infrastructure;

namespace Vape.BLL.Interfaces
{
    public interface IImageService : IDisposable
    {
        void Add(ImageDTO imageDto);

        FullVapeDTO GetFullVape(int? id);

        IEnumerable<FullVapeDTO> GetFullVapes();

        ImageDTO GetImg(int? id);

        void DeleteImgFullVape(int id);

        IEnumerable<ImageDTO> GetImages(int? id);

        IEnumerable<ImageDTO> GetImgFullVapes(int id);
    }
}
