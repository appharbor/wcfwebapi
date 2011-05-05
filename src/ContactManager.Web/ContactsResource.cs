using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;
using ContactManager.Web.Infrastructure;
using Microsoft.ApplicationServer.Http;

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
		public HttpResponseMessage Post(Contact contact)
		{
			_repository.Post(contact);
			return new HttpResponseMessage<Contact>(contact)
			{
				StatusCode = HttpStatusCode.Created,
			};
		}
	}
}
