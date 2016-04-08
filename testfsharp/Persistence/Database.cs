using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;

namespace Persistence
{
	public class Logic
	{
		public string GetUserHtml() {
			var users = new Database ().GetUsers ();
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
				new Movement{Id=1,Name="steve"},
				new Movement{Id=2,Name="jim"},
				new Movement{Id=3,Name="bob"},
				new Movement{Id=4,Name="sally"}
			};
		}
	}
	public class Movement : IIdentity {
		public int Id { get; set; }
		public string Name { get; set; }
	}
}

