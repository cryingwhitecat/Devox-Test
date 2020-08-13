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
    public class CreateProjectController : ControllerBase
    {
        private IProjectDataProvider _dataProvider;
        private LoggerBase _logger;
        public CreateProjectController(IProjectDataProvider dataProvider, LoggerBase logger)
        {
            _dataProvider = dataProvider;
            _logger = logger;
        }
        [HttpPost]
        public async Task<JsonResult> Post([FromBody] Project p)
        {
            try 
            {
               var id = await  _dataProvider.CreateProjectAsync(p);
                _logger.Log("Project created successfully. \n{@Project}",
                    LogLevel.Debug, p);
                return new JsonResult(new { status = "Project added successfully.", ProjectID = id });
            }
            catch(Exception e)
            {
                _logger.Log("Project creation failed. \n{ExceptionMessage}\n{ExceptionStackTrace}",
                         LogLevel.Error, e.Message, e.StackTrace);
                return new JsonResult(new { status = "Error occured." });
            }
            
        }
    }
}
