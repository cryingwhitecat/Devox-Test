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
    public class GetAllActivitiesController : ControllerBase
    {
        private IActivityDataProvider _dataProvider;
        private LoggerBase _logger;
        public GetAllActivitiesController(IActivityDataProvider dataProvider, LoggerBase logger)
        {
            _dataProvider = dataProvider;
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<Activity> Get()
        {
            try
            {
                var act = _dataProvider.GetAllActivities();
                _logger.Log("Activities obtained successfully.", LogLevel.Debug);
                return act;
            }
            catch(Exception e)
            {
                _logger.Log("GetAllActivities failed. \n{ExceptionMessage}\n{ExceptionStackTrace}",
                         LogLevel.Error, e.Message, e.StackTrace);
                return null;
            }
        }
    }
}
