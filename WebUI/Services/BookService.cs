using AutoMapper;
using WebUI.Domain.Contracts;
using WebUI.Domain.Entities;
using WebUI.Repositories;

namespace WebUI.Services
{
    public interface IBookService
    {
        public Task<List<Book>> GetAllBookAsync();
        public Task<Book?> GetBookByIdAsync(Guid id);
        public Task<(bool status, string? message)> CreateNewBookAsync(CreateBook createBook);
        public Task<(bool status, string? message)> UpdateBookAsync(UpdateBook updateBook);
        public Task<(bool status, string? message)> DeleteBookAsync(Book deleteBook);
    }
    public class BookService(IBaseRepository<Book> bookRepository, IMapper mapper) : IBookService
    {
        public async Task<List<Book>> GetAllBookAsync()
        {
            var books = await bookRepository.GetAllAsync(a => a.Author);
            return books;
        }
        
        public async Task<Book?> GetBookByIdAsync(Guid id)
        {
            var book = await bookRepository.GetByIdAsync(id, a => a.Author);
            return book;
        }

        public async Task<(bool status, string? message)> CreateNewBookAsync(CreateBook createBook)
        {
            using var transaction = await bookRepository.BeginTransactionAsync();
            try
            {
                var book = mapper.Map<Book>(createBook);
                await bookRepository.CreateAsync(book);
                await transaction.CommitAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return (false, ex.Message);
            }
        }

        public async Task<(bool status, string? message)> UpdateBookAsync(UpdateBook updateBook)
        {
            using var transaction = await bookRepository.BeginTransactionAsync();
            try
            {
                var book = mapper.Map<Book>(updateBook);
                await bookRepository.UpdateAsync(book);
                await transaction.CommitAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return (false, ex.Message);
            }
        }

        public async Task<(bool status, string? message)> DeleteBookAsync(Book deleteBook)
        {
            using var transaction = await bookRepository.BeginTransactionAsync();
            try
            {
                await bookRepository.DeleteAsync(deleteBook);
                await transaction.CommitAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return (false, ex.Message);
            }
        }
    }
}
