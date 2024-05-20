using Npgsql;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

var botClient = new TelegramBotClient(Environment.GetEnvironmentVariable("TG_BOT_API_KEY"));

using CancellationTokenSource cts = new();

ReceiverOptions receiverOptions = new()
{
    AllowedUpdates = Array.Empty<UpdateType>() 
};

botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);

var me = await botClient.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
Console.ReadLine();

cts.Cancel();

async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    if (update.Message is not { } message)
        return;
    
    if (message.Text is not { } messageText)
        return;

    var chatId = message.Chat.Id;

    var host = Environment.GetEnvironmentVariable("POSTGRES_HOST");
    var username = Environment.GetEnvironmentVariable("POSTGRES_USER");
    var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
    var database = Environment.GetEnvironmentVariable("POSTGRES_NAME");
    var port = Environment.GetEnvironmentVariable("POSTGRES_PORT");
    
    var connectionString = $"Host={host};Username={username};Password={password};Database={database};Port={port}";
    await using var dataSource = NpgsqlDataSource.Create(connectionString);
    
    
    if (messageText == "/events")
    {
        await using (var cmd = dataSource.CreateCommand("SELECT title, start_date, end_date FROM events"))
        await using (var reader = await cmd.ExecuteReaderAsync())
        {
            var list = new List<string>();
            while (await reader.ReadAsync())
            {
                list.Add($"{reader.GetString(0)}" +
                                  $" ({reader.GetDateTime(1).ToShortDateString()} - {reader.GetDateTime(2).ToShortDateString()}");
            }
            
            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: $"Предстоящие события: \n {list[0]}",
                cancellationToken: cancellationToken);
        }

    }
    // Echo received message text
}

Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}
