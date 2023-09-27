using System.Net;

namespace WebApi
{
    public class Dtos
    {
        public record CqrsResponse
        {
            public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

            public string ErrorMessage { get; set; }

        }

    }
}
