using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Persistence
{

	// Pros:
	//       local dependency wiring
	// Cons:
	//       boilerplate
	//       test-only interfaces don't express intent
	//       injects hundreds more functions than necessary
	//       Moq or Rhino mocks
	public class AgreementRepository {
		private IAgreementORM AgreementORM;
		private ILogging Logging;

		public AgreementRepository() :this(new AgreementORM(), new Logging()){ }

		public AgreementRepository(IAgreementORM a, ILogging l) {
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

}
