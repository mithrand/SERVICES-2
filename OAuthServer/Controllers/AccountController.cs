using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OAuth;
using OAuth.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace OAuthServer.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private IAuthRepo repo = null;

        public AccountController(IAuthRepo repo)
        {
            this.repo = repo;
        }

        // POST api/Account/Register
        [AllowAnonymous]
        public async Task<IHttpActionResult> Put(IUserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await repo.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            IHttpActionResult response = null;

            if (result == null)
            {
                response = InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    response = BadRequest();
                }

                response = BadRequest(ModelState);
            }

            return response;
        }
    }
}
