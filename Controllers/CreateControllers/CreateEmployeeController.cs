using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevoxAPI.DataAccess;
using DevoxAPI.Loggers;
using DevoxAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevoxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateEmployeeController : ControllerBase
    {
        private IEmployeeDataProvider _dataProvider;
        private LoggerBase _logger;
        
        public CreateEmployeeController(IEmployeeDataProvider dataProvider, LoggerBase logger)
        {
            _dataProvider = dataProvider;
            _logger = logger;
        }
        [HttpPost]
        public async Task<JsonResult> Post([FromBody] Employee emp)
        {
            try 
            {
                var id = await _dataProvider.CreateEmployeeAsync(emp);
                _logger.Log("Employee Created Successfully. \n{@Employee}",
                    LogLevel.Debug, emp);
                return new JsonResult(new { status = "Employee created successfully",EmployeeID = id });
            }
            catch(Exception e)
            {
                _logger.Log("Employee creation failed. \n{ExceptionMessage}\n{ExceptionStackTrace}",
                        LogLevel.Error, e.Message, e.StackTrace);
                return new JsonResult(new { status = "Error occured" });
            }
        }
    }
}
