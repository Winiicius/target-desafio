using target_desafio.Models;
using target_desafio.Service;

namespace Target.Desafio.Tests.Service;

public class ComissaoServiceTests
{
    [Fact]
    public void DeveRetornarZeroParaVendaAbaixoDeCem()
    {
        var venda = new Venda
        {
            Vendedor = "João Silva",
            Valor = 99.99m
        };

        var service = new ComissaoService();

        var resultado = service.Calcular(venda);

        Assert.Equal(0, resultado);
    }

    [Fact]
    public void DeveCalcularUmPorCentoParaVendaEntreCemEQuatrocentosENoventaENove()
    {
        var venda = new Venda
        {
            Vendedor = "João Silva",
            Valor = 100m
        };

        var service = new ComissaoService();

        var resultado = service.Calcular(venda);

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

        var service = new ComissaoService();

        var resultado = service.Calcular(venda);

        Assert.Equal(4.9999m, resultado);
    }

    [Fact]
    public void DeveCalcularCincoPorCentoParaVendaApartirDeQuinhentos()
    {
        var venda = new Venda
        {
            Vendedor = "João Silva",
            Valor = 500m
        };

        var service = new ComissaoService();

        var resultado = service.Calcular(venda);

        Assert.Equal(25m, resultado);
    }

    [Fact]
    public void DeveSomarComissoesDeVendasDoMesmoVendedor()
    {
        var vendas = new List<Venda>
        {
            new()
            {
                Vendedor = "João Silva",
                Valor = 1000m
            },
            new()
            {
                Vendedor = "João Silva",
                Valor = 200m
            }
        };

        var service = new ComissaoService();

        var resultado = service.CalcularPorVendedor(vendas);

        Assert.Equal(52m, resultado["João Silva"]);
    }

    [Fact]
    public void DeveCalcularComissaoSeparadamenteParaCadaVendedor()
    {
        var vendas = new List<Venda>
        {
            new()
            {
                Vendedor = "João Silva",
                Valor = 1000m
            },
            new()
            {
                Vendedor = "Maria Souza",
                Valor = 600m
            }
        };

        var service = new ComissaoService();

        var resultado = service.CalcularPorVendedor(vendas);

        Assert.Equal(50m, resultado["João Silva"]);
        Assert.Equal(30m, resultado["Maria Souza"]);
    }
}