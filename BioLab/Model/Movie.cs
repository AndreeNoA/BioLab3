using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace BioLab
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }
        public string MovieTitle { get; set; }
        public string MoviePoster { get; set; }
        public string MoviePlot { get; set; }

    }
}