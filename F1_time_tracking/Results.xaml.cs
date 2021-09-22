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
using F1_time_tracking.Data;

namespace F1_time_tracking
{
    /// <summary>
    /// Interaktionslogik für Results.xaml
    /// </summary>
    public partial class Results : Page
    {
        private readonly F1Context f1Context = new();
        private CollectionViewSource seasonViewSource;
        private CollectionViewSource driversViewSource;
        private CollectionViewSource raceViewSource;
        public Results()
        {
            InitializeComponent();
            seasonViewSource = (CollectionViewSource)FindResource(nameof(seasonViewSource));
            driversViewSource = (CollectionViewSource)FindResource(nameof(driversViewSource));
            raceViewSource = (CollectionViewSource)FindResource(nameof(raceViewSource));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            raceViewSource.Source = f1Context.Races.Local.ToObservableCollection();
            seasonViewSource.Source = f1Context.Seasons.Local.ToObservableCollection();
            driversViewSource.Source = f1Context.Drivers.Local.ToObservableCollection();
        }
    }
}
