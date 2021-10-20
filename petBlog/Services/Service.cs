using petBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using petBlog.Data;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace petBlog.Services
{
    public class Service : IService
    {
      private readonly AnimalContext animalContext;
      private  AnimalContext animalDB;
        public Service(AnimalContext  Context, AnimalContext contextchange)
        {
            animalContext = Context;
            animalDB = contextchange;
        }
        public void AddAnimal(Animal animal)
        {
            animalDB.Add(animal);
            animalDB.SaveChanges();
        }
        public void addComment(int animalId, string comment)
        {
            if(comment != null)
            {
            animalDB.Comments.Add(new Comment { AnimalId = animalId, CommentText = comment });
            animalDB.SaveChanges();
            }
        }
        
        public void DeleteAnimal(Animal animal)
        {
            animalDB.Animals.Remove(animal);
            animalDB.SaveChanges();
        }


        public List<Animal> GetAnimals()
        {
            return animalContext.Animals.ToList();
        }

        public List<Category> GetCategories()
        {
            return animalContext.Categories.ToList();
        }
        public void DeleteAnimal(int id)
        {
            var delete = animalContext.Animals.FirstOrDefault(x => x.AnimalId == id);
            animalContext.Animals.Remove(delete);
        }
        public void DeleteComment(Comment comment)
        {
            var delete = animalContext.Comments.FirstOrDefault(x => x.CommentId == comment.CommentId);
            animalContext.Comments.Remove(delete);
        }
        public IEnumerable<Animal> TwoAnimalWithMostComment()
        {
            var list = animalContext.Animals.ToList();
            var comment = list.OrderByDescending(x => x.Comment.Count()).Take(2);
            return comment;
        }
        public IEnumerable<Animal> GetAnimalShwonByCategory(int category)
        {
            var item = animalContext.Animals.ToList();
            var list = item.FindAll(x => x.CategoryId == category);
            return list;

        }

        public Animal getOneAnimal(int id)
        {
            return animalContext.Animals.FirstOrDefault(x => x.AnimalId == id);
        }
        public void EditAnimal(AnimalViewModel viewModel, int animalId, string fileName)
        {
            Animal animal = getOneAnimal(animalId);
            animal.Name = viewModel.Name;
            animal.Age = viewModel.Age;
            animal.CategoryId = viewModel.CategoryId;
            animal.Description = viewModel.Description;
            animal.PictureName = fileName;
            animal.PictureName = fileName;
            animalDB.SaveChanges();

        }
    }
}
