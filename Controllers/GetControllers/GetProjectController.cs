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
    public class GetProjectController : ControllerBase
    {
        private IProjectDataProvider _dataProvider;
        private LoggerBase _logger;
        public GetProjectController(IProjectDataProvider dataProvider,LoggerBase logger)
        {
            _dataProvider = dataProvider;
            _logger = logger;
        }
        [HttpGet]
        public Project Get(int id)
        {
            try
            {
                var p = _dataProvider.GetProject(id);
                _logger.Log("Got project by id.\n{@Project}",
                    LogLevel.Debug, p);
                return p;
            }
            catch(Exception e)
            {
                _logger.Log("Project search by id failed. \n{ExceptionMessage}\n{ExceptionStackTrace}",
                    LogLevel.Error, e.Message, e.StackTrace);
                return null;

            }
        }
    }
}
