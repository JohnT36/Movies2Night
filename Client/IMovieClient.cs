using Movies2Night.Models;

namespace Movies2Night.Client
{
    public interface IMovieClient
    {
        public Task<LongMovieApi> GetMovieByID(string id);
        public Task<ShortMovieApi> GetMovies(string id);


    }
}