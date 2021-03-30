using System.Net;

namespace Api.Domain.Entities
{
    public class ErrorMessage
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
