using ELPO_ProjectUserRelation.DataAccess.Abstract;
using ELPO_ProjectUserRelation.Entities.ELPOContextDir;

namespace ELPO_ProjectUserRelation.DataAccess.Concrete.EFCore
{
    public class CategoryDal : EFCoreGenericRepository<Category, ELPOContext>, ICategoryDal 
    {
    }
}
