using Movies2Night.Models;

namespace Movies2Night.Data
{
    public interface IMovieRepo
    {
        public void AddToFavorites(Search movie);
        public void RemoveFromFavorites(Search movie);
    }
}