using System;
using FSharpLogic;
using NUnit.Core;
using NUnit.Framework;


namespace testfsharp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			new LevelTraversal ().runTests ();
			//new SpiralMatrix ().runTests ();
			//new AddNumbers ().runTests ();
			//UserHelpers.testReverse ();
		}
		/*
        public static void Main(String[] args)
        {
            //get from command line args
            String pathToTestLibrary = "/home/jack/programming/fsharppresentation/testfsharp/FSharpLogic/bin/Debug/FSharpLogic.dll"; 
            TestRunner runner = new TestRunner();
            runner.run(pathToTestLibrary);
        }

        public void run(String pathToTestLibrary)
        {
            CoreExtensions.Host.InitializeService();
            TestPackage testPackage = new TestPackage(@pathToTestLibrary);
            testPackage.BasePath = Path.GetDirectoryName(pathToTestLibrary);
            TestSuiteBuilder builder = new TestSuiteBuilder();
            TestSuite suite = builder.Build(testPackage);
            TestResult result = suite.Run(new NullListener(), TestFilter.Empty);

            Console.WriteLine("has results? " + result.HasResults);
            Console.WriteLine("results count: " + result.Results.Count);
            Console.WriteLine("success? " + result.IsSuccess);
        }
*/
	}
}
