using Persistance;
using System.Web.Http;

namespace MvcClient.Controllers.Api
{
    public class ContactTypeAPIController : ApiController
    {
        public UnitOfWork _uow { get; set; }

        public ContactTypeAPIController()
        {
            _uow = new UnitOfWork();
        }

        // Add initial contact types as a test
        // Below code worked
        [HttpGet]
        public IHttpActionResult Index()
        {
            try
            {
                //_uow.ContactTypeRepository.Insert(new ContactType { TypeName = "staff" });
                //_uow.ContactTypeRepository.Insert(new ContactType { TypeName = "volunteer" });
                //_uow.ContactTypeRepository.Insert(new ContactType { TypeName = "partner organization contact" });
                //_uow.Save();
                return Ok("Contact Types Added");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
