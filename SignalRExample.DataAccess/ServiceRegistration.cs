using Microsoft.Extensions.DependencyInjection;
using SignalRExample.DataAccess.Abstract;
using SignalRExample.DataAccess.Concrete;
using SignalRExample.DataAccess.EntityFramework;
using SignalRExample.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRExample.DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));

            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IBookingDal, EfBookingDal>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IDiscountDal, EfDiscountDal>();
            services.AddScoped<IFeatureDal, EfFeatureDal>();
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
        }
    }
}
