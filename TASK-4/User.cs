public class User
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    // DEV_NOTE: May be used someday...
    // public User(Guid id, string name, string surname)
    // {
    //     this.id = id;
    //     this.name = name;
    //     this.surname = surname;
    // }
}
