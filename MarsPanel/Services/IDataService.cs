using System.Threading.Tasks;
using System.Collections.Generic;

namespace MarsPanel.Services
{
    public interface IDataService
    {
        Task<string> GetObject(string endpoint, Dictionary<string, string> parameters = null );
    }
}
