using System;
using System.Net;

namespace AreaGeode.API
{
    public class HttpException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public HttpException(string message, HttpStatusCode code = HttpStatusCode.InternalServerError) : base(message)
        {
            StatusCode = code;
        }
    }
}
