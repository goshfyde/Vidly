using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1,20)]
        [Display(Name = "In Stock Quantity")]
        public int NumberInStock { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }

        public Movie()
        {
            DateAdded = DateTime.Today;
        }
    }
}