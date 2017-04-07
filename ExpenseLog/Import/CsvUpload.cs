using CsvHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseLog.Import
{
    public class CsvUpload
    {
        /// <summary>
        /// Reads Only MTBank for now
        /// </summary>
        /// <param name="stream">FileStream with csv</param>
        /// <returns>List of rows parsed</returns>
        public List<MTBankFile> ReadCsv(FileStream stream)
        {
            using (TextReader reader = new StreamReader(stream))
            {
                var csv = new CsvReader(reader);
                csv.Configuration.RegisterClassMap<MTBankFileMap>();

                return csv.GetRecords<MTBankFile>().ToList();
            }
        }
    }
}
