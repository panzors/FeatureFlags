
namespace FeatureFlags 
{
    public class NegativePatterns 
    {
        private readonly IFeatureService _featureService;
        private readonly bool _isOn;

        public NegativePatterns(IFeatureService featureService)
        {
            _featureService = featureService;

            // Do not store evaluated feature flags. 
            // You have no way of knowing the lifecycle management of this class
            _isOn = _featureService.Evaluate("flag-name", user);
        }

        // This is not the worst, but it makes life a little more complicated when it comes to feature flag removal.
        public void PerformCode(string user)
        {
            if (_featureService.Evaluate("flag-name", user)){
                // New code
            } else {
                // Old code
            }
        }

        // This isn't the worst but prefer this to be duplicated into an Old_Function() style as building the initial
        // PR is easier for diffing and cognative load.
        // When feature flag removing, this can become a bit spikey.
        public void MultipleFlagEvaluation(string user) 
        {
            var flagIsOn = _featureService.Evaluate("flag-name", user);
            var message = flagIsOn ? "Hello" : "World";
            var description = flagIsOn ? "Multiple evalualtions" : "Gets a bit complicated";
            var addresses = !flagIsOn ? "Concatenate the address": "Did you notice the negation?";

            if (!flagIsOn) {
                return message + description + address;
            }

            return $"{message} {description} {address}";
        }
    }
}