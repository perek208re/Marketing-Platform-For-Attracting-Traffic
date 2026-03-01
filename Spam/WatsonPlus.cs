using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Spam
{
    public class WatsonPlus
    {
        public WatsonPlus(string apiKey, Main mainInstance)
        {
            this.apiKey = apiKey;
            this.main = mainInstance; // Використовуємо переданий екземпляр
            botClient = new TelegramBotClient(this.apiKey);
        }

        private readonly Main main;
        private readonly string apiKey;
        private readonly ITelegramBotClient botClient;
        private bool isAwaitingCoupon = false;
        private bool isAwaitingPhoneNumber = false;
        private int GenerateDiscountCoupon()
        {
            Random random = new Random();
            int discount = random.Next(10000, 999999);
            return discount;
        }

        public void Start()
        {
            botClient.StartReceiving(Update, Error);
        }

        private async Task SendMessageAsync(long chatId, string message, ReplyMarkup replyMarkup = null)
        {
            await botClient.SendTextMessageAsync(chatId, message, replyMarkup: replyMarkup);
        }

        private ReplyKeyboardMarkup CreatePhoneRequestButton()
        {
            return new ReplyKeyboardMarkup(new[]
            {
                new KeyboardButton("Надіслати номер 📞") { RequestContact = true }
            })
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };
        }

        private void ShowChatInfo(Chat chat)
        {
            Console.WriteLine("\nCHAT INFORMATION:");
            Console.WriteLine($"Chat ID: {chat.Id}");
            Console.WriteLine($"Chat Type: {chat.Type}");
            Console.WriteLine($"Title: {chat.Title ?? "NULL"}");
            Console.WriteLine($"Username: {chat.Username ?? "NULL"}");
            Console.WriteLine($"First Name: {chat.FirstName ?? "NULL"}");
            Console.WriteLine($"Last Name: {chat.LastName ?? "NULL"}");
        }

        private void ShowMessageInfo(Message message)
        {
            if (message != null)
            {
                Console.WriteLine($"\nUser says: {message.Text ?? "NULL"}");
            }
        }

        private void ShowContactInfo(Contact contact)
        {
            Console.WriteLine("\nCONTACT INFORMATION:");
            Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
            Console.WriteLine($"First Name: {contact.FirstName}");
            Console.WriteLine($"Last Name: {contact.LastName ?? "NULL"}");
            Console.WriteLine($"User ID: {contact.UserId}");
        }
   public async Task SendCustomMessageAsync(long chatId, string messageText)
{
    if (string.IsNullOrWhiteSpace(messageText))
    {
        await SendMessageAsync(chatId, "❌ Повідомлення не може бути порожнім.");
        return;
    }

    await SendMessageAsync(chatId, messageText);
}


        private async Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            if (message == null) return;

            ShowMessageInfo(message);

            if (message.Text != null)
            {
                if (message.Text.ToLower() == "/start")
                {
                    await SendMessageAsync(message.Chat.Id, "Привіт, я Watsons+! 😊");
                    
                    await SendMessageAsync(message.Chat.Id, "Будь ласка, введіть код вашого купону :");
                    ShowChatInfo(message.Chat);
                    isAwaitingCoupon = true;
                    isAwaitingPhoneNumber = false;
                    return;
                }

                if (isAwaitingCoupon)
                {
                    if (int.TryParse(message.Text, out int coupon) && coupon > 0 && coupon < 100)
                    {
                        int Random = GenerateDiscountCoupon();
                       if(main.newClient(coupon, message.Chat.Id.ToString()))     
                        await SendMessageAsync(message.Chat.Id, $"Ваш купон {Random}, активуйте на нашому сайті.");
                       else
                          await SendMessageAsync(message.Chat.Id, $"Цей купон активований.");
                        await SendMessageAsync(message.Chat.Id, "Щоб завжди бути в курсі найвигідніших акцій і пропозицій, рекомендуємо зареєструватися, відправивши свій номер телефону:", CreatePhoneRequestButton());
                        isAwaitingCoupon = false;
                        isAwaitingPhoneNumber = true;
                        return;
                    }
                    else
                    {
                        await SendMessageAsync(message.Chat.Id, "❌ Купон недійсний:");
                        return;
                    }
                }
            }

            if (isAwaitingPhoneNumber && message.Contact != null)
            {
                ShowContactInfo(message.Contact);
                await SendMessageAsync(message.Chat.Id, "Дякуємо за реєстрацію! 🎉 Тепер ви завжди будете в курсі найсмачніших цін.");
                isAwaitingPhoneNumber = false;
            }
        }

        private Task Error(ITelegramBotClient client, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine($"[ERROR] {exception.Message}");
            return Task.CompletedTask;
        }
    }
}

