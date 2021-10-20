using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace petBlog.Models
{
    public class AnimalViewModel
    {
        [Required(ErrorMessage = "Please enter animal name")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Age")]
        [Range(0, 150)]
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please upload file")]
        [Display(Name = "File")]
        public IFormFile Photo { get; set; }
        [Required(ErrorMessage = "Please enter animal Description")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter Category name")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }

}
