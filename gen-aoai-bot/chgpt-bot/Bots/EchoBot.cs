// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with EchoBot .NET Template version v4.17.1

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using EchoBot.services;
using EchoBot.State;
using Azure.AI.OpenAI;

namespace EchoBot.Bots
{
    public class EchoBot : ActivityHandler
    {

        private BotState _conversationState;
        private static ChatGPTClient chatGptClient = new ChatGPTClient();
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
           string response_msg = "";
            var conversationStateAccessors = _conversationState.CreateProperty<ConversationData>(nameof(ConversationData));
            var conversationData = await conversationStateAccessors.GetAsync(turnContext, () => new ConversationData());

            if (conversationData.chatCompletionsOptions == null)
            {
                conversationData.chatCompletionsOptions = new ChatCompletionsOptions();
                //conversationData.Messages = chatGptClient.InitConversationState();
                response_msg = await chatGptClient.InitConversationPromptState(conversationData.chatCompletionsOptions,turnContext.Activity.Text);
            }
            else
            {

            response_msg = await chatGptClient.GetUpdatedConversationState(conversationData.chatCompletionsOptions,turnContext.Activity.Text);

            }
            await turnContext.SendActivityAsync(MessageFactory.Text(response_msg, response_msg), cancellationToken);
        }

        public EchoBot(ConversationState conversationState)
        {
            _conversationState = conversationState;
        }


        public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            await base.OnTurnAsync(turnContext, cancellationToken);

            // Save any state changes that might have occurred during the turn.
            await _conversationState.SaveChangesAsync(turnContext, false, cancellationToken);
        }

    }
}
