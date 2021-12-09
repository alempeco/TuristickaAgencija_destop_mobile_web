using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuristickaAgencija.Model.Requests;
using TuristickaAgencija.WebAPI.Security;
using TuristickaAgencijaWebAPI.Database;
using TuristickaAgencijaWebAPI.Services;

namespace TuristickaAgencijaWebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TuristickaAgencija API V1", Version = "v1" });

                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                    }
                });

            });
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My Api", Version = "v1" });
            //    c.AddSecurityDefinition("basic", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            //    {
            //        Name = "Authorization",
            //        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
            //        Scheme = "basic",
            //        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            //        Description = "Basic Auth Header"
            //    });
            //    c.OperationFilter<SecurityRequirementsOperationFilter>();

            //});








            services.AddAuthentication("BasicAuthentication").AddScheme
              <AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);



            services.AddScoped<ICRUDService<TuristickaAgencija.Model.Gradovi, GradoviSearchRequest, GradoviInsertRequest, GradoviInsertRequest>, GradoviService>();
            services.AddScoped<ICRUDService<TuristickaAgencija.Model.Smjestaj, SmjestajSearchRequest, SmjestajInsertRequest, SmjestajInsertRequest>,
          SmjestajService>();
            services.AddScoped<ICRUDService<TuristickaAgencija.Model.Vodici, VodicSearchRequest, VodicInsertRequest, VodicInsertRequest>, VodiciService>();


            services.AddScoped<ICRUDService<TuristickaAgencija.Model.Prevoz, PrevozSearchRequest, PrevozInsertRequest, PrevozInsertRequest>,
         PrevozService>();

            services.AddScoped<ICRUDService<TuristickaAgencija.Model.VrstaPutovanja, object, VrstaPutovanjaInsertRequest, VrstaPutovanjaInsertRequest>,
                            BaseCRUDService<TuristickaAgencija.Model.VrstaPutovanja, object, VrstePutovanja, VrstaPutovanjaInsertRequest, VrstaPutovanjaInsertRequest>>();
            services.AddScoped<ICRUDService<TuristickaAgencija.Model.Firme, FirmeSearchRequest, FirmeInsertRequest, FirmeInsertRequest>, FirmeService>();
            services.AddScoped<ICRUDService<TuristickaAgencija.Model.TipPrevoza, TipPrevozaSearchRequest, TipPrevozaInsertRequest, TipPrevozaInsertRequest>, TipPrevozaService>();
            services.AddScoped<IZaposleniciService, ZaposleniciService>();
            services.AddScoped<IPutniciKorisniciService, PutniciKorisniciService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ICRUDService<TuristickaAgencija.Model.OcjenePutovanja, OcjenePutovanjaSearchRequest, OcjenePutovanjaInsertRequest, OcjenePutovanjaInsertRequest>,
            OcjenePutovanjaService>();
            //services.AddScoped<ICRUDService<TuristickaAgencija.Model.Rezervacije, RezervacijeSearchRequest, RezervacijeInsertRequest, RezervacijeInsertRequest>, RezervacijeService>();
            services.AddScoped<ICRUDService<TuristickaAgencija.Model.Komentari, KomentariSearchRequest, KomentariInsertRequest, KomentariInsertRequest>,
            KomentariService>();
            services.AddScoped<ICRUDService<TuristickaAgencija.Model.Novosti, NovostiSearchRequest, NovostiInsertRequest, NovostiInsertRequest>, NovostiService>();

            services.AddScoped<ICRUDService<TuristickaAgencija.Model.Putovanja, PutovanjaSearchRequest, PutovanjaInsertRequest, PutovanjaInsertRequest>, PutovanjaService>();

            services.AddScoped<ICRUDService<TuristickaAgencija.Model.Ocjene, object, OcjeneInsertRequest, OcjeneInsertRequest>,
                                        BaseCRUDService<TuristickaAgencija.Model.Ocjene, object, Ocjene, OcjeneInsertRequest, OcjeneInsertRequest>>();
           
            services.AddScoped<ICRUDService<TuristickaAgencija.Model.Pretplate, PretplateSearchRequest, PretplateInsertRequest, PretplateInsertRequest>,
           PretplateService>();
           

            services.AddScoped<ICRUDService<TuristickaAgencija.Model.Drzave, DrzaveSearchRequest, DrzaveInsertRequest, DrzaveInsertRequest>, DrzaveService>();


            services.AddScoped<ICRUDService<TuristickaAgencija.Model.Rezervacije, RezervacijeSearchRequest, RezervacijeInsertRequest, RezervacijeInsertRequest>, RezervacijeService>();
            services.AddScoped<ICRUDService<TuristickaAgencija.Model.TerminiPutovanja, TerminiSearchRequest, TerminiPutovanjaInsertRequest, TerminiPutovanjaInsertRequest>, TerminiPutovanjaService>();
            services.AddScoped<ICRUDService<TuristickaAgencija.Model.Uplate, UplateSearchRequest, UplateInsertRequest, UplateInsertRequest>, UplateService>();
            //services.AddScoped<ICRUDService<TuristickaAgencija.Model.OnlinePay, OnlinePaySearchRequest, OnlinePayInsertRequest, OnlinePayInsertRequest>, OnlinePayServices>();



            services.AddScoped<ICRUDService<TuristickaAgencija.Model.OnlinePay, OnlinePaySearchRequest, OnlinePayInsertRequest, OnlinePayInsertRequest>,
        OnlinePayServices>();
            var connection = @"data source=.;initial catalog=160090; integrated security = True; ";
            services.AddDbContext<MyContext>(options => options.UseSqlServer(connection));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseAuthentication();


            app.UseMvc();
            //app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            //});


            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TuristickaAgencija API V1");
            });



        }
    }
}
