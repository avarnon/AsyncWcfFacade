using System.Net.Http;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web;

namespace AsyncWcfFacade.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class FacadeService : IFacadeService
    {
        public async Task<string> Search(string term)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync($"https://www.google.com/search?q={HttpUtility.UrlEncode(term ?? string.Empty)}");
            }
        }
    }
}