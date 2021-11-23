using NUnit.Framework;
using System;

public class ExtendedDatabaseTests
{
    private Person person;
    private ExtendedDatabase personDb;
    private Person p1;
    private Person p2;

    [SetUp]
    public void Setup()
    {
        personDb = new ExtendedDatabase();
    }

    [Test]
    public void FindById_ThrowExceptionIfUsernameWithGivenIdDoesNotExist()
    {
        int id = 50;

        Assert.Throws<InvalidOperationException>(() => personDb.FindById(id));
    }

    [Test]
    public void FindById_ThrowExceptionWhenIdIsNegativeNumber()
    {
        int negativeId = -1;

        Assert.Throws<ArgumentOutOfRangeException>(() => personDb.FindById(negativeId));
    }

    [Test]
    public void FindById_FindUserSuccessfully()
    {
        int findId = 1;

        p1 = new Person(1, "Pesho");
        personDb = new ExtendedDatabase(new Person[] { p1 });

        p2 = personDb.FindById(findId);

        Assert.That(p1, Is.EqualTo(p2));
    }

    [Test]
    public void FindByUsername_ThrowExceptionIfUsernameWithGivenNameDoesNotExist()
    {
        string name = "Nikolai";

        Assert.Throws<InvalidOperationException>(() => personDb.FindByUsername(name));
    }

    [Test]
    public void FindByUsername_ThrowExceptionWhenUsernameIsEmpty()
    {
        string emptyName = "";

        Assert.Throws<ArgumentNullException>(() => personDb.FindByUsername(emptyName));
    }

    [Test]
    public void FindByUsername_ThrowExceptionWhenUsernameIsNull()
    {
        string nullName = null;

        Assert.Throws<ArgumentNullException>(() => personDb.FindByUsername(nullName));
    }

    [Test]
    public void FindByUsername_FindPersonSuccessfully()
    {
        string findName = "Pesho";

        p1 = new Person(1, "Pesho");
        personDb = new ExtendedDatabase(new Person[] { p1 });

        p2 = personDb.FindByUsername(findName);

        Assert.That(p1, Is.EqualTo(p2));
    }

    [Test]
    public void Remove_RemovePersonFromArraySuccessfully()
    {
        p1 = new Person(1, "1");
        p2 = new Person(2, "2");

        int expectedCount = 1;

        personDb = new ExtendedDatabase(new Person[] { p1, p2 });
        personDb.Remove();

        Assert.That(personDb.Count, Is.EqualTo(expectedCount));
    }

    [Test]
    public void Remove_ThrowExceptionWhenRemovingFromEmptyArray()
    {
        Assert.Throws<InvalidOperationException>(() => personDb.Remove());
    }

    [Test]
    public void Add_ThrowExceptionWhenTwoIdAreTheSame()
    {
        p1 = new Person(1, "Pesho");
        p2 = new Person(1, "Pesho1");

        personDb.Add(p1);

        Assert.Throws<InvalidOperationException>(() => personDb.Add(p2));
    }

    [Test]
    public void Add_ThrowExceptionWhenTwoNamesAreTheSame()
    {
        p1 = new Person(1, "Pesho");
        p2 = new Person(2, "Pesho");

        personDb.Add(p1);

        Assert.Throws<InvalidOperationException>(() => personDb.Add(p2));
    }

    [Test]
    public void Add_ThrowExceptionWhenExceedRange()
    {
        int n = 16;

        Person[] people = new Person[n];

        for (int i = 0; i < n; i++)
        {
            person = new Person(i, $"Pesho{i}");

            people[i] = person;
        }

        personDb = new ExtendedDatabase(people);

        Assert.Throws<InvalidOperationException>(() => personDb.Add(new Person(1321, "Peshog123")));
    }

    [Test]
    public void Add_AddPersonWithinRange()
    {
        int n = 3;

        p1 = new Person(1, "Pesho1");
        p2 = new Person(2, "Pesho2");

        personDb = new ExtendedDatabase(new Person[] { p1, p2 });

        personDb.Add(new Person(3, "Pesho3"));

        Assert.That(personDb.Count, Is.EqualTo(n));
    }

    [Test]
    public void ExtendedDatabaseCtor_ThrowExceptionWhenTwoIdAreTheSame()
    {
        p1 = new Person(1, "Pesho1");
        p2 = new Person(1, "Pesho2");

        Person[] people = new Person[] { p1, p2 };

        Assert.Throws<InvalidOperationException>(() => personDb = new ExtendedDatabase(people));
    }

    [Test]
    public void ExtendedDatabaseCtor_ThrowExceptionWhenTwoNamesAreTheSame()
    {
        p1 = new Person(1, "Pesho");
        p2 = new Person(2, "Pesho");

        Person[] people = new Person[] { p1, p2 };

        Assert.Throws<InvalidOperationException>(() => personDb = new ExtendedDatabase(people));
    }

    [Test]
    public void ExtendedDatabaseCtor_ThrowExceptionWhenPeopleExceedLength()
    {
        int n = 17;

        Person[] people = new Person[n];

        for (int i = 0; i < n; i++)
        {
            person = new Person(i, $"Pesho{i}");

            people[i] = person;
        }

        Assert.Throws<ArgumentException>(() => personDb = new ExtendedDatabase(people));
    }

    [Test]
    public void ExtendedDatabaseCtor_AddValidNumberOfPersonInArray()
    {
        int n = 16;

        Person[] people = new Person[n];

        for (int i = 0; i < n; i++)
        {
            person = new Person(i, $"Pesho{i}");

            people[i] = person;
        }

        personDb = new ExtendedDatabase(people);

        Assert.That(personDb.Count, Is.EqualTo(n));
    }

    [Test]
    public void PersonCtor_CreateValidPerson()
    {
        person = new Person(123, "Pesho");

        Assert.That(person.UserName == "Pesho" && person.Id == 123);
    }
}
