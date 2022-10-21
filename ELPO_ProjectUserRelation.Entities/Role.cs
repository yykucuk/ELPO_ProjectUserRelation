namespace ELPO_ProjectUserRelation.Entities
{
    public partial class Role : BaseClass
    {
        public ICollection<User> Users { get; set; }
    }
}
