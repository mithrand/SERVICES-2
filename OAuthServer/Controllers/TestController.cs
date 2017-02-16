using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OAuthServer.Controllers
{
    public class TestController : ApiController
    {
        // GET: api/Test
        public string Get()
        {
            return DateTime.Now.ToString();
        }

    }
}
