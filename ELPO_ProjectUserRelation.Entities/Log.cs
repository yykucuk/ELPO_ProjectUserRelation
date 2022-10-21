namespace ELPO_ProjectUserRelation.Entities
{
    public partial class Log
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string MethodName { get; set; }
        public string ClassName { get; set; }
        public System.DateTime DateTime { get; set; }
        public int UserId { get; set; }
    }
}
