using F1_time_tracking.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;

namespace F1_time_tracking
{
    /// <summary>
    /// Interaktionslogik für edit.xaml
    /// </summary>
    public partial class edit : Window
    {
        private readonly F1Context f1Context = new();
        public int Position;
        public int RaceID;
        private Models.Results result_edited;

        /// <summary>
        /// do some stuff at startup of the window
        /// </summary>
        /// <param name="RaceID"></param>
        /// <param name="Position"></param>
        public edit(int RaceID, int Position)
        {
            InitializeComponent();
            this.Position = Position;
            this.RaceID = RaceID;
        }

        /// <summary>
        /// Do stuff at Window Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            f1Context.driverTeams.Load();
            f1Context.Seasons.Load();
            f1Context.Drivers.Load();

            result_edited = f1Context.Result.Where(x => x.RaceId == RaceID)
                .Where(x => x.Position == Position)
                .FirstOrDefault();
            textBox.Text = result_edited.Driver.Name;
            textBox1.Text = result_edited.Position.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            int new_position;
            bool result = Int32.TryParse(textBox1.Text, out new_position);
            if (result == true)
            {
                result_edited.Position = new_position;
                switch (new_position)
                {
                    case 1:
                        result_edited.Points = 10;
                        break;

                    case 2:
                        result_edited.Points = 8;
                        break;

                    case 3:
                        result_edited.Points = 7;
                        break;

                    case 4:
                        result_edited.Points = 6;
                        break;

                    case 5:
                        result_edited.Points = 3;
                        break;

                    case 6:
                        result_edited.Points = 1;
                        break;

                    default:
                        result_edited.Points = 0;
                        break;
                }

                f1Context.Result.Update(result_edited);
                f1Context.SaveChanges();

                Close();
            }
        }
        /// <summary>
        /// closes the dialog if the user wants it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}