using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Persistence
{
	// Pros: Small
	//       compiler safe
	//       test-only code separated
	//       no test-only interfaces
	// Cons: Lose namespacing/long fn names
	//       higher memory consumption
	//       need to delegate every fn
	public class AgreementRepositoryFn {
		private GetById AgreementRepository_GetById = new AgreementORM().GetById;
		private LogError Logging_LogError = new Logging().LogError;

		public Agreement FindById(string id) {
			try {
				return AgreementRepository_GetById(id);
			} catch (Exception e) {
				Logging_LogError ("Missing");
				throw e;
			}
		}
	}
}
