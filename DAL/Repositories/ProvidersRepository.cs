using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contracts;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Common.Search;

namespace DAL.Repositories
{
    public class ProvidersRepository : IRepository<Entities.Provider>
    {
        private readonly ApplicationDbContext _appDbContext;

        public ProvidersRepository(ApplicationDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async Task<Entities.Provider> CreateAsync(Entities.Provider order) 
        {
            try
            {
                if (order != null)
                {
                    var obj = _appDbContext.Add<Provider>(ConvertFromEntity(order));
                    await _appDbContext.SaveChangesAsync();
                    return ConvertToEntity(obj.Entity);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(Entities.Provider order)
        {
            try
            {
                if (order != null)
                {
                    _appDbContext.Remove(ConvertFromEntity(order));
                    await _appDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Entities.Provider>> GetAllAsync()
        {
            try
            {
                var obj = await _appDbContext.Providers.ToListAsync();
                return obj.Select(ConvertToEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Entities.Provider> GetByIdAsync(int Id)
        {
            try
            {
                if (Id != 0)
                {
                    var obj = await _appDbContext.Providers.FirstOrDefaultAsync(x => x.Id == Id);
                    return ConvertToEntity(obj);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Entities.Provider> UpdateAsync(Entities.Provider order)
        {
            try
            {
                if (order != null)
                {
                    var obj = _appDbContext.Update<Provider>(ConvertFromEntity(order));
                    await _appDbContext.SaveChangesAsync();
                    return ConvertToEntity(obj.Entity);

                }
                else 
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static Provider ConvertFromEntity(Entities.Provider order) 
        {
            return order == null
                ? null
                : new Provider()
                {
                    Id = order.Id,
                    Name = order.Name,
                };
        }

        internal static Entities.Provider ConvertToEntity(Provider order)
        {
            return order == null
                ? null
                : new Entities.Provider
                (
                    order.Id,
                    order.Name
                );
        }
    }
}
