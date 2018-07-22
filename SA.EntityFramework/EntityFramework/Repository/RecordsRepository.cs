using Microsoft.EntityFrameworkCore;
using SA.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SA.EntityFramework.EntityFramework.Repository
{
    public class RecordsRepository : IEntityRepository<Record>
    {
        private readonly SaDbContext _context;
        public RecordsRepository(SaDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Record item)
        {
            item.Created = DateTime.Now;
            await _context.Records.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Record>> FindAsync(string key)
            => await GetAllAsync(x => x.Name.StartsWith(key));

        public async Task<Record> GetByIdAsync(int id)
            => await GetRecordsInternal()
                .FirstOrDefaultAsync(x => x.Id == id);

        public async Task RemoveAsync(int id)
        {
            var itemToDelte = await GetAllInternal()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToDelte != null)
            {
                _context.Remove(itemToDelte);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(int id, Record item)
        {
            var itemToUpdate = await GetAllInternal()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (itemToUpdate != null)
            {
                itemToUpdate.Name = item.Name;
                itemToUpdate.MinimumBid = item.MinimumBid;
                itemToUpdate.IsActive = item.IsActive;
                itemToUpdate.Axle = item.Axle;
                itemToUpdate.Body = item.Body;
                itemToUpdate.Colors = item.Colors;
                itemToUpdate.ContactToAppointment = item.ContactToAppointment;
                itemToUpdate.CustomerId = item.CustomerId;
                itemToUpdate.DateOfFirstRegistration = item.DateOfFirstRegistration;
                itemToUpdate.Defects = item.Defects;
                itemToUpdate.Dimensions = item.Dimensions;
                itemToUpdate.Doors = item.Doors;
                itemToUpdate.EngineCapacity = item.EngineCapacity;
                itemToUpdate.Equipment = item.Equipment;
                itemToUpdate.EuroNorm = item.EuroNorm;
                itemToUpdate.Fuel = item.Fuel;
                itemToUpdate.MaximumWeight = item.MaximumWeight;
                itemToUpdate.MaximumWeightOfRide = item.MaximumWeightOfRide;
                itemToUpdate.Mileage = item.Mileage;
                itemToUpdate.MoreDescription = item.MoreDescription;
                itemToUpdate.MostTechnicallyAcceptableWeight = item.MostTechnicallyAcceptableWeight;
                itemToUpdate.MostTechnicallyWeightOfRide = item.MostTechnicallyWeightOfRide;
                itemToUpdate.NumberOfSeets = item.NumberOfSeets;
                itemToUpdate.OperationWeight = item.OperationWeight;
                itemToUpdate.Power = item.Power;
                itemToUpdate.RegistrationCheck = item.RegistrationCheck;
                itemToUpdate.StartingPrice = item.StartingPrice;
                itemToUpdate.State = item.State;
                itemToUpdate.Stk = item.Stk;
                itemToUpdate.ValidFrom = item.ValidFrom;
                itemToUpdate.ValidTo = item.ValidTo;
                itemToUpdate.Vin = item.Vin;

                await _context.SaveChangesAsync();
            }
        }

        public IQueryable<Record> GetAllInternal()
            => _context.Records.AsQueryable();

        private IQueryable<Record> GetRecordsInternal()
            => GetAllInternal()
                .Include(x => x.User)
                .Include(x => x.Customer);

        public async Task<IEnumerable<Record>> GetAllAsync(Expression<Func<Record, bool>> query = null)
            => await
                (query != null
                    ? GetRecordsInternal().Where(query)
                    : GetRecordsInternal())
                .ToListAsync();

        public Task<Record> GetOneAsync(Expression<Func<Record, bool>> query)
            => GetRecordsInternal().FirstOrDefaultAsync(query);

        public async Task<IEnumerable<Record>> GetAllSimpleAsync(Expression<Func<Record, bool>> query = null)
           => await (query != null
                        ? GetAllInternal().Where(query)
                        : GetAllInternal())
                    .ToListAsync();
    }
}
