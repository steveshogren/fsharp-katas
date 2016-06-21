using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Persistence
{
	// Pros:
  //       best control of memory usage
	// Cons:
	//       boilerplate
	//       highly dynamic == weird runtime issues
	//       test-only interfaces don't express intent
	//       injects hundreds more functions than necessary
	//       Moq or Rhino mocks
	public class AgreementRepositoryNinject {
		private IAgreementORM AgreementORM;
		private ILogging Logging;

		//[Inject]
		public AgreementRepositoryNinject(IAgreementORM a, ILogging l) {
			this.AgreementORM = a;
			this.Logging = l;
		}

		public Agreement FindById(string id) {
			try {
				return AgreementORM.GetById(id);
			} catch (Exception e) {
				Logging.LogError ("Missing");
				throw e;
			}
		}
	}

  // in another file...
	public interface IKernel {
		T Get<T>();
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
