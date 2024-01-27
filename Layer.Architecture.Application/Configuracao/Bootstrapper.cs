using Layer.Architecture.Infra.Data.Interface;
using Layer.Architecture.Infra.Data.Repository;
using Layer.Architecture.Service.Interface;
using Layer.Architecture.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architeture.Configuracao
{
    public static class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Services
            services.AddScoped<IParcelaService, ParcelaService>();
            services.AddScoped<IFinanciamentoService, FinanciamentoService>();
            services.AddScoped<IClienteService, ClienteService>();

            //Repositories
            services.AddScoped<ITipoFinanciamentoRepository, TipoFinanciamentoRepository>();
            services.AddScoped<IParcelaRepository, ParcelaRepository>();
            services.AddScoped<IFinanciamentoRepository, FinanciamentoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}
