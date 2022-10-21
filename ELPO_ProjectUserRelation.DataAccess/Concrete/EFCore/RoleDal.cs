using ELPO_ProjectUserRelation.DataAccess.Abstract;
using ELPO_ProjectUserRelation.Entities;

namespace ELPO_ProjectUserRelation.DataAccess.Concrete.EFCore
{
    public class RoleDal : EFCoreGenericRepository<Role, ELPO_DbContext>, IRoleDal
    {
    }
}
