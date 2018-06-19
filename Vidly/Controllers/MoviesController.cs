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

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!"};
            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            var genreList = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = genreList
            };

            if (movie == null)
                return HttpNotFound();


            return View("MovieForm", viewModel);
        }

        [Route("movies/released/{year}/{month:regex(\\d{1}|d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
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
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                //var movieIn = _context.Customers.Single(c => c.Id == customer.Id);
                //customerInDb.Name = customer.Name;
                //customerInDb.BirthDate = customer.BirthDate;
                //customerInDb.MembershipTypeId = customer.MembershipTypeId;
                //customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}