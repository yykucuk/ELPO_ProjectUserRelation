using ELPO_ProjectUserRelation.Bussiness.Abstract;
using ELPO_ProjectUserRelation.DataAccess.Abstract;
using ELPO_ProjectUserRelation.Entities;

namespace ELPO_ProjectUserRelation.Bussiness.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="categoryDal"></param>
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        /// <summary>
        /// It gets all categories
        /// </summary>
        /// <returns></returns>
        public List<Category> GetAll()
        {
            return _categoryDal.GetAll().ToList();
        }

        /// <summary>
        /// It gets the category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }
    }
}
