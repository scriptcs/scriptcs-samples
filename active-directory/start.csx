#r "System.DirectoryServices"

using System.DirectoryServices;
using System.IO;

var fullNames = new List<string>();

foreach (var credential in File.ReadAllLines("credentials.txt"))
{
    if (credential.IndexOf('\\') > 0)
    {
        var domain = credential.Substring(0, credential.IndexOf('\\'));
        var name = credential.Substring(credential.IndexOf('\\') + 1);

        var de = new DirectoryEntry("LDAP://" + domain.ToUpper());
        var search = new DirectorySearcher(de); 
        search.Filter = String.Format("(SAMAccountName={0})", name);
        search.PropertiesToLoad.Add("cn");
        SearchResult result = search.FindOne();

        if (result == null)
        {
            Console.WriteLine("{0} not found.", credential);
        }
        else
        {
			fullNames.Add(string.Format("{0}, {1}", credential, result.Properties["cn"][0].ToString()));            
        }
    }
}

File.WriteAllLines("fullnames.txt", fullNames);