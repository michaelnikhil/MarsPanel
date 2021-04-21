using System.Threading.Tasks;

namespace MarsPanel.Services
{
    public interface IDataService
    {
        Task<string> GetObject(string endpoint);
    }
}
