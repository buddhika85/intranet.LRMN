using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Persistance.DomainModel
{
    public class ApplicationUser : IdentityUser
    {
        // additional application specific user properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public DateTime JoinDate { get; set; }

        public DateTime? ContractEndDate { get; set; }


        public bool UserActive { get; set; }

        public bool IsAdminApproved { get; set; }

        public bool UserLocked { get; set; }


        public string AddressLine1 { get; set; }


        public string AddressLine2 { get; set; }


        public string AddressLine3 { get; set; }


        public string CountyOrRegion { get; set; }


        public string Country { get; set; }


        public string Postcode { get; set; }


        public string VolunteerInterests { get; set; }
        public string PhoneNumber { get; set; }

        // Foriegn key
        public int ContactTypeId { get; set; }

        public DateTime? LastLoginDateTime { get; set; }

        // Navigational Property
        public ContactType ContactType { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
