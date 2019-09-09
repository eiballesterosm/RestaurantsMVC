using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Data.Services;
using System.Web.Http;
using System.Web.Mvc;

namespace Website
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();
            //MVC
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //WebApi
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<InMemoryRestaurantData>().As<IRestaurantData>().SingleInstance();
            var container = builder.Build();
            //MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //WebApi
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}