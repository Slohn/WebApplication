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
    public class OrderItemsRepository : IRepository<Entities.OrderItem>
    {
        private readonly ApplicationDbContext _appDbContext;

        public OrderItemsRepository(ApplicationDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async Task<Entities.OrderItem> CreateAsync(Entities.OrderItem order) 
        {
            try
            {
                if (order != null)
                {
                    var obj = _appDbContext.Add<OrderItem>(ConvertFromEntity(order));
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

        public async Task DeleteAsync(Entities.OrderItem order)
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

        public async Task<IEnumerable<Entities.OrderItem>> GetAllAsync()
        {
            try
            {
                var obj = await _appDbContext.OredItems.ToListAsync();
                return obj.Select(ConvertToEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Entities.OrderItem> GetByIdAsync(int Id)
        {
            try
            {
                if (Id != 0)
                {
                    var obj = await _appDbContext.OredItems.FirstOrDefaultAsync(x => x.Id == Id);
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

        public async Task<Entities.OrderItem> UpdateAsync(Entities.OrderItem order)
        {
            try
            {
                if (order != null)
                {
                    var obj = _appDbContext.Update<OrderItem>(ConvertFromEntity(order));
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

        internal static OrderItem ConvertFromEntity(Entities.OrderItem order) 
        {
            return order == null
                ? null
                : new OrderItem()
                {
                    Id = order.Id,
                };
        }

        internal static Entities.OrderItem ConvertToEntity(OrderItem order)
        {
            return order == null
                ? null
                : new Entities.OrderItem()
                {
                    Id = order.Id,
                };
        }
    }
}
