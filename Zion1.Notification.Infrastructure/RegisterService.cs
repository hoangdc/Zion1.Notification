using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Zion1.Notification.Application.Commands;
using Zion1.Notification.Application.Queries;
using Zion1.Notification.Application.Repositories;
using Zion1.Notification.Domain.Entities;
using Zion1.Notification.Infrastructure.Persistence;
using Zion1.Notification.Infrastructure.Persistence.Repositories;

namespace Zion1.Notification.Infrastructure
{
    public static class RegisterService
    {
        public static IServiceCollection AddNotificationInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NotificationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Zion1SqlServer"), b => b.MigrationsAssembly(typeof(NotificationDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            var smtpSettings = configuration.GetSection("SMTPSettings").Get<EmailSettings>();
            //Store SMTP Settings into Cache

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SendEmailCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetEmailQuery).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SendTextCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetTextQuery).Assembly));

            services.AddScoped<IEmailCommandRepository, EmailCommandRepository>();
            services.AddScoped<IEmailQueryRepository, EmailQueryRepository>();

            services.AddScoped<ITextCommandRepository, TextCommandRepository>();
            services.AddScoped<ITextQueryRepository, TextQueryRepository>();

            return services;
        }
    }
}
