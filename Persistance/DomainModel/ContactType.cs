using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistance.DomainModel
{
    public class ContactType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(maximumLength: 30, MinimumLength = 1, ErrorMessage = "Please enter a valid contact time (Max characters 30)")]
        public string TypeName { get; set; }
    }
}
