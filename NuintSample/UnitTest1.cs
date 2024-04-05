namespace NuintSample
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Hello worls");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}