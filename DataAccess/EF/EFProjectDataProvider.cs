using DevoxAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevoxAPI.DataAccess.EntityFramework
{
    /// <summary>
    /// Data Access class for the Project Type that uses Entity Framework.
    /// </summary>
    public class EFProjectDataProvider : IProjectDataProvider
    {
        public async Task<int> CreateProjectAsync(Project p)
        {
            try
            {
                using (var ctx = new DevoxContext())
                {
                    var proj = await ctx.Project.AddAsync(p);
                    await ctx.SaveChangesAsync();
                    return proj.Entity.ProjectId;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteProject(int projectID)
        {
            try
            {
                using (var ctx = new DevoxContext())
                {
                    var p = ctx.Project.FirstOrDefault(x => x.ProjectId == projectID);
                    ctx.Remove(p);
                    await ctx.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Project> GetAllProjects()
        {
            try
            {
                using (var ctx = new DevoxContext())
                {
                    return ctx.Project.ToList();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Project GetProject(int projectID)
        {
            try
            {
                using (var ctx = new DevoxContext())
                {
                    var p = ctx.Project.FirstOrDefault(x => x.ProjectId == projectID);
                    return p;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async void UpdateProject(Project p)
        {
            try
            {
                using (var ctx = new DevoxContext())
                {
                    ctx.Project.Update(p);
                    await ctx.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        void IProjectDataProvider.DeleteProject(int projectID)
        {
            throw new NotImplementedException();
        }
    }
}
