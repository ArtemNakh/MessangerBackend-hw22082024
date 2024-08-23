
using System.Text.Json;
using MessangerBackend.DTOs;

namespace MessangerBackend.Middlewares
{
    public class MessageFilterMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string[] _bannedWords = { "russia", "war" };

        public MessageFilterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            context.Request.EnableBuffering();

            using var reader = new StreamReader(context.Request.Body, leaveOpen: true);
            var body = await reader.ReadToEndAsync();
            context.Request.Body.Position = 0;

            var messageDto = new MessageDTO();

            using (JsonDocument document = JsonDocument.Parse(body))
            {
                JsonElement root = document.RootElement;

                if (root.TryGetProperty("senderId", out JsonElement senderIdElement))
                    messageDto.SenderId = senderIdElement.GetInt32();
                

                if (root.TryGetProperty("chatId", out JsonElement chatIdElement))
                    messageDto.ChatId = chatIdElement.GetInt32();
                

                if (root.TryGetProperty("text", out JsonElement textElement))
                    messageDto.Text = textElement.GetString();
                
            }

            foreach (var bannedWord in _bannedWords)
            {
                messageDto.Text = messageDto.Text.Replace(bannedWord, "***", StringComparison.OrdinalIgnoreCase);
            }

            var modifiedBody = JsonSerializer.Serialize(messageDto);
            var buffer = System.Text.Encoding.UTF8.GetBytes(modifiedBody);
            context.Request.Body = new MemoryStream(buffer);
            context.Request.ContentLength = buffer.Length;



            await _next(context);
        }
    }

    public static class MessageFilterMiddlewareExtensions
    {
        public static IApplicationBuilder UseMessageFilter(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MessageFilterMiddleware>();
        }
    }
}
