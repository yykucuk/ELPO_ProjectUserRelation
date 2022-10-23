using ELPO_ProjectUserRelation.Bussiness.Abstract;
using ELPO_ProjectUserRelation.DataAccess.Abstract;
using ELPO_ProjectUserRelation.Entities.ELPOContextDir;

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
        /// It creates the new project
        /// </summary>
        /// <param name="name"></param>
        /// <param name="icon"></param>
        /// <param name="description"></param>
        /// <param name="progress"></param>
        /// <returns></returns>
        public bool CreateByResult(string name, string icon, string description, int progress)
        {
            Project project = new Project();
            project.Name = name;
            project.IconUrl = icon;
            project.Description = description;
            project.Progress = progress;
            project.CategoryId = 1;

            return _projectDal.CreateByResult(project);
        }

        /// <summary>
        /// It deletes the project by giving Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteByResult(int id)
        {
            //_db.Projects.Remove(_projectDal.GetById(id));
            //return _db.SaveChanges() > 0;
            Project project = _projectDal.GetById(id);
            return _projectDal.DeleteByResult(project);
        }

        /// <summary>
        /// It gets projects with includings
        /// </summary>
        /// <returns></returns>
        public List<Project> GetAll()
        {
            return _projectDal.GetAll();
        }

        /// <summary>
        /// It gets projects with including Users by UserId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Project> GetProjectsByUserId(int id)
        {
            return _projectDal.GetAllByFilter(s=>s.Id == id);
        }
    }
}
