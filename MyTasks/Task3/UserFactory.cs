namespace Persons;

using System;

// класс UserFactory, который в зависимости от типа пользователя (Employee, Candidate) будет возвращать необходимый объект.

public class UserFactory
{
    
    public User UserObject()
    {
        string input;
        
        Console.WriteLine("Введите тип пользователя: Employee или Candidate");
        input = Console.ReadLine();

        if (input == "Candidate")
        {
            var newCandidate = new Candidate();
            
            Console.WriteLine("Создан экземпляр класса Candidate");
            return newCandidate;
        }

        else if (input == "Employee")
        {
            var newEmployee = new Employee();
            
            Console.WriteLine("Создан экземпляр класса Employee");
            return newEmployee;
        }

        else
        {
            
            Console.WriteLine("Неизвестный тип пользователя");
            return null;
        }
    }
}