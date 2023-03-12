using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InspectorPortal.Data.Entities
{
    [Table("Users")] //kaldırılabilir.
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(128)]
        public string Email { get; set; }

        [Required]
        [MaxLength(128)]
        public string Password { get; set; }

        //public int UserDetailId { get; set; }

        //[ForeignKey(nameof(UserDetailId))]
        //public virtual UserDetail UserDetail { get; set; }
    }
}