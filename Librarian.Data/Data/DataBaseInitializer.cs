using Librarian.Domain.Models.Core;
using System;
using System.Data.Entity;

namespace Librarian.Data.Data
{
    public class DataBaseInitializer : DropCreateDatabaseIfModelChanges<LibrarianContext>
    {
        protected override void Seed(LibrarianContext context)
        {
            #region DataCreation
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
                ReaderId = js.Id,
                BorrowDate = new DateTime(2020, 12, 13)
            };

            tkam.Genres.Add(cl);
            cl.Books.Add(tkam);
            tkam.Authors.Add(hl);
            hl.Books.Add(tkam);

            tgb.Genres.Add(ft);
            ft.Books.Add(tgb);
            tgb.Authors.Add(ng);
            ng.Books.Add(tgb);

            ag.Genres.Add(ft);
            ft.Books.Add(ag);
            ag.Authors.Add(ng);
            ng.Books.Add(ag);

            js.Records.Add(rc1);
            js.Records.Add(rc2);
            #endregion

            context.Authors.AddRange(new[] { hl, ng});
            context.Books.AddRange(new[] { tkam, tgb, ag });
            context.Genres.AddRange(new[] { cl, ft });
            context.Readers.AddRange(new[] { js });
            context.Records.AddRange(new[] { rc1, rc2 });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
