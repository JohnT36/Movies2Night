using Movies2Night.Models;

namespace Movies2Night.Data
{
    public interface IMovieRepo
    {
        public void AddToFavorites(LongMovieApi movie);

        public IEnumerable<Search> GetAllFavorites();
        public void RemoveFromFavorites(Search movie);
    }
}