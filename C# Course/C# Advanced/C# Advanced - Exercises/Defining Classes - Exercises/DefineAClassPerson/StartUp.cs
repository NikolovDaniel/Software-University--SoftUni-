using System;

namespace DefineAClassPerson
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person personOne = new Person()
            {
                Age = 20,
                Name = "Peter"
            };

            Person personTwo = new Person()
            {
                Age = 18,
                Name = "George"
            };

            Person personThree = new Person()
            {
                Age = 43,
                Name = "Jose"
            };
        }
    }
}
