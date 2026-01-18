using System.Transactions;
using NUnit.Framework;

namespace AppendixBDemos;

[TestFixture]
public class TransactionScopeTests
{
    [Test]
    public void MySimpleClass_DoSomething_ReturnsExpectedString()
    {
        var myClass = new MySimpleClass();

        var result = myClass.DoSomething();

        Assert.That(result, Is.EqualTo("Hello from MySimpleClass"));
    }

    [Test]
    public void MySimpleClass_Add_ReturnsCorrectSum()
    {
        var myClass = new MySimpleClass();

        var result = myClass.Add(2, 3);

        Assert.That(result, Is.EqualTo(5));
    }

    // Example of using TransactionScope for database rollback in tests
    // Uncomment and configure connection string to use
    /*
    [Test]
    public void DatabaseTest_WithTransactionScope_RollsBackChanges()
    {
        using var scope = new TransactionScope();
        // Perform database operations here
        // Changes will be rolled back when scope is disposed
        // without calling scope.Complete()
    }
    */
}
