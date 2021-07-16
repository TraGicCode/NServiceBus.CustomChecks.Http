using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using NServiceBus.Logging;

namespace NServiceBus.CustomChecks.Http
{
    public abstract class HttpCustomCheck : CustomCheck
    {
        private static readonly ILog Log = LogManager.GetLogger<HttpCustomCheck>();
        private readonly string _url;

        public HttpCustomCheck(string url, string id, string category, TimeSpan? repeatAfter = null) :
            base(id, category, repeatAfter)
        {
            _url = url;
        }

        public override async Task<CheckResult> PerformCheck()
        {
            var start = Stopwatch.StartNew();
            try
            {
                using (var client = new HttpClient {Timeout = TimeSpan.FromSeconds(30)})
                using (var response = await client.GetAsync(_url).ConfigureAwait(false))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        Log.Info($"Succeeded in contacting {_url}");
                        return CheckResult.Pass;
                    }

                    var error = $"Failed to contact '{_url}'. HttpStatusCode: {response.StatusCode}";
                    Log.Error(error);
                    return CheckResult.Failed(error);
                }
            }
            catch (Exception exception)
            {
                var error = $"Failed to contact '{_url}'. Duration: {start.Elapsed} Error: {exception.Message}";
                Log.Error(error);
                return CheckResult.Failed(error);
            }
        }
    }
}