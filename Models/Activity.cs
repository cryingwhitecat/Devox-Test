using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevoxAPI.Models
{
    public partial class Activity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActivityId { get; set; }
        public DateTime ActivityDate { get; set; }
        public double DurationInHours { get; set; }
        public int ActivityTypeID { get; set; }
        public int EmployeeRoleID { get; set; }
        public int EmployeeID { get; set; }
    }
}
