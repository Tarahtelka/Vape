using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vape.BLL.DTO;
using Vape.DAL.Entities;

namespace Vape.BLL.Interfaces
{
    public interface IImageFluidService : IDisposable
    {
        void Add(ImageFluidDTO imageDto);

        FluidDTO GetFluid(int? id);

        IEnumerable<FluidDTO> GetFluids();

        ImageFluidDTO GetImg(int? id);

        void DeleteImgFluid(int id);

        IEnumerable<ImageFluidDTO> GetImages(int? id);

        IEnumerable<ImageFluidDTO> GetImgFluids(int id);
    }
}
