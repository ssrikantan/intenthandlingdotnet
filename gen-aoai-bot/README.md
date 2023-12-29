# fsi-oai-bot
This is a Bot Application used to showcase a customer agent scenario for a Bank. It is built using the Microsoft Bot Framework. It uses Azure Cognitive Semantic Search and ChatGPT (turbo3.5) model



## Steps to deploy the Bot to Azure App Service

The following configuration is meant to be used when developing locally


```
{
"MicrosoftAppType": "MultiTenant",
  "MicrosoftAppId": "<YOUR_BOT_APP_ID>",
  "MicrosoftAppPassword": "<YOUR_APP_SECRET>",
  "MicrosoftAppTenantId": "",
  "CURRICULUM_INDEX_NAME": "contoso-retail-index",
  "CURRICULUM_SEMANTIC_CONFIG": "contoso-retail-config",
  "BANK_NAME": "Contoso Retail eCom",
  "SEMANTIC_SEARCH_ENDPOINT": "https://<YOUR COGNITIVE SEARCH RESOURCE>.search.windows.net",
  "SEMANTIC_SEARCH_API_KEY": "YOUR_COGNITIVE_SEARCH_API_KEY_",
  "OPEN_AI_ENDPOINT": "https://<YOUR_OPEN_AI_ENDPOINT>.openai.azure.com/",
  "OPEN_AI_API_KEY": "YOUR_OPEN_AI_API_KEY",
  "OPEN_AI_MODEL_DEPLOYMENT_NAME": "turbo",
  "OPEN_AI_MODEL_DEPLOYMENT_NAME_COMPLETIONS_END_POINT": "davinci"
} 
```


Steps to deploy app from VS Code and CLI

The appsettings file should contain only the following when pushing to Azure. This is because the other config parameters have been set in the Web App itself, in Application Settings

{
  "MicrosoftAppType": "MultiTenant",
 "MicrosoftAppId": "<YOUR_BOT_APP_ID>",
  "MicrosoftAppPassword": "<YOUR_APP_SECRET>",
  "MicrosoftAppTenantId": ""
}


Build the Bot Project in Release Mode
dotnet build -c release
az bot prepare-deploy --lang Csharp --code-dir "." --proj-file-path "chgpt-bot.csproj"
Create a zip file manually with all the content in the project folder

az webapp deployment source config-zip --resource-group "sdp_bfsi" --name "mtccontoso" --src "azopenai-bot-pkg.zip"

