using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Data.Repository
{
    public class Course : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ModuleID { get; set; }
    }
}
