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
    public class UpdateProjectController : ControllerBase
    {
        private IProjectDataProvider _dataProvider;
        private LoggerBase _logger;
        public UpdateProjectController(IProjectDataProvider dataProvider, LoggerBase logger)
        {
            _dataProvider = dataProvider;
            _logger = logger;
        }
        [HttpPost]
        public JsonResult Post([FromBody] Project p)
        {
            try
            {
                _dataProvider.UpdateProject(p);
                _logger.Log("Project updated successfully. {@Project}",
                        LogLevel.Debug, p);
                return new JsonResult(new { status = "Project updated successfully." });
            }
            catch(Exception e)
            {
                _logger.Log("Project update failed. \n{ExceptionMessage}\n{ExceptionStackTrace}",
                    LogLevel.Error, e.Message, e.StackTrace);
                return new JsonResult(new { status = "Error occured." });
            }
            
        }
    }
}
