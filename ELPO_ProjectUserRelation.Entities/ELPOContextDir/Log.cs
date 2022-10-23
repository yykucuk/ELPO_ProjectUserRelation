using System;
using System.Collections.Generic;

namespace ELPO_ProjectUserRelation.Entities.ELPOContextDir
{
    public partial class Log
    {
        public int Id { get; set; }
        public string Message { get; set; } = null!;
        public string MethodName { get; set; } = null!;
        public string ClassName { get; set; } = null!;
        public DateTime DateTime { get; set; }
    }
}
