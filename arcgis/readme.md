# ArcGIS.PCL with ScriptCS

Demo of [ArcGIS.PCL](https://github.com/davetimmins/ArcGIS.PCL) running on [ScriptCS](https://github.com/scriptcs/scriptcs)

## Running the samples
* Make sure scriptcs is [installed](https://github.com/scriptcs/scriptcs-samples/blob/master/README.md)
* Install packages `scriptcs -install`
* Run the sample you want. The following are included
  * `scriptcs start.csx` - return a url for each service found for the ArcGIS Server specified
  * `scriptcs geocode.csx` - return the location of the text specified
  * `scriptcs reversegeocode.csx` - return the address of the location specified
  * `scriptcs servicestatus.csx` - check that each service for an ArcGIS Server site is in its configured state. This sample requires access to the ArcGIS Server admin REST API and you will need to put in your own server url, username and password.
  * `scriptcs query.csx` - query an ArcGIS Server service for features. In this case get the earthquakes for the past week with a magnitude greater than 4.5
  * `scriptcs queryandreversegeocode.csx` - example of combining a query operation with a reverse geocode to try and populate the location of the query results with an address

### Comments

The script pack allows you to create an ArcGIS Server gateway using

```csharp
var arcgis = Require<ArcGISPack>();
var gateway = arcgis.CreateGateway("http://localhost/arcgis");
```

The returned `gateway` supports the following as typed operations:

 * `Query<T>` - query a layer by attribute and / or spatial filters
 * `QueryForCount` - only return the number of results for the query operation
 * `QueryForIds` - only return the ObjectIds for the results of the query operation
 * `Find` - search across n layers and fields in a service
 * `ApplyEdits<T>` - post adds, updates and deletes to a feature service layer
 * `Geocode` - single line of input to perform a geocode using a custom locator or the Esri world locator
 * `Suggest` - lightweight geocode operation that only returns text results, commonly used for predictive searching
 * `ReverseGeocode` - find location candidates for a input point location
 * `Simplify<T>` - alter geometries to be topologically consistent
 * `Project<T>` - convert geometries to a different spatial reference
 * `Buffer<T>` - buffers geometries by the distance requested
 * `DescribeSite` - returns a url for every service discovered
 * `Ping` - verify that the server can be accessed
 * `PublicKey` - admin operation to get public key used for encryption of token requests
 * `ServiceStatus` - admin operation to get the configured and actual status of a service

In all cases above `T` is a geometry type of `Point`, `MultiPoint`, `Polyline`, `Polygon` or `Extent`

 If you need to call secure resources and your ArcGIS Server supports token based authentication then specify a `TokenProvider` in your call to `CreateGateway`

 ```csharp
 var arcgis = Require<ArcGISPack>();
 var gateway = arcgis.CreateGateway("http://localhost/arcgis", new TokenProvider("http://localhost/arcgis", "username", "password"));
 ```
