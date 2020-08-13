using DevoxAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevoxAPI.DataAccess
{
    /// <summary>
    /// Data Access Interface that performs all CRUD operations involving Projects.
    /// </summary>
    public interface IProjectDataProvider
    {
        void UpdateProject(Project p);
        void DeleteProject(int projectID);
        Project GetProject(int projectID);
        IEnumerable<Project> GetAllProjects();
        Task<int> CreateProjectAsync(Project p);
    }
}
