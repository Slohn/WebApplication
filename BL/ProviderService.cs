using DAL.Contracts;
using DAL.Repositories;
using Entities;
using Common.Search;

namespace BL
{
    public class ProviderService
    {
        public readonly IRepository<Provider> Repository;

        public ProviderService(IRepository<Provider> repository)
        {
            Repository = repository;
        }

        public async Task<Provider> GetByIdAsync(int id) 
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

        public async Task<Provider> AddAsync(Provider order)
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

        public async Task<IEnumerable<Provider>> GetAllAsync() 
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

        public async Task<IEnumerable<Provider>> GetAsync(ProviderSearchParams searchParams)
        {
            try
            {
                var dbObjects = await Repository.GetAllAsync();
                if (!string.IsNullOrEmpty(searchParams.Name))
                {
                    dbObjects = dbObjects.Where(item => item.Name.ToLower().StartsWith(searchParams.Name.ToLower()));
                }
                return dbObjects.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}