# chgpt-bot

### For all the config parameter values to use to run the application, refer to [link](https://microsoftapc.sharepoint.com/teams/MTCIndia-TeamInteractions/_layouts/OneNote.aspx?id=%2Fteams%2FMTCIndia-TeamInteractions%2FShared%20Documents%2FTeam%20Interactions%2FDemo%20Content%2FDemo%20-%20Environment%20details&wd=target%28OpenAI%20Demos.one%7C9C5746E0-F3F2-4B7C-AB80-8BA3A0A06EA4%2FOpen%20AI%20%2B%20Bot%20framework%7CA32CBA9A-FA87-4A03-91F2-E4152562C84A%2F%29onenote:https://microsoftapc.sharepoint.com/teams/MTCIndia-TeamInteractions/Shared%20Documents/Team%20Interactions/Demo%20Content/Demo%20-%20Environment%20details/OpenAI%20Demos.one#Open%20AI%20+%20Bot%20framework&section-id={9C5746E0-F3F2-4B7C-AB80-8BA3A0A06EA4}&page-id={A32CBA9A-FA87-4A03-91F2-E4152562C84A}&end)

link
Bot Framework v4 echo bot sample.

This bot has been created using [Bot Framework](https://dev.botframework.com), it shows how to create a simple bot that accepts input from the user and echoes it back.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) version 6

  ```bash
  # determine dotnet version
  dotnet --version
  ```

## To try this sample

- In a terminal, navigate to `chgpt-bot`

    ```bash
    # change into project folder
    cd chgpt-bot
    ```

- Run the bot from a terminal or from Visual Studio, choose option A or B.

  A) From a terminal

  ```bash
  # run the bot
  dotnet run
  ```

  B) Or from Visual Studio

  - Launch Visual Studio
  - File -> Open -> Project/Solution
  - Navigate to `chgpt-bot` folder
  - Select `chgpt-bot.csproj` file
  - Press `F5` to run the project

## Testing the bot using Bot Framework Emulator

[Bot Framework Emulator](https://github.com/microsoft/botframework-emulator) is a desktop application that allows bot developers to test and debug their bots on localhost or running remotely through a tunnel.

- Install the Bot Framework Emulator version 4.9.0 or greater from [here](https://github.com/Microsoft/BotFramework-Emulator/releases)

### Connect to the bot using Bot Framework Emulator

- Launch Bot Framework Emulator
- File -> Open Bot
- Enter a Bot URL of `http://localhost:3978/api/messages`

## Deploy the bot to Azure

To learn more about deploying a bot to Azure, see [Deploy your bot to Azure](https://aka.ms/azuredeployment) for a complete list of deployment instructions.

## Further reading

- [Bot Framework Documentation](https://docs.botframework.com)
- [Bot Basics](https://docs.microsoft.com/azure/bot-service/bot-builder-basics?view=azure-bot-service-4.0)
- [Activity processing](https://docs.microsoft.com/en-us/azure/bot-service/bot-builder-concept-activity-processing?view=azure-bot-service-4.0)
- [Azure Bot Service Introduction](https://docs.microsoft.com/azure/bot-service/bot-service-overview-introduction?view=azure-bot-service-4.0)
- [Azure Bot Service Documentation](https://docs.microsoft.com/azure/bot-service/?view=azure-bot-service-4.0)
- [.NET Core CLI tools](https://docs.microsoft.com/en-us/dotnet/core/tools/?tabs=netcore2x)
- [Azure CLI](https://docs.microsoft.com/cli/azure/?view=azure-cli-latest)
- [Azure Portal](https://portal.azure.com)
- [Language Understanding using LUIS](https://docs.microsoft.com/en-us/azure/cognitive-services/luis/)
- [Channels and Bot Connector Service](https://docs.microsoft.com/en-us/azure/bot-service/bot-concepts?view=azure-bot-service-4.0)

Generated using `dotnet new echobot` v4.17.1
