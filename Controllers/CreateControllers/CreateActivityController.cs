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
    public class CreateActivityController : ControllerBase
    {
        private IActivityDataProvider _dataProvider;
        private LoggerBase _logger;
        public CreateActivityController(IActivityDataProvider activityDataProvider, LoggerBase logger)
        {
            _dataProvider = activityDataProvider;
            _logger = logger;
        }
        [HttpPost]
        public async Task<JsonResult> Post([FromBody] Activity activity)
        {
            try
            {
                var id = await _dataProvider.CreateActivityAsync(activity);
                _logger.Log("Created new Activity: {@Activity}", LogLevel.Debug, activity);
                return new JsonResult(new { status = "Activity added successfully.", ActivityID = id });
            }
            catch(Exception e)
            {
                _logger.Log("Activity creation failed. \n{ExceptionMessage}\n{ExceptionStackTrace}", 
                    LogLevel.Error, e.Message, e.StackTrace);
                return new JsonResult(new { status = "Error occured." });
            }
        }
    }
}
