using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Persistence
{
	public class Logic
	{
		public string GetUserHtml() {
			var users = new Database().GetMovements();
			return users.Aggregate("<ul>", (ret, user)=> ret + UserHelpers.MakeLI(user)) + "</ul>";
		}
	}
	public class Database
	{
        public static PositionType GetPositionType (MovementType movementType, ApplyToParty applyToParty)
        {
            if ((movementType == MovementType.Deliver && applyToParty == ApplyToParty.Principal)
                || (movementType == MovementType.Return && applyToParty == ApplyToParty.Counterparty))
                return PositionType.Held;
            if ((movementType == MovementType.Return && applyToParty == ApplyToParty.Principal)
                || (movementType == MovementType.Deliver && applyToParty == ApplyToParty.Counterparty))
                return PositionType.Posted;

            return PositionType.Undefined;
        }
		public List<Movement> GetMovements() {
			return new List<Movement> {
				new Movement{Id=1,
					Name="pay back Steve", 
					ApplyToParty=ApplyToParty.Counterparty, 
					MovementType= MovementType.Deliver
				},
				new Movement{Id=2,Name="Bill pays me",
					ApplyToParty=ApplyToParty.Counterparty, 
					MovementType= MovementType.Deliver
				},
				new Movement{Id=3,Name="Bob owes Sally",
					ApplyToParty=ApplyToParty.Counterparty, 
					MovementType= MovementType.Deliver
				},
				new Movement{Id=4,Name="Sally paid Bill",
					ApplyToParty=ApplyToParty.Counterparty, 
					MovementType= MovementType.Deliver
				}
			};
		}
		public List<User> GetUsers() {
			return new List<User> {
				new User{Id=1,Name="steve"},
				new User{Id=2,Name="jim"},
				new User{Id=3,Name="bob"},
				new User{Id=4,Name="sally"}
			};
		}
	}
	public class Movement : IMovement,IIdentity {
		public int Id { get; set; }
		public string Name { get; set; }
		public MovementType MovementType {get;set;}
		public ApplyToParty ApplyToParty {get;set;}
	}
	public class User : IIdentity {
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
