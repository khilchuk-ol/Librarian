using Librarian.Domain.Models.Core;
using System.Collections.Generic;

namespace Librarian.Domain.Services.Abstract
{
    public interface IAuthorService
    {
        IEnumerable<Author> FindAuthorsByName(string query);
    }
}
