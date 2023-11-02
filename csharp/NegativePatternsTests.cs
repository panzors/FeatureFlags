namespace FeatureFlags.Tests
{
    public class NegativePatternsTests 
    {
        [Setup, BeforeEach]
        public NegativePatternsTests() 
        {
            // Your mocking library will definitely result in returning false most instances.
            // Avoid leaving this as default because it probably will be default(bool) = false
            // Or if you must, be intentional about setting it to Returns(false)
            _featureService = new Mock<IFeatureService>();
            // FIX: 
            // _featureService.Setup(x => x.Evaluate("flag-name")).Returns(true);
            _sut = new Pattern(_featureService.Object, ...otherServices);
        }

        /// Avoid attaching the flag on when building this test case
        [Test]
        public void Method_Load_Result()
        // FIX: public void Method_Load_Result()
        {
            var result = _sut.Method();

            // Arbitrary validation
            result.Data.Should().Be(10);
            _mock.FlaggOnRoute().WasCalled(1);
        }

        [Test]
        public void Method_FullyActive_Result()
        {
            // It's not easy to understand what should happen here. Are there other flags?
            _featureService.Setup(x => x.Evaluate(It.IsAny<string>(), It.IsAny<string>())).Return(true);
            var result = _sut.Method();

            // Arbitrary validation
            result.Data.Should().Be(10);
            _mock.FlaggOnRoute().WasCalled(1);

            // This may happen?
            _mock.UnintendedRoute().WasCalled(??);
        }
    }

}
