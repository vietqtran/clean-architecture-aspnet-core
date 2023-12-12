
using System.Net.Http;

namespace Solution.MVC.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return HttpClient;
            }
        }
    }
}
