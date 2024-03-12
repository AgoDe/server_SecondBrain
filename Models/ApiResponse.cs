using System.Net;
using SecondBrain.Models.Dto;

namespace SecondBrain.Models
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            ErrorMessages = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
        public PaginationDto Pagination { get; set; }
        public QueryDto Query { get; set; }
    }
}