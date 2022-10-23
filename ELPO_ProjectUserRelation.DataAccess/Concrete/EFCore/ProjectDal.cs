using ELPO_ProjectUserRelation.DataAccess.Abstract;
using ELPO_ProjectUserRelation.Entities.ELPOContextDir;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace ELPO_ProjectUserRelation.DataAccess.Concrete.EFCore
{
    public class ProjectDal : EFCoreGenericRepository<Project, ELPOContext>, IProjectDal
    {
        /// <summary>
        /// It sets users into ProjectUserRelations of the project
        /// </summary>
        /// <param name="users"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private List<Project> SetUsersIntoProject(List<Project> projects, ELPOContext context)
        {
            try
            {
                foreach (Project project in projects)
                {
                    foreach (ProjectUserRelation projectUserRelation in project.ProjectUserRelations)
                    {
                        projectUserRelation.User = context.Users.FirstOrDefault(s => s.Id == projectUserRelation.UserId);
                    }
                }
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            }

            return projects;
        }

        /// <summary>
        /// It gets projects with includings
        /// </summary>
        /// <returns></returns>
        public override List<Project> GetAll()
        {
            List<Project> projects = new List<Project>();

            try
            {
                using (var context = new ELPOContext())
                {
                    projects = context.Projects.Include(i => i.ProjectUserRelations).Include(i => i.Category).ToList();
                    projects = SetUsersIntoProject(projects, context);
                }
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            }

            return projects;
        }

        /// <summary>
        /// It gets the project with including by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Project GetById(int id)
        {
            Project project = new Project();
            using (var context = new ELPOContext())
            {
                try
                {
                    project = context.Projects.Include(i => i.ProjectUserRelations).Include(i => i.Category).FirstOrDefault(s=>s.Id == id);
                }
                catch (Exception ex)
                {
                    new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
                    return null;
                }
            }
            return project;
        }

        /// <summary>
        /// It deletes project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override bool DeleteByResult(Project project)
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
                        foreach (ProjectUserRelation item in project.ProjectUserRelations.ToList())
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
                        //After that We delete Project
                        context.Entry(project).State = EntityState.Deleted;
                        context.Set<Project>().Remove(project);
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
        /// It gets projects with includings by Expression
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override List<Project> GetAllByFilter(Expression<Func<Project, bool>> filter)
        {
            List<Project> projects = new List<Project>();
            try
            {
                using (var context = new ELPOContext())
                {
                    projects = context.Projects.Where(filter).Include(i => i.ProjectUserRelations).Include(i => i.Category).ToList();
                    projects = SetUsersIntoProject(projects, context);
                }
            }
            catch (Exception ex)
            {
                new LogDal().CreateLog(ex.Message, this.GetType().Name, MethodBase.GetCurrentMethod().Name);
            }
            return projects;
        }
    }
}
