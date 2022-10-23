
using ELPO_ProjectUserRelation.Bussiness.Abstract;
using ELPO_ProjectUserRelation.DataAccess.Abstract;
using ELPO_ProjectUserRelation.Entities.ELPOContextDir;

namespace ELPO_ProjectUserRelation.Bussiness.Concrete
{
    public class ProjectUserRelationManager : IProjectUserRelationService
    {
        private IProjectUserRelationDal _projectUserRelationDal;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="projectUserRelationDal"></param>
        public ProjectUserRelationManager(IProjectUserRelationDal projectUserRelationDal)
        {
            _projectUserRelationDal = projectUserRelationDal;
        }

        /// <summary>
        /// It deletes ProjectUserRelation by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteByResult(int id)
        {
            ProjectUserRelation projectUserRelation = _projectUserRelationDal.GetById(id);
            return _projectUserRelationDal.DeleteByResult(projectUserRelation);
        }
    }
}
