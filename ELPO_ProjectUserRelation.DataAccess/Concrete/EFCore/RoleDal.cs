using ELPO_ProjectUserRelation.DataAccess.Abstract;
using ELPO_ProjectUserRelation.Entities.ELPOContextDir;

namespace ELPO_ProjectUserRelation.DataAccess.Concrete.EFCore
{
    public class RoleDal : EFCoreGenericRepository<Role, ELPOContext>, IRoleDal //ELPOContext
    {
    }
}
