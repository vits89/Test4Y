using Nancy;

namespace WebApp4Y.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", _ => "Hello World!");
        }
    }
}
