using ELPO_ProjectUserRelation.Entities;

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
        /// <param name="project"></param>
        /// <returns></returns>
        public bool Create(Project project);

        /// <summary>
        /// It deletes the project by giving Id
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(int id);


    }
}
