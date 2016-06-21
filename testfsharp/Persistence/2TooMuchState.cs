// Argument: Interface Injection Brings Unnecessary State

// When we bring in an interface, we are bringing in every single function on
// that interface. We often only use one or two functions on an interface, but
// most of our interfaces have many functions. This obscures the intent of the
// dependency without explicitly reading every function in the SUT to see what
// is used and how.

// Example: Which functions are used in these dependencies?

//IAgreementRepository agreementRepo (FindAll, FindById, Save, ...)
//IMarginCallRepository marginCallRepo (FindAll, FindById, Save, ... )

