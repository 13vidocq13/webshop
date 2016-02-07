using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using EntitiesAndMapping.Mapping;

namespace TestWork_Nix
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        public static ISessionFactory SessionFactory = CreateSessionFactory();

        public static ISession CurrentSession
        {
            get { return (ISession)HttpContext.Current.Items["current.session"]; }
            set { HttpContext.Current.Items["current.session"] = value; }
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            CurrentSession = SessionFactory.OpenSession();
        }
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            if (CurrentSession != null)
                CurrentSession.Dispose();
        }
        protected static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
           .Database(MsSqlConfiguration.MsSql2005.ConnectionString(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=WebShop;Integrated Security=True"))
           .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CategoriesMap>())
           .BuildSessionFactory();
        }
    }
}