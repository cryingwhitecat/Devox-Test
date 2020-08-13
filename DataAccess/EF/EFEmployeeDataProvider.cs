using DevoxAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevoxAPI.DataAccess.EntityFramework
{
    /// <summary>
    /// Data Access class for the Employee Type that uses Entity Framework.
    /// </summary>
    public class EFEmployeeDataProvider : IEmployeeDataProvider
    {
        public async Task<int> CreateEmployeeAsync (Employee emp)
        {
            try
            {
                using (var ctx = new DevoxContext())
                {
                    var r = await ctx.AddAsync(emp);
                    await ctx.SaveChangesAsync();
                    return r.Entity.EmployeeId;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async void DeleteEmployee(int empID)
        {
            try
            {
                using (var ctx = new DevoxContext())
                {
                    var emp = ctx.Employee.FirstOrDefault(x => x.EmployeeId == empID);
                    ctx.Employee.Remove(emp);
                    await ctx.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                using (var ctx = new DevoxContext())
                {
                    return ctx.Employee.ToList();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Employee GetEmployee(int empID)
        {
            try
            {
                using (var ctx = new DevoxContext())
                {
                    var emp = ctx.Employee.FirstOrDefault(x => x.EmployeeId == empID);
                    return emp;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async void UpdateEmployee(Employee emp)
        {
            try
            {
                using (var ctx = new DevoxContext())
                {
                    ctx.Employee.Update(emp);
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
