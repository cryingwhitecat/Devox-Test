using DevoxAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevoxAPI.DataAccess
{
    /// <summary>
    /// Data Access Interface that performs all CRUD operations involving Activity objects.
    /// </summary>
    public interface IActivityDataProvider
    {
        void DeleteActivity(int activityID);
        void UpdateActivity(Activity activity);
        Activity GetActivity(int activityID);
        IEnumerable<Activity> GetAllActivities();
        Task<int> CreateActivityAsync(Activity activity);
    }
}
