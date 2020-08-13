using DevoxAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevoxAPI.DataAccess
{
    /// <summary>
    /// Data Access Interface that performs all CRUD operations involving Employee objects.
    /// </summary>
    public interface IEmployeeDataProvider
    {
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(int empID);
        Employee GetEmployee(int empID);
        IEnumerable<Employee> GetAllEmployees();
        Task<int> CreateEmployeeAsync(Employee emp);
    }
}
