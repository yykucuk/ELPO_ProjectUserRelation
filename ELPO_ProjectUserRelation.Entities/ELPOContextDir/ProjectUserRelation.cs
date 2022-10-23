using System;
using System.Collections.Generic;

namespace ELPO_ProjectUserRelation.Entities.ELPOContextDir
{
    public partial class ProjectUserRelation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
