using System.Windows;
using System.Windows.Controls;

namespace MovieCatalog
{
    /// <summary>
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        private Frame Frame;
        private MovieViewModel MovieVM;
        private Movie Movie;

        public EditPage()
        {
            InitializeComponent();
        }

        public EditPage(Frame frame, MovieViewModel movieVM, Movie movie)
        {
            InitializeComponent();
            this.Frame = frame;
            this.MovieVM = movieVM;
            this.Movie = movie;
                                                            // Loading Record into TextBoxes
            this.Title_TBox.Text = movie.Title;
            this.Genre_TBox.Text = movie.Genre;
            this.duration_TBox.Text = movie.Duration.ToString();
            this.ReleaseYear_TBox.Text = movie.ReleaseYear.ToString();
            this.UpdateBtn.IsEnabled = false;           // Diable the update button
        }

        /*
         * Function: Event Handler for Update Button
         * Updates the record in Collection
         */
        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Movie tempMovie = new Movie();
            tempMovie.Id = Movie.Id;
            tempMovie.Title = Title_TBox.Text;
            tempMovie.Genre = Genre_TBox.Text;
            tempMovie.Duration = int.Parse(duration_TBox.Text.ToString());
            tempMovie.ReleaseYear = int.Parse(ReleaseYear_TBox.Text.ToString());
            MovieVM.UpdateRecordInRepo(tempMovie);
            MessageBox.Show("The record is updated", "Update");
        }

        /*
         * Function: Event Handler for Back Button
         * Navigates to previous container, in this case Page
         */
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.NavigationService.GoBack();
        }

        /* 
         * Function: Event Handler for TextBox
         * Enable update button if text is edited in Box
         */
        private void LostFocus_TextBox(object sender, RoutedEventArgs e)
        {
            if (!(this.Movie.Title.Equals(this.Title_TBox.Text)
                && this.Movie.Genre.Equals(this.Genre_TBox.Text)
                && this.Movie.Duration.Equals(int.Parse(this.duration_TBox.Text))
                && this.Movie.ReleaseYear.Equals(int.Parse(this.ReleaseYear_TBox.Text))))
            {
                UpdateBtn.IsEnabled = true;
            }
        }
    }
}
