using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Persistence
{
	// Pros:
  //       low boilerplate
	//       best control of memory usage
	// Cons:
	//       highly dynamic == weird runtime issues
	//       kernel everywhere
	//       breaks compiler
	//       test-only interfaces
	//       Moq or Rhino mocks
	public class AgreementRepositoryNinjectKernel {
		//[Inject]
		internal IKernel kernel;

		public Agreement FindById(string id) {
			try {
				return kernel.Get<AgreementORM>().GetById(id);
			} catch (Exception e) {
				kernel.Get<Logging> ().LogError ("Missing");
				throw e;
			}
		}
	}
}
