using F1_time_tracking.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace F1_time_tracking
{
    /// <summary>
    /// Interaktionslogik für Results.xaml
    /// </summary>
    public partial class Results : Page
    {
        private readonly F1Context f1Context = new();

        //List where the Results are stored
        private List<Models.Results> ResultSource;
        //CollectionViewSource for the seasons
        private CollectionViewSource seasonViewSource;

        public Results()
        {
            InitializeComponent();

            // do some magic
            seasonViewSource = (CollectionViewSource)FindResource(nameof(seasonViewSource));
        }

        /// <summary>
        /// Do things when the Window is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Opens a Dialog to add a new Result and savs it to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (((Models.Race)comboBox1.SelectedItem != null) && ((Models.Season)comboBox.SelectedItem != null))
            {
                AddResult addResult = new(((Models.Race)comboBox1.SelectedItem).Id, ((Models.Season)comboBox.SelectedItem).Id);
                addResult.ShowDialog();
            }
                
        }

        /// <summary>
        /// Is Run when the Season ComboBox is Run
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            comboBox1.ItemsSource = f1Context.Races.Local.ToObservableCollection().Where(x => x.Season.Id == ((Models.Season)comboBox.SelectedItem).Id);
        }

        /// <summary>
        /// IS Run when the Race Combobox changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox1.SelectedItem != null)
                dataGrid1.ItemsSource = f1Context.Result.Local.Where(x => x.RaceId == ((Models.Race)comboBox1.SelectedItem).Id)
                        .ToList();
        }

        /// <summary>
        /// A Button that reloads all data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        /// <summary>
        /// Opens a Dialog to edit a Result and saves it to the Database, but there is a bug that the datagrid doesnt get the new result, The edited result is the database but the grid wont load it,
        /// you have to start the program new to load it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            if ((Models.Results)dataGrid1.SelectedItem != null)
            {
                edit edit = new(((Models.Results)dataGrid1.SelectedItem).RaceId, ((Models.Results)dataGrid1.SelectedItem).Position);
                dataGrid1.ItemsSource = null;
                Nullable<bool> dialogResult = edit.ShowDialog();

                if (dialogResult == false)
                    refresh();
            }
        }

        /// <summary>
        /// Refreshes the Datagrid1 
        /// </summary>
        private void refresh()
        {

            if (comboBox1.SelectedItem != null)
                dataGrid1.ItemsSource = f1Context.Result.Where(x => x.RaceId == ((Models.Race)comboBox1.SelectedItem).Id).ToList();
        }

        /// <summary>
        /// Deletes a Record from the Database and the DataGrid1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            if ((Models.Results)dataGrid1.SelectedItem != null)
            {
                f1Context.Result.Remove((Models.Results)dataGrid1.SelectedItem);
                f1Context.SaveChanges();

                if (comboBox1.SelectedItem != null)
                    dataGrid1.ItemsSource = f1Context.Result.Where(x => x.RaceId == ((Models.Race)comboBox1.SelectedItem).Id).ToList();
            }
        }
    }
}