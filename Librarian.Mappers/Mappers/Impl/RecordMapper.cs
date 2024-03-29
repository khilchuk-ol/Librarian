﻿using Librarian.Domain.Models.Core;
using Librarian.Gui.Models;
using Librarian.Mappers.Abstract;
using System;

namespace Librarian.Mappers.Impl
{
    public class RecordMapper : IRecordMapper
    {
        public RecordModel Map(Record from) =>
            new RecordModel()
            {
                Id = from.Id,
                BookId = from.BookId,
                BookTitle = from.Book?.Title,
                ReaderId = from.ReaderId,
                BorrowDate = from.BorrowDate,
                ReturnDate = from.ReturnDate
            };

        public Record Map(RecordModel from) =>
            new Record()
            {
                Id = from.Id,
                BookId = from.BookId,
                ReaderId = from.ReaderId,
                BorrowDate = from.BorrowDate,
                ReturnDate = from.ReturnDate
            };

        public void Map(RecordModel from, Record to)
        {
            if (to.Id != from.Id)
                throw new ArgumentException("Cannot map. Object are not related");
            to.BookId = from.BookId;
            to.ReaderId = from.ReaderId;
            to.BorrowDate = from.BorrowDate;
            to.ReturnDate = from.ReturnDate;
        }
    }
}
