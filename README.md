# scriptcs samples

This repository is a collection of `scriptcs` samples. 

**Note**: to use samples that use HttpListener (Web API, ServiceStack, Nancy) you need to run CMD with elevation!

## Installing scriptcs (easy path)
* Install [chocolatey](http://chocolatey.org/)
* Install scriptcs using `cinst scriptcs -pre -source "http://www.myget.org/F/scriptcsnightly/"`

## Installing scriptcs (dev path)
* Clone the scriptcs repo at https://github.com/scriptcs/scriptcs and change to the dev branch
* Run the scriptcs build script `build.cmd`
* Add 'src/scriptcs/src/scriptcs/bin/Release' to your path.

## Running the samples
* Change to the folder of the sample you want to run.
* Install packages `scriptcs -install`
* Run the app `scriptcs start.csx` 

## Submit your own!
We are always looking for new, interesting samples and use cases!
Before sending a pull request with a new sample, please follow the below checklist:

* Include `packages.config` if you rely on Nuget packages. Only include the top level packages.
* Include `readme.md` describing what the sample is about, and how it should be used
* Make sure the sample runs against the latest version of `scriptcs` [dev branch](https://github.com/scriptcs/scriptcs/tree/dev)

If, during the process of creating a sample, you encounter/discover any issues with scriptcs, please make sure to [file an issue in the scriptcs repo](https://github.com/scriptcs/scriptcs/issues). If you discover an issue with a current sample, [file an issue in this repo](https://github.com/scriptcs/scriptcs.samples/issues)

## Community
Want to chat about your sample? You can find us on:

* [Twitter](https://twitter.com/scriptcsnet)
* [Google Groups](https://groups.google.com/forum/?fromgroups#!forum/scriptcs)
* [JabbR](https://jabbr.net/#/rooms/scriptcs)

## License 
All samples are available as [Apache 2 License](https://github.com/scriptcs/scriptcs-samples/blob/master/LICENSE.md)
