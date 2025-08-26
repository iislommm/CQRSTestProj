using CQRSBook.Application.Interfaces;
using CQRSBook.Infrastructure.Persistence;
using CQRSBook.Infrastructure.Persistence.Repositories;
using CQRSBook.Infrastructure.Persistense.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace CQRSBook.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        var sqlConnectionString = configuration.GetConnectionString("DatabaseConnectionMS");
        var mongoConnectionString = configuration.GetConnectionString("MongoDBConnectionString");

        services.AddDbContext<AppDbContext>(options =>
          options.UseSqlServer(sqlConnectionString));

        services.AddScoped<IBookReadRepository, BookReadRepository>();
        services.AddScoped<IBookWriteRepository, BookWriteRepository>();

        var mongoClient = new MongoClient(mongoConnectionString);
        var mongoDatabase = mongoClient.GetDatabase("CQRSBookDb");

        services.AddSingleton<IMongoDatabase>(mongoDatabase);
        services.AddScoped<IBookWriteRepository, MongoBookWriteRepository>();
        services.AddScoped<IBookReadRepository, MongoBookReadRepository>();

        return services;
    }
}