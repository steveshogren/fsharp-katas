using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Persistence
{

	// Pros: compiler safe
	//       explicit
	// Cons: test/production mixed
	//       very wordy
	//       test-only interfaces
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

	public delegate void LogError(string id);
	public class Logging {
		public void LogError(string id) {
			throw new NotImplementedException();
		}	
	}
	public delegate Agreement GetById(string id);
	public class AgreementORM {
		public Agreement GetById(string id) {
			throw new NotImplementedException();
		}	
	}
	public class Agreement {}
}
