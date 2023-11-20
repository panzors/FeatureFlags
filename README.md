# FeatureFlags
This repository is meant to be used to distribute knowledge. Please feel free to browse and modify or even steal. Most of these ideas are simply just ideas. They are my personal best guess for what should be ideal so there's still room for improvement as I get more feedback.

## Learning Modules

1. What is a feature flag [What is a feature flag](./docs/Introduction.md) - Skip this if you're aware of the concept
1. [General best practice](./docs/BestPractice.md) - Skip this if you're a cool cat


## What's in this?
This repo probably will not compile as they are code snippets that I'm going to use to demonstrate. Please check the pull requests to get the second part of the story.

## Learning

### Examples
- C# + unit tests
- React TS
- Javascript testing

## QR code for this repo
![Home](githubrepo.png)

## Learning module
This is not a tutorial on how to bolt you feature flag into your system. It can be a config file, it can be using a 3rd party application, it can be reading from a s3 bucket. Howver you do it is fine but some patterns will still hold true.

What this will not cover is how to handle compounding feature flags. That might be a side effect of your development cycle and you need to clean it up before going forward.

### General ettiquite
- Feature flags should be short lived. 
- Counter to common sense, you **should** violate DRY concepts. Prefer duplication over "smart injections". 
- Optimise for the flag removal pull-request as you've probably forgotten about this feature as it's been on for a few months.
- Have a constants file of the flag name in a central location for easier tracking. Avoid magic strings.
- Flag should always have positive english wording. Avoid "hide-address-form" if possible, instead prefer something without negativity "user-form-v2". It's not perfect but it implies direction.
- Add your flags in a single commit if possible or even a separate PR.
- Add your flags BEFORE logical code
- Initial commits should always be FF-off in non-dev environments. Mitigates risk
- Avoid concurrency and caching. Only do it if you HAVE TO.

### C# (~/csharp)


### React TS
React has a bit more complexity around it because of the way I've seen components get very large very quickly. There's also the concept of state stores and dispatches. A mix of actions/events vs transform data displayed. It's also quite hard to consider what a backing typescript file has access to.

### Javascript
Testing can easily get out of hand really quickly.

If you adhere to having a clean setup process and stub out the right defaults on calls it should alleviate a lot of the stressers.