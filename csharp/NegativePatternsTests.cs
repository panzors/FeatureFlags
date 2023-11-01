namespace FeatureFlags.Tests
{
    public class NegativePatternsTests 
    {
        [Setup]
        //[BeforeEach]
        public PatternTests() 
        {
            // Avoid leaving this as default because it probably will be default(bool) which is false
            // If you have an injection library, it is UNSAFE to assume true.
            _featureService = new Mock<IFeatureService>();
            _sut = new Pattern(_featureService.Object, ...otherServices);
        }

        // Avoid attaching the flag on when building this test case
        [Test]
        public void Method_Load_FlagNameOn_Result()
        {
            _featureService.Setup(x => x.Evaluate("flag-name", "customer")).Return(true);
            var result = _sut.Method();

            // Arbitrary validation
            result.Data.Should().Be(10);
            _mock.FlaggOnRoute().WasCalled(1);
        }

        // While your CI tool will track this stat, it's better to change the name as FF-off state is
        // the unusual path. Always build as the future state.
        [Test]
        public void Method_Load_Result()
        {
            // Letting this slip through "as default action" will cause you to miss this test when you remove it
            // It will also prompt an internal debate of "wait, is this intended behaviour?"
            // _featureService.Setup(x => x.Evaluate("flag-name", "customer")).Return(false);
            var result = _sut.Method();

            // Arbitrary validation
            result.Data.Should().Be(22);
            _mock.FlaggedOffRoute().WasCalled(1);
        }

        [Test]
        public void Method_FullyActive_Result()
        {
            // Do not do this as it has unintended consequences if you ever have more than 1 flag present.
            // Always specify EXACTLY what's going on.
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
