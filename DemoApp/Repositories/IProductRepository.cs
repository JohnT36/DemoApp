using DemoApp.Models;
using System.Collections.Generic;

namespace DemoApp.Repositories
{
    public interface IProductRepository
    {
        
        public IEnumerable<Product> GetProducts();
        public Product GetProduct(int id);
        public void UpdateProduct(Product product);
        public void CreateProduct(Product prodToCreate);
        public void DeleteProduct(Product product);
        public IEnumerable<Category> GetCategories();
        public Product AssignCategory();






    }
}
