using ELPO_ProjectUserRelation.DataAccess.Abstract;
using ELPO_ProjectUserRelation.Entities;

namespace ELPO_ProjectUserRelation.DataAccess.Concrete.EFCore
{
    public class CategoryDal : EFCoreGenericRepository<Category, ELPO_DbContext>, ICategoryDal
    {
    }
}
