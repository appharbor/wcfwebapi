using System.Web.Configuration;
using SisoDb;

namespace ContactManager.Web.Infrastructure
{
	public class SisoDbContactRepository
	{
		private readonly ISisoDatabase _database;

		private SisoDbContactRepository()
		{
			string connectionString = WebConfigurationManager.ConnectionStrings["default"]
				.ConnectionString;
			var connectionInfo = new SisoConnectionInfo(
				string.Format(@"sisodb:provider=Sql2008||plain:{0}", connectionString));
			var factory = new SisoDbFactory();
			_database = factory.CreateDatabase(connectionInfo);
		}
	}
}
