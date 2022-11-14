using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IRepository<TModel>
    {
        public Task<TModel> CreateAsync(TModel obj);
        public Task DeleteAsync(TModel obj);
        public Task<TModel> UpdateAsync(TModel obj);
        public Task<IEnumerable<TModel>> GetAllAsync();
        public Task<TModel> GetByIdAsync(int id);
        //public Task<IEnumerable<TModel>> GetAsync(TFilterModel filterModel);
    }
}
