using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource touristViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("touristViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // touristViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource touristAssigmentViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("touristAssigmentViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // touristAssigmentViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource touristCampingTripInfoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("touristCampingTripInfoViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // touristCampingTripInfoViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource touristCompetitionInfoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("touristCompetitionInfoViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // touristCompetitionInfoViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource touristGroupInfoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("touristGroupInfoViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // touristGroupInfoViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource campingPlaceViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("campingPlaceViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // campingPlaceViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource campingRouteViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("campingRouteViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // campingRouteViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource campingRoutePlaceInfoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("campingRoutePlaceInfoViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // campingRoutePlaceInfoViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource campingTripViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("campingTripViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // campingTripViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource competitionViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("competitionViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // competitionViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource areaTypeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("areaTypeViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // areaTypeViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource touristLevelViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("touristLevelViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // touristLevelViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource touristPostViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("touristPostViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // touristPostViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource scheduleViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("scheduleViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // scheduleViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource trainingViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("trainingViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // trainingViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource tripRecordViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("tripRecordViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // tripRecordViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource groupViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("groupViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // groupViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource sectionViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("sectionViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // sectionViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource activityTypeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("activityTypeViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // activityTypeViewSource.Source = [generic data source]
        }
    }
}
