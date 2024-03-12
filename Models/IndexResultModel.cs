using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecondBrain.Models.Dto;

namespace SecondBrain.Models
{
    public class IndexResultModel
    {
        public Object Result { get; set; }
        public PaginationDto Pagination { get; set; }
        public QueryDto Query { get; set; }
    }
}