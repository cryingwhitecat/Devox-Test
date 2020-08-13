using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevoxAPI.DataAccess;
using DevoxAPI.Loggers;
using DevoxAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevoxAPI.Controllers.GetControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllEmployeesController : ControllerBase
    {
        private IEmployeeDataProvider _dataProvider;
        private LoggerBase _logger;
        public GetAllEmployeesController(IEmployeeDataProvider dataProvider, LoggerBase logger)
        {
            _dataProvider = dataProvider;
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            try
            {
                var allEmp = _dataProvider.GetAllEmployees();
                _logger.Log("Employees list obtained successfully.", LogLevel.Debug);
                return allEmp;
            }
            catch(Exception e)
            {
                _logger.Log("Could not obtain employees list. Error Message: \n{ErrorMessage}\n{ErrorStackTrace}", 
                    LogLevel.Error, e.Message, e.StackTrace);
                return null;
            }
        }
    }
}
