# Querying Windows Active Directory (AD) with scriptcs

## Running the sample
* Make sure scriptcs is [installed](https://github.com/scriptcs/scriptcs-samples/blob/master/README.md)
* Create a text file called credentials.txt with lines of AD credentials in `DOMAIN\User` format
* Run `scriptcs start.csx`
* A new file will be created called fullnames.txt which includes the account names from AD

## Comments

Sample credentials.txt (between the xxxxx):

xxxxx <br />
DOMAINA\asm <br />
DOMAINA\ani <br />
DOMAINA\gan <br />
DOMAINB\bte <br />
xxxxx

Sample fullnames.txt output file (between the xxxxx):

xxxxx <br />
DOMAINA\asm, Andrew Smith <br />
DOMAINA\ani, Adam Nice <br />
DOMAINA\gan, George Andrews <br />
DOMAINB\bte, Brian Tennison <br />
xxxxx