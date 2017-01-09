using MvcClient.Logger;
using Persistance;
using System;
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

                return View();
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