namespace FeatureFlags.Tests
{
    // Positive and negative flag values should exist for the test.
    // If that ends up with too many duplicated tests, that shows you have some refactoring to do
    public class PatternTests 
    {
        [Setup]
        //[BeforeEach]
        public PatternTests() 
        {
            _featureService = new Mock<IFeatureService>();

            _sut = new Pattern(_featureService.Object, ...otherServices);
        }

        [Test]
        public void Method_Load_Result()
        {
            var result = _sut.Method();

            // Arbitrary validation
            result.Data.Should().Be(10);
            _mock.FlaggOnRoute().WasCalled(1);
        }
    }

    // If you have a library that can support this, I highly recommend you inject it using attributes
    // See the flag removal PR for this.
    public class PatternBonusTests
    {
        [Test]
        public void Method_Load_Result()
        {
            var result = _sut.Method();

            // Arbitrary validation
            result.Data.Should().Be(10);
            _mock.FlaggOnRoute().WasCalled(1);
        }

    }
}
