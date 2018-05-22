
namespace NCD.Application.Services
{
    using System.Data.Entity;
    using NCD.Application.Domain;
     
    public interface IApplicationDbContext
    {
        IDbSet<Person> Persons { get; set; }
    }
}