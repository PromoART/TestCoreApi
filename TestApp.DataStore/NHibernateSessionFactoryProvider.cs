using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using TestApp.Core.Data;
using TestApp.DataStore.Entities;

namespace TestApp.DataStore
{
    public class NHibernateSessionFactoryProvider:INHibernateSessionFactoryProvider
    {
        private const string DbConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
            AttachDbFilename=C:\work\Test\TestCoreApi\TestApp.DataStore\DBSTORAGE.MDF;
            Integrated Security=True";

        //private const string CurrentSessionKey = "nhibernate.current_session";

        public NHibernateSessionFactoryProvider()
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(DbConnectionString).ShowSql())
                .Mappings(m =>
                {
                    m.HbmMappings.AddFromAssemblyOf<PlayerEntity>();
                })
                .BuildConfiguration();


            new SchemaUpdate(configuration).Execute(true, true);

            Factory = configuration.BuildSessionFactory();
        }

        public ISessionFactory Factory { get; }
    }
}
