using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //movies
        public ActionResult Index()
        {
            var movieList = _context.Movies.Include(c => c.Genre).ToList();
            return View(movieList);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }


        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            var genreList = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = genreList
            };

            if (movie == null)
                return HttpNotFound();


            return View("MovieForm", viewModel);
        }

        public ActionResult New()
        {
            var genreList = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genreList
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var genreList = _context.Genres.ToList();
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = genreList
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}