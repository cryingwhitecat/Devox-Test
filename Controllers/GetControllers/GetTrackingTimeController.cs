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
    public class GetTrackingTimeController : ControllerBase
    {
        private IActivityDataProvider _dataProvider;
        private LoggerBase _logger;
        public GetTrackingTimeController(IActivityDataProvider dataProvider, LoggerBase logger)
        {
            _dataProvider = dataProvider;
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<Activity> Get([FromBody] GetTrackingTimeModel model)
        {
            try
            {
                var all_act = _dataProvider.GetAllActivities().Where(x => x.EmployeeID == model.ID && x.ActivityDate == model.Date);
                _logger.Log("GET TRACKING TIME: 200 OK, {numAct} ACTIVITIES FOUND.", LogLevel.Debug, all_act.Count());
                return all_act;
            }
            catch(Exception e)
            {
                _logger.Log("Error occured. Exception: \n{ExceptionMessage}\n{ExceptionStackTrace}",LogLevel.Error, e.Message, e.StackTrace);
                return null;
            }
        }

    }

}
