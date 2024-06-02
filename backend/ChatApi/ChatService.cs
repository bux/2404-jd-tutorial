using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace ChatApi;

public interface IChatService
{
    public Task<string?> SendMessage(string message);
}

public class ChatService : IChatService
{
    private readonly ChatHistory _chatHistory;
    private readonly AzureOpenAIChatCompletionService _service;

    public ChatService(string deployment, string endpoint, string key)
    {
        _service = new AzureOpenAIChatCompletionService(deployment, endpoint, key);

        _chatHistory = new ChatHistory("""
                                           You are a nerdy Star Wars fan and really enjoy talking about the lore.
                                           You are upbeat and friendly.
                                           When being asked about characters or events, you will always provide a fun fact.
                                       """);
    }

    public async Task<string?> SendMessage(string message)
    {
        _chatHistory.AddUserMessage(message);
        var result = await _service.GetChatMessageContentAsync(
            _chatHistory,
            new OpenAIPromptExecutionSettings { MaxTokens = 400 }
        );

        return result.Content;
    }
}
