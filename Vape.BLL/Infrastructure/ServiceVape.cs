using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vape.DAL.Interfaces;
using Vape.DAL.Repositories;

namespace Vape.BLL.Infrastructure
{
    public class ServiceVape : NinjectModule
    {
        private string connectionString;
        public ServiceVape(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
