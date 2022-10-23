using System;
using System.Collections.Generic;

namespace ELPO_ProjectUserRelation.Entities.ELPOContextDir
{
    public partial class User
    {
        public User()
        {
            ProjectUserRelations = new HashSet<ProjectUserRelation>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int RoleId { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string Password { get; set; } = null!;
        public DateTime? LastOnline { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<ProjectUserRelation> ProjectUserRelations { get; set; }
    }
}
