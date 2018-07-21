using System.Collections.Generic;
using System.Threading.Tasks;
using SA.Core.Model;

namespace SA.Application.Records
{
    public interface IRecordService
    {
        Task<IEnumerable<Record>> GetAllPublished();
        Task<IEnumerable<Record>> GetAll();
        Task<IEnumerable<Record>> GetAllForCustomer(int id);
        Task<Record> GetById(int id);
    }
}
