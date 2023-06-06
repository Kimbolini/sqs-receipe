using System;

namespace backend.Common
{
    public class HttpResponseException : Exception
    {
        public int Status { get; set; } = 500;
        public string Value { get; set; }

        public HttpResponseException(int status, string message) : base()
        {
            this.Status = status;
            this.Value = message;
        }

        public HttpResponseException(int status, InternalException exception) : base()
        {
            this.Status = status;
            this.Value = exception.Message;
        }
    }
}
