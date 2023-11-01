
namespace FeatureFlags{

    public class Pattern {
        private readonly IFeatureService _featureService;
        public Pattern (IFeatureService featureService){
            _featureService = featureService;
        }

        public void FriendlyExample(string user) {
            // Use a short return for this example, there is an overwhelming consensus this is faster to evaluate
            if (_featureService.Evaluate("flag-name", user) == false){
                return Old_FriendlyExample(user);
            }

            // existing code
            // Continue...
        }

        private void Old_FriendlyExample(string user) {
            // Still working code
        }
    }
}