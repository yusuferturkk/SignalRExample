using SignalRExample.Entity.Entities;
using SignalRExample.Business.Abstract;
using SignalRExample.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRExample.Business.Concrete
{
    public class BookingManager : GenericManager<Booking>, IBookingService
    {
        public BookingManager(IGenericDal<Booking> genericDal) : base(genericDal)
        {
        }
    }
}
