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
    public class DeleteProjectController : ControllerBase
    {
        private IProjectDataProvider _dataProvider;
        private LoggerBase _logger;
        public DeleteProjectController(IProjectDataProvider dataProvider, LoggerBase logger)
        {
            _dataProvider = dataProvider;
            _logger = logger;
        }
        [HttpPost]
        public JsonResult DeleteProject(int? id)
        {
            try
            {
                _dataProvider.DeleteProject((int)id);
                _logger.Log("Project with ID {ProjectID} deleted successfully.",
                     LogLevel.Debug, id);
                return new JsonResult(new { status = "Project deleted successfully." });
            }
            catch(Exception e)
            {
                _logger.Log("Project deletion failed. \n{ExceptionMessage}\n{ExceptionStackTrace}",
                        LogLevel.Error, e.Message, e.StackTrace);
                return new JsonResult(new { status = "Error occured." });
            }
            
        }
    }
}
