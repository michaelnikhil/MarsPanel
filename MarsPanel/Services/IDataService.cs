using System.Threading.Tasks;
using MarsPanel.Configuration;

namespace MarsPanel.Services
{
    public interface IDataService
    {
        Task<string> GetObject(Endpoint endpoint);
        Task<string> GetApod(string date);
        Task<string> GetApod();
    }
}
