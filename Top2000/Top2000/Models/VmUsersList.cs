using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Top2000.Models
{
    public class VmUsersList
    {

        public string userId { get; set; }
        public string roleId { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public IList<string> RoleUser { get; set; }
        public string button { get; set; }
        
    }
}