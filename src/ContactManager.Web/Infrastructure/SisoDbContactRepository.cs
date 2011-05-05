using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using SisoDb;

namespace ContactManager.Web.Infrastructure
{
	public class SisoDbContactRepository : IContactRepository
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
			_database.CreateIfNotExists();
		}

		public void Update(Contact updatedContact)
		{
			throw new NotImplementedException();
		}

		public Contact Get(int id)
		{
			throw new NotImplementedException();
		}

		public List<Contact> GetAll()
		{
			using (var session = _database.CreateUnitOfWork())
			{
				return session.GetAll<Contact>().ToList();
			}
		}

		public void Post(Contact contact)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}
	}
}
