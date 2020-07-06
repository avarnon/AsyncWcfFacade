using System;
using System.Threading.Tasks;
using FacadeService;

namespace AsyncWcfFacade.Core.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () => await MainAsync(args)).Wait();
        }

        private static async Task MainAsync(string[] args)
        {
            try
            {
                FacadeServiceClient facadeServiceClient = new FacadeServiceClient();
                Console.WriteLine(await facadeServiceClient.SearchAsync("test"));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }

            Console.Read();
        }
    }
}
