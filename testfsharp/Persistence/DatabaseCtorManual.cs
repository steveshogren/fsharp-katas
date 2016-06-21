using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Persistence
{

	// Pros:
  //       compiler correctness checking preserved
	//       dependency wiring in-line
	// Cons:
  //       test/production mixed
	//       boilerplate
	//       test-only interfaces
	//       injects hundreds more functions than necessary
	//       Moq or Rhino mocks
	public class AgreementRepository {
		private AgreementORM AgreementORM;
		private Logging Logging;

		public AgreementRepository() :this(new AgreementORM(), new Logging()){ }

		public AgreementRepository(AgreementORM a, Logging l) {
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
