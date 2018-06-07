﻿using System.Collections.Generic;
using System.Linq;

namespace TicketParser
{
    public static class TicketInfo
    {
        public static string GetMatchName(string name)
        {
            var matches = new Dictionary<string, string>
            {
                #region Матчи
                {"IMT01","Матч 01 - Россия : Саудовская Аравия - Москва «Лужники» 14 ИЮН 18:00"},
                {"IMT02","Матч 02 - Египет : Уругвай - Екатеринбург 15 ИЮН 17:00"},
                {"IMT03","Матч 03 - Португалия : Испания - Сочи 15 ИЮН 21:00"},
                {"IMT04","Матч 04 - Марокко : ИР Иран - Санкт-Петербург 15 ИЮН 18:00"},
                {"IMT05","Матч 05 - Франция : Австралия - Казань 16 ИЮН 13:00"},
                {"IMT06","Матч 06 - Перу : Дания - Саранск 16 ИЮН 19:00"},
                {"IMT07","Матч 07 - Аргентина : Исландия - Москва «Спартак» 16 ИЮН 16:00"},
                {"IMT08","Матч 08 - Хорватия : Нигерия - Калининград 16 ИЮН 21:00"},
                {"IMT09","Матч 09 - Бразилия : Швейцария - Ростов-на-Дону 17 ИЮН 21:00"},
                {"IMT10","Матч 10 - Коста-Рика : Сербия - Самара 17 ИЮН 16:00"},
                {"IMT11","Матч 11 - Германия : Мексика - Москва «Лужники» 17 ИЮН 18:00"},
                {"IMT12","Матч 12 - Швеция : Корея - Нижний Новгород 18 ИЮН 15:00"},
                {"IMT13","Матч 13 - Бельгия : Панама - Сочи 18 ИЮН 18:00"},
                {"IMT14","Матч 14 - Тунис : Англия - Волгоград 18 ИЮН 21:00"},
                {"IMT15","Матч 15 - Польша : Сенегал - Москва «Спартак» 19 ИЮН 18:00"},
                {"IMT16","Матч 16 - Колумбия : Япония - Саранск 19 ИЮН 15:00"},
                {"IMT17","Матч 17 - Россия : Египет - Санкт-Петербург 19 ИЮН 21:00"},
                {"IMT18","Матч 18 - Уругвай : Саудовская Аравия - Ростов-на-Дону 20 ИЮН 18:00"},
                {"IMT19","Матч 19 - Португалия : Марокко - Москва «Лужники» 20 ИЮН 15:00"},
                {"IMT20","Матч 20 - ИР Иран : Испания - Казань 20 ИЮН 21:00"},
                {"IMT21","Матч 21 - Франция : Перу - Екатеринбург 21 ИЮН 20:00"},
                {"IMT22","Матч 22 - Дания : Австралия - Самара 21 ИЮН 16:00"},
                {"IMT23","Матч 23 - Аргентина : Хорватия - Нижний Новгород 21 ИЮН 21:00"},
                {"IMT24","Матч 24 - Нигерия : Исландия - Волгоград 22 ИЮН 18:00"},
                {"IMT25","Матч 25 - Бразилия : Коста-Рика - Санкт-Петербург 22 ИЮН 15:00"},
                {"IMT26","Матч 26 - Сербия : Швейцария - Калининград 22 ИЮН 20:00"},
                {"IMT27","Матч 27 - Германия : Швеция - Сочи 23 ИЮН 21:00"},
                {"IMT28","Матч 28 - Корея : Мексика - Ростов-на-Дону 23 ИЮН 18:00"},
                {"IMT29","Матч 29 - Бельгия : Тунис - Москва «Спартак» 23 ИЮН 15:00"},
                {"IMT30","Матч 30 - Англия : Панама - Нижний Новгород 24 ИЮН 15:00"},
                {"IMT31","Матч 31 - Польша : Колумбия - Казань 24 ИЮН 21:00"},
                {"IMT32","Матч 32 - Япония : Сенегал - Екатеринбург 24 ИЮН 20:00"},
                {"IMT33","Матч 33 - Уругвай : Россия - Самара 25 ИЮН 18:00"},
                {"IMT34","Матч 34 - Саудовская Аравия : Египет - Волгоград 25 ИЮН 17:00"},
                {"IMT35","Матч 35 - ИР Иран : Португалия - Саранск 25 ИЮН 21:00"},
                {"IMT36","Матч 36 - Испания : Марокко - Калининград 25 ИЮН 20:00"},
                {"IMT37","Матч 37 - Дания : Франция - Москва «Лужники» 26 ИЮН 17:00"},
                {"IMT38","Матч 38 - Австралия : Перу - Сочи 26 ИЮН 17:00"},
                {"IMT39","Матч 39 - Нигерия : Аргентина - Санкт-Петербург 26 ИЮН 21:00"},
                {"IMT40","Матч 40 - Исландия : Хорватия - Ростов-на-Дону 26 ИЮН 21:00"},
                {"IMT41","Матч 41 - Сербия : Бразилия - Москва «Спартак» 27 ИЮН 21:00"},
                {"IMT42","Матч 42 - Швейцария : Коста-Рика - Нижний Новгород 27 ИЮН 21:00"},
                {"IMT43","Матч 43 - Корея : Германия - Казань 27 ИЮН 17:00"},
                {"IMT44","Матч 44 - Мексика : Швеция - Екатеринбург 27 ИЮН 19:00"},
                {"IMT45","Матч 45 - Англия : Бельгия - Калининград 28 ИЮН 20:00"},
                {"IMT46","Матч 46 - Панама : Тунис - Саранск 28 ИЮН 21:00"},
                {"IMT47","Матч 47 - Япония : Польша - Волгоград 28 ИЮН 17:00"},
                {"IMT48","Матч 48 - Сенегал : Колумбия - Самара 28 ИЮН 18:00"},
                {"IMT49","Матч 49 - 1A : 2B - Сочи 30 ИЮН 21:00"},
                {"IMT50","Матч 50 - 1C : 2D - Казань 30 ИЮН 17:00"},
                {"IMT51","Матч 51 - 1B : 2A - Москва «Лужники» 01 ИЮЛ 17:00"},
                {"IMT52","Матч 52 - 1D : 2C - Нижний Новгород 01 ИЮЛ 21:00"},
                {"IMT53","Матч 53 - 1E : 2F - Самара 02 ИЮЛ 18:00"},
                {"IMT54","Матч 54 - 1G : 2H - Ростов-на-Дону 02 ИЮЛ 21:00"},
                {"IMT55","Матч 55 - 1F : 2E - Санкт-Петербург 03 ИЮЛ 17:00"},
                {"IMT56","Матч 56 - 1H : 2G - Москва «Спартак» 03 ИЮЛ 21:00"},
                {"IMT57","Матч 57 - W49 : W50 - Нижний Новгород 06 ИЮЛ 17:00"},
                {"IMT58","Матч 58 - W53 : W54 - Казань 06 ИЮЛ 21:00"},
                {"IMT59","Матч 59 - W51 : W52 - Сочи 07 ИЮЛ 21:00"},
                {"IMT60","Матч 60 - W55 : W56 - Самара 07 ИЮЛ 18:00"},
                {"IMT61","Матч 61 - W57 : W58 - Санкт-Петербург 10 ИЮЛ 21:00"},
                {"IMT62","Матч 62 - W59 : W60 - Москва «Лужники» 11 ИЮЛ 21:00"},
                {"IMT63","Матч 63 - Матч за 3−е место - Санкт-Петербург 14 ИЮЛ 17:00"},
                {"IMT64","Матч 64 - Финал - Москва «Лужники» 15 ИЮЛ 18:00"},
#endregion
            };
            return matches.Where(x => x.Key == name).Select(x => x.Value).First();
        }

        public static string GetTicketCategory(string category)
        {
            var categories = new Dictionary<string, string>()
            {
                {"14","Категория 1"},
                {"15","Категория 2"},
                {"16","Категория 3"},
                {"17","Категория 4"},
            };

            return categories.Where(x => x.Key == category).Select(x => x.Value).First();
        }

        public static string GetTicketQuantity(string quantity)
        {
            var quant = new Dictionary<string, string>()
            {
                {"0","Нет в наличии"},
                {"1","Низкое количество"},
                {"2","Среднее количество"},
                {"3","Высокое количество"}
            };
            return quant.Where(x => x.Key == quantity).Select(x => x.Value).First();
        }

        public static Match ConvertToMatch(this IGrouping<string, Availability> group)
        {
            var match = new Match()
            {
                Name = GetMatchName(group.Key),
                Categories = new List<Category>()
            };

            group.ToList().ForEach(m =>
            {
                if (m.a != "0")
                {
                    match.Categories.Add(new Category
                    {
                        Name = GetTicketCategory(m.c),
                        Quantity = GetTicketQuantity(m.a)
                    });
                }
            });

            return match;
        }
    }
}
