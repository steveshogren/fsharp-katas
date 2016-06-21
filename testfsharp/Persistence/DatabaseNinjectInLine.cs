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
	//       test-only interfaces don't express intent
	//       Moq or Rhino mocks
	public class AgreementRepositoryNinjectKernel {
		//[Inject]
		internal IKernel kernel;

		public Agreement FindById(string id) {
			try {
				return kernel.Get<IAgreementORM>().GetById(id);
			} catch (Exception e) {
				kernel.Get<ILogging> ().LogError ("Missing");
				throw e;
			}
		}
	}

  // in another file...
  public class NinjectWiring {
      Bind<IAgreementORM>.To<AgreementORM>();
      Bind<ILogging>.To<Logging>();
  }
}



// Recommendations:
// - Always bind using transient scope
// - Put all bind methods in a CLASSNAME_BIND class next to the class, not in a "project-level" class

