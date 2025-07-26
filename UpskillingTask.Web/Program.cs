
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UpskillingTask.Domain.Contracts;
using UpskillingTask.Persistence.Data;
using UpskillingTask.Persistence.Repositories;
using UpskillingTask.Service;
using UpskillingTask.Service.MappingProfiles;
using UpskillingTask.ServiceAbstraction;

namespace UpskillingTask.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container
            builder.Services.AddControllers();

            builder.Services.AddDbContext<UpskillingTaskDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IUnitofWork,UnitofWork>();
            builder.Services.AddScoped<IBookService,BookService>();
            builder.Services.AddScoped<ICategoryService,CategoryService>();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<BookProfile>();
                cfg.AddProfile<CategoryProfile>();
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            var app = builder.Build();

            #region Configure the HTTP request pipeline

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers(); 
            #endregion

            app.Run();
        }
    }
}
