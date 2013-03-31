
## NUnit CSX test runner:

## Running the sample
* Make sure scriptcs is [installed](https://github.com/scriptcs/scriptcs-samples/blob/master/README.md)
* Install packages `scriptcs -install`
* Run `scriptcs start.csx`
* This will run NUnit unit tests declared in the attached `MyUnitTests.dll` test assembly 

## Notes
You can replace the test assembly with your own if you want, in the `start.csx`:

	var path = "MyUnitTests.dll";
	var runner = TestSetup.GetRunner(new[] {path});

Array of assemblies can be passed too.