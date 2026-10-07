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

        var dados = service.Ler<target_desafio.Models.EstoqueData>(caminho);

        Assert.NotEmpty(dados.Estoque);
        Assert.Equal(101, dados.Estoque[0].CodigoProduto);
        Assert.Equal("Caneta Azul", dados.Estoque[0].DescricaoProduto);
        Assert.Equal(150, dados.Estoque[0].Estoque);
    }
}