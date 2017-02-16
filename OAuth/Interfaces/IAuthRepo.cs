using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;

namespace OAuth.Interfaces
{
    public interface IAuthRepo:IDisposable
    {
        Task<IdentityResult> RegisterUser( IUserModel UserModel);
        Task<IdentityUser> FindUser(string userName, string password);
    }
}
