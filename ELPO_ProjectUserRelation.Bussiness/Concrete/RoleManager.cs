﻿using ELPO_ProjectUserRelation.Bussiness.Abstract;
using ELPO_ProjectUserRelation.DataAccess.Abstract;
using ELPO_ProjectUserRelation.Entities.ELPOContextDir;

namespace ELPO_ProjectUserRelation.Bussiness.Concrete
{
    public class RoleManager : IRoleService
    {
        private IRoleDal _roleDal;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="roleDal"></param>
        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        /// <summary>
        /// It gets all roles
        /// </summary>
        /// <returns></returns>
        public List<Role> GetAll()
        {
            return _roleDal.GetAll().ToList();
        }

        /// <summary>
        /// It gets the role by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Role GetById(int id)
        {
            return _roleDal.GetById(id);
        }
    }
}
