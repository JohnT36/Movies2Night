using Dapper;
using Movies2Night.Models;
using System.Data;
using System.Data.Common;

namespace Movies2Night.Data
{
    public class MovieRepo : IMovieRepo
    {
        private readonly IDbConnection _conn;

        public MovieRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public void AddToFavorites(LongMovieApi movie)
        {
            _conn.Execute("INSERT INTO movies (Title, Year, imdbID, Poster) VALUES (@Title, @Year, @imdbID, @Poster);",
                 new { Title = movie.Title, Year = movie.Year, imdbID = movie.imdbID, Poster = movie.Poster  });
        }

        public IEnumerable<Search> GetAllFavorites()
        {
            return _conn.Query<Search>("SELECT * FROM movies;");
        }

        public void RemoveFromFavorites(Search movie)
        {
            _conn.Execute("Delete From movie where imdbID = @imdbID", new { imdbID = movie.imdbID, });
        }
    }
}
