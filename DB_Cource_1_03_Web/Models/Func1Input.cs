using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB_Cource_1_03_Web.Models
{
    public class Func1Input
    {
        public string Section { get; set; }
        public string Group { get; set; }
        public bool? Sex { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Age { get; set; }
    }
}