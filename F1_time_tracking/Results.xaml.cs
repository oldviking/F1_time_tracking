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
using Microsoft.EntityFrameworkCore;

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
            f1Context.Races.Load();
            f1Context.Seasons.Load();
            f1Context.Drivers.Load();
            raceViewSource.Source = f1Context.Races.Local.ToObservableCollection();
            seasonViewSource.Source = f1Context.Seasons.Local.ToObservableCollection();
            driversViewSource.Source = f1Context.Drivers.Local.ToObservableCollection();
        }

        private void MoveDown(object sender, RoutedEventArgs e)
        {
            int idx = ((Models.Race)comboBox1.SelectedItem).Results.IndexOf((Models.Results)dataGrid.SelectedItem);
            if (idx > 0)
            {
                ((Models.Race)comboBox1.SelectedItem).Results.Remove((Models.Results)dataGrid.SelectedItem);
                ((Models.Race)comboBox1.SelectedItem).Results.Insert(idx - 1, (Models.Results)dataGrid.SelectedItem);
                dataGrid.Items.Refresh();
                recalculatePosition();
                dataGrid.SelectedIndex--;

            }
        }

            private void MoveUp(object sender, RoutedEventArgs e)
        {

        }

        private void recalculatePosition()
        {
            foreach (Models.Results r in ((Models.Race)comboBox1.SelectedItem).Results)
            {
                r.Position = ((Models.Race)comboBox1.SelectedItem).Results.IndexOf(r) + 1;
            }
            dataGrid.Items.Refresh();
        }
    }
}
