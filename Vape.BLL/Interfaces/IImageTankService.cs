using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vape.BLL.DTO;
using Vape.DAL.Entities;

namespace Vape.BLL.Interfaces
{
    public interface IImageTankService : IDisposable
    {
        void Add(ImageTankDTO imageDto);

        TankDTO GetTank(int? id);

        IEnumerable<TankDTO> GetTanks();

        ImageTankDTO GetImg(int? id);

        void DeleteImgTank(int id);

        IEnumerable<ImageTankDTO> GetImages(int? id);

        IEnumerable<ImageTankDTO> GetImgTanks(int id);
    }
}
