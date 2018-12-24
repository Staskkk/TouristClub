using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB_Cource_1_03_Web.Models
{
    public class Func7Input
    {
        public string TrainerName { get; set; }
        public string Section { get; set; }
        public string ActivityType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}