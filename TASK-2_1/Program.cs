namespace Task2_1;

public static class Program
{
    public static void Main(string[] args)
    {
        var ticket = new Chatbot(Chatbot.InputName("surname"), Chatbot.InputName("name"), Chatbot.InputDate());

        Chatbot.ShowResult(ticket, RandomUtils.GetRandomTime());
    }
}
