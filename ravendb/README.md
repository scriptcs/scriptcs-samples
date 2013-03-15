*Instructions*

- Install nuget somewhere in your path.
- Install scriptcs somewhere in your path.
- Download this gist to a folder.
- From that directory, run 'nuget install .\packages'
- Then run 'scriptcs start.csx'

*Comments*

You're ouput should be a list of assemblies needed by RavenDB then the following:

Starting RavenDB Server, Please Be Patient...
RavenDB Started, Listening On http://localhost:8081

You will also notice that your browser will pop up with the RavenDB management studio.

This will start a RavenDB embedded server instance. Currently the directory for you data is C:\scriptcs\ravendb. You can change this in the script to be anywhere you'd like.

Note: The server instance will only be available as long as the script is running.