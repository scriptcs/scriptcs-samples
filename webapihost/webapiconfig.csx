public class ControllerResolver : DefaultHttpControllerTypeResolver
{
    public override ICollection<Type> GetControllerTypes(IAssembliesResolver assembliesResolver)
    {
        return Assembly.GetExecutingAssembly().GetTypes()
            .Where(x => typeof(System.Web.Http.Controllers.IHttpController).IsAssignableFrom(x)).ToList();
    }
}

var config = new HttpSelfHostConfiguration(new Uri("http://localhost:8080"));
config.Services.Replace(typeof(IHttpControllerTypeResolver), new ControllerResolver());
config.Routes.MapHttpRoute(
    name: "DefaultApi",
    routeTemplate: "api/{controller}/{id}",
    defaults: new { id = RouteParameter.Optional });
