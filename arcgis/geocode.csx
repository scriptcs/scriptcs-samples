var arcgis = Require<ArcGISPack>();

var gateway = arcgis.CreateGateway("http://geocode.arcgis.com/arcgis");
var geocode = new SingleInputGeocode("/World/GeocodeServer/".AsEndpoint())
{
  Text = "London"
};
var resultGeocode = gateway.Geocode(geocode).Result;
foreach (var result in resultGeocode.Results)
{
  var feature = result.Feature;
  Console.WriteLine(String.Format("{0}, x:{1:N6}, y:{2:N6}", result.Name, feature.Geometry.X, feature.Geometry.Y));
}
