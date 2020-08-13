using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevoxAPI.Models
{
    public partial class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        public string RoleName { get; set; }

    }
}
