using ExpenseLog.Controllers;
using System;
using System.IO;
using Xunit;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Xunit.Abstractions;

namespace UnitTests
{
    public class CsvTest
    {
        private readonly ITestOutputHelper output;
        public CsvTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public async System.Threading.Tasks.Task Test1Async()
        {
            //Arrange
            var fileMock = new Mock<IFormFile>();
            //Setup mock file 

            var fs = File.OpenRead("sample_bank.csv");
            fileMock.Setup(m => m.OpenReadStream()).Returns(fs);

            var sut = new UploadController();
            var file = fileMock.Object;
            //Act
            var result = await sut.UploadCsv(file);
            //Assert
            Assert.IsType(typeof(OkObjectResult), result);
            output.WriteLine(((OkObjectResult)result).Value.ToString());
        }
    }
}
