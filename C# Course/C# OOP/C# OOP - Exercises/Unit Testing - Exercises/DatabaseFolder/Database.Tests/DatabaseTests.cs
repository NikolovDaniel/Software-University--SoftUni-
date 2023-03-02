using NUnit.Framework;
using System;


public class DatabaseTests
{
    private Database database;

    [SetUp]
    public void Setup()
    {
        database = new Database();
    }

    [Test]
    public void Ctor_IncrementArray()
    {
        int n = 3;

        for (int i = 0; i < n; i++)
        {
            database.Add(i);
        }

        Assert.That(database.Count, Is.EqualTo(n));
    }

    [Test]
    public void Ctor_InrecementOverLimit()
    {
        Assert.Throws<InvalidOperationException>(() => database = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 }));
    }

    [Test]
    public void Add_AddElementsInDb()
    {
        int n = 3;

        for (int i = 0; i < n; i++)
        {
            database.Add(i);
        }

        Assert.That(database.Count, Is.EqualTo(n));
    }

    [Test]
    public void Add_AddElementsOverLimit()
    {
        int n = 16;

        for (int i = 0; i < n; i++)
        {
            database.Add(i);
        }

        Assert.Throws<InvalidOperationException>(() => database.Add(17));
    }

    [Test]
    public void Remove_DecreaseElementsInDb()
    {
        int n = 3;

        for (int i = 0; i < n; i++)
        {
            database.Add(i);
        }

        database.Remove();

        int expectedLength = 2;

        Assert.That(database.Count, Is.EqualTo(expectedLength));
    }

    [Test]
    public void Remove_DecreaseElementsInEmptyDb()
    {
        Assert.Throws<InvalidOperationException>(() => database.Remove());
    }

    [Test]
    public void Fetch_CopyArrayAndCheckIfTheyAreEqual()
    {
        database = new Database(new int[] { 1, 2, 3 });

        int[] firstDatabase = database.Fetch();
        database.Add(4);
        int[] secondDatabase = database.Fetch();

        Assert.False(firstDatabase.Equals(secondDatabase));
    }

    [Test]
    public void Count_ValidateCountOfDb()
    {
        database = new Database(new int[] { 1, 2, 3 });

        int count = database.Count;

        Assert.That(database.Count, Is.EqualTo(count));
    }
}
