using EComTest.Domain.CategoryEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Application.CategoryCQRS.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<List<Category>>
    {
        public int CatId { get; set; }

        public string sqlProc = "EXEC GetCategoryById";
    }
}
