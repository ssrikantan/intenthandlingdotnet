using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Azure;
using Azure.AI.OpenAI;
using System;


using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
using System.Collections.Generic;
using System.Text;

namespace EchoBot.services
{


    public class ChatGPTClient
    {
        string endpoint = AppParameters.OPEN_AI_ENDPOINT;
        OpenAIClient client;

        private static string system_prompt = string.Empty;
        public ChatGPTClient()
        {
            client = new OpenAIClient(new System.Uri(endpoint), new AzureKeyCredential(AppParameters.OPEN_AI_API_KEY));
            if(string.IsNullOrEmpty(system_prompt))
            {
               string[] all_lines = System.IO.File.ReadAllLines(@"..\data\metaprompt.txt");
                foreach(string line in all_lines)
                {
                     system_prompt += line;
                }
            }
        }

        public async Task<string> InitConversationPromptState(ChatCompletionsOptions chatCompletionsOptions, string message)
        {
            string answer = String.Empty;
            chatCompletionsOptions.Messages.Add(new ChatMessage(ChatRole.System, system_prompt));
            chatCompletionsOptions.Messages.Add(new ChatMessage(ChatRole.User, message));
            answer = await MakeConversation(chatCompletionsOptions);
            chatCompletionsOptions.Messages.Add(new ChatMessage(ChatRole.Assistant, answer));
            return answer;
        }


        public async Task<string> GetUpdatedConversationState( ChatCompletionsOptions chatCompletionsOptions, string query)
        {
            string answer = String.Empty;
            System.Console.WriteLine("***************  running new user query from the Bot ****************");
            System.Console.WriteLine("user query from the Bot :" + query);

    
            // Update the conversation context with the new user query
            chatCompletionsOptions.Messages.Add(new ChatMessage(ChatRole.User, query));
            answer = await MakeConversation(chatCompletionsOptions);
            chatCompletionsOptions.Messages.Add(new ChatMessage(ChatRole.Assistant, answer));
            return answer;
        }


        public async Task<string> MakeConversation(ChatCompletionsOptions chatCompletionsOptions)
        {
            string response_msg = string.Empty;


            //chatCompletionsOptions.Messages = currentConversationState;

            Response<StreamingChatCompletions> response = null;
            try
            {
                response = await client.GetChatCompletionsStreamingAsync(deploymentOrModelName: AppParameters.OPEN_AI_MODEL_DEPLOYMENT_NAME, chatCompletionsOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error running ChatGPT Bot " + ex.StackTrace);
                response_msg = ex.Message;
                return response_msg;
            }
            using StreamingChatCompletions streamingChatCompletions = response.Value;

            await foreach (StreamingChatChoice choice in streamingChatCompletions.GetChoicesStreaming())
            {

                await foreach (ChatMessage message in choice.GetMessageStreaming())
                {

                    response_msg += message.Content;
                }
            }
            Console.WriteLine("the answer to the question from ChatGPT\n" + response_msg);
            return response_msg;

        }
    }


}