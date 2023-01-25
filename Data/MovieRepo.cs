using System.Data;

namespace Movies2Night.Data
{
    public class MovieRepo : IMovieRepo
    {
        private readonly IDbConnection _conn;

        public MovieRepo(IDbConnection conn)
        {
            _conn = conn;
        }


    }
}
