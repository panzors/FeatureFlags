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

            // This is one approach to doing this if you've got an init or setup step.
            // In development, always return true and explicitly mark false if you need.
            // This is also shippable if you want to create empty TDD tests.
            _featureService.Setup(x => x.Evaluate("flag-name", "customer")).Return(true);
            _sut = new Pattern(_featureService.Object, ...otherServices);
        }

        [Test]
        public void Method_Load_Result()
        {
            _featureService.Setup(x => x.Evaluate("flag-name", "customer")).Return(true);
            var result = _sut.Method();

            // Arbitrary validation
            result.Data.Should().Be(10);
            _mock.FlaggOnRoute().WasCalled(1);
        }

        // The FF-off state should have the additional "method name" associated with it.
        // This becomes apparent when you "Forget to remove tests" 
        [Test]
        public void Old_Method_Load_Result()
        {
            _featureService.Setup(x => x.Evaluate("flag-name", "customer")).Return(false);
            var result = _sut.Method();

            // Arbitrary validation
            result.Data.Should().Be(22);
            _mock.FlaggedOffRoute().WasCalled(1);
        }
    }

    // If you have a library that can support this, I highly recommend you inject it using attributes
    // See the flag removal PR for this.
    public class PatternBonusTests
    {
        [Test]
        [FeatureFlag("flag-name", true)]
        public void Method_Load_Result()
        {
            var result = _sut.Method();

            // Arbitrary validation
            result.Data.Should().Be(10);
            _mock.FlaggOnRoute().WasCalled(1);
        }

        [Test]
        [FeatureFlag("flag-name", false)]
        public void Old_Method_Load_Result()
        {
            var result = _sut.Method();

            // Arbitrary validation
            result.Data.Should().Be(22);
            _mock.FlaggedOffRoute().WasCalled(1);
        }
    }
}
