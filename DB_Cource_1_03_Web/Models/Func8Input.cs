using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB_Cource_1_03_Web.Models
{
    public class Func8Input
    {
        public string Section { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string InstructorName { get; set; }
        public int? GroupCount { get; set; }
    }
}