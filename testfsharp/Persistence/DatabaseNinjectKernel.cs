using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Persistence
{
	// Pros: Small
	//       implicit
	//       test-only code separated
	//       control memory usage
	// Cons: Dynamic
	//       kernel everywhere
	//       breaks compiler
	//       test-only interfaces
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
