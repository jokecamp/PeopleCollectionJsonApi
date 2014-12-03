using Autofac;
using Autofac.Integration.WebApi;
using CollectionJson;
using PeopleCollectionJsonApi.DataAccess;
using PeopleCollectionJsonApi.Model;
using System.Web.Http;

namespace PeopleCollectionJsonApi
{
    public static class ServiceConfiguration
    {
        public static void Configure(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("default", "{controller}/{id}", new { id = RouteParameter.Optional });

            // Autofac
            var builder = new ContainerBuilder();

            // Register Data Access
            builder.RegisterType<PersonRepo>().As<IPersonRepo>();

            // Register Collection+JSON Serialization/Deserialization
            builder.RegisterType<PersonDocWriter>().As<ICollectionJsonDocumentWriter<Person>>();
            builder.RegisterType<PersonDocReader>().As<ICollectionJsonDocumentReader<Person>>();

            // Register Endpoints/Controllers
            builder.RegisterApiControllers(typeof(ServiceConfiguration).Assembly);

            builder.RegisterHttpRequestMessage(config);

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);

            config.DependencyResolver = resolver;
        }
    }
}
