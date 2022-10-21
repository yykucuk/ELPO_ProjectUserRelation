using System.ComponentModel.DataAnnotations;

namespace ELPO_ProjectUserRelation.Entities
{
    public partial class Project : BaseClass
    {
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string Description { get; set; }

        [StringLength(150)]
        public string IconUrl { get; set; }

        public int Progress { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
