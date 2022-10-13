using Allocations.Core.BusinnessLogic;
using Allocations.Core.Ef;
using Allocations.Core.Ef.Repositories;
using Allocations.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Allocations.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<IUserBL, UserBL>();
            builder.Services.AddTransient<IEmployeeBL, EmployeeBL>();
            builder.Services.AddTransient<IRoleBL, RoleBL>();

            builder.Services.AddTransient<IUserRepository, EFUserRepository>();
            builder.Services.AddTransient<IEmployeeRepository, EFEmployeeRepository>();
            builder.Services.AddTransient<IRoleRepository, EFRoleRepository>();


            builder.Services.AddDbContext<AllocationsDbContext>(o =>
            {
                o.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            var app = builder.Build();

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