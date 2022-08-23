using Dapper;
using DemoApp.Models;
using System.Collections.Generic;
using System.Data;

namespace DemoApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;
        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public Product AssignCategory()
        {
            var categoryList = GetCategories();
            var product = new Product();
            product.Categories = categoryList;

            return product;
        }
        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;");
        }

        public IEnumerable<Product> GetProducts()
        {
            return _conn.Query<Product>("Select * from products;");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>($"Select * from products where productid = {id};");

        }
        
        public void UpdateProduct(Product product)
        {
            if (product.CategoryID == 0)
            {
                
            }
            _conn.Execute($@"UPDATE products SET Name = @Name,
                                                 Price = @Price,
                                                 CategoryID = @CategoryID,
                                                 URL = @Url, 
                                                 Ingredients = @Ingredients 
                                                 WHERE ProductID = {product.ProductID};", 
                                                 new { Name = product.Name, Price = product.Price, CategoryID = product.CategoryID, Url = product.Url, product.Ingredients });
        

        }

        public void CreateProduct(Product prodToCreate)
        {
            _conn.Execute($@"INSERT INTO products 
                                        (NAME, PRICE, CATEGORYID, URL, INGREDIENTS)
                                        VALUES (@name, @price, @categoryID, @url, @ingredients);",
                new { name = prodToCreate.Name, price = prodToCreate.Price, categoryID = prodToCreate.CategoryID, url = prodToCreate.Url, ingredients = prodToCreate.Ingredients });
        }

        public void DeleteProduct(Product product)
        {
            _conn.Execute($"Delete from products where productid = {product.ProductID};");
        }
    }
}
