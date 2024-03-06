using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SecondBrain.Customization.ModelBinders;

namespace SecondBrain.Models
{
    [ModelBinder(typeof(QueryInputModelBinder))]
    public class QueryInputModel
    {

        public QueryInputModel(string search, string orderBy, bool ascending, int pageNumber, int pageSize)
        {
            Search = search ?? "";
            OrderBy = orderBy ?? "Id";
            Ascending = ascending;
            PageNumber = Math.Max(1, pageNumber);
            
            PageSize = pageSize;
            Offset = (PageNumber - 1) * PageSize;

        }
        public string Search { get; set; }
        public string OrderBy { get; set; }
        public bool Ascending { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; }
        public int Offset { get; }
    }
}