using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genres> GenreTypes;

        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Number in stock")]
        [Range(1, 20)]
        public int? Stocks { get; set; }

        [Required]
        [Display(Name = "Genres")]
        public int? GenresId { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;
            Stocks = 0;
            ReleaseDate = new DateTime();
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            Stocks = movie.Stocks;
            GenresId = movie.GenresId;
        }
    }
}