using ELPO_ProjectUserRelation.DataAccess.Abstract;
using ELPO_ProjectUserRelation.Entities;

namespace ELPO_ProjectUserRelation.DataAccess.Concrete.EFCore
{
    public class LogDal : EFCoreGenericRepository<Log, ELPO_DbContext>, ILogDal
    {
        /// <summary>
        /// It record logs to ms sql
        /// </summary>
        /// <param name="message"></param>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        public void CreateLog(string message, string className, string methodName)
        {
            Log log = new Log();
            log.Message = message;
            log.ClassName = className;
            log.MethodName = methodName;
            log.DateTime = DateTime.Now;

            using (var context = new ELPO_DbContext())
            {
                context.Set<Log>().Add(log);
                context.SaveChanges();
            }
        }
    }
}
