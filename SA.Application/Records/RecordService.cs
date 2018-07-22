using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SA.Core.Model;
using SA.EntityFramework.EntityFramework.Repository;

namespace SA.Application.Records
{
    public class RecordService : IRecordService
    {
        private readonly IEntityRepository<Record> _recordRepository;
        private readonly IEntityRepository<Bid> _bidRepository;
        public RecordService(
            IEntityRepository<Record> recordRepository,
            IEntityRepository<Bid> bidRepository)
        {
            _recordRepository = recordRepository;
            _bidRepository = bidRepository;
        }

        public async Task<IEnumerable<Record>> GetAll()
            => await _recordRepository.GetAllAsync();

        public async Task<IEnumerable<Record>> GetAllForCustomer(int id)
            => await _recordRepository.GetAllAsync(x => x.CustomerId == id);

        public IEnumerable<RecordMinimumDto> GetAllForCustomerMinimum(int id)
        {
            var now = DateTime.Now;

            var records = _recordRepository
                .GetAllInternal()
                .Where(x => x.Bids.Any()
                    && x.UserId == id
                    && x.ValidTo >= now
                    && x.IsActive)
                .Select(x => new RecordMinimumDto {
                    Id = x.Id,
                    Name = x.Name,
                    ValidTo = x.ValidTo,
                    CurrentPrice = x.Bids.Max(y => y.Price)
                })
                .AsEnumerable();

            return records;
        }

        public async Task<IEnumerable<Record>> GetAllPublished()
        {
            var now = DateTime.Now;
            return await _recordRepository
                .GetAllAsync(x => x.IsActive
                    && x.ValidFrom <= now
                    && x.ValidTo >= now);
        }

        public async Task<IEnumerable<Record>> GetAllUsersActiveWithBids(int id)
        {
            var bids = await _bidRepository.GetAllSimpleAsync(x => x.UserId == id);
            var recordIds = bids.Select(x => x.RecordId);

            var items = await _recordRepository
                .GetAllSimpleAsync(x => x.IsActive && recordIds.Contains(x.Id));

            return items;
        }

        public async Task<Record> GetById(int id)
            => await _recordRepository.GetByIdAsync(id);
    }
}
