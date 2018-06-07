using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicketParser
{
    public static class Conversion
    {
        public static void Start()
        {
            Console.WriteLine(DateTime.Now);
            var message = "Хай. Погнали смотреть какие билеты в наличии. Будем долбить их каждые 45 секунд";
            Console.WriteLine(message);

            TimerCallback timerParse = new TimerCallback(ViewTickets);
            Timer timer = new Timer(timerParse, 0, 0, 45000);

            Console.ReadKey();
        }

        public static async void ViewTickets(object o)
        {
            var tickets = await Availability.GetTickets();
            var groupsTickets = tickets?.GroupBy(x => x.p).ToList();

            var matches = new List<Match>();

            groupsTickets?.ForEach(m =>
            {
                if (m.Any(x => x.a != "0"))
                    matches.Add(m.ConvertToMatch());
            });

            if (matches.Count > 0)
                ConsoleWrite(matches);
            else
            {
                Console.WriteLine("Не нашёл билетов :(((");
            }

        }

        public static void ConsoleWrite(List<Match> matches)
        {            
            var categories = new List<string>();
            var messages = new List<string>();

            string message = null;

            matches.ForEach(match =>
            {
                match.Categories.ForEach(m => categories.Add($"{m.Name} - {m.Quantity}"));
                message = $@"НАЙДЕНЫ БИЛЕТЫ!!!! НАЙДЕНЫ БИЛЕТЫ!!! Фиксирую время: {DateTime.Now}
{match.Name} 
{string.Join(", ", categories.ToArray())}";

                categories.Clear();
                
                messages.Add(message);
                message.ToConsole();
            });

            messages.SendEmailMessage();
        }        

        private static void ToConsole(this string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.Beep();
            Console.WriteLine();

        }
        private static void SendEmailMessage(this List<string> messages)
        {
            try
            {
                var info = new NetworkCredential()
                {
                    UserName = "ticketparser@yandex.ru",
                    Password = "Pars2018"
                };

                var client = new SmtpClient()
                {
                    Timeout = 10000, 
                    EnableSsl = true,
                    Host = "smtp.yandex.ru",
                    Credentials = info
                };
               
                var mail = new MailMessage("ticketparser@yandex.ru", "Chezzy_fcb1990@icloud.com")
                {
                    Subject = "Наличие билетов",
                    SubjectEncoding = Encoding.UTF8,
                    Body = string.Join(@",

", messages.ToArray()),
                    BodyEncoding = Encoding.UTF8
                };

                Console.WriteLine("Отправляю сообщение на Email...");
                client.Send(mail);
                Console.WriteLine("Сообщение успешно отправлено!");
            }
            catch (SmtpException ex)
            {
                Console.WriteLine($"Не смог отправить сообщение. Причина : {ex.Message} ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Не смог отправить сообщение. Причина : {ex.Message} ");
            }
        }
    }
}
