using DevoxAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevoxAPI.DataAccess.EntityFramework
{
    /// <summary>
    /// Data Access class for the ActivityType Type that uses Entity Framework.
    /// </summary>
    public class EFActivityTypeDataProvider : IActivityTypeDataProvider
    {
        public async Task<int> CreateActivityTypeAsync(ActivityType type)
        {
            try
            {
                using (var ctx = new DevoxContext())
                {
                    var r = await ctx.ActivityType.AddAsync(type);
                    await ctx.SaveChangesAsync();
                    return r.Entity.ActivityTypeId;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async void DeleteActivityType(int activityTypeID)
        {
            try
            {
                using (var ctx = new DevoxContext())
                {
                    var act = ctx.ActivityType.FirstOrDefault(x => x.ActivityTypeId == activityTypeID);
                    ctx.ActivityType.Remove(act);
                    await ctx.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActivityType GetActivityType(int activityTypeID)
        {
            try
            {
                using (var ctx = new DevoxContext())
                {
                    var act = ctx.ActivityType.FirstOrDefault(x => x.ActivityTypeId == activityTypeID);
                    return act;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async void UpdateActivityType(ActivityType type)
        {
            try
            {
                using (var ctx = new DevoxContext())
                {
                    ctx.Update(type);
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
