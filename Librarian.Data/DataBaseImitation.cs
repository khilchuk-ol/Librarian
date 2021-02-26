using Librarian.Data.Models;
using System;
using System.Collections.Generic;

namespace Librarian.Data
{
    public static class DataBaseImitation
    {
        public static IEnumerable<Book> DBBooks { get; set; } 
        public static IEnumerable<Reader> DBReaders { get; set; } 
        public static IEnumerable<Author> DBAuthors { get; set; } 
        public static IEnumerable<Genre> DBGenres { get; set; }
        public static IEnumerable<Record> DBRecords { get; set; }

        static DataBaseImitation()
        {
            var hl = new Author
            {
                Name = "Harper",
                Surname = "Lee"
            };
            var ng = new Author
            {
                Name = "Neil",
                Surname = "Gaiman"
            };

            var ft = new Genre("Fantasy");
            var cl = new Genre("Classics");

            var js = new Reader(345)
            {
                Name = "John",
                Surname = "Smith",
                Passport = "EE 300000",
                Phone = "+380456378134"
            };

            var tkam = new Book
            {
                Title = "To kill a mockingbird",
                PageCount = 420,
                Number = 568,
                IsBorrowed = true
            };
            var ag = new Book
            {
                Title = "American gods",
                PageCount = 600,
                Number = 8934
            };
            var tgb = new Book
            {
                Title = "The graveyard book",
                PageCount = 350,
                Number = 784
            };

            var rc1 = new Record
            {
                Book = ag,
                BookId = ag.Id,
                Reader = js,
                ReaderId = js.Id,
                BorrowDate = new DateTime(2020, 12, 13),
                ReturnDate = new DateTime(2020, 12, 20)
            };

            var rc2 = new Record
            {
                Book = tkam,
                BookId = tkam.Id,
                Reader = js,
                ReaderId = js.Id
            };

            tkam.Genres.Add(cl);
            tkam.Authors.Add(hl);
            tgb.Genres.Add(ft);
            tgb.Authors.Add(ng);
            ag.Genres.Add(ft);
            ag.Authors.Add(ng);
            js.Records.Add(rc1);
            js.Records.Add(rc2);

            DBBooks = new HashSet<Book>
            {
                tkam, ag, tgb
            };
            DBGenres = new HashSet<Genre>
            {
                cl, ft
            };
            DBAuthors = new HashSet<Author>
            {
                ng, hl
            };
            DBReaders = new HashSet<Reader>
            {
                js
            };
            DBRecords = new HashSet<Record>
            {
                rc1, rc2
            };
        }
    }
}
