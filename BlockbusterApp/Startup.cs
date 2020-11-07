using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockbusterApp.src.Application.Event;
using BlockbusterApp.src.Application.UseCase;
using BlockbusterApp.src.Application.UseCase.Email;
using BlockbusterApp.src.Domain;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Infrastructure.Persistence.Repository;
using BlockbusterApp.src.Infrastructure.Service.Hashing;
using BlockbusterApp.src.Infrastructure.Service.Mailer;
using BlockbusterApp.src.Infrastructure.Service.User;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Application.Event;
using BlockbusterApp.src.Shared.Domain.Event;
using BlockbusterApp.src.Shared.Infrastructure.Bus.Middleware;
using BlockbusterApp.src.Shared.Infrastructure.Bus.UseCase;
using BlockbusterApp.src.Shared.Infrastructure.Event;
using BlockbusterApp.src.Shared.Infrastructure.Persistence.Context;
using BlockbusterApp.src.Shared.Infrastructure.Persistence.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace BlockbusterApp
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
            services.AddDbContextPool<BlockbusterAppContext>(options => options
                .UseMySql(Configuration.GetConnectionString("DefaultConnection"))
            );
            //Application
            services.AddScoped<UserConverter>();
            services.AddScoped<SendUserWelcomeEmailUseCase>();
            services.AddScoped<SignUpUserUseCase>();
            services.AddScoped<IEventHandler, SendWelcomeEmailWhenUserSignedUpEventHandler>();
            services.AddScoped<SendUserWelcomeEmailConverter>();
            //Domain
            services.AddScoped<IUserFactory, UserFactory>();
            services.AddScoped<SignUpUserValidator>();

            //Infra
            services.AddScoped<IHashing, DefaultHashing>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton<BlockbusterAppContext>();
            services.AddScoped<IEventProvider, EventProvider>();

            services.AddScoped<IDomainEventPublisher, DomainEventPublisherSync>();
            services.AddScoped<IEventBus, EventBus>();
            services.AddScoped<IMailer, SendGridMailer>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IUseCaseBus, UseCaseBus>();
            services.AddScoped<IRequest, SignUpUserRequest>();
            services.AddScoped<IResponse, SignUpUserResponse>();

            services.AddScoped<UseCaseMiddleware>();
            services.AddScoped<TransactionMiddleware>();
            services.AddScoped<EventDispatcherSyncMiddleware>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMvcCore().AddVersionedApiExplorer(o => o.GroupNameFormat = "'v'VVV");
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddApiVersioning(config =>
            {
                config.ReportApiVersions = true;
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });
            services.AddSwaggerGen(
                options =>
                {
                    var provider = services.BuildServiceProvider()
                                        .GetRequiredService<IApiVersionDescriptionProvider>();
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerDoc(
                            description.GroupName,
                            new Info()
                            {
                                Title = $"Sample API {description.ApiVersion}",
                                Version = description.ApiVersion.ToString()
                            });
                    }
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider, IServiceProvider serviceProvider)
        {
            IUseCaseBus useCaseBus = serviceProvider.GetService<IUseCaseBus>();
            IUseCase signUpUserUseCase = serviceProvider.GetService<SignUpUserUseCase>();
            IUseCase welcomeEmailUseCase = serviceProvider.GetService<SendUserWelcomeEmailUseCase>();
            useCaseBus.Subscribe(signUpUserUseCase);
            useCaseBus.Subscribe(welcomeEmailUseCase);

            List<IMiddlewareHandler> middlewareHandlers = new List<IMiddlewareHandler>
            {
                serviceProvider.GetService<TransactionMiddleware>(),
                serviceProvider.GetService<EventDispatcherSyncMiddleware>()
            };

            useCaseBus.SetMiddlewares(middlewareHandlers);

            IEventBus eventBus = serviceProvider.GetService<IEventBus>();
            eventBus.Subscribe(serviceProvider.GetService<SendWelcomeEmailWhenUserSignedUpEventHandler>(), "user_signed_up");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });
            app.UseCors("AllowAllOrigins");
            app.UseMvc();
        }
    }
}
