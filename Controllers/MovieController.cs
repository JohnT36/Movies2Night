﻿using Microsoft.AspNetCore.Mvc;
using Movies2Night.Client;
using Movies2Night.Data;
using Movies2Night.Models;

namespace Movies2Night.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieClient _client;
        private readonly IMovieRepo _conn;
        public MovieController(IMovieClient client, IMovieRepo conn)
        {
            _client= client;
            _conn= conn;
        }
    
        public IActionResult Index(SearchString sOs)
        {
            var searchstring = sOs.Name;
            var movies = _client.GetMovies(searchstring);

            return View(movies.Result);
        }

        public IActionResult AddToFavorites()
        {
            var movieToAddID = Request.Form["movieToAddID"];
            var movieToAdd = _client.GetMovieByID(movieToAddID);
            _conn.AddToFavorites(movieToAdd.Result);
            return RedirectToAction("Favorites");
        }

        public IActionResult Favorites()
        {
            var favMovies = _conn.GetAllFavorites();
            return View(favMovies);
        }
    }
}
