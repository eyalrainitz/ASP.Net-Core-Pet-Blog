using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using petBlog.Data;
using petBlog.Models;
using petBlog.Services;

namespace petBlog.Controllers
{
    public class AnimalController : Controller
    {
        private  AnimalContext db;
        private readonly IService _service;
        private IWebHostEnvironment webHostEnvironment;

        public AnimalController(AnimalContext animalContext, IService service, IWebHostEnvironment web)
        {
            db = animalContext;
            _service = service;
            webHostEnvironment = web;
        }

        public ActionResult Index()
        {
            ViewBag.Categories = _service.GetCategories();
            var list = _service.TwoAnimalWithMostComment();
            return View(list);
        }
        [HttpGet]
        public ActionResult ShowCategory(int id = 0)
        {
            ViewBag.Categories = _service.GetCategories();
            if (id == 0)
            {
                ViewBag.Animal = _service.GetAnimals();
            }
            else
            {
                ViewBag.Animal = _service.GetAnimalShwonByCategory(id);

            }
            return View();
        }

        public ActionResult ShowAnimal(int  id)
        {
            return View(_service.getOneAnimal(id));
        }
        
        public ActionResult Admin()
        {
            return View(_service.GetAnimals());
        }
        //Add Page
        public IActionResult AddAnimal()
        {
            ViewBag.Categories = _service.GetCategories();
            return View();
        }
        //Add animal Task
        [HttpPost]
        public async Task<IActionResult> NewAnimalPage(AnimalViewModel animal)
        {
            if (ModelState.IsValid)
            {
                Animal demo = new Animal { Name = animal.Name, Age = animal.Age, Description = animal.Description, CategoryId = animal.CategoryId };
                string fileName = Guid.NewGuid().ToString() + animal.Photo.FileName;
                var saveImage = Path.Combine(webHostEnvironment.WebRootPath, "Images", fileName);
                using (var stream = new FileStream(saveImage, FileMode.Create))
                {
                    await animal.Photo.CopyToAsync(stream);
                }
                demo.PictureName = fileName;
                _service.AddAnimal(demo);
                return RedirectToAction("Admin");
            }
            else
            {
                ViewBag.Categories = _service.GetCategories();
                return View("AddAnimal");
            }
        }

        //add coment and stay in the same page
        [HttpPost]
        public IActionResult AddComment(int animalId, string comment)
        {
            _service.addComment(animalId, comment);
            return RedirectToAction("ShowAnimal", new { id = animalId });
        }
        //delete animal and come back to the admin page
        public IActionResult Delete(Animal animal)
        {
            _service.DeleteAnimal(animal);
            return RedirectToAction("Admin");
        }
        //task for doing the change for animal
        [HttpPost]
        public async Task<IActionResult> EditAnimal(AnimalViewModel animal, int id)
        {
            if (ModelState.IsValid)
            {
                string fileName = Guid.NewGuid().ToString() + animal.Photo.FileName;
                var saveImage = Path.Combine(webHostEnvironment.WebRootPath, "Images", fileName);
                using (var stream = new FileStream(saveImage, FileMode.Create))
                {
                    await animal.Photo.CopyToAsync(stream);
                }
                _service.EditAnimal(animal, id, fileName);
                return RedirectToAction("Admin");

            }
            else
            {
                ViewBag.Categories = _service.GetCategories();
                ViewBag.AnimalID = id;
                return View("EditAnimalPage");
            }
        }
        //Animal page
        [HttpGet]
        public IActionResult EditAnimalPage(int id)
        {
            ViewBag.Categories = _service.GetCategories();
            ViewBag.AnimalID = id;
            Animal animal = _service.getOneAnimal(id);
            AnimalViewModel demo = new AnimalViewModel { Name = animal.Name, Age = animal.Age, Description = animal.Description, CategoryId = animal.CategoryId };
            return View(demo);
        }

    }
}
