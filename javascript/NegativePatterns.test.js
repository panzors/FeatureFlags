

describe("Negative examples", () => {

    // Avoid baking in the flag name into a test as removals may miss them and leave them hanging
    test("Draw a shape feature-abc flag=ON", () => {
        // ...
    })

    // Similar to above, easy to miss
    test("Draw a shape feature-abc flag=OFF", () => {
        // ...
    })

    // It appears to be a good use of parameters but the each[] condition should be for providing data.
    test.each([true, false])("Draw a shape feature flag=%s", (state) => {
        // Set the flag result in an each state
        flagResult = state;

        const result = doSomething();
    
        // It should be fine to duplicate your test. Don't fear duplication.

        if (state === true){
            expect(result.change).toBe("future state");
        } else {
            expect(result.change).toBe("previous state");
        }
        const shouldMessage = state ? "future state" : "previous state";
        expect(result.message).toBe(shouldMessage);

        expect(result.other).toContain("additional validations");

    })

    test.each([
        { flagState: true, payload: "future state"}, 
        { flagState: false, payload: "previous state"}
    ])("Draw a shape feature flag=%s", (state) => {
        flagResult = flagState;
        const result = doSomething();

        // Looks cleaver but hard to remove.
        expect(result.change).toBe(payload);
    })

    test("Execute standard payload", () => {
        // Sometimes a
    })

    test("Execute additional payload", () => {

    })
})

describe("Situation where you only need to validate a specific extra field", () => {
    test("SetProperties should set basic properties", () => {
        const result = setProperties();

        expect(result.propa).toBe("propa");
        expect(result.propb).toBe("propb");
    })

    // Engineers looking at this would be a bit doubtful removing this. It feels like it should
    // be part of the above test? It's a little unnecessary
    // You should duplicate the above test and validate everything. Unit tests are relatively 
    // cheat to execute, if they're not, you've got other problems. Respect future person's time.
    test("SetProperties should set additional properties", () => {
        jest.doMock('./feature', (flagName) => {
            return flagName === 'flag-name';
        })
        const result = setProperties();
        expect(result.propc).toBe("propc");
    })
})