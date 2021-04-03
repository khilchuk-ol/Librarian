using Librarian.Domain.Models.Core;
using Librarian.Gui.Models;
using Librarian.Mappers.Abstract;
using System;

namespace Librarian.Mappers.Impl
{
    public class ReaderMapper : IReaderMapper
    {
        public ReaderModel Map(Reader from) => 
            new ReaderModel() 
            { 
                Id = from.Id, 
                Name = from.Name,
                Surname = from.Surname,
                Parentname = from.Parentname,
                TicketNumber = from.TicketNumber,
                Passport = from.Passport,
                Phone = from.Phone
            };

        public Reader Map(ReaderModel from) => 
            new Reader()
            {
                Id = from.Id,
                Name = from.Name,
                Surname = from.Surname,
                Parentname = from.Parentname,
                TicketNumber = from.TicketNumber,
                Passport = from.Passport,
                Phone = from.Phone
            };

        public void Map(ReaderModel from, Reader to)
        {
            if (to.Id != from.Id)
                throw new ArgumentException("Cannot map. Object are not related");
            to.Name = from.Name;
            to.Surname = from.Surname;
            to.Parentname = from.Parentname;
            to.TicketNumber = from.TicketNumber;
            to.Passport = from.Passport;
            to.Phone = from.Phone;
        }
    }
}
