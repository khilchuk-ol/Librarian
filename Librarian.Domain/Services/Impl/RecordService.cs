using JetBrains.Annotations;
using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Models.Core;
using Librarian.Domain.Services.Abstract;
using System.Collections.Generic;

namespace Librarian.Domain.Services.Impl
{
    public class RecordService : IRecordService
    {
        public IRecordRepository Repository { get; }

        public RecordService([NotNull] IRecordRepository repo)
        {
            Repository = repo;
        }
        public void LoadInfo(Record r)
        {
            var tmp = Repository.FindWithInfo(r.Id);
            r.Book = tmp.Book;
            r.Reader = tmp.Reader;
        }

        public Record GetRecordWithInfo(int id)
        {
            return Repository.FindWithInfo(id);
        }

        public IEnumerable<Record> GetRecords()
        {
            return Repository.FindAll();
        }

        public IEnumerable<Record> GetActive(int readerId)
        {
            return Repository.GetActive(readerId);
        }

        public IEnumerable<Record> GetPast(int readerId)
        {
            return Repository.GetPast(readerId);
        }
    }
}
