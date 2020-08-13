using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevoxAPI.Models
{
    /// <summary>
    /// Model for the GetTrackingTimeController
    /// </summary>
    public class GetTrackingTimeModel
    {
        /// <summary>
        /// Employee ID.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Activity Date.
        /// </summary>
        public DateTime Date { get; set; }
    }
}
