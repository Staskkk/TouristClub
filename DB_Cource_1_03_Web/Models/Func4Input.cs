using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB_Cource_1_03_Web.Models
{
    public class Func4Input
    {
        public string Group { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
    }
}