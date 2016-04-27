using System;
using FSharpLogic;

namespace testfsharp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			new SpiralMatrix ().runTests ();
			//UserHelpers.testReverse ();
		}
	}
}
