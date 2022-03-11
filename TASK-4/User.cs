namespace Persons;

public class User
{
    private Guid _id;
    private string _name;
    private string _surname;

    public Guid Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string Surname
    {
        get { return _surname; }
        set { _surname = value; }
    }
}
