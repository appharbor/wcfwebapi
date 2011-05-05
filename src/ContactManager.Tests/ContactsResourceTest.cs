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
		[Fact]
		public void When_GET_then_contacts_are_returned()
		{
			var repository = new Mock<IContactRepository>();
			var fakeContacts = new List<Contact>();
			fakeContacts.Add(new Contact { Name = "Foo Bar" });
			repository.Setup(x => x.GetAll()).Returns(fakeContacts);
			var contactsResource = new ContactsResource(repository.Object);
			var contacts = contactsResource.Get().Select(x => x.Name);
			Assert.Equal("Foo Bar", contacts.First());
		}
	}
}
