using System;

namespace Interfaces
{
	public interface IIdentity {
		int Id { get; set; }
		string Name { get; set; }
	}
	public interface IMovement {
		int Id { get; set; }
		string Name { get; set; }
		MovementType MovementType {get;set;}
		ApplyToParty ApplyToParty {get;set;}
	}
}

