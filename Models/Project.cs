using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevoxAPI.Models
{
    public partial class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
