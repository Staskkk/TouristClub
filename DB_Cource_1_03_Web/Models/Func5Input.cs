using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB_Cource_1_03_Web.Models
{
    public class Func5Input
    {
        public string Section { get; set; }
        public string Group { get; set; }
        public int? TripCount { get; set; }
        public int? CampingTripId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CampingRouteId { get; set; }
        public string CampingPlace { get; set; }
        public string TouristLevel { get; set; }
    }
}