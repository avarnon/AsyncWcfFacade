using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CoreWcfFacade.Services
{
    public class FacadeService : IFacadeService
    {
        private readonly IHttpClientFactory _clientFactory;

        public FacadeService(IHttpClientFactory clientFactory)
        {
            this._clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
        }

        public async Task<string> Search(string term) => await this._clientFactory.CreateClient().GetStringAsync($"search?q={HttpUtility.UrlEncode(term ?? string.Empty)}");
    }
}