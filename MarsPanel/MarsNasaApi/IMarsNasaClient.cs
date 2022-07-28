using MarsPanel.Configuration;
using System.Threading.Tasks;

namespace MarsPanel.MarsNasa
{
    public interface IMarsNasaClient
    {
        Task<string> GetObject();
    }
}
