
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // autofac config?rasyonu
            // dependency'leri art?k burada de?il AutofacBusinessModule'da tan?ml?yorum
            //burada singleton yazarsan bundan sorna devreye girmez.
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
             .ConfigureContainer<ContainerBuilder>
             (builder =>
             {
                 builder.RegisterModule(new AutofacBusinessModule());
             });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

           

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}