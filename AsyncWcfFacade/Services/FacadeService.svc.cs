using System;
using System.Net.Http;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web;

namespace AsyncWcfFacade.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class FacadeService : IFacadeService
    {
        private readonly HttpClient _httpClient;

        public FacadeService(HttpClient httpClient)
        {
            this._httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<string> Search(string term) => await this._httpClient.GetStringAsync($"search?q={HttpUtility.UrlEncode(term ?? string.Empty)}");
    }
}