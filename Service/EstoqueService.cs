using target_desafio.Models;

namespace target_desafio.Service;

public class EstoqueService
{
    public int ProcessarMovimentacao(List<Produto> produtos, Movimentacao movimentacao)
    {
        if (movimentacao.Quantidade <= 0)
        {
            throw new InvalidOperationException("A quantidade da movimentação deve ser maior que zero.");
        }

        var produto = produtos.FirstOrDefault(
            p => p.CodigoProduto == movimentacao.CodigoProduto);

        if (produto is null)
        {
            throw new InvalidOperationException("Produto não encontrado.");
        }

        if (movimentacao.Descricao.StartsWith(
                "Entrada",
                StringComparison.OrdinalIgnoreCase))
        {
            produto.Estoque += movimentacao.Quantidade;
        }
        else if (movimentacao.Descricao.StartsWith(
                     "Saída",
                     StringComparison.OrdinalIgnoreCase))
        {
            if (produto.Estoque < movimentacao.Quantidade)
            {
                throw new InvalidOperationException(
                    "A quantidade de saída é maior que o estoque disponível.");
            }

            produto.Estoque -= movimentacao.Quantidade;
        }
        else
        {
            throw new InvalidOperationException(
                "Tipo de movimentação inválido.");
        }

        return produto.Estoque;
    }
}