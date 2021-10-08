using System.Windows;

namespace F1_time_tracking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //TODO: Remove before presenting the app
#if DEBUG
            MainFrame.Content = new Overview();
#else
            MainFrame.Content = new Login();
#endif
        }
    }
}