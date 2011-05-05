using System.Web.Mvc;
using System.Web.Routing;
using ContactManager.Web.Infrastructure;
using Microsoft.ApplicationServer.Http.Activation;
using Microsoft.ApplicationServer.Http.Description;
using StructureMap;

namespace ContactManager.Web
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);

			var container = new Container();
			container.Configure(x =>
			{
				x.For<IContactRepository>()
					.Use(y => new ContactRepository());
			});

			var configuration = HttpHostConfiguration.Create()
				.SetResourceFactory((t, i, m) => container.GetInstance(t), (i, o) => { });

			RouteTable.Routes.MapServiceRoute<ContactsResource>("contacts", configuration);
		}
	}
}
