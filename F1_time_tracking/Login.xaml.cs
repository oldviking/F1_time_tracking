using F1_time_tracking.Data;
using F1_time_tracking.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace F1_time_tracking
{
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public F1Context context = new F1Context();

        public Login()
        {
            InitializeComponent();

            //adds a new db context
            F1Context context = new F1Context();
            this.context = context;
        }

        /// <summary>
        /// Checks if the user exists and if he/she/it exist it will geck if the password thats is stored and input are the same(Caps and so on)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            User user = context.Users.FirstOrDefault(us => us.username == Username.Text);
            if (user != null)
            {
                PasswordFunctions pwfunctions = new();
                string hash = pwfunctions.PasswordHasher(Password: Password.Password, salt: user.salt);
                if (pwfunctions.verifyHashes(DbHash: user.password, InputHash: hash))
                {
                    Overview overview = new();
                    this.NavigationService.Navigate(overview);
                }
                else
                {
                    MessageBox.Show("Wrong Password!");
                }
            }
            else
            {
                MessageBox.Show("No User with the Username " + Username.Text + "!");
            }
        }

        /// <summary>
        /// Adds a new user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            PasswordFunctions pwfunctions = new();
            User dbUseer = context.Users.FirstOrDefault(us => us.username == Username.Text);
            if (dbUseer != null)
            {
                User user = new();
                user.username = Username.Text;
                user.salt = pwfunctions.SaltGenerator();
                user.password = pwfunctions.PasswordHasher(Password: Password.Password, user.salt);
                context.Users.Add(user);
                context.SaveChanges();

                MessageBox.Show("User Created!");
            }
            else
            {
                MessageBox.Show("User exists already!");
            }
        }
    }
}