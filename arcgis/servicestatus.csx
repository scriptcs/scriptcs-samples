var arcgis = Require<ArcGISPack>();

var serverUrl = "https://localhost/arcgis";
var username= "";
var password = "";
if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
{
  Console.WriteLine("Uh-oh spaghetti-o, looks like you forgot to set the user credentials.");
}
else
{
  var gateway = arcgis.CreateGateway(serverUrl, new TokenProvider(serverUrl, username, password));
  var response = gateway.DescribeSite().Result;

  Console.WriteLine(String.Format("Checking service statuses for {0}", gateway.RootUrl));
  foreach (var resource in response.Services)
  {
    // requires access to the admin site
    var status = gateway.ServiceStatus(resource).Result;
    if (!String.Equals(status.Actual, status.Expected, StringComparison.OrdinalIgnoreCase))
      Console.WriteLine(String.Format("NOT {2} : {0} ({1})", resource.Name, resource.Type, status.Expected));
    else
      Console.WriteLine(String.Format("{2} : {0} ({1})", resource.Name, resource.Type, status.Actual));
  }
}
