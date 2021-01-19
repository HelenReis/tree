using System.Linq;
using System.Threading.Tasks;
using Tree.Domain.Models;

namespace Tree.Data.Contract
{
    public interface IRegionRepository
    {
        void Create(Region device);

        void Update(Region device);

        void Delete(Region device);

        Task<Region> GetById(int deviceId);

        Task<bool> AnyAsync(int deviceId);

        IQueryable<Region> Query();
    }
}
