using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ExpenseLog.Import
{
    // "Тип","Дата операции","Дата обработки","Место операции","Oписание операции","Карта","Валюта","Сумма в валюте операции","Сумма в валюте счета","Остаток счета"
    //  "A","30.03.2017 17:47:56","..","GIPPO TRADE CENTRE / MINSK / BY","Оплата товаров и услуг","535104******9291","BYN","-42.60","-42.60",""

    public class MTBankFile
    {
        public string Type { get; set; }
        public DateTime DateOfOperation { get; set; }
        public string DateOfTransaction { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public string Card { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public decimal BaseCurrencyAmount { get; set; }
        public decimal? RemainingBalance { get; set; }

        public override string ToString()
        {
            string result = "";
            var props = (typeof(MTBankFile)).GetProperties();
            foreach (var prop in props)
            {
                result += prop.GetValue(this)+ " ,";
            }
            return result;

        }
    }
}
