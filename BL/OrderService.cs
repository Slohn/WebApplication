using DAL.Contracts;
using DAL.Repositories;
using Entities;
using Common.Search;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class OrderService
    {
        public readonly IRepository<Order> Repository;

        public OrderService(IRepository<Order> repository)
        {
            Repository = repository;
        }

        public async Task<Order> GetByIdAsync(int id) 
        {
            try
            {
                return await Repository.GetByIdAsync(id);
            }
            catch (Exception) 
            {
                throw; 
            }
        }

        public async Task<Order> AddAsync(Order order)
        {
            try
            {
                return await Repository.CreateAsync(order);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(int Id)
        {
            try
            {
                if (Id == 0)
                    return;
                var obj = await Repository.GetByIdAsync(Id);
                if (obj != null)
                    await Repository.DeleteAsync(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Order>> GetAllAsync() 
        {
            try
            {
                return (await Repository.GetAllAsync()).ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<SearchResult<Order>> GetAsync(OrderSearchParams searchParams) 
        {
            try 
            {
                var dbObjects = await Repository.GetAllAsync();
                if (searchParams.StartDate != null) 
                {
                    dbObjects = dbObjects.Where(i => i.Date > searchParams.StartDate);
                }
                if (searchParams.EndDate != null) 
                {
                    dbObjects = dbObjects.Where(i => i.Date < searchParams.EndDate);
                }
                if (!string.IsNullOrEmpty(searchParams.Number)) 
                {
                    dbObjects = dbObjects.Where(i => i.Number == searchParams.Number);
                }
                if (searchParams.ProviderId != null)
                {
                    dbObjects = dbObjects.Where(i => i.ProviderId == searchParams.ProviderId);
                }
                return new SearchResult<Order>
                {
                    Total =  dbObjects.Count(),
                    RequestedObjectsCount = searchParams.ObjectsCount,
                    RequestedStartIndex = searchParams.StartIndex.Value,
                    Objects = new List<Order>()
                };
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}