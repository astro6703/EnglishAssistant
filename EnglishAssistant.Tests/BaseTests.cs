using NUnit.Framework;

namespace EnglishAssistant.Tests
{
    [TestFixture]
    public class BaseTests
    {
        [Test]
        public void Test()
        {
            Assert.That(true, Is.True);
        }
    }
}