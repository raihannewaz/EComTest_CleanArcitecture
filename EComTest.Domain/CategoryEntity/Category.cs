using EComTest.Domain.ProductEntity;
using System.ComponentModel.DataAnnotations;


namespace EComTest.Domain.CategoryEntity
{
    public class Category
    {

        public int CategoryId { get; private set; }
        public string? CategoryName { get; private set; }



        public void CreateOrUpdateCategoryName(string categoryName)
        {
            CategoryName = categoryName;
        }

        public void UpdateCategory(int id, string categoryName)
        {
            CategoryId = id;
            CategoryName = categoryName;
        }



    }
}


