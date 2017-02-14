// <copyright company="Recorded Books, Inc" file="BlackRocketMessageHandler.cs">
// Copyright © 2015 All Rights Reserved
// </copyright>

namespace BlackRocket.WebApi
{
    using XF.WebApi;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class BlackRocketMessageHandler : DelegatingHandler
    {

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            //WebApiCaller.SetValue("patronId", 780808);

            return base.SendAsync(request, cancellationToken);
        }
    }

}
