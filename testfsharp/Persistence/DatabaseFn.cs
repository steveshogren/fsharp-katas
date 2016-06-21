using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Persistence
{
	// Pros:
	//       interfaces reserved only for polymorphism
	//       no more Moq or Rhino mocks!
  //       only injecting needed functions
	//       local dependency wiring
	// Cons:
  //       namespacing/long fn names
	//       higher memory consumption from generated classes?
	//       N lines of test-only interfaces becomes N-2 lines of test-only delegates
	public class AgreementRepositoryFn {
		private AgreementRepository.GetById AgreementRepository_GetById = new AgreementORM().GetById;
		private Logging.LogError Logging_LogError = new Logging().LogError;

		public Agreement FindById(string id) {
			try {
				return AgreementRepository_GetById(id);
			} catch (Exception e) {
				Logging_LogError ("Missing");
				throw e;
			}
		}
	}
}


// Recommendations:
// - Convert 3+ Delegates from the same class into an interface expressing that intent, not the ICLASSNAME
// - Store Delegates inside the class, and reference it with the classname
// - Name fields like CLASSNAME_FNNAME for a useful local namespace
// - Prefer to use a lambda over a mock if at all possible
