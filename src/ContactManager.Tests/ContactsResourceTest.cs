using System.Collections.Generic;
using System.Linq;
using ContactManager.Web;
using ContactManager.Web.Infrastructure;
using Moq;
using Xunit;

namespace ContactManager.Tests
{
	public class ContactsResourceTest
	{
		private readonly Mock<IContactRepository> _repository;
		private readonly ContactsResource _resource;

		public ContactsResourceTest()
		{
			_repository = new Mock<IContactRepository>();
			var fakeContacts = new List<Contact>();
			fakeContacts.Add(new Contact { Name = "Foo Bar" });
			_repository.Setup(x => x.GetAll()).Returns(fakeContacts);
			_resource = new ContactsResource(_repository.Object);
		}

		[Fact]
		public void When_GET_then_contacts_are_returned()
		{
			var contacts = _resource.Get().Select(x => x.Name);
			Assert.Equal("Foo Bar", contacts.First());
		}

		[Fact]
		public void When_POST_then_contact_is_added()
		{
			var contact = new Contact { Name = "Foo Bar" };
			_resource.Post(contact);
			_repository.Verify(x => x.Post(contact));
		}
	}
}
