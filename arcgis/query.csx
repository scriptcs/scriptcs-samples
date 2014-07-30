var arcgis = Require<ArcGISPack>();

var gateway = arcgis.CreateGateway("http://sampleserver3.arcgisonline.com/ArcGIS");
var query = new Query(@"/Earthquakes/EarthquakesFromLastSevenDays/MapServer/0".AsEndpoint())
{
  Where = "magnitude > 4.5",
  ReturnGeometry = true,
  OutFields = new List<String> { "magnitude" }
};

var result = gateway.Query<Point>(query).Result;

foreach (var feature in result.Features)
{
  Console.WriteLine(String.Format("Magnitude {0} quake at x:{1:N6}, y:{2:N6}", feature.Attributes["magnitude"], feature.Geometry.X, feature.Geometry.Y));
}
