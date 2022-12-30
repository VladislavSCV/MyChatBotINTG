using Microsoft.VisualBasic;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ConsoleApp3
{
    class Program1
    {
        static async Task Main(string[] args)
        {
            var botClient = new TelegramBotClient("5522123279:AAGaQ27U4WDeA4JJdbLAzQWqrpIuQ_qlSqY");
            using CancellationTokenSource cts = new();

            // Начало приема не блокирует поток вызывающего абонента. Прием осуществляется в пуле потоков.
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>() // получать все типы обновлений
            };

            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );

            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Имя бота: @{me.Username}");
            Console.ReadLine();

            // Отправьте запрос на отмену, чтобы остановить бота
            cts.Cancel();

            async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
                // Обрабатывать только обновления сообщений: https://core.telegram.org/bots/api#message
                if (update.Message is not { } message)
                    return;
                // Обрабатывайте только текстовые сообщения
                if (message.Text is not { } messageText)
                    return;

                var chatId = message.Chat.Id;

                Console.WriteLine($"В чате номер'{chatId}' сказали: {message.Text}. Time:{message.Date.AddHours(3)}:{message.Date.Minute}:{message.Date.Second}");

               

                ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
                {
                            new KeyboardButton[] { "Ссылки на полезные тг каналы🕸" },
                            new KeyboardButton[] { "Душевная поддержка🔎" },

                            new KeyboardButton[] { "Связь с разработчиком👨‍💻" },
                            new KeyboardButton[] { "Приятные обои🔎" },
                            new KeyboardButton[] { "Мемчики🎰" },
                            new KeyboardButton[] { "GitHub Work🌎" },
                            new KeyboardButton[] { "Spam_attack👾" }
                        })
                {
                    ResizeKeyboard = true
                };
                switch (message.Text)
                {
                    case "/start":
                        Message message110101111101 = await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Привет, это экспериментальный бот для обучения в сфере IT! Можете его протестировать!",
                        cancellationToken: cancellationToken);

                        Message sentMessage = await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "Выберите действие",
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);
                        break;

                    case "Связь с разработчиком👨‍💻":
                        Message message011 = await botClient.SendContactAsync(
                        chatId: chatId,
                        phoneNumber: "+79688393800",
                        firstName: "Vladislav",
                        lastName: "SCV",
                        cancellationToken: cancellationToken);
                        break;

                    case "Ссылки на полезные тг каналы🕸":
                        Message sentMessage122 = await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "https://t.me/itcour1",
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);
                        Message sentMessage2123 = await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "https://t.me/hack_less",
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);
                        Message sentMessage431 = await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "https://t.me/+lv2bFm5tiEYxZmZi",
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);
                        Message sentMessage1321 = await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "https://t.me/tproger_official",
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);
                        Message sentMessage1232 = await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "https://t.me/+LqyHN4O0iFE5YjEy",
                    replyMarkup: replyKeyboardMarkup,
                    cancellationToken: cancellationToken);
                        break;



                    case "Душевная поддержка🔎":
                        var motv= new List<string> { "У тебя точно все получиться!", "Пока мечтатели мечтают, ты будешь писать код и добиваться успеха", "JUST DO IT!", "Тебе нужно кодить столько, сколько не смог никто", "Садись кодить!" };
                        Random random = new Random();
                        int index = random.Next(motv.Count);
                        var name = motv[index];
                        motv.RemoveAt(index);
                        Message message123 = await botClient.SendTextMessageAsync(
                           chatId: chatId,
                           text: name,
                           cancellationToken: cancellationToken);
                        break;

                    case "Топ 5 IT каналов в тг🕸":
                        Message message11011011011 = await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Эти каналы лучшие по моему мнению. Для изучения языков программировния и компьютерной грамотности они подходят на отлично!",
                        cancellationToken: cancellationToken);
                        Message message11011011 = await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "https://t.me/the_windows",
                        cancellationToken: cancellationToken);
                        Message message110110110 = await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "https://t.me/PushEnter",
                        cancellationToken: cancellationToken);
                        Message message1101101101 = await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "https://t.me/+LqyHN4O0iFE5YjEy",
                        cancellationToken: cancellationToken);
                        Message message11011011010 = await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "https://t.me/+T2bX79ISn5M3NjIy",
                        cancellationToken: cancellationToken);
                        Message message110110110101 = await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "https://t.me/tproger_official",
                        cancellationToken: cancellationToken);

                        break;

                    case "Приятные обои🔎":
                        var prob = new List<string> { "https://lh3.googleusercontent.com/-wwFDSdYIc4I/VdQbQtTLRuI/AAAAAAAAAJY/TyKVNZW9VnU/s1920-Ic42/Jobs_1920X1080.JPG \n Стильно и для работы"
                            ,"https://coolsen.ru/wp-content/uploads/2021/12/129-20211213_015722.jpg \n Выглядит не плохо)"
                            ,"https://phonoteka.org/uploads/posts/2022-06/1656611418_8-phonoteka-org-p-oboi-programmirovanie-10.jpg \n WOW"
                            ,"https://mobimg.b-cdn.net/v3/fetch/ef/efb7c97665471fbc8b1ad522e4112974.jpeg","https://www.zastavki.com/pictures/1920x1200/2011/Creative_Wallpaper_Way_to_a_creative_028379_.jpg \n ..."
                            ,"https://www.fonstola.ru/images/201610/fonstola.ru_247289.jpg" 
                            ,"https://i.pinimg.com/originals/fa/06/a6/fa06a6cc191377d0bb3f68d3f63ca2d8.jpg" 
                            ,"https://million-wallpapers.ru/wallpapers/4/35/503339429260115/biznes-noutbuk-v-ofise.jpg" 
                            ,"https://www.tapeciarnia.pl/tapety/normalne/tapeta-czarne-szesciany-w-wodzie.jpg" 
                            ,"https://24warez.ru/uploads/posts/2017-01/1484987255_computerdesktopwallpaperscollection1716__012.jpg" 
                            ,"https://phonoteka.org/uploads/posts/2021-06/1624387053_36-phonoteka_org-p-realistichnie-oboi-na-telefon-krasivo-37.jpg" 
                            ,"https://phonoteka.org/uploads/posts/2021-07/1625360579_17-phonoteka-org-p-oboi-minimalizm-kaktus-oboi-krasivo-17.jpg" 
                            ,"https://phonoteka.org/uploads/posts/2021-07/1625388671_3-phonoteka-org-p-oboi-dlya-rabochego-stola-minimalizm-perfe-3.jpg" 
                            ,"https://phonoteka.org/uploads/posts/2022-06/1654156482_63-phonoteka-org-p-spokoinie-oboi-na-telefon-krasivo-66.jpg" 
                            ,"https://phonoteka.org/uploads/posts/2021-06/1624091641_2-phonoteka_org-p-oboi-na-telefon-so-smislom-krasivo-2.jpg" 
                            ,"https://catherineasquithgallery.com/uploads/posts/2021-02/1614390919_67-p-temnii-fon-na-noutbuke-80.jpg" 
                            ,"https://celes.club/uploads/posts/2022-06/1654679440_30-celes-club-p-oboi-vindovs-krasnie-krasivie-33.png"};
                        Random random1 = new Random();
                        int index1 = random1.Next(prob.Count);
                        var prob1 = prob[index1];
                        prob.RemoveAt(index1);

                        Message message12345 = await botClient.SendPhotoAsync(
                        chatId: chatId,
                        photo: prob1,
                        caption: "<b></b>. <i></i>: <a href=\"\"></a>",
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                        break;

                    case "Мемчики🎰":
                        Message message1101101 = await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Для доп. мемчиков введите команду еще раз) ",
                        cancellationToken: cancellationToken);

                        var memch = new List<string> { "https://cs6.pikabu.ru/post_img/2014/07/28/5/1406524554_1605969918.jpg",
                            "https://cs6.pikabu.ru/post_img/big/2014/10/13/11/1413219813_1340057670.png",
                            "https://fikiwiki.com/uploads/posts/2022-02/1644925836_43-fikiwiki-com-p-prikolnie-kartinki-pro-programmistov-46.jpg",
                            "https://mtdata.ru/u21/photo2331/20735334115-0/original.jpg",
                            "https://www.xelent.ru/upload/medialibrary/9f0/1.jpg",
                            "https://fuzeservers.ru/wp-content/uploads/3/c/a/3ca5a929d2df227fbc2489f2de86ba8d.jpeg",
                            "https://i.yapx.cc/ME9Bo.jpg" ,
                            "https://avatars.dzeninfra.ru/get-zen_doc/1773286/pub_5cca7a61ffaa2300b352cdb7_5cca7b3557047600b302fcff/scale_1200" ,
                            "https://i03.fotocdn.net/s131/c7dabcac5fec859e/public_pin_l/2947761026.jpg" ,
                            "https://cdn.trinixy.ru/pics5/20140512/nerd_joke_08.jpg" ,
                            "https://lh5.googleusercontent.com/_fstRDiuZZnM6hiGW2geW0DaGEj0YIHpVNyTENnoV3eM3wvL1EDMhKr_ibH1-sxzTfQscD4QNozzlzosoyC8N2XlXUpoKlX0te76OdmVFrQBGRliy_mdh_0eWjouUebRZrf0MhYE" ,
                            "https://fuzeservers.ru/wp-content/uploads/9/2/2/9220769ed530f1ea0293011ad8c70c3f.jpeg" ,
                            "https://fuzeservers.ru/wp-content/uploads/1/7/e/17e8ee9f137ffedd55317461c9403018.png" ,
                            "https://i.pinimg.com/originals/3c/08/4c/3c084cb786d567c47eb1d80b4fe8d8b8.jpg" ,
                            "https://yt3.ggpht.com/ytc/AKedOLTCXmofi2ibdtaEoy2tXuDkKZ5RAuxg_MCOMINg=s900-c-k-c0x00ffffff-no-rj"};
                        Random random2 = new Random();
                        int index2 = random2.Next(memch.Count);
                        var memch1 = memch[index2];
                        memch.RemoveAt(index2);

                        Message message123456 = await botClient.SendPhotoAsync(
                        chatId: chatId,
                        photo: memch1,
                        caption: "<b>Улыбнись)</b>. <i></i>: <a href=\"\"></a>",
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                        break;

                    case "GitHub Work🌎":
                        Message message111 = await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Это моя первая работа",
                        parseMode: ParseMode.MarkdownV2,
                        disableNotification: true,
                        replyToMessageId: update.Message.MessageId,
                        replyMarkup: new InlineKeyboardMarkup(
                            InlineKeyboardButton.WithUrl(
                                text: "Перейдите по ссылке",
                        url: "https://github.com/VladislavSCV/_MY_FIRST_WORK_on-C-/blob/main/Program.cs"
                                 )),
                        cancellationToken: cancellationToken);

                        Message message112 = await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Это мое хобби",
                        parseMode: ParseMode.MarkdownV2,
                        disableNotification: true,
                        replyToMessageId: update.Message.MessageId,
                        replyMarkup: new InlineKeyboardMarkup(
                            InlineKeyboardButton.WithUrl(
                                text: "Перейдите по ссылке",
                        url: "https://github.com/VladislavSCV/HW._2.8/blob/main/Ready.HW_DOLBAN.WU_HU.cs"
                                 )),
                        cancellationToken: cancellationToken);

                        Message message113 = await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Это моя последняя работа",
                        parseMode: ParseMode.MarkdownV2,
                        disableNotification: true,
                        replyToMessageId: update.Message.MessageId,
                        replyMarkup: new InlineKeyboardMarkup(
                            InlineKeyboardButton.WithUrl(
                                text: "Перейдите по ссылке",
                        url: "https://github.com/VladislavSCV/Game_Life2.3/blob/main/Game_Life!1.2.cs"
                                 )),
                        cancellationToken: cancellationToken);
                        break;

                    case "Spam_attack👾":
                        
                        for (int x=0; x<30;x++) {
                            
                            Message message110110111 = await botClient.SendTextMessageAsync(
                            chatId: chatId,
                            text: "Я СЛЕЖУ ЗА ТОБОЙ)",
                            cancellationToken: cancellationToken); }
                        break;

                    default:
                        Message message11011 = await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Такс вы или ошиблись командой или хотите поговорить?\n" +
                        "Ну ничего если вам скучно можете заглянуть на интересные IT каналы!",
                        cancellationToken: cancellationToken);
                        break;
                }
            }
            // Повторите полученный текст сообщения
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
        }
    }
}

