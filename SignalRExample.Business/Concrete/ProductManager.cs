using SignalRExample.Entity.Entities;
using SignalRExample.Business.Abstract;
using SignalRExample.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRExample.DataAccess.EntityFramework;

namespace SignalRExample.Business.Concrete
{
    public class ProductManager : GenericManager<Product>, IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IGenericDal<Product> genericDal, IProductDal productDal) : base(genericDal)
        {
            _productDal = productDal;
        }

        public async Task<ICollection<Product>> GetProductsWithCategoriesAsync()
        {
            return await _productDal.GetProductsWithCategoriesAsync();
        }
    }
}
