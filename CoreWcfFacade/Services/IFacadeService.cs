using System.ServiceModel;
using System.Threading.Tasks;

namespace CoreWcfFacade.Services
{
    [ServiceContract]
    public interface IFacadeService
    {
        [OperationContract]
        Task<string> Search(string term);
    }
}
