using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockbusterApp.src.Application.Event;
using BlockbusterApp.src.Application.UseCase.Country;
using BlockbusterApp.src.Application.UseCase.Email;
using BlockbusterApp.src.Application.UseCase.Token;
using BlockbusterApp.src.Application.UseCase.Token.Delete;
using BlockbusterApp.src.Application.UseCase.Token.Update;
using BlockbusterApp.src.Application.UseCase.User;
using BlockbusterApp.src.Application.UseCase.User.Find;
using BlockbusterApp.src.Domain;
using BlockbusterApp.src.Domain.CountryAggregate;
using BlockbusterApp.src.Domain.CountryAggregate.Service;
using BlockbusterApp.src.Domain.TokenAggregate;
using BlockbusterApp.src.Domain.UserAggregate;
using BlockbusterApp.src.Domain.UserAggregate.Service;
using BlockbusterApp.src.Infrastructure.Persistence.Repository;
using BlockbusterApp.src.Infrastructure.Service.Hashing;
using BlockbusterApp.src.Infrastructure.Service.Mailer;
using BlockbusterApp.src.Infrastructure.Service.Token;
using BlockbusterApp.src.Infrastructure.Service.User;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Application.Event;
using BlockbusterApp.src.Shared.Domain.Event;
using BlockbusterApp.src.Shared.Infrastructure.Bus.Middleware;
using BlockbusterApp.src.Shared.Infrastructure.Bus.Middleware.Exception;
using BlockbusterApp.src.Shared.Infrastructure.Bus.UseCase;
using BlockbusterApp.src.Shared.Infrastructure.Event;
using BlockbusterApp.src.Shared.Infrastructure.Persistence.Context;
using BlockbusterApp.src.Shared.Infrastructure.Persistence.Repository;
using BlockbusterApp.src.Shared.Infrastructure.Security.Authentication.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
using Microsoft.IdentityModel.Tokens;
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
            var appSettingsSection = Configuration.GetSection("AppSettings");
            var secret = Configuration.GetValue<string>("AppSettings:Secret");
            var key = Encoding.ASCII.GetBytes(secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddOptions();

            services.AddDbContextPool<BlockbusterAppContext>(options => options
                .UseMySql(Configuration.GetConnectionString("DefaultConnection"))
            );
            //Application
                //User
            services.AddScoped<SignUpUserUseCase>();
            services.AddScoped<IRequest, SignUpUserRequest>();
            services.AddScoped<IResponse, SignUpUserResponse>();
            services.AddScoped<UserConverter>();

            services.AddScoped<FindUserByEmailConverter>();
            services.AddScoped<FindUserByEmailUseCase>();
            services.AddScoped<IRequest, FindUserByEmailRequest>();
            services.AddScoped<IResponse, FindUserByEmailResponse>();
                //Country
            services.AddScoped<FindCountryUseCase>();
            services.AddScoped<IRequest, FindCountryRequest>();
            services.AddScoped<IResponse, FindCountryResponse>();
            services.AddScoped<CountryConverter>();
                //Email
            services.AddScoped<SendWelcomeEmailWhenUserSignedUpEventHandler>();
            services.AddScoped<SendUserWelcomeEmailUseCase>();
            services.AddScoped<IRequest, SendUserWelcomeEmailRequest>();
            services.AddScoped<IResponse, SendUserWelcomeEmailResponse>();
            services.AddScoped<SendUserWelcomeEmailConverter>();

            services.AddScoped<ExceptionConverter>();
                //Token
            services.AddScoped<CreateTokenUseCase>();
            services.AddSingleton<IRequest, CreateTokenRequest>();
            services.AddSingleton<IResponse, CreateTokenResponse>();
            services.AddScoped<TokenConverter>();

            services.AddScoped<UpdateTokenUseCase>();
            services.AddScoped<IRequest, UpdateTokenRequest>();
            services.AddScoped<IResponse, UpdateTokenResponse>();
            services.AddScoped<UpdateTokenConverter>();

            services.AddScoped<DeleteTokenUseCase>();
            services.AddScoped<IRequest, DeleteTokenRequest>();
            services.AddScoped<IResponse, DeleteTokenResponse>();
            services.AddScoped<DeleteTokenConverter>();

            //Domain
            services.AddScoped<IUserFactory, UserFactory>();
            services.AddScoped<SignUpUserValidator>();
            services.AddScoped<CountryFinderValidator>();
            services.AddScoped<ITokenFactory, TokenFactory>();

            services.AddScoped<PasswordValidator>();

            //Infra
                //Repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
                //Hashing
            services.AddScoped<IHashing, DefaultHashing>();
                //Mailer
            services.AddScoped<IMailer, SendGridMailer>();
                //Token
            services.AddScoped<TokenAdapter>();
            services.AddScoped<TokenFacade>();
            services.AddScoped<TokenTranslator>();
                //Shared
                    //Bus
                        //Middleware
                        
            services.AddScoped<EventDispatcherSyncMiddleware>();
            services.AddScoped<ExceptionMiddleware>();
            //services.AddSingleton<IMiddlewareHandler, MiddlewareHandler>();
            services.AddSingleton<TransactionMiddleware>();
            services.AddScoped<UseCaseMiddleware>();
                        
                        //UseCase
            services.AddSingleton<IUseCaseBus, UseCaseBus>();
                    //Event
            services.AddScoped<IDomainEventPublisher, DomainEventPublisherSync>();
            services.AddScoped<IEventBus, EventBus>();
            services.AddScoped<IEventProvider, EventProvider>();
                    //Persistence
                        //Context            
            services.AddSingleton<BlockbusterAppContext>();
                        //Repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                               
            services.AddScoped<IJWTEncoder, JWTEncoder>();
            services.AddScoped<IJWTDecoder, JWTDecoder>();

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
            IUseCase findCountryUseCase = serviceProvider.GetService<FindCountryUseCase>();
            IUseCase createTokenUseCase = serviceProvider.GetService<CreateTokenUseCase>();
            IUseCase findUserByEmailUseCase = serviceProvider.GetService<FindUserByEmailUseCase>();
            IUseCase updateTokenUseCase = serviceProvider.GetService<UpdateTokenUseCase>();
            IUseCase deleteTokenUseCase = serviceProvider.GetService<DeleteTokenUseCase>();
            useCaseBus.Subscribe(signUpUserUseCase);
            useCaseBus.Subscribe(welcomeEmailUseCase);
            useCaseBus.Subscribe(findCountryUseCase);
            useCaseBus.Subscribe(createTokenUseCase);
            useCaseBus.Subscribe(findUserByEmailUseCase);
            useCaseBus.Subscribe(updateTokenUseCase);
            useCaseBus.Subscribe(deleteTokenUseCase);

            List<IMiddlewareHandler> middlewareHandlers = new List<IMiddlewareHandler>
            {
                serviceProvider.GetService<TransactionMiddleware>(),
                serviceProvider.GetService<EventDispatcherSyncMiddleware>(),
                serviceProvider.GetService<ExceptionMiddleware>(),
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
            app.UseAuthentication();

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
