// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

//TODO: remove once cascade delete is implemented
namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient
{
    public class StacksDeletePollingHandler : DelegatingHandler, ICloneable
    {
        private const string SubscriptionSegment = "/subscriptions/";
        private const string ExpandString = "2021-04-01";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            if (request.Method == HttpMethod.Get)
            {
                var requestUri = request.RequestUri.GetLeftPart(UriPartial.Path);
                var test = request.RequestUri.GetLeftPart(UriPartial.Query);
                var lastSubscriptionsSegmentIndex = requestUri.LastIndexOf(SubscriptionSegment, StringComparison.InvariantCultureIgnoreCase);

                if (lastSubscriptionsSegmentIndex >= 0)
                {
                    var segments = requestUri
                        .Substring(lastSubscriptionsSegmentIndex)
                        .CoalesceString()
                        .Trim('/')
                        .SplitRemoveEmpty('/');

                    if (IsDeletePollingRequest(segments))
                    {
                        
                        var fullUri = request.RequestUri.ToString();
                        var splitUri = fullUri.Split('?');
                        if(splitUri[1].Equals("api-version=2021-05-01-preview", StringComparison.InvariantCultureIgnoreCase))
                        {
                            string uriString = splitUri[0];
                            UriBuilder uri = new UriBuilder(uriString);
                            var addQueryString = "?api-version=" + ExpandString;
                            var apiString = uri.ToString() + addQueryString;
                            request.RequestUri = new Uri(apiString);
                        }
                    }
                }
            }
            
            return base.SendAsync(request, cancellationToken);
        }

        private bool IsDeletePollingRequest(string[] segments)
        {
            if("operationresults".Equals(segments[2], StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public object Clone()
        {
            return new StacksDeletePollingHandler();
        }
    }
}