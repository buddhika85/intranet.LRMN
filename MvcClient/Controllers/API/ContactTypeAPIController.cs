using MvcClient.Logger;
using Persistance;
using System;
using System.Linq;
using System.Web.Http;

namespace MvcClient.Controllers.API
{
    public class ContactTypeAPIController : ApiController
    {
        UnitOfWork _uow;
        MvcLogger _mvcLogger;

        public ContactTypeAPIController()
        {
            _uow = new UnitOfWork();
            _mvcLogger = new MvcLogger(log4net.LogManager.GetLogger(typeof(ContactTypeAPIController)));
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var contactTypes = _uow.ContactTypeRepository.GetAll().ToList();
                return Ok(contactTypes);
            }
            catch (Exception ex)
            {
                _mvcLogger.LogException(ex, ControllerContext, nameof(Get), User.Identity.Name);
                throw;
            }
        }
    }
}
