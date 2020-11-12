using System.Collections.Generic;
using System.Threading.Tasks;
using Easify.RestEase.Client;
using Easify.Template.Common;
using RestEase;

namespace Easify.Template.Client
{
    public interface ISampleClient : IRestClient
    {
        [Get("api/samples")]
        Task<IEnumerable<SampleDto>> GetSampleListAsync();
    }
}