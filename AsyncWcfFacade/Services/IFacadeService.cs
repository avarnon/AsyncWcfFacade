using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;

namespace AsyncWcfFacade.Services
{
    [ServiceContract]
    public interface IFacadeService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Search/{term}", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml)]
        Task<string> Search(string term);
    }
}
