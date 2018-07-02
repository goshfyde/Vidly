using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        public ApplicationDbContext _context { get; set; }

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
            IEnumerable<Movie> movieList = 
                from movie in _context.Movies
                where newRental.MovieIds.Contains(movie.Id)
                select movie;
            foreach (Movie movie in movieList)
            {
                Rental rental = new Rental() {Customer = customerInDb, Movie = movie};
                rental.DateRented = DateTime.Today;
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
