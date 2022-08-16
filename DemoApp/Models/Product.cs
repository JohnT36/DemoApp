using System.Collections.Generic;

namespace DemoApp.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public int Sold { get; set; }
        public string Url { get; set; }
        public string Ingredients { get; set; }
        public IEnumerable<Category> Categories { get; set; }



    }
}
