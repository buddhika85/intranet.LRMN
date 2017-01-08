using System.Web.Mvc;

namespace MvcClient.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}