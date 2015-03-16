# Parsing XML (with output to file) with scriptcs

## Running the sample
* Make sure you have ScriptCS installed.
* Make sure FileParse.csx and schema.xml files are in the same folder.
* Run "scriptcs FileParse.csx > output.txt" in command prompt.
* Output.txt file should appear in the same folder as the script and schema files.
* Remove "> output.txt" from command to output result to screen.

## Comments

The need for this example came about when we needed a working proof of concept of
command line driven linq query our DBAs could use as part of SQL job chain. We have data
stored in XML form and needed a flexible parsing solution that can be edited without
the need to compile anything that does the parsing.
