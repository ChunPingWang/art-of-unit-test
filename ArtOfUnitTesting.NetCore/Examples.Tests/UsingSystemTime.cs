using Examples;
using NUnit.Framework;

namespace Examples.Tests;

[TestFixture]
public class TestsWithTime
{
    [Test]
    public void SettingSystemTime_Always_ChangesTime()
    {
        SystemTime.Set(new DateTime(2000, 1, 1));

        string output = TimeLogger.CreateMessage("a");

        Assert.That(output, Does.Contain("2000"));
    }

    [TearDown]
    public void AfterEachTest()
    {
        SystemTime.Reset();
    }
}
