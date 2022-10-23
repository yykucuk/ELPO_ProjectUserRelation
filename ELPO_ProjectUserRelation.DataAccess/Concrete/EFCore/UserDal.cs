using ELPO_ProjectUserRelation.DataAccess.Abstract;
using ELPO_ProjectUserRelation.Entities.ELPOContextDir;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace ELPO_ProjectUserRelation.DataAccess.Concrete.EFCore
{
    public class UserDal : EFCoreGenericRepository<User, ELPOContext>, IUserDal
    {
        /// <summary>
        /// It sets projects into ProjectUserRelations of the user
        /// </summary>
        /// <param name="users"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private List<User> SetProjectsIntoUser(List<User> users, ELPOContext context)
        {
            try
            {
                foreach (User user in users)
                {
                    foreach (ProjectUserRelation projectUserRelation in user.ProjectUserRelations)
                    {
                        projectUserRelation.Project = context.Projects.FirstOrDefault(s => s.Id == projectUserRelation.ProjectId);
                    }
                }
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            }

            return users;
        }

        /// <summary>
        /// It gets Users with including projects
        /// </summary>
        /// <returns></returns>
        public override List<User> GetAll()
        {
            List<User> users = new List<User>();

            try
            {
                using (var context = new ELPOContext())
                {
                    users = context.Users.Include(i => i.ProjectUserRelations).Include(i=>i.Role).ToList();
                    users = SetProjectsIntoUser(users, context);
                }
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            }

            return users;
        }

        /// <summary>
        /// It gets the User with including ProjectUserRelations by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override User GetById(int id)
        {
            User user = new User();

            try
            {
                using (var context = new ELPOContext())
                {
                    user = context.Users.Include(i => i.ProjectUserRelations).FirstOrDefault(s=>s.Id == id);
                }
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            }

            return user;
        }

        /// <summary>
        /// It deletes user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override bool DeleteByResult(User user)
        {
            int result = 0;
            using (var context = new ELPOContext())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //First all of we need to delete ProjectUserRelation rows, thus we take all ProjectUserRelation with ProjectUserRelationId
                        List<ProjectUserRelation> projectUserRelations = new List<ProjectUserRelation>();
                        foreach (ProjectUserRelation item in user.ProjectUserRelations.ToList())
                        {
                            ProjectUserRelation projectUserRelation = new ProjectUserRelation();
                            projectUserRelation = context.ProjectUserRelations.FirstOrDefault(s => s.Id == item.Id);
                            projectUserRelations.Add(projectUserRelation);
                        }
                        //We delete all ProjectUserRelation of selected Project
                        foreach (var item in projectUserRelations)
                        {
                            context.Entry(item).State = EntityState.Deleted;
                            context.Set<ProjectUserRelation>().Remove(item);
                            context.SaveChanges();
                        }
                        //After that We delete User
                        context.Entry(user).State = EntityState.Deleted;
                        context.Set<User>().Remove(user);
                        result = context.SaveChanges();

                        dbContextTransaction.Commit();
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// It gets Users with includings by Expression
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override List<User> GetAllByFilter(Expression<Func<User, bool>> filter)
        {
            List<User> users = new List<User>();

            try
            {
                using (var context = new ELPOContext())
                {
                    users = context.Users.Where(filter).Include(i => i.ProjectUserRelations).Include(i => i.Role).ToList();
                    users = SetProjectsIntoUser(users, context);
                }
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            }

            return users;
        }
    }
}
