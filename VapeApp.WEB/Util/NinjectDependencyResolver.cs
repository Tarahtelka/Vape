using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vape.BLL.Interfaces;
using Vape.BLL.Services;

namespace VapeApp.WEB.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IOrderService>().To<OrderService>();
            kernel.Bind<IImageService>().To<ImageService>();
            kernel.Bind<IImageBoxModService>().To<ImageBoxModService>();
            kernel.Bind<IImageTankService>().To<ImageTankService>();
            kernel.Bind<IImageDripService>().To<ImageDripService>();
            kernel.Bind<IImageFluidService>().To<ImageFluidService>();
            kernel.Bind<IImageMechModService>().To<ImageMechModService>();

        }
    }
}
