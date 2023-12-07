using GMPay.Core.Interfaces;
using GMPay.Core.Services;

namespace GMPay.Api.Middlewares
{
    public static class ServiceExtension
    {
        public static void ConfigureService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IMerchantService), typeof(MerchantService));

           
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        }

    }
}
