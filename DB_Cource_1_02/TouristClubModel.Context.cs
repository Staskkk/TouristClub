﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class sp19TourClubEntities : DbContext
    {
        public sp19TourClubEntities()
            : base("name=sp19TourClubEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ActivityType> ActivityTypes { get; set; }
        public virtual DbSet<AreaType> AreaTypes { get; set; }
        public virtual DbSet<CampingPlace> CampingPlaces { get; set; }
        public virtual DbSet<CampingRoutePlaceInfo> CampingRoutePlaceInfoes { get; set; }
        public virtual DbSet<CampingRoute> CampingRoutes { get; set; }
        public virtual DbSet<CampingTrip> CampingTrips { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<DayOfWeek> DayOfWeeks { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<TouristAssigment> TouristAssigments { get; set; }
        public virtual DbSet<TouristCampingTripInfo> TouristCampingTripInfoes { get; set; }
        public virtual DbSet<TouristCompetitionInfo> TouristCompetitionInfoes { get; set; }
        public virtual DbSet<TouristGroupInfo> TouristGroupInfoes { get; set; }
        public virtual DbSet<TouristLevel> TouristLevels { get; set; }
        public virtual DbSet<TouristPost> TouristPosts { get; set; }
        public virtual DbSet<Tourist> Tourists { get; set; }
        public virtual DbSet<Training> Trainings { get; set; }
        public virtual DbSet<TripRecord> TripRecords { get; set; }
    
        [DbFunction("sp19TourClubEntities", "func1")]
        public virtual IQueryable<func1_Result> func1(string section, string group, Nullable<bool> sex, Nullable<System.DateTime> birthDate, Nullable<int> age)
        {
            var sectionParameter = section != null ?
                new ObjectParameter("section", section) :
                new ObjectParameter("section", typeof(string));
    
            var groupParameter = group != null ?
                new ObjectParameter("group", group) :
                new ObjectParameter("group", typeof(string));
    
            var sexParameter = sex.HasValue ?
                new ObjectParameter("sex", sex) :
                new ObjectParameter("sex", typeof(bool));
    
            var birthDateParameter = birthDate.HasValue ?
                new ObjectParameter("birthDate", birthDate) :
                new ObjectParameter("birthDate", typeof(System.DateTime));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("age", age) :
                new ObjectParameter("age", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<func1_Result>("[sp19TourClubEntities].[func1](@section, @group, @sex, @birthDate, @age)", sectionParameter, groupParameter, sexParameter, birthDateParameter, ageParameter);
        }
    
        [DbFunction("sp19TourClubEntities", "func10")]
        public virtual IQueryable<func10_Result> func10(string section, string group, string allowedTripActivityType)
        {
            var sectionParameter = section != null ?
                new ObjectParameter("section", section) :
                new ObjectParameter("section", typeof(string));
    
            var groupParameter = group != null ?
                new ObjectParameter("group", group) :
                new ObjectParameter("group", typeof(string));
    
            var allowedTripActivityTypeParameter = allowedTripActivityType != null ?
                new ObjectParameter("allowedTripActivityType", allowedTripActivityType) :
                new ObjectParameter("allowedTripActivityType", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<func10_Result>("[sp19TourClubEntities].[func10](@section, @group, @allowedTripActivityType)", sectionParameter, groupParameter, allowedTripActivityTypeParameter);
        }
    
        [DbFunction("sp19TourClubEntities", "func11")]
        public virtual IQueryable<func11_Result> func11(Nullable<bool> isInstructorTrainer, string instructorLevel, Nullable<int> campingTripsCount, Nullable<int> campingTripId, Nullable<int> campingRouteId, string campingPlace)
        {
            var isInstructorTrainerParameter = isInstructorTrainer.HasValue ?
                new ObjectParameter("isInstructorTrainer", isInstructorTrainer) :
                new ObjectParameter("isInstructorTrainer", typeof(bool));
    
            var instructorLevelParameter = instructorLevel != null ?
                new ObjectParameter("instructorLevel", instructorLevel) :
                new ObjectParameter("instructorLevel", typeof(string));
    
            var campingTripsCountParameter = campingTripsCount.HasValue ?
                new ObjectParameter("campingTripsCount", campingTripsCount) :
                new ObjectParameter("campingTripsCount", typeof(int));
    
            var campingTripIdParameter = campingTripId.HasValue ?
                new ObjectParameter("campingTripId", campingTripId) :
                new ObjectParameter("campingTripId", typeof(int));
    
            var campingRouteIdParameter = campingRouteId.HasValue ?
                new ObjectParameter("campingRouteId", campingRouteId) :
                new ObjectParameter("campingRouteId", typeof(int));
    
            var campingPlaceParameter = campingPlace != null ?
                new ObjectParameter("campingPlace", campingPlace) :
                new ObjectParameter("campingPlace", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<func11_Result>("[sp19TourClubEntities].[func11](@isInstructorTrainer, @instructorLevel, @campingTripsCount, @campingTripId, @campingRouteId, @campingPlace)", isInstructorTrainerParameter, instructorLevelParameter, campingTripsCountParameter, campingTripIdParameter, campingRouteIdParameter, campingPlaceParameter);
        }
    
        [DbFunction("sp19TourClubEntities", "func12")]
        public virtual IQueryable<func12_Result> func12(string section, string group)
        {
            var sectionParameter = section != null ?
                new ObjectParameter("section", section) :
                new ObjectParameter("section", typeof(string));
    
            var groupParameter = group != null ?
                new ObjectParameter("group", group) :
                new ObjectParameter("group", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<func12_Result>("[sp19TourClubEntities].[func12](@section, @group)", sectionParameter, groupParameter);
        }
    
        [DbFunction("sp19TourClubEntities", "func13")]
        public virtual IQueryable<func13_Result> func13(string section, string group, Nullable<int> routeId)
        {
            var sectionParameter = section != null ?
                new ObjectParameter("section", section) :
                new ObjectParameter("section", typeof(string));
    
            var groupParameter = group != null ?
                new ObjectParameter("group", group) :
                new ObjectParameter("group", typeof(string));
    
            var routeIdParameter = routeId.HasValue ?
                new ObjectParameter("routeId", routeId) :
                new ObjectParameter("routeId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<func13_Result>("[sp19TourClubEntities].[func13](@section, @group, @routeId)", sectionParameter, groupParameter, routeIdParameter);
        }
    
        [DbFunction("sp19TourClubEntities", "func2")]
        public virtual IQueryable<func2_Result> func2(string section, Nullable<bool> sex, Nullable<int> age, string specActivity)
        {
            var sectionParameter = section != null ?
                new ObjectParameter("section", section) :
                new ObjectParameter("section", typeof(string));
    
            var sexParameter = sex.HasValue ?
                new ObjectParameter("sex", sex) :
                new ObjectParameter("sex", typeof(bool));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("age", age) :
                new ObjectParameter("age", typeof(int));
    
            var specActivityParameter = specActivity != null ?
                new ObjectParameter("specActivity", specActivity) :
                new ObjectParameter("specActivity", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<func2_Result>("[sp19TourClubEntities].[func2](@section, @sex, @age, @specActivity)", sectionParameter, sexParameter, ageParameter, specActivityParameter);
        }
    
        [DbFunction("sp19TourClubEntities", "func3")]
        public virtual IQueryable<func3_Result> func3(string section)
        {
            var sectionParameter = section != null ?
                new ObjectParameter("section", section) :
                new ObjectParameter("section", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<func3_Result>("[sp19TourClubEntities].[func3](@section)", sectionParameter);
        }
    
        [DbFunction("sp19TourClubEntities", "func4")]
        public virtual IQueryable<func4_Result> func4(string group, Nullable<System.DateTime> date, Nullable<System.TimeSpan> startTime, Nullable<System.TimeSpan> endTime)
        {
            var groupParameter = group != null ?
                new ObjectParameter("group", group) :
                new ObjectParameter("group", typeof(string));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            var startTimeParameter = startTime.HasValue ?
                new ObjectParameter("startTime", startTime) :
                new ObjectParameter("startTime", typeof(System.TimeSpan));
    
            var endTimeParameter = endTime.HasValue ?
                new ObjectParameter("endTime", endTime) :
                new ObjectParameter("endTime", typeof(System.TimeSpan));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<func4_Result>("[sp19TourClubEntities].[func4](@group, @date, @startTime, @endTime)", groupParameter, dateParameter, startTimeParameter, endTimeParameter);
        }
    
        [DbFunction("sp19TourClubEntities", "func5")]
        public virtual IQueryable<func5_Result> func5(string section, string group, Nullable<int> tripCount, Nullable<int> campingTripId, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, Nullable<int> campingRouteId, string campingPlace, string touristLevel)
        {
            var sectionParameter = section != null ?
                new ObjectParameter("section", section) :
                new ObjectParameter("section", typeof(string));
    
            var groupParameter = group != null ?
                new ObjectParameter("group", group) :
                new ObjectParameter("group", typeof(string));
    
            var tripCountParameter = tripCount.HasValue ?
                new ObjectParameter("tripCount", tripCount) :
                new ObjectParameter("tripCount", typeof(int));
    
            var campingTripIdParameter = campingTripId.HasValue ?
                new ObjectParameter("campingTripId", campingTripId) :
                new ObjectParameter("campingTripId", typeof(int));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("startDate", startDate) :
                new ObjectParameter("startDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("endDate", endDate) :
                new ObjectParameter("endDate", typeof(System.DateTime));
    
            var campingRouteIdParameter = campingRouteId.HasValue ?
                new ObjectParameter("campingRouteId", campingRouteId) :
                new ObjectParameter("campingRouteId", typeof(int));
    
            var campingPlaceParameter = campingPlace != null ?
                new ObjectParameter("campingPlace", campingPlace) :
                new ObjectParameter("campingPlace", typeof(string));
    
            var touristLevelParameter = touristLevel != null ?
                new ObjectParameter("touristLevel", touristLevel) :
                new ObjectParameter("touristLevel", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<func5_Result>("[sp19TourClubEntities].[func5](@section, @group, @tripCount, @campingTripId, @startDate, @endDate, @campingRouteId, @campingPlace, @touristLevel)", sectionParameter, groupParameter, tripCountParameter, campingTripIdParameter, startDateParameter, endDateParameter, campingRouteIdParameter, campingPlaceParameter, touristLevelParameter);
        }
    
        [DbFunction("sp19TourClubEntities", "func6")]
        public virtual IQueryable<func6_Result> func6(Nullable<System.DateTime> birthDate, Nullable<int> age, Nullable<int> assigmentYear)
        {
            var birthDateParameter = birthDate.HasValue ?
                new ObjectParameter("birthDate", birthDate) :
                new ObjectParameter("birthDate", typeof(System.DateTime));
    
            var ageParameter = age.HasValue ?
                new ObjectParameter("age", age) :
                new ObjectParameter("age", typeof(int));
    
            var assigmentYearParameter = assigmentYear.HasValue ?
                new ObjectParameter("assigmentYear", assigmentYear) :
                new ObjectParameter("assigmentYear", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<func6_Result>("[sp19TourClubEntities].[func6](@birthDate, @age, @assigmentYear)", birthDateParameter, ageParameter, assigmentYearParameter);
        }
    
        [DbFunction("sp19TourClubEntities", "func7")]
        public virtual IQueryable<func7_Result> func7(string trainerName, string section, string activityType, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate)
        {
            var trainerNameParameter = trainerName != null ?
                new ObjectParameter("trainerName", trainerName) :
                new ObjectParameter("trainerName", typeof(string));
    
            var sectionParameter = section != null ?
                new ObjectParameter("section", section) :
                new ObjectParameter("section", typeof(string));
    
            var activityTypeParameter = activityType != null ?
                new ObjectParameter("activityType", activityType) :
                new ObjectParameter("activityType", typeof(string));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("startDate", startDate) :
                new ObjectParameter("startDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("endDate", endDate) :
                new ObjectParameter("endDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<func7_Result>("[sp19TourClubEntities].[func7](@trainerName, @section, @activityType, @startDate, @endDate)", trainerNameParameter, sectionParameter, activityTypeParameter, startDateParameter, endDateParameter);
        }
    
        [DbFunction("sp19TourClubEntities", "func8")]
        public virtual IQueryable<func8_Result> func8(string section, Nullable<System.DateTime> startDate, Nullable<System.DateTime> endDate, string instructorName, Nullable<int> groupCount)
        {
            var sectionParameter = section != null ?
                new ObjectParameter("section", section) :
                new ObjectParameter("section", typeof(string));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("startDate", startDate) :
                new ObjectParameter("startDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("endDate", endDate) :
                new ObjectParameter("endDate", typeof(System.DateTime));
    
            var instructorNameParameter = instructorName != null ?
                new ObjectParameter("instructorName", instructorName) :
                new ObjectParameter("instructorName", typeof(string));
    
            var groupCountParameter = groupCount.HasValue ?
                new ObjectParameter("groupCount", groupCount) :
                new ObjectParameter("groupCount", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<func8_Result>("[sp19TourClubEntities].[func8](@section, @startDate, @endDate, @instructorName, @groupCount)", sectionParameter, startDateParameter, endDateParameter, instructorNameParameter, groupCountParameter);
        }
    
        [DbFunction("sp19TourClubEntities", "func9")]
        public virtual IQueryable<func9_Result> func9(string campingPlace, Nullable<int> minLengthKm, string minTouristLevel)
        {
            var campingPlaceParameter = campingPlace != null ?
                new ObjectParameter("campingPlace", campingPlace) :
                new ObjectParameter("campingPlace", typeof(string));
    
            var minLengthKmParameter = minLengthKm.HasValue ?
                new ObjectParameter("minLengthKm", minLengthKm) :
                new ObjectParameter("minLengthKm", typeof(int));
    
            var minTouristLevelParameter = minTouristLevel != null ?
                new ObjectParameter("minTouristLevel", minTouristLevel) :
                new ObjectParameter("minTouristLevel", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<func9_Result>("[sp19TourClubEntities].[func9](@campingPlace, @minLengthKm, @minTouristLevel)", campingPlaceParameter, minLengthKmParameter, minTouristLevelParameter);
        }
    }
}
