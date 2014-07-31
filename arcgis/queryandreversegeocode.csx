var arcgis = Require<ArcGISPack>();

var gateway = arcgis.CreateGateway("http://sampleserver3.arcgisonline.com/ArcGIS");
var query = new Query(@"/Earthquakes/EarthquakesFromLastSevenDays/MapServer/0".AsEndpoint())
{
  Where = "magnitude > 5.2",
  ReturnGeometry = true,
  OutFields = new List<String> { "magnitude" }
};

var result = gateway.Query<Point>(query).Result;
var gatewayGeocode = arcgis.CreateGateway("http://geocode.arcgis.com/arcgis");

foreach (var feature in result.Features)
{
  var reverseGeocode = new ReverseGeocode("/World/GeocodeServer/".AsEndpoint())
  {
    Location = new Point
    {
      X = feature.Geometry.X,
      Y = feature.Geometry.Y,
      SpatialReference = new SpatialReference
      {
        Wkid = result.SpatialReference.Wkid
      }
    },
    Distance = 1000
  };
  try
  {
  var resultGeocode = gatewayGeocode.ReverseGeocode(reverseGeocode).Result;
  Console.WriteLine(String.Format("Magnitude {0} quake at {1}, {2}, {3}, {4}",
    feature.Attributes["magnitude"],
    resultGeocode.Address.AddressText,
    resultGeocode.Address.City,
    resultGeocode.Address.Region,
    resultGeocode.Address.CountryCode));
  }
  catch (Exception ex)
  {
    // some locations may not be at a valid address
    Console.WriteLine(String.Format("Magnitude {0} quake at x:{1:N6}, y:{2:N6}", feature.Attributes["magnitude"], feature.Geometry.X, feature.Geometry.Y));
  }
}
