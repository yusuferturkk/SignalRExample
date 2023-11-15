using SignalRExample.Business.Abstract;
using SignalRExample.DataAccess.Abstract;
using SignalRExample.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRExample.Business.Concrete
{
    public class TestimonialManager : GenericManager<Testimonial>, ITestimonialService
    {
        public TestimonialManager(IGenericDal<Testimonial> genericDal) : base(genericDal)
        {
        }
    }
}
