using ELPO_ProjectUserRelation.Entities;

namespace ELPO_ProjectUserRelation.Bussiness.Abstract
{
    public interface IRoleService
    {
        /// <summary>
        /// It gets all roles
        /// </summary>
        /// <returns></returns>
        public List<Role> GetAll();

        /// <summary>
        /// It gets the role by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Role GetById(int id);
    }
}
