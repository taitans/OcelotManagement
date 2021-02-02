using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Taitans.OcelotManagement
{
    public interface IOcelotManager : IDomainService
    {
        Task<Ocelot> CreateAsync(string name);
    }
}
