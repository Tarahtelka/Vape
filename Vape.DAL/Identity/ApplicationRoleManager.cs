using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Vape.DAL.Entities;

namespace Vape.DAL.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(RoleStore<ApplicationRole> store)
                    : base(store)
        {
        }
    }
}