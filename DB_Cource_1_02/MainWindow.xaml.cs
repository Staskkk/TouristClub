using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DB_Cource_1_02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private sp19TourClubEntities context;

        CollectionViewSource touristViewSource;
        CollectionViewSource touristAssigmentViewSource;
        CollectionViewSource touristCampingTripInfoViewSource;
        CollectionViewSource touristCompetitionInfoViewSource;
        CollectionViewSource touristGroupInfoViewSource;
        CollectionViewSource campingPlaceViewSource;
        CollectionViewSource campingRouteViewSource;
        CollectionViewSource campingRoutePlaceInfoViewSource;
        CollectionViewSource campingTripViewSource;
        CollectionViewSource competitionViewSource;
        CollectionViewSource areaTypeViewSource;
        CollectionViewSource touristLevelViewSource;
        CollectionViewSource touristPostViewSource;
        CollectionViewSource scheduleViewSource;
        CollectionViewSource trainingViewSource;
        CollectionViewSource tripRecordViewSource;
        CollectionViewSource groupViewSource;
        CollectionViewSource sectionViewSource;
        CollectionViewSource activityTypeViewSource;

        public MainWindow(sp19TourClubEntities context)
        {
            this.context = context;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.touristViewSource = ((CollectionViewSource)(this.FindResource("touristViewSource")));
            this.touristAssigmentViewSource = ((CollectionViewSource)(this.FindResource("touristAssigmentViewSource")));
            this.touristCampingTripInfoViewSource = ((CollectionViewSource)(this.FindResource("touristCampingTripInfoViewSource")));
            this.touristCompetitionInfoViewSource = ((CollectionViewSource)(this.FindResource("touristCompetitionInfoViewSource")));
            this.touristGroupInfoViewSource = ((CollectionViewSource)(this.FindResource("touristGroupInfoViewSource")));
            this.campingPlaceViewSource = ((CollectionViewSource)(this.FindResource("campingPlaceViewSource")));
            this.campingRouteViewSource = ((CollectionViewSource)(this.FindResource("campingRouteViewSource")));
            this.campingRoutePlaceInfoViewSource = ((CollectionViewSource)(this.FindResource("campingRoutePlaceInfoViewSource")));
            this.campingTripViewSource = ((CollectionViewSource)(this.FindResource("campingTripViewSource")));
            this.competitionViewSource = ((CollectionViewSource)(this.FindResource("competitionViewSource")));
            this.areaTypeViewSource = ((CollectionViewSource)(this.FindResource("areaTypeViewSource")));
            this.touristLevelViewSource = ((CollectionViewSource)(this.FindResource("touristLevelViewSource")));
            this.touristPostViewSource = ((CollectionViewSource)(this.FindResource("touristPostViewSource")));
            this.scheduleViewSource = ((CollectionViewSource)(this.FindResource("scheduleViewSource")));
            this.trainingViewSource = ((CollectionViewSource)(this.FindResource("trainingViewSource")));
            this.tripRecordViewSource = ((CollectionViewSource)(this.FindResource("tripRecordViewSource")));
            this.groupViewSource = ((CollectionViewSource)(this.FindResource("groupViewSource")));
            this.sectionViewSource = ((CollectionViewSource)(this.FindResource("sectionViewSource")));
            this.activityTypeViewSource = ((CollectionViewSource)(this.FindResource("activityTypeViewSource")));

            LoadAll();
        }

        private void LoadAll()
        {
            TryFunc(context.Tourists.Load);
            TryFunc(context.TouristAssigments.Load);
            TryFunc(context.TouristCampingTripInfoes.Load);
            TryFunc(context.TouristCompetitionInfoes.Load);
            TryFunc(context.TouristGroupInfoes.Load);
            TryFunc(context.CampingPlaces.Load);
            TryFunc(context.CampingRoutes.Load);
            TryFunc(context.CampingRoutePlaceInfoes.Load);
            TryFunc(context.CampingTrips.Load);
            TryFunc(context.Competitions.Load);
            TryFunc(context.AreaTypes.Load);
            TryFunc(context.TouristLevels.Load);
            TryFunc(context.TouristPosts.Load);
            TryFunc(context.Schedules.Load);
            TryFunc(context.Trainings.Load);
            TryFunc(context.TripRecords.Load);
            TryFunc(context.Groups.Load);
            TryFunc(context.Sections.Load);
            TryFunc(context.ActivityTypes.Load);

            touristViewSource.Source = context.Tourists.Local;
            touristAssigmentViewSource.Source = context.TouristAssigments.Local;
            touristCampingTripInfoViewSource.Source = context.TouristCampingTripInfoes.Local;
            touristCompetitionInfoViewSource.Source = context.TouristCompetitionInfoes.Local;
            touristGroupInfoViewSource.Source = context.TouristGroupInfoes.Local;
            campingPlaceViewSource.Source = context.CampingPlaces.Local;
            campingRouteViewSource.Source = context.CampingRoutes.Local;
            campingRoutePlaceInfoViewSource.Source = context.CampingRoutePlaceInfoes.Local;
            campingTripViewSource.Source = context.CampingTrips.Local;
            competitionViewSource.Source = context.Competitions.Local;
            areaTypeViewSource.Source = context.AreaTypes.Local;
            touristLevelViewSource.Source = context.TouristLevels.Local;
            touristPostViewSource.Source = context.TouristPosts.Local;
            scheduleViewSource.Source = context.Schedules.Local;
            trainingViewSource.Source = context.Trainings.Local;
            tripRecordViewSource.Source = context.TripRecords.Local;
            groupViewSource.Source = context.Groups.Local;
            sectionViewSource.Source = context.Sections.Local;
            activityTypeViewSource.Source = context.ActivityTypes.Local;
        }

        public static bool TryFunc(Action method)
        {
            try
            {
                method();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.context.Dispose();
                this.context = LoginWindow.Connect(null, null);
                LoadAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(GetRealException(ex).Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(GetRealException(ex).Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static Exception GetRealException(Exception ex)
        {
            Exception res = ex;
            while (res.InnerException != null)
            {
                res = res.InnerException;
            }

            return res;
        }
    }
}
