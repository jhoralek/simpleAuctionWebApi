using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;

namespace SA.Application.Records
{
    public class RecordService : IRecordService
    {
        private readonly IEntityRepository<Record> _recordRepository;
        public RecordService(IEntityRepository<Record> recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public async Task<IEnumerable<Record>> GetAll()
            => await _recordRepository.GetAllAsync();

        public async Task<IEnumerable<Record>> GetAllForCustomer(int id)
            => await _recordRepository.GetAllAsync(x => x.CustomerId == id);

        public async Task<IEnumerable<Record>> GetAllPublished()
        {
            var now = DateTime.Now;
            return await _recordRepository
                .GetAllAsync(x => x.IsActive
                    && x.ValidFrom <= now
                    && x.ValidTo >= now);
        }

        public async Task<Record> GetById(int id)
            => await _recordRepository.GetByIdAsync(id);
    }
}
