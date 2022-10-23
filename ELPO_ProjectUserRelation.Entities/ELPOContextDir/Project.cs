using System;
using System.Collections.Generic;

namespace ELPO_ProjectUserRelation.Entities.ELPOContextDir
{
    public partial class Project
    {
        public Project()
        {
            ProjectUserRelations = new HashSet<ProjectUserRelation>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public string? IconUrl { get; set; }
        public int? Progress { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<ProjectUserRelation> ProjectUserRelations { get; set; }
    }
}
