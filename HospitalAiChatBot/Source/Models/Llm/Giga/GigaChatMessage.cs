// ReSharper disable InvalidXmlDocComment

using System.Text.Json.Serialization;

namespace HospitalAiChatBot.Source.Models.Llm.Giga;

public class GigaChatMessage(string content, LlmChatMessageAuthorRole role, string[]? attachments = null)
    : LlmChatMessage(content, role)
{
    [JsonPropertyName("attachments")]
    /// <summary>
    ///     <para>Массив идентификаторов файлов, которые нужно использовать при генерации.</para>
    ///     <see cref="https://developers.sber.ru/docs/ru/gigachat/api/reference/rest/post-chat">
    ///         Подробнее о работе с файлами с GigaChat API
    ///     </see>
    /// </summary>
    public string[] Attachments = attachments ?? [];
}