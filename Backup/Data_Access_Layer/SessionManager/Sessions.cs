using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Web;
using FluentNHibernate.Cfg.Db;
using EntitiesAndMapping.Mapping;
using FluentNHibernate.Cfg;

namespace Data_Access_Layer.SessionManager
{
    public class Sessions
    {
        protected static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
           .Database(MsSqlConfiguration.MsSql2005.ConnectionString(@"Data Source=(local)\SQLEXPRESS;Initial Catalog=WebShop;Integrated Security=True"))
           .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CategoriesMap>())
           .BuildSessionFactory();
        }

        public static ISessionFactory SessionFactory = CreateSessionFactory();
        
        public static ISession NewSession
        {
            get { return (ISession)HttpContext.Current.Items["current.session"]; }
            set { HttpContext.Current.Items["current.session"] = value; }
        }
    }
}
