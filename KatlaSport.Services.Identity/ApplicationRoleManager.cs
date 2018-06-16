using Microsoft.AspNet.Identity;

namespace KatlaSport.Services.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>, IApplicationRoleManager
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store)
            : base(store)
        {
        }
    }
}
