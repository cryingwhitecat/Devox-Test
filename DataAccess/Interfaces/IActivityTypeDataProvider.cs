using DevoxAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevoxAPI.DataAccess
{
    /// <summary>
    /// Data Access Interface that performs all CRUD operations involving ActivityType objects.
    /// </summary>
    public interface IActivityTypeDataProvider
    {
        void UpdateActivityType(ActivityType type);
        void DeleteActivityType(int activityTypeID);
        ActivityType GetActivityType(int activityTypeID);
        Task<int> CreateActivityTypeAsync(ActivityType type);
    }
}
