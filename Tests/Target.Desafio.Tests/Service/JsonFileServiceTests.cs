using target_desafio.Models;
using target_desafio.Service;

namespace Target.Desafio.Tests.Service;

public class JsonFileServiceTests
{
    [Fact]
    public void DeveLerEstoqueDoArquivoJson()
    {
        var caminho = Path.Combine(
            AppContext.BaseDirectory,
            "Data",
            "estoque.json");

        var service = new JsonFileService();

        var dados = service.Ler<EstoqueData>(caminho);

        Assert.NotEmpty(dados.Estoque);
        Assert.Equal(101, dados.Estoque[0].CodigoProduto);
        Assert.Equal("Caneta Azul", dados.Estoque[0].DescricaoProduto);
        Assert.Equal(150, dados.Estoque[0].Estoque);
    }

    [Fact]
    public void DeveLerVendasDoArquivoJson()
    {
        var caminho = Path.Combine(
            AppContext.BaseDirectory,
            "Data",
            "vendas.json");

        var service = new JsonFileService();

        var dados = service.Ler<VendasData>(caminho);

        Assert.NotEmpty(dados.Vendas);
        Assert.Equal("João Silva", dados.Vendas[0].Vendedor);
        Assert.Equal(1200.50m, dados.Vendas[0].Valor);
    }
}