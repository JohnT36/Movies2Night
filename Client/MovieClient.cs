using Movies2Night.Models;
using MySqlX.XDevAPI;
using System.Data;

namespace Movies2Night.Client
{
    public class MovieClient : IMovieClient
    {
        readonly HttpClient client = new HttpClient();
        public MovieClient()
        {
            

        }

        public async Task<LongMovieApi> GetMovieByID(string id)
        {

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://movie-database-alternative.p.rapidapi.com/?r=json&i={id}"),
                Headers =
    {
        { "X-RapidAPI-Key", "808da3f3fbmshdaff4f757eacf35p1d49afjsnbe67d9c4db7a" },
        { "X-RapidAPI-Host", "movie-database-alternative.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body1 = await response.Content.ReadFromJsonAsync<LongMovieApi>();
                return body1;
            }
        }

        public async Task<ShortMovieApi> GetMovies(string id)
        {
            
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://movie-database-alternative.p.rapidapi.com/?s={id}&r=json&page=1"),
                    Headers =
    {
        { "X-RapidAPI-Key", "808da3f3fbmshdaff4f757eacf35p1d49afjsnbe67d9c4db7a" },
        { "X-RapidAPI-Host", "movie-database-alternative.p.rapidapi.com" },
    },
                };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body1 = await response.Content.ReadFromJsonAsync<ShortMovieApi>();
                return body1;
            }
        }

    }
}
