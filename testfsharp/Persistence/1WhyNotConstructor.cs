// Argument: Dependencies Not Through The Constructor Are Harder To Use

// Someone said yesterday that they didn't like in-line Ninject because you have
// to read the SUT to see what needs to be mocked. This is true for all
// unit-testing with mocks. You _always_ have to read the function to see what
// to mock.

// For example, when presented with the following constructor and function,
// which of the two dependencies need to be mocked? Which functions?
public MarginCallService (IAgreementRepository agreementRepo,
                          IMarginCallRepository marginCallRepo) {...}
public SaveResponse SaveAgreements(List<Agreement> agreements) {...}
// The body of SaveAgreements must be read, regardless of the method used for
// injection



// Argument: In-Line Ninject Is Global State

// The argument that In-Line Ninject is "massive global state" is absolutely
// true, and remains true for all uses of Ninject: Property, Constructor, or
// In-Line. That is the point and power of Ninject: dynamic, global replacement
// of dependencies. In effect, any use of Ninject is a replacement of the
// language's dispatch table. Wiring Ninject through the Constructor does not
// prevent or protect us from that global state, it just makes it more explicit.

