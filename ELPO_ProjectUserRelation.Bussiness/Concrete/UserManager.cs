using ELPO_ProjectUserRelation.Bussiness.Abstract;
using ELPO_ProjectUserRelation.DataAccess.Abstract;
using ELPO_ProjectUserRelation.Entities;

namespace ELPO_ProjectUserRelation.Bussiness.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userDal"></param>
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        /// <summary>
        /// It gets all users
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll()
        {
            return _userDal.GetAll().ToList();
        }

        /// <summary>
        /// It gets the user by name and password
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public User GetUserByNameAndPassword(string name, string password)
        {
            return _userDal.GetOne(s => s.Name == name & s.Password == password);
        }

        /// <summary>
        /// It deletes user by giving Id
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(int id)
        {
            User user = _userDal.GetById(id);
            return _userDal.DeleteByResult(user);
        }
    }
}
