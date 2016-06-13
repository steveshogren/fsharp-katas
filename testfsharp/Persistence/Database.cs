using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Persistence
{
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
				return this.AgreementORM.GetById(id);
			} catch (Exception e) {
				this.Logging.LogError ("Missing");
				throw e;
			}
		}
	}
	public class Logging {
		public void LogError(string id) {
			throw new NotImplementedException();
		}	
	}
	public class AgreementORM {
		public Agreement GetById(string id) {
			throw new NotImplementedException();
		}	
	}
	public class Agreement {}
}
