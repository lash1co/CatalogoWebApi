using Autofac;
using Autofac.Integration.WebApi;
using CatalogoWebApi.DataAccess;
using CatalogoWebApi.Models;
using CatalogoWebApi.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CatalogoWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //var builder = new ContainerBuilder();
            //builder.RegisterType<ProductoRepository>().As<IProductoRepository>();
            //builder.RegisterType<CategoriaRepository>().As<ICategoriaRepository>();
            //builder.RegisterType<ProductoService>().As<IProductoService>();
            //builder.RegisterType<CategoriaService>().As<ICategoriaService>();
            //var container = builder.Build();
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
