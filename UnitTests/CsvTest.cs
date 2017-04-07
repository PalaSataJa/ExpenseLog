using ExpenseLog.Controllers;
using System;
using System.IO;
using Xunit;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Xunit.Abstractions;
using ExpenseLog.Import;
using System.Collections.Generic;
using System.Reflection;
using System.Globalization;

namespace UnitTests
{
    public class CsvTest
    {
        private readonly ITestOutputHelper output;
        private readonly string filePath;
        public CsvTest(ITestOutputHelper output)
        {
            this.output = output;
            string fileName = "sample_bank.csv";
            var location = typeof(CsvTest).GetTypeInfo().Assembly.Location;
            var dirPath = Path.GetDirectoryName(location);
            filePath =  Path.Combine(dirPath, fileName);
        }

        [Fact]
        public async System.Threading.Tasks.Task TestCsvController()
        {
            //Arrange
            var fileMock = new Mock<IFormFile>();

            //Setup mock file 
            var fs = File.OpenRead(filePath);
            fileMock.Setup(m => m.OpenReadStream()).Returns(fs);

            var sut = new UploadController();
            var file = fileMock.Object;
            //Act
            var result = await sut.UploadCsv(file);
            //Assert
            Assert.IsType(typeof(OkObjectResult), result);
            output.WriteLine(((OkObjectResult)result).Value.ToString());
        }

        [Fact]
        public void TestParser()
        {
            var fs = File.OpenRead(filePath);
            var sut = new CsvUpload();

            var result = sut.ReadCsv(fs);

            Assert.IsType<List<MTBankFile>>(result);
            foreach (var item in result)
            {
                output.WriteLine(item.ToString());
            }
        }

        [Fact]
        public void TestTime()
        {
            var str = "30.03.2017 17:47:56";
            DateTime date;

            Assert.False(DateTime.TryParse(str, out date));

            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");

            Assert.True(DateTime.TryParse(str, out date));
        }

        [Fact]
        public void TestDeciamal()
        {
            var str = "-42.60";
            decimal amount;

            Decimal.TryParse(str, out amount);
            output.WriteLine(amount.ToString());
        }
    }
}
