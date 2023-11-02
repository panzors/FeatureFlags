
/// C# has standard defaults as a programming language
public class AssumedDefaultsTests 
{
    [Setup, BeforeEach]
    public AssumedDefaultsTests() 
    {
        // Your mocking library will definitely result in returning false most instances.
        // Avoid leaving this as default because it probably will be default(bool) = false
        // Or if you must, be intentional about setting it to Returns(false)
        _featureService = new Mock<IFeatureService>();
        // FIX: 
        // _featureService.Setup(x => x.Evaluate("flag-name")).Returns(true);
        _sut = new Service(_featureService.Object, ...otherServices);
    }
}