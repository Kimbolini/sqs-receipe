using System.Runtime.Serialization;

namespace backend.Common
{
    [Serializable]
    public class InternalException : Exception
    {
        ///<Nullable>enable</Nullable>
        public InternalException(string message, Exception? exception) : base(message, exception)
        {

        }
        protected InternalException(SerializationInfo info, StreamingContext context)
        {
            //added protected constructor cause sonarcloud told me to.
        }
    }
}
