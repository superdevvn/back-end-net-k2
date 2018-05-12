using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Models;
using Repositories;
using Repositories.Common;

namespace Services
{
    public class RoleService
    {
        RoleRepository roleRepository = new RoleRepository();
        UserService userService = new UserService();

        public PagingResult GetList(string orderBy, string orderDirection, int page, int pageSize, string code, string date)
        {
            string whereClause = "1>0";
            if (!string.IsNullOrWhiteSpace(code)) whereClause += " AND Code.Contains(\"" + code + "\")"; //StartWith, EndWith , ==
            if(!string.IsNullOrWhiteSpace(date))
            {
                DateTime dt = DateTime.Parse(date);
                whereClause += string.Format(" AND CreatedDate >= DateTime({0},{1},{2})", dt.Year, dt.Month, dt.Day);
                dt = dt.AddDays(1);
                whereClause += string.Format(" AND CreatedDate < DateTime({0},{1},{2})", dt.Year, dt.Month, dt.Day);
            }
            return roleRepository.GetList(orderBy, orderDirection, page, pageSize, whereClause);
        }

        public IEnumerable GetList()
        {
            return roleRepository.GetList();
        }

        public Role Get(Guid id)
        {
            var role = roleRepository.Get(id);
            if (role == null) throw new Exception("ROLE_INCORRECT_ID");
            return role;
        }

        public Role Save(Role role)
        {
            if (string.IsNullOrWhiteSpace(role.Code) || role.Code.Length > 15) throw new Exception("ROLE_INVALID_CODE");
            if (role.Id == Guid.Empty)
            {
                if (roleRepository.HasCode(role.Code)) throw new Exception("ROLE_DUPLICATE_CODE");
                return roleRepository.Create(role, userService.GetCurrrentUser().Id);
            }
            else
            {
                if(roleRepository.HasCode(role.Id, role.Code)) throw new Exception("ROLE_DUPLICATE_CODE");
                return roleRepository.Update(role, userService.GetCurrrentUser().Id);
            }
        }

        public void Delete(Guid id)
        {
            var role = roleRepository.Get(id);
            if (role == null) throw new Exception("ROLE_INCORRECT_ID");
            roleRepository.Delete(id);
        }
    }
}
