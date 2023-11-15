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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }
    }
}
