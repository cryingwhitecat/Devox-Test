using DevoxAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevoxAPI.DataAccess.EntityFramework
{
    /// <summary>
    /// Data Access class for the Activity Type that uses Entity Framework.
    /// </summary>
    public class EFActivityDataProvider : IActivityDataProvider
    {
        public async Task<int> CreateActivityAsync(Activity activity)
        {
            try
            {
                using (var ctx = new DevoxContext())
                {
                    var r = await ctx.Activity.AddAsync(activity);
                    await ctx.SaveChangesAsync();
                    return r.Entity.ActivityId;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void DeleteActivity(int activityID)
        {
            try
            {
                using(var ctx = new DevoxContext())
                {
                    var act = ctx.Activity.FirstOrDefault(x => x.ActivityId == activityID);
                    ctx.Activity.Remove(act);
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Activity GetActivity(int activityID)
        {
            try
            {
                using(var ctx = new DevoxContext())
                {
                    var act = ctx.Activity.FirstOrDefault(x => x.ActivityId == activityID);
                    return act;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Activity> GetAllActivities()
        {
            try 
            {
                using(var ctx = new DevoxContext())
                {
                    return ctx.Activity.ToList();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async void UpdateActivity(Activity activity)
        {
            try
            {
                using (var ctx = new DevoxContext())
                {
                    ctx.Activity.Update(activity);
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
