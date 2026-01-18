using System;
using Chapter5.LogAn;
using NSubstitute;
using NUnit.Framework;

namespace NSubExamples
{
    [TestFixture]
    public class NSubBasics
    {
        [Test]
        public void SubstituteFor_ForInterfaces_ReturnsAFakeInterface()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            Assert.That(fakeRules.IsValidLogFileName("something.bla"), Is.False);
        }

        [Test]
        public void Returns_ArgAny_IgnoresArgument()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            fakeRules.IsValidLogFileName(Arg.Any<string>()).Returns(true);

            Assert.That(fakeRules.IsValidLogFileName("anything, really"), Is.True);
        }

        [Test]
        public void Returns_ArgAny_Throws()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            fakeRules.When(x => x.IsValidLogFileName(Arg.Any<string>()))
                     .Do(x => { throw new Exception("fake exception"); });

            Assert.Throws<Exception>(() =>
                                     fakeRules.IsValidLogFileName("anything"));
        }

        [Test]
        public void Returns_ByDefault_WorksForHardCodedArgument()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            fakeRules.IsValidLogFileName("file.name").Returns(true);

            Assert.That(fakeRules.IsValidLogFileName("file.name"), Is.True);
        }

        [Test]
        public void RecursiveFakes_work()
        {
            IPerson p = Substitute.For<IPerson>();

            Assert.That(p.GetManager(), Is.Not.Null);
            Assert.That(p.GetManager().GetManager(), Is.Not.Null);
            Assert.That(p.GetManager().GetManager().GetManager(), Is.Not.Null);
        }

        public interface IPerson
        {
            IPerson GetManager();
        }
    }
}
