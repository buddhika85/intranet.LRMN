using MvcClient.Logger;
using Persistance;
using System;
using System.Web.Http;

namespace MvcClient.Controllers.API
{
    public class ManageContactsAPIController : ApiController
    {
        UnitOfWork _uow;
        MvcLogger _mvcLogger;

        public ManageContactsAPIController()
        {
            _uow = new UnitOfWork();
            _mvcLogger = new MvcLogger(log4net.LogManager.GetLogger(typeof(ManageContactsAPIController)));
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                throw new Exception("exception thrown");
            }
            catch (Exception ex)
            {
                _mvcLogger.LogException(ex, ControllerContext, nameof(Get), User.Identity.Name);
                throw ex;
            }
        }
    }
}
