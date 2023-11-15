using SignalRExample.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRExample.Business.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        Task<ICollection<Product>> GetProductsWithCategoriesAsync();
    }
}
