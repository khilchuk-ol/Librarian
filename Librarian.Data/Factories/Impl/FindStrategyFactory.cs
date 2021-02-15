using Librarian.Data.Models;
using Librarian.Data.Strategies;
using Librarian.Data.Strategies.Impl;
using Librarian.Data.Strategies.TypesEnum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Librarian.Data.Factories.Impl
{
    public class FindStrategyFactory<TElement, TCriterion> : IFindStrategyFactory<TElement, TCriterion>
    {
        private static readonly FindStrategyFactory<TElement, TCriterion> _instance = new FindStrategyFactory<TElement, TCriterion>();

        private static readonly IDictionary<FindType, Delegate> _predicates = new Dictionary<FindType, Delegate>
        {
            { FindType.BookByAuthor, (Func<Book, int, bool>)((b, id) => b.Authors.Select(au => au.Id).ToList().Contains(id)) },
            { FindType.BookByTitle, (Func<Book, string, bool>)((b, s) => b.Title.ToLower().Contains(s.Trim().ToLower())) },
            { FindType.ReaderByName, (Func<Reader, string, bool>)((r, s) => r.Fullname.ToLower().Contains(s.Trim().ToLower())) },
            { FindType.ReaderByTicket, (Func<Reader, int, bool>)((r, num) => r.TicketNumber == num) },
            { FindType.AuthorByName, (Func<Author, string, bool>)((a, s) => a.Fullname.ToLower().Contains(s.Trim().ToLower())) }
        };

        public static FindStrategyFactory<TElement, TCriterion> Instance => _instance;

        private FindStrategyFactory() { }

        public IFindStrategy<TElement, TCriterion> Create<TElement, TCriterion>(FindType type) =>
            new FindStrategy<TElement, TCriterion>((Func<TElement, TCriterion, bool>)_predicates[type]);
    }
}
