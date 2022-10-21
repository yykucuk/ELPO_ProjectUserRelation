using ELPO_ProjectUserRelation.Bussiness.Abstract;
using ELPO_ProjectUserRelation.DataAccess.Abstract;
using ELPO_ProjectUserRelation.Entities;

namespace ELPO_ProjectUserRelation.Bussiness.Concrete
{
    public class ProjectManager : IProjectService
    {
        private IProjectDal _projectDal;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="projectDal"></param>
        public ProjectManager(IProjectDal projectDal)
        {
            _projectDal = projectDal;
        }

        /// <summary>
        /// It gets all projects
        /// </summary>
        /// <returns></returns>
        public List<Project> GetAll()
        {
            return _projectDal.GetAll().ToList();
        }

        /// <summary>
        /// It creates the new project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public bool Create(Project project)
        {
            return _projectDal.CreateByResult(project);
        }

        /// <summary>
        /// It deletes the project by giving Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            Project project = _projectDal.GetById(id);
            return _projectDal.DeleteByResult(project);
        }
    }
}
