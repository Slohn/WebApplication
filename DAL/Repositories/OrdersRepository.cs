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
    public class OrdersRepository : IRepository<Entities.Order>
    {
        private readonly ApplicationDbContext _appDbContext;

        public OrdersRepository(ApplicationDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async Task<Entities.Order> CreateAsync(Entities.Order order) 
        {
            try
            {
                if (order != null)
                {
                    var obj = _appDbContext.Add<Order>(ConvertFromEntity(order));
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

        public async Task DeleteAsync(Entities.Order order)
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

        public async Task<IEnumerable<Entities.Order>> GetAllAsync()
        {
            try
            {
                var obj = await _appDbContext.Orders.ToListAsync();
                return obj.Select(ConvertToEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Entities.Order> GetByIdAsync(int Id)
        {
            try
            {
                if (Id != 0)
                {
                    var obj = await _appDbContext.Orders.FirstOrDefaultAsync(x => x.Id == Id);
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

        public async Task<Entities.Order> UpdateAsync(Entities.Order order)
        {
            try
            {
                if (order != null)
                {
                    var obj = _appDbContext.Update<Order>(ConvertFromEntity(order));
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

        internal static Order ConvertFromEntity(Entities.Order order) 
        {
            return order == null
                ? null
                : new Order()
                {
                    Id = order.Id,
                    Number = order.Number,
                    Date = order.Date,
                    ProviderId = order.ProviderId
                };
        }

        internal static Entities.Order ConvertToEntity(Order order)
        {
            return order == null
                ? null
                : new Entities.Order
                (
                    order.Id,
                    order.Number,
                    order.Date,
                    order.ProviderId
                );
        }
    }
}
