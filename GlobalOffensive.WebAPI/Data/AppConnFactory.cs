using ServiceStack.OrmLite;

namespace GlobalOffensive.WebAPI.Data
{
    public class AppConnFactory : OrmLiteConnectionFactory
    {
        public AppConnFactory(string connString, IOrmLiteDialectProvider dialectProvider) : base(connString, dialectProvider)
        {
        }
    }
}