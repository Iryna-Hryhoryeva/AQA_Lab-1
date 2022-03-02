namespace TASK_6;

public class PhoneNotFoundException : Exception
{
    public PhoneNotFoundException()
    {
    }

    public PhoneNotFoundException(string message) : base(message)
    {
    }

    public PhoneNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }
}

public class StoreNotFoundException : Exception
{
    public StoreNotFoundException()
    {
    }

    public StoreNotFoundException(string message) : base(message)
    {
    }

    public StoreNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }
}
