namespace ELPO_ProjectUserRelation.Entities
{
    public partial class Category : BaseClass
    {
        public ICollection<Project> Projects { get; set; }
    }
}
