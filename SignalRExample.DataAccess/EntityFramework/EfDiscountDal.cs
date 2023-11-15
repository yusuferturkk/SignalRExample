using SignalRExample.Entity.Entities;
using SignalRExample.DataAccess.Abstract;
using SignalRExample.DataAccess.Concrete;
using SignalRExample.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRExample.DataAccess.EntityFramework
{
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(SignalRContext context) : base(context)
        {
        }
    }
}
