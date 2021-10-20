using Microsoft.EntityFrameworkCore;
using petBlog.Models;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace petBlog.Data
{
    public class AnimalContext : DbContext
    {
        public AnimalContext(DbContextOptions<AnimalContext> options) : base(options)
        {

        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
    //EntityFrameWorkCore code first
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new { CategoryId =1  ,CategoryName = "Mammoth" },
                new { CategoryId =2  ,CategoryName = "Aqua" },
                new { CategoryId =3  ,CategoryName = "Birds" },
                new { CategoryId =4  ,CategoryName = "Reptiles" }
                );
            modelBuilder.Entity<Animal>().HasData(
                new {AnimalId = 1,  Name = "Af-had", Age = 13, Description = "Japanness spitz dog", CategoryId = 1, PictureName = "dog_japanese-spitz_desktop.jpg" },
                new {AnimalId = 2, Name = "Cat", Age = 5, Description = " regular cat", CategoryId = 1, PictureName = "download.jpg" },
                new {AnimalId = 3 ,Name = "gold", Age = 6, Description = "gold fish", CategoryId = 2, PictureName = "images.jpg" },
                new {AnimalId = 4, Name = "doll", Age = 3, Description = "dolphine", CategoryId = 2, PictureName = "dolphin.jpg" },
                new {AnimalId = 5,Name = "jack", Age = 10, Description = "parrot", CategoryId = 3, PictureName = "parrot.jpg" },
                new { AnimalId = 6, Name = "Alonso", Age = 1, Description = "american egale", CategoryId = 3, PictureName = "egale.jpg"},
                new { AnimalId = 7, Name = "Dan", Age = 2, Description = "whale", CategoryId = 2, PictureName = "whale.jpg"}
                );
            modelBuilder.Entity<Comment>().HasData(
                new { CommentId = 1, AnimalId = 1 , CommentText = "great dog" },
                new { CommentId = 2, AnimalId = 1 , CommentText = "a lot of hair" },
                new { CommentId = 3, AnimalId = 2 , CommentText = "nice cat" },
                new { CommentId = 4, AnimalId = 5 , CommentText = "good color" },
                new { CommentId = 5, AnimalId = 5 , CommentText = "quit" },
                new { CommentId = 6, AnimalId = 3 , CommentText = "size of 1 Kg" }
                );
        }


    }
}
