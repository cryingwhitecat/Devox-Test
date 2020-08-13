using DevoxAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevoxAPI.DataAccess.EntityFramework
{
    /// <summary>
    /// Data Access class for the ActivityRole Type that uses Entity Framework.
    /// </summary>
    public class EFActivityRolesDataProvider : IActivityRolesDataProvider
    {
        public async Task<int> CreateRoleAsync(Role role)
        {
            try
            {
                using (var ctx = new DevoxContext())
                {
                    var r = await ctx.Role.AddAsync(role);
                    return r.Entity.RoleId;
                    await ctx.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async void DeleteRole(int roleID)
        {
            try
            {
                using (var ctx = new DevoxContext())
                {
                    var role = ctx.Role.FirstOrDefault(x => x.RoleId == roleID);
                    ctx.Remove(role);
                    await ctx.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Role GetRole(int roleID)
        {
            try
            {
                using (var ctx = new DevoxContext())
                {
                    var role = ctx.Role.FirstOrDefault(x => x.RoleId == roleID);
                    return role;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async void UpdateRole(Role role)
        {
            try
            {
                using (var ctx = new DevoxContext())
                {
                    ctx.Role.Update(role);
                    await ctx.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
