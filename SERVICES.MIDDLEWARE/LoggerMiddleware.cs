using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using log4net;

namespace SERVICES.MIDDLEWARES
{
    public class LoggerMiddleware: OwinMiddleware
    {

        #region members

        private ILog _logger;

        #endregion

        #region constructors

        public LoggerMiddleware(OwinMiddleware next, ILog Logger):base(next)
        {
            this._logger = Logger;
        }

        #endregion

        #region invoke

        public override async Task Invoke(IOwinContext context)
        {
            _logger.Debug("Middleware begin");
            await this.Next.Invoke(context);
            _logger.Debug("Middleware end");
        }

        #endregion
    }
}
