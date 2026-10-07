namespace target_desafio.Models;

public class Movimentacao
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public int CodigoProduto { get; set; }

    public int Quantidade { get; set; }

    public string Descricao { get; set; } = string.Empty;
}