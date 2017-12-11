using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MovieCatalog
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        MovieViewModel MovieVM;
        Frame Frame;

        public Search()
        {
            InitializeComponent();
        }

        public Search(Frame frame, MovieViewModel movieVM)
        {
            InitializeComponent();
            this.Frame = frame;
            this.MovieVM = movieVM;

            this.Loaded += SearchPage_Loaded;
            EditBtn.IsEnabled = false;
            DelBtn.IsEnabled = false;
        }

        private void SearchPage_Loaded(object sender, RoutedEventArgs e)
        {
            searchBox.Focusable = true;
            Keyboard.Focus(searchBox);
        }

        /*
         * Function: Event Handler for Search Button
         */
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (searchBox.Text == "")
            {
                WarningSearchLabel.Visibility = Visibility.Visible;
                return;
            }

            WarningSearchLabel.Visibility = Visibility.Hidden;
            gridTable.DataContext = MovieVM.searchRepo(searchBox.Text);
            gridTable.Columns[0].Visibility = Visibility.Hidden;        // Hides the first column i.e. ID

            if (gridTable.SelectedCells.Count == 0)         // Disanle the Edit and Delete Button if no row selected
            {
                EditBtn.IsEnabled = false;
                DelBtn.IsEnabled = false;
            }
            else
            {
                EditBtn.IsEnabled = true;
                DelBtn.IsEnabled = true;
            }
        }

        /*
         * Function: Event Handler for Search Box GotFocus
         * Removes text from Search Box
         */
        private void searchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            searchBox.Text = "";
            searchBox.FontStretch = FontStretches.Normal;
            searchBox.FontStyle = FontStyles.Normal;
            searchBox.Foreground = Brushes.Black;
        }

        /*
         * Function: Event Handler for Delete Button
         * Delete the Selected Record from Database
         */
        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            Movie movie = (Movie) gridTable.SelectedItem;
            MovieVM.DeleteRecordFromRepo(movie.Id);
            gridTable.DataContext = MovieVM.searchRepo(searchBox.Text);     // Updating the DataTable
            gridTable.Columns[0].Visibility = Visibility.Hidden;
        }

        /*
         * Function: Event Hanlder for Edit Button
         */
        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Movie tempMovie = (Movie) gridTable.SelectedItem;
            Frame.Navigate(new EditPage(Frame, MovieVM, tempMovie));
        }

        private void gridTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridTable.SelectedCells.Count == 0)
            {
                EditBtn.IsEnabled = false;
                DelBtn.IsEnabled = false;
                return;
            }
            EditBtn.IsEnabled = true;
            DelBtn.IsEnabled = true;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new HomePage(Frame, MovieVM));
        }
    }
}
