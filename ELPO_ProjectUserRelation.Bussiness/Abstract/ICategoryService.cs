using ELPO_ProjectUserRelation.Entities;

namespace ELPO_ProjectUserRelation.Bussiness.Abstract
{
    public interface ICategoryService
    {
        /// <summary>
        /// It gets all categories
        /// </summary>
        /// <returns></returns>
        public List<Category> GetAll();

        /// <summary>
        /// It gets the category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Category GetById(int id);
    }
}
