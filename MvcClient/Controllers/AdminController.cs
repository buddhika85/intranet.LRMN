using MvcClient.Logger;
using Persistance;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MvcClient.Controllers
{
    public class AdminController : Controller
    {
        UnitOfWork _uow;
        MvcLogger _mvcLogger;

        public AdminController()
        {
            _uow = new UnitOfWork();
            _mvcLogger = new MvcLogger();
        }

        // GET: Admin
        public ActionResult Dashboard()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                _mvcLogger.LogException(ex, ControllerContext, User.Identity.Name);
                throw;
            }
        }

        public ActionResult ManageContacts()
        {
            try
            {
                var applicationUsers = _uow.ApplicationUserRepository.QueryObjectGraph("ContactType").ToList();
                return View(applicationUsers);
            }
            catch (Exception ex)
            {
                _mvcLogger.LogException(ex, ControllerContext, User.Identity.Name);
                throw;
            }
        }

        public ActionResult ManagePartnerContacts()
        {
            try
            {

                return View();
            }
            catch (Exception ex)
            {
                _mvcLogger.LogException(ex, ControllerContext, User.Identity.Name);
                throw;
            }
        }

    }
}