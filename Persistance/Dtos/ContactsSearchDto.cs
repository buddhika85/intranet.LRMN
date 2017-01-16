namespace Persistance.Dtos
{
    public class ContactsSearchDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IsApproved { get; set; }
        public string IsLocked { get; set; }
        public string IsActivated { get; set; }
        public int ContactTypeId { get; set; }
        public string VolunteerInerests { get; set; }
    }
}
