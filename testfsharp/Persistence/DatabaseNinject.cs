using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Persistence
{
	// Pros:
  //       best control of memory usage
	// Cons:
  //       test/production mixed
	//       more boilerplate
	//       highly dynamic == weird runtime issues
	//       test-only interfaces
	//       injects hundreds more functions than necessary
	//       Moq or Rhino mocks
	public class AgreementRepositoryNinject {
		private AgreementORM AgreementORM;
		private Logging Logging;

		//[Inject]
		public AgreementRepositoryNinject(AgreementORM a, Logging l) {
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
	public interface IKernel {
		T Get<T>();
	}
}
