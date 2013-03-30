# RavenDB with scriptcs

## Running the sample

* Make sure scriptcs is [installed](https://github.com/scriptcs/scriptcs-samples/blob/master/README.md)
* Install packages `scriptcs -install`
* Run `scriptcs start.csx`
* A browser will pop up with the RavenDB managemetn studio

## Comments

You're ouput should be a list of assemblies needed by RavenDB then the following:

Starting RavenDB Server, Please Be Patient...
RavenDB Started, Listening On http://localhost:8081

This will start a RavenDB embedded server instance. Currently the directory for you data is C:\scriptcs\ravendb. You can change this in the script to be anywhere you'd like.

Note: The server instance will only be available as long as the script is running.