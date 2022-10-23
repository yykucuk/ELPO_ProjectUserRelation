using ELPO_ProjectUserRelation.DataAccess.Abstract;
using ELPO_ProjectUserRelation.Entities.ELPOContextDir;

namespace ELPO_ProjectUserRelation.DataAccess.Concrete.EFCore
{
    public class ProjectUserRelationDal : EFCoreGenericRepository<ProjectUserRelation, ELPOContext>, IProjectUserRelationDal
    {
    }
}
