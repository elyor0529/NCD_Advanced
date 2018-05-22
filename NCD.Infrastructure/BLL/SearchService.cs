
namespace NCD.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using NCD.Application.Domain;
    using NCD.Application.Services;
    using Ninject;
    using NCD.Application;

    public class SearchService : ISearchService
    {
        [Inject]
        public IApplicationDbContext ApplicationDbContext { get; set; }

        /// <summary>
        /// To search person list with submitted criteria 
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IEnumerable<Person> SearchCriminal(SearchViewModel criteria)
        {

            //all persons
            var query = ApplicationDbContext.Persons.AsQueryable();

            //name
            if (!string.IsNullOrWhiteSpace(criteria.Name))
                query = query.Where(item => item.Name.Contains(criteria.Name));

            //age
            if (criteria.AgeFrom != null)
            {
                if (criteria.AgeTo != null)
                    query = from person in query
                            let years = DateTime.Now.Year - person.BirthDate.Year
                            let age = DbFunctions.AddYears(person.BirthDate, years) > DateTime.Now ? years - 1 : years
                            where age >= criteria.AgeFrom && age <= criteria.AgeTo
                            select person;
                else
                    query = from person in query
                            let years = DateTime.Now.Year - person.BirthDate.Year
                            let age = DbFunctions.AddYears(person.BirthDate, years) > DateTime.Now ? years - 1 : years
                            where age == criteria.AgeFrom
                            select person;
            }

            //height
            if (criteria.HeightFrom != null)
            {
                if (criteria.HeightTo != null)
                    query = query.Where(item => item.Height >= (decimal)criteria.HeightFrom && item.Height <= (decimal)criteria.HeightTo);
                else
                    query = query.Where(item => item.Height == (decimal)criteria.HeightFrom);
            }

            //weight
            if (criteria.WeightFrom != null)
            {
                if (criteria.WeightTo != null)
                    query = query.Where(item => item.Weight >= (decimal)criteria.WeightFrom && item.Weight <= (decimal)criteria.WeightTo);
                else
                    query = query.Where(item => item.Weight == (decimal)criteria.WeightFrom);
            }

            //top number of results(return to unlimited email attachments)
            if (criteria.MaxNumberResults > 0)
            {
                query = query.OrderBy(item => item.Name).Take(criteria.MaxNumberResults.Value);
            }

            return query;
        }

    }
}
