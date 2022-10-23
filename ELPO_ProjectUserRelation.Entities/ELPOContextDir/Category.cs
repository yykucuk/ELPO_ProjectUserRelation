using System;
using System.Collections.Generic;

namespace ELPO_ProjectUserRelation.Entities.ELPOContextDir
{
    public partial class Category
    {
        public Category()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Color { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
