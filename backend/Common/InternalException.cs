namespace backend.Common
{
    public class InternalException : Exception
    {
        ///<Nullable>enable</Nullable>
        public InternalException(string message, Exception? exception) : base(message, exception)
        {

        }
    }
}
