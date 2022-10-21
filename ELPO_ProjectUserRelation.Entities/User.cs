using System.ComponentModel.DataAnnotations;

namespace ELPO_ProjectUserRelation.Entities
{
    public partial class User : BaseClass
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        [StringLength(150)]
        public string ProfileImageUrl { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}