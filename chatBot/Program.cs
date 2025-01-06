using System;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi;


Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

#region token
string token = "7046899072:AAEPA0oDocOVyMGOqCfUzxSsyQefEyZXNrI";
#endregion

var bot = new TelegramBot(token, null);
long offset = 0;

while (true)
{
    var updates = bot.MakeRequestAsync(new GetUpdates() { Offset = offset }).Result;
    foreach(var update in updates)
    {
        if (update.Message != null)
        {
            var message = update.Message;
            string messageText = message.Text.ToLower();
            string responseText;
            if (messageText == "вітаю")
            {
                responseText = "Добрий день!";
            }
            else if (messageText == "котра година?")
            {
                responseText = $"Поточний час: {DateTime.Now}";
            }
            else
            {
                responseText =$"Не розумію";
            }
            bot.MakeRequestAsync(new SendMessage(message.Chat.Id, responseText)).Wait();
            Console.WriteLine(update.Message.Text);
            offset = update.UpdateId + 1;
        }
    }
}
