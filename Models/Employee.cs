using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevoxAPI.Models
{
    public partial class   Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public DateTime Dob { get; set; }

    }
}
