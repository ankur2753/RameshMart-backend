using BuisnessLayer;
using BuisnessLayer.Abstraction;
using DataLayer.DBContext;
using DataLayer.Repository;
using DataLayer.Repository.Abstraction;

namespace ApiLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
           
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
            builder.Services.AddScoped<IDBContext,DatabaseContex>();
            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<IAuthRepo,AuthRepository>();
            builder.Services.AddScoped<ICartRepo, CartRepo>();
            builder.Services.AddScoped<IProductManager,ProductManager>();
            builder.Services.AddScoped<IAuthManager,AuthManager>();
            builder.Services.AddScoped<ICartManager, CartManager>();
            builder.Services.AddScoped<IOrderRepo, OrdersRepo>();
            builder.Services.AddScoped<IOrderManager,OrderManager>();
           
            var app = builder.Build();
            app.UseCors("corsapp");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}