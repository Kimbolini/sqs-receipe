using System;
using System.Runtime.Serialization;

namespace backend.Common
{
    [Serializable]
    public class HttpResponseException : Exception
    {
        public int Status { get; set; }
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
        
        protected HttpResponseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            //Without this constructor, deserialization will fail
        }
    }
}
