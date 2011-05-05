using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;
using ContactManager.Web.Infrastructure;
using Microsoft.ApplicationServer.Http;
using Microsoft.ApplicationServer.Http.Dispatcher;

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

		[WebGet(UriTemplate = "{contactId}")]
		public Contact GetSingle(int contactId)
		{
			var contact = _repository.Get(contactId);
			if (contact == null)
			{
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}

			return contact;
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
			var response = new HttpResponseMessage<Contact>(contact);
			response.Headers.Location = new Uri(contact.Self, UriKind.Relative);
			return response;
		}
	}
}
