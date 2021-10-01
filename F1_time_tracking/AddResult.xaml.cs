using F1_time_tracking.Data;
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
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace F1_time_tracking
{
    /// <summary>
    /// Interaktionslogik für AddResult.xaml
    /// </summary>
    public partial class AddResult : Window
    {
        private readonly F1Context f1Context = new();
        public int Position;
        public int RaceID, SeasonID;
        public AddResult(int RaceID, int SeasonID)
        {
            InitializeComponent();
            this.SeasonID = SeasonID;
            this.RaceID = RaceID;
        }


        private void OnLoad(object sender, RoutedEventArgs e)
        {
            f1Context.driverTeams.Load();
            f1Context.Seasons.Load();
            f1Context.Drivers.Load();
            comboBox.ItemsSource = f1Context.driverTeams.Local.ToObservableCollection()
                .Where(x => x.Season.Id == SeasonID);
        }

        private void Addbutton_Click(object sender, RoutedEventArgs e)
        {
            if(comboBox.SelectedItem != null)
            {
                bool isNumeric = int.TryParse(textBox.Text, out Position);
                if (isNumeric == false)
                {
                    MessageBox.Show("Bitte eine gültige Zahl als Position eigeben!");
                }
                else
                {
                    Models.Results result = new();
                    Models.DriverTeam driverTeam = ((Models.DriverTeam)comboBox.SelectedItem);
                    int DriverID = comboBox.SelectedIndex + 1;
                    result.Driver = driverTeam.Driver;
                    result.DriverId = driverTeam.DriverID;
                    result.RaceId = RaceID;
                    result.Position = Position;
                    result.Race = f1Context.Races.FirstOrDefault(x => x.Id == RaceID);

                    switch (Position){
                        case 1:
                            result.Points = 10;
                            break;
                        case 2:
                            result.Points = 8;
                            break;
                        case 3:
                            result.Points = 7;
                            break;
                        case 4:
                            result.Points = 6;
                            break;
                        case 5:
                            result.Points = 3;
                            break;
                        case 6:
                            result.Points = 1;
                            break;
                        default:
                            result.Points = 0;
                            break;
                    }
                    f1Context.Result.Add(result);
                    f1Context.SaveChanges();
                    this.Close();
                }
            }
            
            


        }
    }
}
