using Ninject;
using SampleWebApi.Business;
using SampleWebApi.Business.Contracts;
using SampleWebApi.Business.CounterHelper;
using SampleWebApi.Business.PerformanceCounterHelper;
using SampleWebApi.Core;
using SampleWebApi.Core.Common.Contracts;
using SampleWebApi.Core.Common.Contracts.Log;
using SampleWebApi.Core.Log;
using SampleWebApi.Data.Contracts;
using SampleWebApi.Data2;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SampleWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            #region Ninject
            GlobalConfiguration.Configuration.DependencyResolver = new CustomNinjectDependencyResolver(CreateKernel());
            #endregion Ninject
            CreateAndSetupPerformanceCounter(GetPerformanceCounters());

        }

        protected void Application_End()
        {
            DisposePerformanceCounter(GetPerformanceCounters());
        }

        private IPerformanceCounter[] GetPerformanceCounters()
        {
            IPerformanceCounter[] performanceCounterArray = new IPerformanceCounter[] { NumberOfItems.Instance, AverageTimer32.Instance, AverageCount64.Instance };
            return performanceCounterArray;
        }

        private void CreateAndSetupPerformanceCounter(IPerformanceCounter[] counters)
        {
            foreach (var counter in counters)
            {
                counter.SetupCategory();
                counter.CreateCounters();
            }
        }

        private void DisposePerformanceCounter(IPerformanceCounter[] counters)
        {
            foreach (var counter in counters)
            {
                counter.Dispose();
            }
        }

        private IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<ILogger>().To<Logger>().InSingletonScope();
            kernel.Bind<IExchangeRateService>().To<ExchangeRateService>().InSingletonScope();
            kernel.Bind<IExchangeRateEngine>().To<ExchangeRateEngine>().InSingletonScope();
            return kernel;
        }
    }

    
}
