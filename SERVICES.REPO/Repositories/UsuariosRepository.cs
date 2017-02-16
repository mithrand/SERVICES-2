using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OAuth.Interfaces;
using SERVICES.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.REPO
{
    public interface IUsuariosRepository:IDisposable,IAuthRepo
    {

    }

    public class UsuariosRepository: IUsuariosRepository
    {
        private IServicesDBContext ctx;

        private UserManager<IdentityUser> _userManager;

        public UsuariosRepository(IServicesDBContext ctx)
        {
            this.ctx = ctx;
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(ctx as System.Data.Entity.DbContext));
        }

        public async Task<IdentityResult> RegisterUser(IUserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            ctx.Dispose();
            _userManager.Dispose();

        }
    }
}
