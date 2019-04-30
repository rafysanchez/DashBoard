using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sow.Automation.Dashboard.AutoMapper;
using Sow.Automation.Data.Contexto;
using Sow.Automation.Data.Entidades.UsuarioAplicacaoContexto.Interfaces;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces;
using Sow.Automation.Data.Repositorios;
using Sow.Automation.Data.Entidades.Manipuladores.Interfaces;
using Sow.Automation.Data.Entidades.NotificacoesContexto;
using Sow.Automation.Data.Entidades.Manipuladores;
using Sow.Automation.Dashboard.Interfaces;
using Sow.Automation.Dashboard.Services;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Cqrs.Commands.Handlers;
using Sow.Automation.Data.Entidades.ServicosRoboContexto;
using Sow.Automation.Data.Services;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.ContextoPadrao;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.ContextoPadrao.Handlers;
using Sow.Automation.Data.Entidades.ServicosRoboContexto.Interfaces.ContextoPadrao;
using Sow.Automation.Data.Repositorios.ContextoPadrao;

namespace Sow.Automation.Dashboard
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
            services.AddSession(options => {

                options.IdleTimeout = TimeSpan.FromMinutes(100);

            });
            services.AddMvc();
            RegisterServices(services);


        }
        public IConfigurationRoot ConfigurationRoot { get; }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

          

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Login}/{id?}");
            });

        }

        private void RegisterServices(IServiceCollection services)
        {   
            //AUTOMAPPER
            var mappingConfig = AutoMapperConfiguration.RegisterMappings();
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);


            //DATA
            services.AddScoped<DashBoardDbContext, DashBoardDbContext>();


            services.AddScoped<ICustasRepository, CustasRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IRegrasForumRepository, RegrasForumRepository>();
            services.AddScoped<IRegrasForunsBairrosRepository, RegrasForunsBairrosRepository>();
            services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
            services.AddScoped<IAgendamentoExecucoesRepository, AgendamentoExecucoesRepository>();


            // Domain - Eventos
            services.AddScoped<IDomainNotificationHandler, DomainNoticationHandler>();

            //APLICATION
            services.AddScoped<IRegisterAppService, RegisterAppService>();
            services.AddScoped<IUserAppServices, UserAppServices>();
            services.AddScoped<IQueryAppService, QueryAppService>();
            services.AddScoped<IAgendamentoAppService, AgendamentoAppService>();


            

            // Domain - Commands
            services.AddScoped<IHandler<RegrasForunsBrasil>, RegrasForunsBrasilCommandHandler>();
            services.AddScoped<IHandler<Comarca>, ComarcaCommandHandler>();

            services.AddScoped<IHandler<Cidade>, CidadeCommandHandler>();

            services.AddScoped<IHandler<Bairro>, BairroCommandHandler>();
            services.AddScoped<IHandler<RegrasForunsBairros>, RegraBairroCommandHandler>();


            services.AddScoped<IHandler<EstadosVsCustas>, CustasCommandHandler>();

            services.AddScoped<IHandler<AgendamentoInfo>, AgendamentoHandler>();

      

            services.AddScoped<JsonServices, JsonServices>();
            


        }
    }
}
