using ELPO_ProjectUserRelation.Entities;

namespace ELPO_ProjectUserRelation.Bussiness.Abstract
{
    public interface IUserService
    {
        /// <summary>
        /// It gets User by Name and Password
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUserByNameAndPassword(string name, string password);

        /// <summary>
        /// It gets all users
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll();

        /// <summary>
        /// It deletes the user by giving Id
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(int id);
    }
}
