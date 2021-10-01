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
        
        private List<Models.Results> ResultSource;
        private CollectionViewSource seasonViewSource;

        public Results()
        {
            InitializeComponent();
            
            seasonViewSource = (CollectionViewSource)FindResource(nameof(seasonViewSource));


        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            f1Context.Races.Load();
            f1Context.Seasons.Load();
            f1Context.Drivers.Load();
            f1Context.Teams.Load();
            f1Context.Result.Load();
            ResultSource = new();
            seasonViewSource.Source = f1Context.Seasons.Local.ToObservableCollection();
            ResultSource.AddRange(f1Context.Result.Local.AsEnumerable());
            comboBox.ItemsSource = f1Context.Seasons.Local.ToObservableCollection();
            

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddResult addResult = new( ((Models.Race)comboBox1.SelectedItem).Id, ((Models.Season)comboBox.SelectedItem).Id); 
            addResult.ShowDialog();
            
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBox1.ItemsSource = f1Context.Races.Local.ToObservableCollection().Where(x => x.Season.Id == ((Models.Season)comboBox.SelectedItem).Id);

        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ResultViewSource.Source = f1Context.Result.Local.ToObservableCollection().Where(x => x.RaceId == ((Models.Race)comboBox1.SelectedItem).Id);


            if(comboBox1.SelectedItem != null)
            dataGrid1.ItemsSource = f1Context.Result.Local.Where(x => x.RaceId == ((Models.Race)comboBox1.SelectedItem).Id).ToList();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            f1Context.Races.Load();
            f1Context.Seasons.Load();
            f1Context.Drivers.Load();
            f1Context.Teams.Load();
            f1Context.Result.Load();

            

        }

        
    }
}
