using NHibernate;

namespace TestApp.Core.Data
{
    public interface INHibernateSessionFactoryProvider
    {
        ISessionFactory Factory { get; }
    }
}
