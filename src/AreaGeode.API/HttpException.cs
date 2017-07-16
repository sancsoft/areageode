using System;
using System.Net;

namespace AreaGeode.API
{
    /// <summary>
    /// Exception specific to HTTP transactions to facilitate errors from the API.  No idea
    /// why they don't have this in Core 
    /// </summary>
    public class HttpException : Exception
    {
        /// <summary>
        /// Http status code associated with the exception
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Create an HTTP specific exception with a conventional string exception message
        /// and an HTTP status code
        /// </summary>
        /// <param name="message"></param>
        /// <param name="code"></param>
        public HttpException(string message, HttpStatusCode code = HttpStatusCode.InternalServerError) : base(message)
        {
            StatusCode = code;
        }
    }
}
