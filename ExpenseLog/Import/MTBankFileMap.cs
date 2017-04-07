using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseLog.Import
{
    // "Тип","Дата операции","Дата обработки","Место операции","Oписание операции","Карта","Валюта","Сумма в валюте операции","Сумма в валюте счета","Остаток счета"
    //  "A","30.03.2017 17:47:56","..","GIPPO TRADE CENTRE / MINSK / BY","Оплата товаров и услуг","535104******9291","BYN","-42.60","-42.60",""

    public class MTBankFileMap : CsvClassMap<MTBankFile>
    {
        CultureInfo cultureInfo = new CultureInfo("ru-RU");
        public MTBankFileMap()
        {
            Map(m => m.Type).Name("Тип");
            Map(m => m.DateOfOperation).Name("Дата операции").TypeConverterOption(cultureInfo);
            Map(m => m.DateOfTransaction).Name("Дата обработки");
            Map(m => m.Place).Name("Место операции");
            Map(m => m.Description).Name("Oписание операции");
            Map(m => m.Card).Name("Карта");
            Map(m => m.Currency).Name("Валюта");
            Map(m => m.Amount).Name("Сумма в валюте операции").TypeConverterOption(NumberStyles.Currency);
            Map(m => m.BaseCurrencyAmount).Name("Сумма в валюте счета").TypeConverterOption(NumberStyles.Currency); ;
            Map(m => m.RemainingBalance).Name("Остаток счета").TypeConverterOption(NumberStyles.Currency); ;
        }

    }
}
