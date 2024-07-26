namespace LivrariaOn;
public class Book
{
    public int Id { get; set; }
    public string titulo { get; set; } = string.Empty;
    public string autor { get; set; } = string.Empty;
    public string genero { get; set; } = string.Empty;

    public decimal preco { get; set; }

    public int quantidade_em_estoque { get; set; }
}
