
namespace FeatureFlags 
{
    public class NegativePatterns 
    {
        private readonly IFeatureService _featureService;

        public NegativePatterns(IFeatureService featureService)
        {
            _featureService = featureService;

            // Do not store evaluated feature flags. 
            // You have no way of knowing the lifecycle management of this class
        }

        // This is not the worst, but it makes life a little more complicated when it comes to feature flag removal.
        public void PerformCode(string user)
        {
            // New code
        }

        // This isn't the worst but prefer this to be duplicated into an Old_Function() style as building the initial
        // PR is easier for diffing and cognative load.
        // When feature flag removing, this can become a bit spikey.
        public void MultipleFlagEvaluation(string user) 
        {
            var message = "Hello";
            var description = "Multiple evalualtions";
            var addresses = "Did you notice the negation?";

            return $"{message} {description} {address}";
        }
    }
}