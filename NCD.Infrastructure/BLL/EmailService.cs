

namespace NCD.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Mail;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using NCD.Application.Domain;
    using NCD.Application.Services;
    using RazorEngine.Templating;
    using iTextSharp.text.html.simpleparser;
    using NCD.Infrastructure.Helpers;
    using PagedList;
    using System.Threading.Tasks;
    using System.Collections.Concurrent;

    public class EmailService : IEmailService
    {
        /// <summary>
        /// E-mail partion size
        /// </summary>
        private const int ATTACHMENT_SIZE = 10;


        /// <summary>
        /// Send async email 
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="persons"></param>
        /// <returns></returns>
        public async Task SendAsync(string emailAddress, Person[] persons)
        {
            //template path
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Templates\EmailTemplate.cshtml");

            if (string.IsNullOrWhiteSpace(emailAddress))
                throw new ArgumentNullException("emailAddress");

            if (persons == null || !persons.Any())
                throw new ArgumentNullException("persons");

            // Partition the entire source array.
            //https://msdn.microsoft.com/en-us/library/dd997411(v=vs.110).aspx
            var rangePartitioner = Partitioner.Create(0, persons.Length, ATTACHMENT_SIZE);

            // Loop over the partitions
            var rangePartitions = rangePartitioner.GetDynamicPartitions();

            foreach (var rangePartition in rangePartitions)
            {
                var attachments = new string[rangePartition.Item2 - rangePartition.Item1];
                var attachmentIndex = 0;

                // Loop over each range element without a delegate invocation.
                for (var counter = rangePartition.Item1; counter < rangePartition.Item2; counter++)
                {
                    var person = persons[counter];
                    var html = RazorHelper.Compile(path, person);
                    var pdf = iTextSharpHelper.Convert(html);
                    var tmpPath = Path.Combine(Path.GetTempPath(), String.Format("{0}_{1}.pdf", person.Name, Path.GetFileNameWithoutExtension(Path.GetRandomFileName())));

                    File.WriteAllBytes(tmpPath, pdf);

                    attachments[attachmentIndex] = tmpPath;
                    attachmentIndex++;
                }

                var subject = string.Format("Criminal Profiles - Part {0}/{1}", rangePartition.Item1 + 1, rangePartition.Item2);
                var body = @"Hi, we are sending you the results of your search. Please open the attached files.";

                await SendGridHelper.SendAsync(emailAddress, subject, body, attachments);
            }

        }


    }
}
