using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace petBlog.Models
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Invalid Name")]
        [RegularExpression("A-Za-z", ErrorMessage = "Invalid Name")]
        public string Name { get; set; }
        [Required]
        [Range(0, 150, ErrorMessage = "Please enter a proper age")]
        public int Age { get; set; }
        public string Description { get; set; }
        [Required]
        public string PictureName { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
