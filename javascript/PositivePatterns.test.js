describe("A well meaning example", () => {
    let flagResult;
    beforeEach(() => {
        jest.resetModules();
        
        // stubbing out a default is preferable at the beginning of the test
        flagResult = true
        jest.mock('./feature', (flagName) => {
            // do specify your flag name to be specific to help the next person remove it easier
            if (flagName === 'flag-name'){
                return flagResult;
            }

            return false;
        })
    })

    // It's entirely likely to forget to remove text from a test and then you're left with
    // descriptions that do not make any sense
    test("Draw a big circle", () => {
        const shape = subject.drawShape();
        expect(shape).tobe("big circle");
    })

    // Prefer to put additional flag notes into the old negative path
    test("Old Draw a big circle", () => {
        flagResult = false;
        const shape = subject.drawShape();
        expect(shape).tobe("circle");
    })
})

describe("An alternative example", () => {
    let flagResult;
    beforeEach(() => {
        jest.resetModules();
        
        // stubbing out a default is preferable at the beginning of the test
        flagResult = true
        jest.mock('./feature', (flagName) => {
            // do specify your flag name to be specific to help the next person remove it easier
            if (flagName === 'flag-name'){
                return flagResult;
            }

            return false;
        })
    })

    // It's entirely likely to forget to remove text from a test and then you're left with
    // descriptions that do not make any sense
    test("Draw a big circle", () => {
        const shape = subject.drawShape();
        expect(shape).tobe("big circle");
    })

    // Prefixing an entire category of tests to be the negative path could make life easier
    // for subsequent PRs.
    descirbe("With flag off", () => {
        beforeEach(() => {
            flagResult = false;
        })
        // Prefer to put additional flag notes into the old negative path
        test("Draw a big circle", () => {
            const shape = subject.drawShape();
            expect(shape).tobe("circle");
        })
    })
})