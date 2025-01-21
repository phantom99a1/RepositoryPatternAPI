using AutoMapper;
using WebUI.Domain.Contracts;
using WebUI.Domain.Entities;
using WebUI.Repositories;

namespace WebUI.Services
{
    public interface IAuthorService
    {
        public Task<List<Author>> GetAllAuthorAsync();
        public Task<Author?> GetAuthorByIdAsync(Guid id);
        public Task<(bool status, string? message)> CreateNewAuthorAsync(CreateAuthor createAuthor);
        public Task<(bool status, string? message)> UpdateAuthorAsync(UpdateAuthor updateAuthor);
        public Task<(bool status, string? message)> DeleteAuthorAsync(Author deleteAuthor);
    }
    public class AuthorService(IBaseRepository<Author> authorRepository, IMapper mapper) : IAuthorService
    {
        public async Task<List<Author>> GetAllAuthorAsync()
        {
            var authors = await authorRepository.GetAllAsync(a => a.Books);
            return authors;
        }

        public async Task<Author?> GetAuthorByIdAsync(Guid id)
        {
            var author = await authorRepository.GetByIdAsync(id, a => a.Books);
            return author;
        }

        public async Task<(bool status, string? message)> CreateNewAuthorAsync(CreateAuthor createAuthor)
        {
            using var transaction = await authorRepository.BeginTransactionAsync();
            var now = DateTime.Now;
            var user = "admin";
            try
            {
                var author = mapper.Map<Author>(createAuthor);
                author.CreateUser = user;
                author.CreateDateTime = now;
                author.LastModifiedDateTime = now;
                author.LastModifiedUser = user;
                await authorRepository.CreateAsync(author);
                await transaction.CommitAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return (false, ex.Message);
            }
        }

        public async Task<(bool status, string? message)> UpdateAuthorAsync(UpdateAuthor updateAuthor)
        {
            using var transaction = await authorRepository.BeginTransactionAsync();
            var now = DateTime.Now;
            var user = "admin";
            try
            {
                var author = mapper.Map<Author>(updateAuthor);                
                author.LastModifiedDateTime = now;
                author.LastModifiedUser = user;
                await authorRepository.UpdateAsync(author);
                await transaction.CommitAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return (false, ex.Message);
            }
        }

        public async Task<(bool status, string? message)> DeleteAuthorAsync(Author deleteAuthor)
        {
            using var transaction = await authorRepository.BeginTransactionAsync();
            try
            {
                await authorRepository.DeleteAsync(deleteAuthor);
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
