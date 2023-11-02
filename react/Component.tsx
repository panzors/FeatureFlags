
// This is quite possibly the most common use for feature flags there is for rendering things.
// Single use evaluation that does renders a specific thing. 
const CommonUseCase = () => {
    const isFFOn = dispatch(selector.featureEnabled("flag-name"))
    return <div>
        {isFFOn && <span>hello</span>}
    </div>
}

// This is common for slightly larger components where you kind-of didn't want to create a new file 
// just for your inner render
const AlternativeCommonUseCase = () => {
    const isFFOn = dispatch(selector.featureEnabled("flag-name"))
    const user = dispatch(selector.getUser());
    const isLoading = dispatch(selector.getUserLoading());
    const loadingMessage = dispatch(selector.getUserLoadingCurrentStep());

    useEffect(() => {
        // This is a very common approach to use the positive case because it's easier to conceptualise
        if (isFFOn && loadingMessage === "Stage 1") {
            dispatch(somethingSpecial);
        }
    }, [isLoading, loadingMessage])
    const renderSection = () => {
        if (!isFFOn)
            return null;

        return <span>{user.name}</span>
    }
    return <div>{renderSection()}</div>
}

const BetterCommonUseCase = () => {
    const isFFOn = dispatch(selector.featureEnabled("flag-name"))
    if (!isFFOn){
        return <div>old route</div>
    }

    return <div>
        <span>hello</span>
    </div>
}

// There might be cases where duplicating entire files is much easier. Makes deletion and finding
// references much easier
// Duplication has its own flaws as you may encounter merge problems if the duplicate stays alive
const AbstractToParentInstead = () => {
    const isFFOn = dispatch(selector.featureEnabled("flag-name"))
    if (!isFFOn){
        return <OldComponent>old route</OldComponent>
    }
    
    return <Component>
        new route
    </Component>
}