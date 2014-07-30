var arcgis = Require<ArcGISPack>();

var gateway = arcgis.CreateGateway("http://geocode.arcgis.com/arcgis");
var reverseGeocode = new ReverseGeocode("/World/GeocodeServer/".AsEndpoint())
{
  Location = new Point
  {
    X = 174.775505,
    Y = -41.290893,
    SpatialReference = new SpatialReference
    {
      Wkid = SpatialReference.WGS84.LatestWkid
    }
  }
};
var result = gateway.ReverseGeocode(reverseGeocode).Result;
Console.WriteLine(String.Format("{0}, {1}, {2}, {3}",
  result.Address.AddressText,
  result.Address.City,
  result.Address.Region,
  result.Address.CountryCode));
