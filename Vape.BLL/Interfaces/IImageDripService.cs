using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vape.BLL.DTO;
using Vape.DAL.Entities;

namespace Vape.BLL.Interfaces
{
    public interface IImageDripService : IDisposable
    {
        void Add(ImageDripDTO imageDto);

        DripDTO GetDrip(int? id);

        IEnumerable<DripDTO> GetDrips();

        ImageDripDTO GetImg(int? id);

        void DeleteImgDrip(int id);

        IEnumerable<ImageDripDTO> GetImages(int? id);

        IEnumerable<ImageDripDTO> GetImgDrips(int id);
    }
}
