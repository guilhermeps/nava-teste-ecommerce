using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nava.Processo.Seletivo.WebApi.Controllers.AtualizarStatusVenda;
using Nava.Processo.Seletivo.WebApi.Controllers.BuscarVenda;
using Nava.Processo.Seletivo.WebApi.Controllers.RegistrarVenda;

namespace Nava.Processo.Seletivo.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AdicionarBancoDeDadosEmMemoria(services);
            AdicionarImplementacoesDeNegocio(services);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AdicionarBancoDeDadosEmMemoria(IServiceCollection services)
        {
            services.AddScoped<Negocio.Repositorios.IRepositorioVenda, Infraestrutura.Dados.RepositorioVendas>();
            services.AddDbContext<Infraestrutura.Dados.ContextoVendas>(options =>
            {
                options.UseInMemoryDatabase("banco_em_memoria");
            });
        }

        private void AdicionarImplementacoesDeNegocio(IServiceCollection services)
        {
            services.AddScoped<Negocio.Fronteiras.RegistrarVenda.IRegistrarVenda, Negocio.CasosDeUso.RegistrarVenda>();
            services.AddScoped<RegistrarVendaApresentador>();
            services.AddScoped<Negocio.Fronteiras.RegistrarVenda.IManipuladorDeSaida>(i => i.GetRequiredService<RegistrarVendaApresentador>());

            services.AddScoped<Negocio.Fronteiras.BuscarVenda.IBuscarVenda, Negocio.CasosDeUso.BuscarVenda>();
            services.AddScoped<BuscarVendaApresentador>();
            services.AddScoped<Negocio.Fronteiras.BuscarVenda.IManipuladorDeSaida>(i => i.GetRequiredService<BuscarVendaApresentador>());

            services.AddScoped<Negocio.Fronteiras.AtualizarVenda.IAtualizarStatus, Negocio.CasosDeUso.AtualizarStatusVenda>();
            services.AddScoped<AtualizarStatusVendaApresentador>();
            services.AddScoped<Negocio.Fronteiras.AtualizarVenda.IManipuladorDeSaida>(i => i.GetRequiredService<AtualizarStatusVendaApresentador>());
        }
    }
}
