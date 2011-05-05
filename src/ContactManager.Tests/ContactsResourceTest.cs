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
		private readonly ContactsResource _resource;

		public ContactsResourceTest()
		{
			var repository = new Mock<IContactRepository>();
			var fakeContacts = new List<Contact>();
			fakeContacts.Add(new Contact { Name = "Foo Bar" });
			repository.Setup(x => x.GetAll()).Returns(fakeContacts);
			_resource = new ContactsResource(repository.Object);
		}

		[Fact]
		public void When_GET_then_contacts_are_returned()
		{
			var contacts = _resource.Get().Select(x => x.Name);
			Assert.Equal("Foo Bar", contacts.First());
		}
	}
}
