using System.Net.Http;

namespace ContactManager.Web
{
	public class PostStatusCodeMessageHandler : DelegatingChannel
	{
		public PostStatusCodeMessageHandler(DelegatingChannel innerChannel)
			: base(innerChannel)
		{
		}
	}
}
