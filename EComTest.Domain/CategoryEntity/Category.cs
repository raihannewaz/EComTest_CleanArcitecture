using EComTest.Domain.ProductEntity;
using System.ComponentModel.DataAnnotations;


namespace EComTest.Domain.CategoryEntity
{
    public class Category
    {
        [Key]
        public int CategoryId { get; private set; }
        public string? CategoryName { get; private set; }

        public ICollection<Product>? Product { get; set; }



        public void CreateCategory(string categoryName)
        {
            CategoryName = categoryName;
        }

        public void UpdateCategory(int id, string categoryName)
        {
            CategoryId = id;
            CategoryName = categoryName;
        }


        public void UpdateCategoryName(string newName)
        {
            CategoryName = newName;
        }


    }
}


