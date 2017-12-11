using System.Windows;
using System.Windows.Controls;

namespace MovieCatalog
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private Frame Frame;
        MovieViewModel MovieVM;

        public HomePage()
        {
            InitializeComponent();
        }

        public HomePage(Frame frame1, MovieViewModel movieVM)
        {
            InitializeComponent();
            this.Frame = frame1;
            this.MovieVM = movieVM;
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(new Search(this.Frame, this.MovieVM));
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(new AddPage(this.Frame, this.MovieVM));

        }
    }
}
