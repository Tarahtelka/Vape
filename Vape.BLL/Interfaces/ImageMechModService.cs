using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vape.BLL.DTO;
using Vape.DAL.Entities;

namespace Vape.BLL.Interfaces
{
    public interface IImageMechModService : IDisposable
    {
        void Add(ImageMechModDTO imageDto);

        MechModDTO GetMechMod(int? id);

        IEnumerable<MechModDTO> GetMechMods();

        ImageMechModDTO GetImg(int? id);

        void DeleteImgMechMod(int id);

        IEnumerable<ImageMechModDTO> GetImages(int? id);

        IEnumerable<ImageMechModDTO> GetImgMechMods(int id);
    }
}
