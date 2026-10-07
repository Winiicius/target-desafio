using target_desafio.Models;
using target_desafio.Service;

namespace Target.Desafio.Tests.Service;

public class ComissaoServiceTests
{
    private readonly ComissaoService _service = new();

    [Fact]
    public void DeveRetornarZeroParaVendaAbaixoDeCem()
    {
        var venda = new Venda
        {
            Vendedor = "João Silva",
            Valor = 99.99m
        };

        var resultado = _service.Calcular(venda);

        Assert.Equal(0m, resultado);
    }

    [Fact]
    public void DeveCalcularUmPorCentoParaVendaDeCem()
    {
        var venda = new Venda
        {
            Vendedor = "João Silva",
            Valor = 100m
        };

        var resultado = _service.Calcular(venda);

        Assert.Equal(1m, resultado);
    }

    [Fact]
    public void DeveCalcularUmPorCentoParaVendaAbaixoDeQuinhentos()
    {
        var venda = new Venda
        {
            Vendedor = "João Silva",
            Valor = 499.99m
        };

        var resultado = _service.Calcular(venda);

        Assert.Equal(4.9999m, resultado);
    }

    [Fact]
    public void DeveCalcularCincoPorCentoParaVendaDeQuinhentos()
    {
        var venda = new Venda
        {
            Vendedor = "João Silva",
            Valor = 500m
        };

        var resultado = _service.Calcular(venda);

        Assert.Equal(25m, resultado);
    }
}