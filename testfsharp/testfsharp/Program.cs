using System;
using FSharpLogic;

namespace testfsharp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			new HasCycle ().runTests ();
			//new SpiralMatrix ().runTests ();
			//new AddNumbers ().runTests ();
			//UserHelpers.testReverse ();
		}
	}
}
