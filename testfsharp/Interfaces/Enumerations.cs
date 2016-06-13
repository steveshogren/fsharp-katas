using System;

namespace Interfaces
{
	public class Test {
		public void test(Func<DateTime> a) {
			throw new AggregateException();
		}
		public void tet2() {
			test (() => DateTime.Now);
		}
	}
	public enum MovementType
	{
		Undefined = 0,
		Deliver = 1,
		Return = 2
	}
	public enum ApplyToParty
	{
		Undefined = 0,
		Principal = 1,
		Counterparty = 2
	}
	public enum PositionType
	{
		Undefined = 0,
		Posted = 1,
		Held = 2
	}
}

