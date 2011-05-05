using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
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

		[WebGet(UriTemplate = "")]
		public List<Contact> Get()
		{
			return _repository.GetAll();
		}

		[WebInvoke(Method = "POST", UriTemplate = "")]
		public Contact Post(Contact contact)
		{
			_repository.Post(contact);
			return contact;
		}
	}
}
