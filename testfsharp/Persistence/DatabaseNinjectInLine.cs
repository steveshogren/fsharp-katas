using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Persistence
{
	// Pros:
  //       low boilerplate
	//       best control of memory usage
  //       easily mock at all levels
	// Cons:
  //       external uses of classes require DI container
	//       highly dynamic == weird runtime issues
	//       kernel everywhere
	//       test-only interfaces don't express intent
	//       Moq or Rhino mocks
  //       even easier to ignore design principles around coordination
  //       more implicit about dependencies than constructor injection
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


