using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SERVICES.REPO;
using SERVICES.MODEL;

namespace SERVICES.API.Controllers
{
    [Authorize]
    public class OrdenesController : ApiController
    {
        #region privateMembers

        private IOrdenesRepository ordenesRepo;

        #endregion

        #region constructor
        public OrdenesController(IOrdenesRepository repo) : base()
        {
            this.ordenesRepo = repo;
        }


        #endregion
        // GET: api/Ordenes
        public IEnumerable<Orden> Get()
        {
            return ordenesRepo.GetAll();
        }

        // GET: api/Ordenes/5
        public Orden Get(long id)
        {
            return ordenesRepo.GetById(id);
        }

        // POST: api/Ordenes
        public void Post([FromBody]string value)
        {
           
        }

        // PUT: api/Ordenes/5
        public void Put(Orden orden)
        {
            ordenesRepo.Add(orden);
        }

        // DELETE: api/Ordenes/5
        public void Delete(int id)
        {
            ordenesRepo.Delete(id);
        }
    }
}
