using SignalRExample.Entity.Entities;
using SignalRExample.DataAccess.Abstract;
using SignalRExample.DataAccess.Concrete;
using SignalRExample.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SignalRExample.DataAccess.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public async Task<ICollection<Product>> GetProductsWithCategoriesAsync()
        {
            using var context = new SignalRContext();
            var products = await context.Products.Include(x => x.Category).ToListAsync();
            return products;
        }
    }
}
