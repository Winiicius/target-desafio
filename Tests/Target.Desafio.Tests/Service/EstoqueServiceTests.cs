using target_desafio.Models;
using target_desafio.Service;

namespace Target.Desafio.Tests.Service;

public class EstoqueServiceTests
{
    [Fact]
    public void ProcessarMovimentacao_Entrada_DeveAumentarEstoque()
    {
        var produtos = new List<Produto>
        {
            new()
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 150
            }
        };

        var movimentacao = new Movimentacao
        {
            CodigoProduto = 101,
            Quantidade = 50,
            Descricao = "Entrada de estoque"
        };

        var service = new EstoqueService();

        var estoqueFinal = service.ProcessarMovimentacao(produtos, movimentacao);

        Assert.Equal(200, estoqueFinal);
    }

    [Fact]
    public void ProcessarMovimentacao_Saida_DeveDiminuirEstoque()
    {
        var produtos = new List<Produto>
        {
            new()
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 150
            }
        };

        var movimentacao = new Movimentacao
        {
            CodigoProduto = 101,
            Quantidade = 50,
            Descricao = "Saída de estoque"
        };

        var service = new EstoqueService();

        var estoqueFinal = service.ProcessarMovimentacao(produtos, movimentacao);

        Assert.Equal(100, estoqueFinal);
    }

    [Fact]
    public void ProcessarMovimentacao_ProdutoInexistente_DeveGerarErro()
    {
        var produtos = new List<Produto>
        {
            new()
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 150
            }
        };

        var movimentacao = new Movimentacao
        {
            CodigoProduto = 999,
            Quantidade = 10,
            Descricao = "Entrada de estoque"
        };

        var service = new EstoqueService();

        Assert.Throws<InvalidOperationException>(
            () => service.ProcessarMovimentacao(produtos, movimentacao));
    }

    [Fact]
    public void ProcessarMovimentacao_Entrada_QuantidadeZero_DeveGerarErro()
    {
        var produtos = new List<Produto>
        {
            new()
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 150
            }
        };

        var movimentacao = new Movimentacao
        {
            CodigoProduto = 101,
            Quantidade = 0,
            Descricao = "Entrada de estoque"
        };

        var service = new EstoqueService();

        Assert.Throws<InvalidOperationException>(
            () => service.ProcessarMovimentacao(produtos, movimentacao));
    }

    [Fact]
    public void ProcessarMovimentacao_QuantidadeNegativa_DeveGerarErro()
    {
        var produtos = new List<Produto>
        {
            new()
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 150
            }
        };

        var movimentacao = new Movimentacao
        {
            CodigoProduto = 101,
            Quantidade = -10,
            Descricao = "Entrada de estoque"
        };

        var service = new EstoqueService();

        Assert.Throws<InvalidOperationException>(
            () => service.ProcessarMovimentacao(produtos, movimentacao));
    }

    [Fact]
    public void ProcessarMovimentacao_SaidaMaiorQueEstoque_DeveGerarErro()
    {
        var produtos = new List<Produto>
        {
            new()
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 150
            }
        };

        var movimentacao = new Movimentacao
        {
            CodigoProduto = 101,
            Quantidade = 200,
            Descricao = "Saída de estoque"
        };

        var service = new EstoqueService();

        Assert.Throws<InvalidOperationException>(
            () => service.ProcessarMovimentacao(produtos, movimentacao));
    }

    [Fact]
    public void ProcessarMovimentacao_TipoInvalido_DeveGerarErro()
    {
        var produtos = new List<Produto>
        {
            new()
            {
                CodigoProduto = 101,
                DescricaoProduto = "Caneta Azul",
                Estoque = 150
            }
        };

        var movimentacao = new Movimentacao
        {
            CodigoProduto = 101,
            Quantidade = 10,
            Descricao = "Transferência de estoque"
        };

        var service = new EstoqueService();

        Assert.Throws<InvalidOperationException>(
            () => service.ProcessarMovimentacao(produtos, movimentacao));
    }
}