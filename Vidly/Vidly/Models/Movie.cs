﻿using System;
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
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Required]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }


        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
    }
}