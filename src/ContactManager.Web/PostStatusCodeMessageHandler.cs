﻿using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ContactManager.Web
{
	public class PostStatusCodeMessageHandler : DelegatingChannel
	{
		public PostStatusCodeMessageHandler(DelegatingChannel innerChannel)
			: base(innerChannel)
		{
		}

		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			return SendAsync(request, cancellationToken)
				.ContinueWith(x =>
			{
				var response = x.Result;
				if (request.Method.Equals(HttpMethod.Post) && response.StatusCode == HttpStatusCode.OK)
				{
					response.StatusCode = HttpStatusCode.Created;
				}

				return response;
			});
		}
	}
}
