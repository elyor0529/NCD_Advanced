namespace NCD.UTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NCD.Infrastructure.Helpers;

    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        [Description("SnedGrid test email")]
        public async void TestMethod1()
        {
            await SendGridHelper.SendAsync("elyor.blog@gmail.com", "Test", "Test", Environment.CurrentDirectory + "\\clashofclans.pdf");
        }
    }
}
