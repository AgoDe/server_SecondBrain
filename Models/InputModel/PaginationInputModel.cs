using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecondBrain.Customization.ModelBinders;

namespace SecondBrain.Models.InputModel
{
    [ModelBinder(typeof(PaginationInputModelModelBinder))]
    public class PaginationInputModel
    {
         public PaginationInputModel(int pageNumber, int pageSize)
        {
            PageNumber = Math.Max(1, pageNumber);
            PageSize = pageSize <= 0 ? 10 : pageSize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}