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
    public class CreateActivityTypeController : ControllerBase
    {
        private IActivityTypeDataProvider _dataProvider;
        private LoggerBase _logger;
        public CreateActivityTypeController(IActivityTypeDataProvider dataProvider, LoggerBase logger)
        {
            _dataProvider = dataProvider;
            _logger = logger;
        }
        [HttpPost]
        public async Task<JsonResult> Post([FromBody] ActivityType activityType)
        {
            try
            {
               var id = await  _dataProvider.CreateActivityTypeAsync(activityType);
                _logger.Log("Activity type created successfully. {@ActivityType}", LogLevel.Debug, activityType);
                return new JsonResult(new { status = "Activity type created successfully", ActivityTypeID = id });
            }
            catch(Exception e)
            {
                _logger.Log("Activity type creation failed. \n{ExceptionMessage}\n{ExceptionStackTrace}",
                     LogLevel.Error, e.Message, e.StackTrace);
                return new JsonResult(new { status = "Error occured." });
            }
        }
    }
}
