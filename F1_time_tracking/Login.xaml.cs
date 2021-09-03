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

        public string PasswordHasher(string Password)
        {
            string result = Convert.ToBase64String(KeyDerivation)
        }
        

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
