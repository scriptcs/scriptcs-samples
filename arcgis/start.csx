var arcgis = Require<ArcGISPack>();

var gateway = arcgis.CreateGateway("http://services.arcgisonline.com/arcgis");
var response = gateway.DescribeSite().Result;

Console.WriteLine(String.Format("Discovered services for {0}", gateway.RootUrl));
foreach (var resource in response.ArcGISServerEndpoints)
{
  Console.WriteLine(resource.RelativeUrl);
}
