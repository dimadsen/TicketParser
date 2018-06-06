using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TicketParser
{
    public class Availability
    {
        /// <summary>
        /// Id матча
        /// </summary>
        public string p { get; set; }

        /// <summary>
        /// Id категории 
        /// </summary>
        public string c { get; set; } 

        /// <summary>
        /// Id наличия
        /// </summary>
        public string a { get; set; } 

        public static async Task<List<Availability>> GetTickets()
        {
            List< Availability> tickets = null;
            try
            {
                Console.WriteLine("Начал грязный парсинг...");
                string url = "https://tickets.fifa.com/API/WCachedL1/ru/BasicCodes/GetBasicCodesAvailavilityDemmand?currencyId=USD";

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");

                client.BaseAddress = new Uri(url);

                var response = await client.GetAsync(new Uri(url));
                response.EnsureSuccessStatusCode(); // выброс исключения, если произошла ошибка

                // десериализация ответа в формате json
                var content = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(content);
                var str = o.SelectToken(@"$.Data.Availability");
                var availabilitys = JsonConvert.DeserializeObject<List<Availability>>(str.ToString());


                tickets = availabilitys.Where(x => x.c != "18" && x.c != "19" && x.c != "20" && x.c != "37").ToList();
                Console.WriteLine("Всё норма. страничка с билетиками успешно получена");
                return tickets;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Чёт не удалось загрузить страничку с билетами. Причина: {ex.Message}");
                return tickets;
            }
            
        }
    }
    
}
