using F1_time_tracking.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;

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

        /// <summary>
        /// do some Magic at startup
        /// </summary>
        /// <param name="RaceID"></param>
        /// <param name="SeasonID"></param>
        public AddResult(int RaceID, int SeasonID)
        {
            InitializeComponent();
            this.SeasonID = SeasonID;
            this.RaceID = RaceID;
        }
        /// <summary>
        /// do some stuff at window load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            f1Context.driverTeams.Load();
            f1Context.Seasons.Load();
            f1Context.Drivers.Load();
            comboBox.ItemsSource = f1Context.driverTeams.Local.ToObservableCollection()
                .Where(x => x.Season.Id == SeasonID);
        }

        /// <summary>
        /// Adds a new result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Addbutton_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedItem != null)
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
                    result.Driver.Team = (System.Collections.Generic.ICollection<Models.Team>)f1Context.Teams.FirstOrDefault(x => x.Id == driverTeam.TeamID);
                    result.RaceId = RaceID;
                    result.Position = Position;
                    result.Race = f1Context.Races.FirstOrDefault(x => x.Id == RaceID);

                    switch (Position)
                    {
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