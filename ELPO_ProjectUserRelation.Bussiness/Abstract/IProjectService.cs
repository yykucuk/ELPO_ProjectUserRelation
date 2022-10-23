using ELPO_ProjectUserRelation.Entities.ELPOContextDir;

namespace ELPO_ProjectUserRelation.Bussiness.Abstract
{
    public interface IProjectService
    {
        /// <summary>
        /// It gets all projects
        /// </summary>
        /// <returns></returns>
        public List<Project> GetAll();

        /// <summary>
        /// It creates the new project
        /// </summary>
        /// <param name="name"></param>
        /// <param name="icon"></param>
        /// <param name="description"></param>
        /// <param name="progress"></param>
        /// <returns></returns>
        public bool CreateByResult(string name, string icon, string description, int progress);

        /// <summary>
        /// It deletes the project by giving Id
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteByResult(int id);

        /// <summary>
        /// It gets projects with including Users by UserId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Project> GetProjectsByUserId(int id);

    }
}
