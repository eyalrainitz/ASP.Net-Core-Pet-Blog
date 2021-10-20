using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace petBlog.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int AnimalId { get; set; }
        [Required]
        public string CommentText { get; set; }

        public virtual Animal animal { get; set; }
        // public virtual ICollection<Animal> Animals { get; set; }

    }
}
