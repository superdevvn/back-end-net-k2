using System;
using System.Collections;
using System.Collections.Generic;
using Models;
using Repositories;

namespace Services
{
    public class RoleService
    {
        RoleRepository roleRepository = new RoleRepository();
        UserService userService = new UserService();
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
                role.Id = Guid.NewGuid();
                role.CreatedDate = DateTime.Now;
                role.CreatedBy = userService.GetCurrrentUser().Id;
                role.ModifiedDate = DateTime.Now;
                role.ModifiedBy = userService.GetCurrrentUser().Id;
                return roleRepository.Create(role);
            }
            else
            {
                if(roleRepository.HasCode(role.Id, role.Code)) throw new Exception("ROLE_DUPLICATE_CODE");
                role.ModifiedDate = DateTime.Now;
                role.ModifiedBy = userService.GetCurrrentUser().Id;
                return roleRepository.Update(role);
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
