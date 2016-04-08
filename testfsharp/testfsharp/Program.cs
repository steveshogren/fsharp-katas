using System;
using Persistence;

namespace testfsharp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			Console.WriteLine (String.Join(",", new Logic().GetUserHtml()));
		}
	}
}
