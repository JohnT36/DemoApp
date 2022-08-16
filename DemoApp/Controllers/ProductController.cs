using DemoApp.Models;
using DemoApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DemoApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }


        public IActionResult GetProductByCat(int CategoryID)
        {
            return View(_repo.GetProducts().Where(x => x.CategoryID == CategoryID));
             
        }
            
        public IActionResult PizzaPie()
        {
            var products = _repo.GetProducts();
            var prod = products.Where(x => x.CategoryID == 1);
            return View(prod);
        }

        public IActionResult PizzaSlice()
        {
            var products = _repo.GetProducts();
            var prod = products.Where(x => x.CategoryID == 2);
            return View(prod);
        }

        public IActionResult Salad()
        {
            var products = _repo.GetProducts();
            var prod = products.Where(x => x.CategoryID == 3);
            return View(prod);
        }

        public IActionResult Drink()
        {
            var products = _repo.GetProducts();
            var prod = products.Where(x => x.CategoryID == 5);
            return View(prod);
        }

        public IActionResult Dessert()
        {
            var products = _repo.GetProducts();
            var prod = products.Where(x => x.CategoryID == 4);
            return View(prod);
        }

        public IActionResult ViewProduct(int id)
        {
            var product = _repo.GetProduct(id);
            return View(product);
        }

        public IActionResult CreateProduct(Product product)
        {
            var prod = _repo.AssignCategory();
            
            return View(prod);

        }

        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            _repo.CreateProduct(productToInsert);

            if (productToInsert.CategoryID == 1)
            {
                return RedirectToAction("PizzaPie");
            }
            if (productToInsert.CategoryID == 2)
            {
                return RedirectToAction("PizzaSlice");
            }
            if (productToInsert.CategoryID == 3)
            {
                return RedirectToAction("Salad");
            }
            if (productToInsert.CategoryID == 4)
            {
                return RedirectToAction("Dessert");
            }
            if (productToInsert.CategoryID == 5)
            {
                return RedirectToAction("Drink");
            }

            return RedirectToAction("Index", "Home");


        }

        public IActionResult DeleteProduct(Product product)
        {
            _repo.DeleteProduct(product);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult UpdateProduct(int id)
        {
            var product = _repo.GetProduct(id);
            product.Categories = _repo.GetCategories();
            if (product == null)
            {
                return View("Error");
            }
            return View(product);
        }

        public IActionResult UpdateProductToDatabase(Product product)
        {
            _repo.UpdateProduct(product);

            switch (product.CategoryID)
            {
                case 1: return RedirectToAction("PizzaPie");
                case 2: return RedirectToAction("PizzaSlice");
                case 3: return RedirectToAction("Salad");
                case 4: return RedirectToAction("Dessert");
                case 5: return RedirectToAction("Drink");

                default: return RedirectToAction("Error");
                
            };


           //if (product.CategoryID == 1)
           //{
           //    return RedirectToAction("PizzaPie");
           //}
           //else if (product.CategoryID == 2)
           //{
           //    return RedirectToAction("PizzaSlice");
           //}
           //else if (product.CategoryID == 3)
           //{
           //    return RedirectToAction("Salad");
           //}
           //else if (product.CategoryID == 4)
           //{
           //    return RedirectToAction("Dessert");
           //}
           //else 
           //{
           //    return RedirectToAction("Drink");
           //}
            


            
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
