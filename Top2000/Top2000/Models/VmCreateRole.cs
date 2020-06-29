using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Top2000.Models
{
    public class VmCreateRole
    {
        [Required]
        public string RoleName { get; set; }
    }
}