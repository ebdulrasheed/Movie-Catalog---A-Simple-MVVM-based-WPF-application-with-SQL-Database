using System.Windows;
using System.Windows.Controls;

namespace MovieCatalog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MovieViewModel MovieVM { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MovieVM = new MovieViewModel();
            Frame.Navigate(new HomePage(Frame,MovieVM));
        }
    }
}
