using iThesaurus.Data.Repositories;
using iThesaurus.Data.Repositories.Abstract;
using iThesaurus.Data.Repositories.Concrete;
using iThesaurus.Domain.Abstract;
using iThesaurus.Domain.Concrete;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace iThesaurus
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            ConfigureContainer(container);
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        public static void ConfigureContainer(UnityContainer container)
        {
            container.RegisterType<IThesaurus, Thesaurus>();
            container.RegisterType<IWordRepository, WordRepository>();
            container.RegisterType<IUnitOfWork, ThesaurusContext>(new PerResolveLifetimeManager());
        }
    }
}