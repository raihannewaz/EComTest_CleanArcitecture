using EComTest.Domain.ProductEntity;
using System.ComponentModel.DataAnnotations;


namespace EComTest.Domain.CategoryEntity
{
    public class Category
    {

        public int CategoryId { get; private set; }
        public string? CategoryName { get; private set; }

        private Category()
        {

        }

        private Category(string name)
        {
            CategoryName = name;
        }

        public static Category Create(string name)
        {
            return new Category(name);
        }



        public void UpdateCategory(string categoryName)
        {

            CategoryName = categoryName;
        }


    }
}


