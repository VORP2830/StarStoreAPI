namespace StarStore.Domain.Exceptions;

public class StarStoreException : Exception
{
    public StarStoreException(string message) : base(message) { }
    public static void When(bool hasError, string error)
    {
        if (hasError)
        {
            throw new StarStoreException(error);
        }
    }
}