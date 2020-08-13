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
    public class GetTrackingTimeByWeekController : ControllerBase
    {
        private IActivityDataProvider _dataProvider;
        private LoggerBase _logger;
        public GetTrackingTimeByWeekController(IActivityDataProvider dataProvider, LoggerBase logger)
        {
            _dataProvider = dataProvider;
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<Activity> GetByWeek(int year, int weekID)
        {
            try
            {
                DateTime dt = DateTime.Parse($"{year}-01-01");
                var timespanStart = dt + TimeSpan.FromDays(7 * (weekID - 1));
                var timespanEnd = dt + TimeSpan.FromDays((7 * weekID) - 1); 
                _logger.Log("GetByWeek executed successfully.",
                        LogLevel.Debug);
                return _dataProvider.GetAllActivities().Where(x => x.ActivityDate >= timespanStart && x.ActivityDate <= timespanEnd);
            }
            catch(Exception e)
            {
                _logger.Log("GetAllProjects failed. \n{ExceptionMessage}\n{ExceptionStackTrace}",
                         LogLevel.Error, e.Message, e.StackTrace);
                return null;
            }
        }
    }
}
