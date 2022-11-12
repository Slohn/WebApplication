using Common.Search;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public abstract class BaseDal<TDbContext, TDbObject, TEntity, TObjectId, TSearchParams, TConvertParams>
		where TDbContext : DbContext, new()
		where TDbObject : class, new()
		where TEntity : class
		where TSearchParams : BaseSearchParams
		where TConvertParams : class
	{
	}
}
