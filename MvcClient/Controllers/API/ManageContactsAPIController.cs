using MvcClient.Logger;
using Persistance;
using Persistance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var result = _uow.ApplicationUserRepository.SQLQuery<ApplicationUserViewModel>(
                    sql: "usp_GetApplicationUsers", parameters: null);
                IList<ApplicationUserViewModel> contacts = result.ToList();
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                _mvcLogger.LogException(ex, ControllerContext, nameof(Get), User.Identity.Name);
                throw;
            }
        }
    }
}
