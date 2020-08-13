using DevoxAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevoxAPI.DataAccess
{
    /// <summary>
    /// Data Access Interface that performs all CRUD operations involving ActivityRole objects.
    /// </summary>
    public interface IActivityRolesDataProvider
    {
        void UpdateRole(Role role);
        void DeleteRole(int roleID);
        Role GetRole(int roleID);
        Task<int> CreateRoleAsync(Role role);
    }
}
