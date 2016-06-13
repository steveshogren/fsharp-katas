using System;

namespace Persistence
{

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

