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
    public class AboutManager : GenericManager<About>, IAboutService
    {
        public AboutManager(IGenericDal<About> genericDal) : base(genericDal)
        {
        }
    }
}
