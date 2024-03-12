using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SecondBrain.Customization.ModelBinders;

namespace SecondBrain.Models.Dto
{
    [ModelBinder(typeof(QueryDtoModelBinder))]
    public class QueryDto
    {
        public QueryDto(string search, string orderBy, bool ascending, DateTime? dateFrom, DateTime? dateTo, bool? isActive)
        {
            Search = search ?? "";
            OrderBy = orderBy ?? "Id";
            Ascending = ascending;
        }
        public string Search { get; set; }
        public string OrderBy { get; set; }
        public bool Ascending { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateFrom { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateTo { get; set; }
        public bool? isActive { get; set; }
    }
}