// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with EchoBot .NET Template version v4.17.1

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EchoBot
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
            services.AddHttpClient().AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.MaxDepth = HttpHelper.BotMessageSerializerSettings.MaxDepth;
            });

            // Create the Bot Framework Authentication to be used with the Bot Adapter.
            services.AddSingleton<BotFrameworkAuthentication, ConfigurationBotFrameworkAuthentication>();

            // Create the Bot Adapter with error handling enabled.
            services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>();

            var storage = new MemoryStorage();

            // Create the User state passing in the storage layer.
            var userState = new UserState(storage);
            services.AddSingleton(userState);

            // Create the Conversation state passing in the storage layer.
            var conversationState = new ConversationState(storage);
            services.AddSingleton(conversationState);

            // Create the bot as a transient. In this case the ASP Controller is expecting an IBot.
            services.AddTransient<IBot, Bots.EchoBot>();

            AppParameters.CURRICULUM_INDEX_NAME = Configuration["CURRICULUM_INDEX_NAME"];
            AppParameters.CURRICULUM_SEMANTIC_CONFIG = Configuration["CURRICULUM_SEMANTIC_CONFIG"];
            AppParameters.BANK_NAME = Configuration["BANK_NAME"];
            AppParameters.SEMANTIC_SEARCH_ENDPOINT = Configuration["SEMANTIC_SEARCH_ENDPOINT"];
            AppParameters.SEMANTIC_SEARCH_API_KEY = Configuration["SEMANTIC_SEARCH_API_KEY"];
            AppParameters.OPEN_AI_ENDPOINT = Configuration["OPEN_AI_ENDPOINT"];
            AppParameters.OPEN_AI_API_KEY = Configuration["OPEN_AI_API_KEY"];
            AppParameters.OPEN_AI_MODEL_DEPLOYMENT_NAME = Configuration["OPEN_AI_MODEL_DEPLOYMENT_NAME"];
            AppParameters.OPEN_AI_MODEL_DEPLOYMENT_NAME_COMPLETIONS_END_POINT = Configuration["OPEN_AI_MODEL_DEPLOYMENT_NAME_COMPLETIONS_END_POINT"];
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles()
                .UseStaticFiles()
                .UseWebSockets()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

            // app.UseHttpsRedirection();


        }
    }
}
