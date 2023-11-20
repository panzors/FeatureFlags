# Introduction to feature flags

When developing an application that has a CI/CD mindest, it's often troublesome to manage code. This guide will not discuss the benifits and drawbacks of faster CI/CD.

To simplify, a feature flag is anything that switches based on a deployed setting 

```
if (setting.Invoices2Feature) {
    // do the thing
}
```

This can be as simple as a configuration file deployed with the application or fetched from the URL or a 3rd party hosted application.

## More advanced flags

More advanced flags are dependent on parameters you give it or, returns a percentage for rollout purposes

```
if (featureService.getState("flag-name", "Sam May")){
    // do the thing
}
```

```
if (featureService.getPercentage("flag-name", user.Id) > 0.9){
    // do the thing
}
```

Random evalulation is fine for some things but if it has customer impact, you need to be consistent. Consider a one way hash for a set of customer and modulate that value so customers do not get a weird on/off state as you ramp up to full release.

## Naming convention and intentions

Always have the feature flag OFF by default. It should always default to false if it can't evalualte.

Knowing that, name your features with that intention and be clear about it.

```
RefactoredGetCustomerRoute
CalculationV2
RecurringCustomerFlow
```

Note there are times when using "v2" "new" or even "feature" is fine. Avoid using terms like "Enabled" and especially avoid negative terms like "Disabled". It makes it easier to grok and evauluate in your head.


