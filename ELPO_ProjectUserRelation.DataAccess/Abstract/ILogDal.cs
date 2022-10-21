using ELPO_ProjectUserRelation.Entities;

namespace ELPO_ProjectUserRelation.DataAccess.Abstract
{
    public interface ILogDal : IRepository<Log>
    {
        void CreateLog(string message, string className, string methodName);
    }
}
