using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MovieCatalog
{
    public class MovieViewModel
    {
        public ObservableCollection<Movie> Movies { get; set; }
        private MovieRepository MovieRepository { get; set; }

        public MovieViewModel()
        {
            MovieRepository = new MovieRepository();
            Movies = new ObservableCollection<Movie>(MovieRepository.movieRepository);
            Movies.CollectionChanged += Movies_CollectionChanged;       // Event Handler for change in collection
        }
        
        /*
         * Function: Search for the query string in Movies Collection
         * Saves time and resources by searching in Collection in memory
         * rather than in database
         */
        public List<Movie> searchRepo(string searchQuery)
        {
            if (searchQuery == "*" || searchQuery == " ")
                throw new Exception("Warning: Symbols such as '*' or whitespace are not acceptable");

            List<Movie> MoviesList =                // Temporary list for storing results returned from search query
                (from tempMovie in Movies
                where tempMovie.Title.Contains(searchQuery)
                select tempMovie).ToList();
            return MoviesList;
        }

        /*
         * Function: Add Record to Collection and Database
         */
        public void AddRecordToRepo(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException("Error: The argument is Null");
            Movies.Add(movie);
        }

        /*
         * Function: Delete Records from Collection and Database
         */
        public void DeleteRecordFromRepo(int id)
        {
            if (id < 0)
                throw new Exception("Record ID must be non-negative");

            int index = 0;
            while (index < Movies.Count)
            {
                if (Movies[index].Id == id)
                {
                    Movies.RemoveAt(index);
                    break;
                }
                index++;
            }
        }

        /*
         * Function: Updates the Object in Collection
         * with refernce to the id
         */
        public void UpdateRecordInRepo(Movie movie)
        {
            if (movie.Id < 0)
                throw new Exception("Error: ID cannot be negative");

            int index = 0;
            while(index < Movies.Count)
            {
               if (Movies[index].Id == movie.Id)
                {
                    Movies[index] = movie;
                    break;
                }
                index++;
            }
        }

        /*
         * Event Handler: Handles the CollectionChanged event of ObservableCollection
         * Updates the Database if any change is made to the Movies Collection
         * Thus removes unncecessary burden of accessing Database
         */
        private void Movies_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                int newIndex = e.NewStartingIndex;
                MovieRepository.addNewRecord(Movies[newIndex]);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                List<Movie> tempListOfRemovedItems = e.OldItems.OfType<Movie>().ToList();
                MovieRepository.DelRecord(tempListOfRemovedItems[0].Id);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                List<Movie> tempListOfMovies = e.NewItems.OfType<Movie>().ToList();
                MovieRepository.UpdateRecord(tempListOfMovies[0]);      // As the IDs are unique, only one row will be effected hence first index only
            }
        }
    }
}