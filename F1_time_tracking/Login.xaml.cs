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
using System.Security.Cryptography;
using F1_time_tracking.Models;

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
            F1Context context = new F1Context();
            this.context = context;
        }

        
        

        private void button_Click(object sender, RoutedEventArgs e)
        {
            User user = context.Users.FirstOrDefault(us => us.username == Username.Text);
            if(user != null)
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
                MessageBox.Show("No User with the Username "+ Username.Text + "!");
            }


        }

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
