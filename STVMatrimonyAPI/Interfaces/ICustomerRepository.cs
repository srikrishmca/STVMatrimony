using STVMatrimony.Models;
using System.Threading.Tasks;

namespace STVMatrimonyAPI.Interfaces
{
    public interface ICustomerRepository
    {
        Task<int> InsertUpdateCustomer(Customer request);
    }
}
