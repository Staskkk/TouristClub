using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
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
using System.Windows.Shapes;

namespace DB_Cource_1_02
{
    public partial class sp19TourClubEntities : DbContext
    {
        public sp19TourClubEntities(string connectionString) : base(connectionString)
        {
        }
    }

    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        public static EntityConnectionStringBuilder entityString;

        public static sp19TourClubEntities Connect(string userName, string password)
        {
            sp19TourClubEntities dbContext = null;
            try
            {
                if (userName != null)
                {
                    entityString = new EntityConnectionStringBuilder()
                    {
                        Provider = "System.Data.SqlClient",
                        Metadata = "res://*/TouristClubModel.csdl|res://*/TouristClubModel.ssdl|res://*/TouristClubModel.msl",
                        ProviderConnectionString = @"data source=STAS\SQLEXPRESS;initial catalog=sp19TourClub;persist security info=True;MultipleActiveResultSets=True;App=EntityFramework"
                    };
                    entityString.ProviderConnectionString += ";user id=" + userName + ";Password=" + password;
                }

                dbContext = new sp19TourClubEntities(entityString.ConnectionString);
                if (dbContext.Database.Exists())
                    return dbContext;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            dbContext?.Dispose();
            return null;
        }

        private void Butto_Login_Click(object sender, RoutedEventArgs e)
        {
            string login = tbxLogin.Text;
            var context = Connect(login, tbxPass.Password);
            if (context == null)
            {
                MessageBox.Show("Invalid login or password!");
                return;
            }

            new MainWindow(context).Show();
            Close();
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
