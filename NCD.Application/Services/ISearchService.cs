

namespace NCD.Application.Services
{
    using System.Collections.Generic;
    using NCD.Application.Domain;

    public interface ISearchService
    {
        IEnumerable<Person> SearchCriminal(SearchViewModel criteria);
    }
}
