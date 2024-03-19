using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComTest.Application.CategoryCQRS.Command.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<int>
    {
        public int CatId { get; set; }
    }
}
