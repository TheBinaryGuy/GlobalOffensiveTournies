using GlobalOffensive.WebAPI.Data;
using GlobalOffensive.WebAPI.Services;
using ServiceStack.OrmLite;
using System.Configuration;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.WebApi;

namespace GlobalOffensive.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            var IsMySql = ConfigurationManager.AppSettings["DbToUse"].ToString() == "MySql";
            var connString = IsMySql ?
                ConfigurationManager.ConnectionStrings["MySql"].ToString() :
                ConfigurationManager.ConnectionStrings["SqlServer"].ToString();
            var dialect = IsMySql ? MySqlDialect.Provider : SqlServerDialect.Provider;

            container.RegisterSingleton<AppConnFactory>(new InjectionFactory(c => new AppConnFactory(connString, dialect)));
            container.RegisterType<ITournamentService, TournamentService>();
            container.RegisterType<IMatchService, MatchService>();

            config.DependencyResolver = new UnityDependencyResolver(container);

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}