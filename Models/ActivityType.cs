using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevoxAPI.Models
{
    public partial class ActivityType
    {
        public ActivityType()
        {
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActivityTypeId { get; set; }
        [Column(name : "ActivityType")]
        public string ActivityTypeName { get; set; }
    }
}
