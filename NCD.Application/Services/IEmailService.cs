

namespace NCD.Application.Services
{
    using System.Collections.Generic;
    using NCD.Application.Domain;
    using System.Threading.Tasks;

    public interface IEmailService
    {
        Task SendAsync(string emailAddress, Person[] persons);
    }
}
