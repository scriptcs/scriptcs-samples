
## NUnit CSX test runner:

1. Install NUnit packages from Nuget `nuget install -o packages`
2. Create a `bin` folder and copy `nunit.core.interfaces.dll` and `nunit.core.dll` from `\packages\NUnit.Runners.2.6.2\tools\lib` to `bin`
3. Run `scriptcs start.csx`
4. This will run NUnit unit tests declared in the attached `MyUnitTests.dll` test assembly 

You can replace the test assembly with your own if you want, in the `start.csx`:

	var path = "MyUnitTests.dll";
	var runner = TestSetup.GetRunner(new[] {path});

Array of assemblies can be passed too.