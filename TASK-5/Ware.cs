namespace Task5;

public class Ware
{
    private string _id;
    private string _name;
    private string _category;
    private string _price;

    public string Id
    {
        get { return _id; }
        set { _id = value; }
    }
    
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    
    public string Category
    {
        get { return _category; }
        set { _category = value; }
    }
    
    public string Price
    {
        get { return _price; }
        set { _price = value; }
    }
}
