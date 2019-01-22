using NHibernate;

namespace TestApp.Core.Interfaces
{
    public interface IDataProviderFactory
    {
        ISessionFactory Factory { get; }
    }
}
