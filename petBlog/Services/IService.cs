using petBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace petBlog.Services
{
   public interface IService
    {
        void addComment(int animalId, string comment);
        List<Category> GetCategories();
        List<Animal> GetAnimals();
        Animal getOneAnimal(int id);
        void AddAnimal(Animal animal);
        void DeleteAnimal(Animal animal);
        IEnumerable<Animal> TwoAnimalWithMostComment();
        IEnumerable<Animal> GetAnimalShwonByCategory(int category);
        void EditAnimal(AnimalViewModel viewModel, int animalId, string fileName);


    }
}
