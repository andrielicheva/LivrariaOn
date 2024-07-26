using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LivrariaOn.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly BookDbContext _context;

    public BooksController(BookDbContext context)
    {
        _context = context;
    }

    // GET: api/books
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        // Retorna todos os livros do banco de dados
        return await _context.Books.ToListAsync();
    }


    // GET: api/books/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        // Busca um livro pelo ID
        var book = await _context.Books.FindAsync(id);

        // Se o livro não existe, retorna 404 Not Found
        if (book == null)
        {
            return NotFound();
        }

        // Retorna o livro encontrado
        return book;
    }

    // POST: api/books
    [HttpPost]
    public async Task<ActionResult<Book>> CreateBook(Book book)
    {
        // Adiciona um novo livro ao contexto
        _context.Books.Add(book);
        // Salva as mudanças no banco de dados
        await _context.SaveChangesAsync();

        // Retorna um código 201 Created e o livro criado
        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }

    // PUT: api/books/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, Book book)
    {
        // Verifica se o ID fornecido é diferente do ID do livro
        if (id != book.Id)
        {
            // Retorna um código 400 Bad Request se os IDs não coincidem
            return BadRequest();
        }

        // Define o estado do livro como modificado no contexto
        _context.Entry(book).State = EntityState.Modified;

        try
        {
            // Salva as mudanças no banco de dados
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            // Verifica se o livro com o ID especificado existe
            if (!BookExists(id))
            {
                // Retorna 404 Not Found se o livro não existe
                return NotFound();
            }
            else
            {
                // Releva a exceção se ocorrer um erro de concorrência
                throw;
            }
        }

        // Retorna um código 204 No Content indicando sucesso na atualização
        return NoContent();
    }

    // DELETE: api/books/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        // Busca um livro pelo ID
        var book = await _context.Books.FindAsync(id);
        // Se o livro não existe, retorna 404 Not Found
        if (book == null)
        {
            return NotFound();
        }

        // Remove o livro do contexto
        _context.Books.Remove(book);
        // Salva as mudanças no banco de dados
        await _context.SaveChangesAsync();

        // Retorna um código 204 No Content indicando sucesso na exclusão
        return NoContent();
    }

    // Verifica se um livro com o ID especificado existe no banco de dados
    private bool BookExists(int id)
    {
        return _context.Books.Any(e => e.Id == id);
    }
}
