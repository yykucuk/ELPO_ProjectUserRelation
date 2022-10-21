using System.ComponentModel.DataAnnotations;

namespace ELPO_ProjectUserRelation.Entities
{
    public partial class BaseClass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
