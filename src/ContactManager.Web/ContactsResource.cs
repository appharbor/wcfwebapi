using System.ServiceModel;
using ContactManager.Web.Infrastructure;

namespace ContactManager.Web
{
	[ServiceContract]
	public class ContactsResource
	{
		private readonly IContactRepository _repository;

		public ContactsResource(IContactRepository repository)
		{
			_repository = repository;
		}
	}
}
