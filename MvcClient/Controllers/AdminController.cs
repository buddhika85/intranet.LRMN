using MvcClient.Logger;
using Persistance;
using System;
using System.Web;
using System.Web.Mvc;

namespace MvcClient.Controllers
{
    [Authorize]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        UnitOfWork _uow;
        MvcLogger _mvcLogger;

        public AdminController()
        {
            _uow = new UnitOfWork();
            _mvcLogger = new MvcLogger(log4net.LogManager.GetLogger(typeof(AdminController)));
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
                throw new HttpException(500, "Error - Dashboard did not get loaded - Contact IT Support");
            }
        }

        [HttpGet]
        public ActionResult ManageContacts()
        {
            try
            {
                //var applicationUsers = _uow.ApplicationUserRepository.QueryObjectGraph("ContactType").ToList();
                return View();
            }
            catch (Exception ex)
            {
                _mvcLogger.LogException(ex, ControllerContext, User.Identity.Name);
                throw new HttpException(500, "Error - ManageContacts page did not get loaded - Contact IT Support");
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
                throw new HttpException(500, "Error - ManagePartnerContacts page did not get loaded - Contact IT Support");
            }
        }

    }
}