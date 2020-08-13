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
    public class CreateRoleController : ControllerBase
    {
        private IActivityRolesDataProvider _dataProvider;
        private LoggerBase _logger;
        public CreateRoleController(IActivityRolesDataProvider dataProvider, LoggerBase logger)
        {
            _dataProvider = dataProvider;
            _logger = logger;
        }
        [HttpPost]
        public async Task<JsonResult> Post([FromBody] Role role)
        {
            try
            {
                var id = _dataProvider.CreateRoleAsync(role);
                _logger.Log("Role created successfully. \n{@Role}",
                    LogLevel.Debug, role);
                return new JsonResult(new { status = "Role added successfully.", RoleID = id });
            }
            catch(Exception e)
            {
                _logger.Log("Role creation failed. \n{ExceptionMessage}\n{ExceptionStackTrace}",
                    LogLevel.Error, e.Message, e.StackTrace);
                return new JsonResult(new { status = "Error occured." });
            }
        }
    }
}
