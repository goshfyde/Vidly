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
            var customerInDb = _context.Customers.Single(c => c.Id == newRental.CustomerId);
            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id));
            foreach (var movie in movies)
            {
                var rental = new Rental
                    {
                        Customer = customerInDb,
                        Movie = movie,
                        DateRented = DateTime.Now
                    };
                _context.Rentals.Add(rental);
                movie.NumberAvailable--;
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
