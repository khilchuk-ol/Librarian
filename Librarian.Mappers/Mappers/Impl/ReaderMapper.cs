using Librarian.Domain.Models.Core;
using Librarian.Gui.Models;
using Librarian.Mappers.Abstract;

namespace Librarian.Mappers.Mappers.Impl
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
    }
}
