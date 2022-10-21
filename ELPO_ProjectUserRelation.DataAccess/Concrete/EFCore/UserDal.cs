using ELPO_ProjectUserRelation.DataAccess.Abstract;
using ELPO_ProjectUserRelation.Entities;

namespace ELPO_ProjectUserRelation.DataAccess.Concrete.EFCore
{
    public class UserDal : EFCoreGenericRepository<User, ELPO_DbContext>, IUserDal
    {
    }
}
