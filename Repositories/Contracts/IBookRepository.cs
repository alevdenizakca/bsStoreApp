using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges);
        Task<Book> GetABookByIdAsync(int id,bool trackChanges);
        void CreateABook(Book book);
        void UpdateABook(Book book);
        void DeleteABook(Book book);
    }
}
