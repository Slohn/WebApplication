using DAL.Contracts;
using DAL.Repositories;
using Entities;
using Common.Search;

namespace BL
{
    public class OrderItemService
    {
        public readonly IRepository<OrderItem> Repository;

        public OrderItemService(IRepository<OrderItem> repository)
        {
            Repository = repository;
        }

        public async Task<OrderItem> GetByIdAsync(int id) 
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

        public async Task<OrderItem> AddAsync(OrderItem order)
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

        public async Task<IEnumerable<OrderItem>> GetAllAsync() 
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

        public async Task<IEnumerable<OrderItem>> GetAsync(OrderItemSearchParams searchParams) 
        {
            try 
            {
                var dbObjects = await Repository.GetAllAsync();
                if (!string.IsNullOrEmpty(searchParams.Name)) 
                {
                    dbObjects = dbObjects.Where(i => i.Name == searchParams.Name);
                }
                return dbObjects.ToList();
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}