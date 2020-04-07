using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace BioLab
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        [HtmlAttributeName("src")]
        public string ImageLink { get; set; }

    }
}