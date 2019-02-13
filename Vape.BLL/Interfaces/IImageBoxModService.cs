using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vape.BLL.DTO;

namespace Vape.BLL.Interfaces
{
    public interface IImageBoxModService : IDisposable
    {
            void Add(ImageBoxModDTO imageDto);

            BoxModDTO GetBoxMod(int? id);

            IEnumerable<BoxModDTO> GetBoxMods();

            ImageBoxModDTO GetImg(int? id);

            void DeleteImgBoxMod(int id);

            IEnumerable<ImageBoxModDTO> GetImages(int? id);

            IEnumerable<ImageBoxModDTO> GetImgBoxMods(int id);        
    }
}
