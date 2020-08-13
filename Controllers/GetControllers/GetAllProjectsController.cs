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
    public class GetAllProjectsController : ControllerBase
    {
        private IProjectDataProvider _dataProvider;
        private LoggerBase _logger;
        public GetAllProjectsController(IProjectDataProvider dataProvider, LoggerBase logger)
        {
            _dataProvider = dataProvider;
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<Project> Get()
        {
            try
            {
                var allp = _dataProvider.GetAllProjects();
                _logger.Log("Got all projects successfully.",
                    LogLevel.Debug);
                return allp;
            }
            catch (Exception e)
            {
                _logger.Log("GetAllProjects failed. \n{ExceptionMessage}\n{ExceptionStackTrace}",
                    LogLevel.Error, e.Message, e.StackTrace);
                return null;
            }
        }
    }
}
