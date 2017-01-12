using System;

namespace Persistance.ViewModels
{
    public class ApplicationUserViewModel
    {
        public int UserIdGenerated { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public bool UserActive { get; set; }
        public bool UserLocked { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string CountyOrRegion { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public string VolunteerInterests { get; set; }
        public DateTime? LastLoginDateTime { get; set; }
        public int ContactTypeId { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
