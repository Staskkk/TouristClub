//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB_Cource_1_02
{
    using System;
    using System.Collections.Generic;
    
    public partial class CampingRoute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CampingRoute()
        {
            this.CampingRoutePlaceInfoes = new HashSet<CampingRoutePlaceInfo>();
            this.CampingTrips = new HashSet<CampingTrip>();
        }
    
        public int Id { get; set; }
        public int AreaTypeId { get; set; }
        public int DurationDays { get; set; }
        public double LengthKm { get; set; }
        public string Description { get; set; }
    
        public virtual AreaType AreaType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampingRoutePlaceInfo> CampingRoutePlaceInfoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CampingTrip> CampingTrips { get; set; }
    }
}
