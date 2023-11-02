/// There are times when you need to actively tag everything and or make it very obvious that this
/// test needs to be removed when you remove the feature flag.
public class ForgettingTests
{
    /// When the feature flag is removed, one of these your build will now fail.
    [Test]
    [FeatureFlag("flag-name", true)]
    public void Method_NormalOperation_ReturnsNewValues()
    {
        var result = _sut.Method();

        result.Property1.should().be("Property 1++");
        result.Property2.should().be("Property 2++");
        result.Property3.should().be("Property 3++");
    }
}