using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebUI.Domain.Contracts;
using WebUI.Services;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(IBookService bookService, IMapper mapper) : ControllerBase
    {        
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var books = await bookService.GetAllBookAsync();
            var bookDTO = mapper.Map<List<GetBookDTO>>(books);
            return Ok(bookDTO);
        }

        [HttpGet]
        [Route("GetBookById/{id}")]
        public async Task<IActionResult> GetBookByIdAsync(Guid id)
        {
            var book = await bookService.GetBookByIdAsync(id);
            if(book == null)
            {
                return NotFound();
            }

            var bookDTO = mapper.Map<GetBookDTO>(book);
            return Ok(bookDTO);
        }

        [HttpPost]
        [Route("CreateNewBook")]
        public async Task<IActionResult> CreateNewBookAsync([FromBody] CreateBook createBook)
        {
            try
            {
                var (status, error) = await bookService.CreateNewBookAsync(createBook);
                return status ? Ok(new { status, errorMessage = "" }) : Ok(new { errorMessage = error });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateBook/{id}")]
        public async Task<IActionResult> UpdateBookAsync(Guid id, [FromBody] UpdateBook updateBook)
        {
            try
            {
                var book = await bookService.GetBookByIdAsync(id);
                if(book == null)
                {
                    return NotFound();
                }
                var (status, error) = await bookService.UpdateBookAsync(updateBook);
                return status ? Ok(new { status, errorMessage = "" }) : Ok(new { errorMessage = error });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBookAsync(Guid id)
        {
            try
            {
                var book = await bookService.GetBookByIdAsync(id);
                if (book == null)
                {
                    return NotFound();
                }
                var (status, error) = await bookService.DeleteBookAsync(book);
                return status ? Ok(new { status, errorMessage = "" }) : Ok(new { errorMessage = error });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
