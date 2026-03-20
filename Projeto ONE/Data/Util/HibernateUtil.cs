using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Projeto_ONE.Data.Mapping;


namespace Projeto_ONE.Data.Util
{
    public class HibernateUtil
    {
        private static ISessionFactory factory;
     
        public static ISessionFactory GetSessionFactory()
        {
            if (factory == null)
            {
                factory = Fluently.Configure()
                    .Database(
                        MsSqlConfiguration.MsSql2012
                        .ConnectionString(
                            ConfigurationManager.ConnectionStrings["banco"].ConnectionString
                        )
                        .ShowSql()
                        .FormatSql()
                    )
                    .Mappings(m => m.FluentMappings
                        .AddFromAssemblyOf<UsuarioMap>()
                        .AddFromAssemblyOf<CategoriaMap>()
                        .AddFromAssemblyOf<TarefaMap>())
                    .BuildSessionFactory();
            }

            return factory;
        }
    }
    
}