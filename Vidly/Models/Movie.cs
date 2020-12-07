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

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime AddedDate { get; set; }

        [Required]
        [Display (Name = "Number in stock")]
        [Range(1, 20)]
        public int Stocks { get; set; }

        public Genres Genre { get; set; }

        [Required]
        [Display (Name= "Genres")]
        public int GenresId { get; set; }

    }
}