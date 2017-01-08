using System.Web.Mvc;

namespace MvcClient.Controllers
{
    public class UserController : Controller
    {
        // redirect user to landing dashboard page after login in
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            else if (User.IsInRole("ProjectOwner"))
            {
                return RedirectToAction("Dashboard", "ProjectOwner");
            }
            else if (User.IsInRole("Contact"))
            {
                return RedirectToAction("Dashboard", "Contact");
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnUrl = "\\" });
            }
        }
    }
}