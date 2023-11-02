
namespace FeatureFlags{

    public class Pattern {
        private readonly IFeatureService _featureService;
        public Pattern (IFeatureService featureService) {
            _featureService = featureService;
        }

        public void FriendlyExample(string user) {
            // Continue...
        }
    }
}