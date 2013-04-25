# Querying Windows Active Directory (AD) with scriptcs

## Running the sample
* Make sure scriptcs is [installed](https://github.com/scriptcs/scriptcs-samples/blob/master/README.md)
* Create a text file called credentials.txt with lines of AD credentials in `DOMAIN\User` format
* Run `scriptcs start.csx`
* A new file will be created called fullnames.txt which includes the account names from AD

## Comments

Sample credentials.txt (between the xxxxx):

xxxxx
DOMAINA\asm
DOMAINA\ani
DOMAINA\gan
DOMAINB\bte
xxxxx

Sample fullnames.txt output file (between the xxxxx):

xxxxx
DOMAINA\asm, Andrew Smith
DOMAINA\ani, Adam Nice
DOMAINA\gan, George Andrews
DOMAINB\bte, Brian Tennison
xxxxx