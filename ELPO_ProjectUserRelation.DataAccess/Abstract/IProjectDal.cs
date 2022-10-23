using ELPO_ProjectUserRelation.Entities.ELPOContextDir;
using System.Linq.Expressions;

namespace ELPO_ProjectUserRelation.DataAccess.Abstract
{
    public interface IProjectDal : IRepository<Project>
    {
        /// <summary>
        /// It gets projects with includings
        /// </summary>
        /// <returns></returns>
        public List<Project> GetAll();

        /// <summary>
        /// It gets projects with includings by Expression
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<Project> GetAllByFilter(Expression<Func<Project, bool>> filter);

        /// <summary>
        /// It deletes project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteByResult(Project project);

        /// <summary>
        /// It gets the project with including by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Project GetById(int id);
    }
}
