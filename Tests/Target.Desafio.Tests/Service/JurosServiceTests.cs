using target_desafio.Models;
using target_desafio.Service;

namespace Target.Desafio.Tests.Service;

public class JurosServiceTests
{
    [Fact]
    public void DeveRetornarZeroQuandoVencimentoEhHoje()
    {
        var cobranca = new Cobranca
        {
            Valor = 1000m,
            DataVencimento = new DateTime(2026, 10, 7)
        };

        var service = new JurosService();

        var resultado = service.Calcular(
            cobranca,
            new DateTime(2026, 10, 7));

        Assert.Equal(0m, resultado);
    }

    [Fact]
    public void DeveCalcularJurosDeUmDiaDeAtraso()
    {
        var cobranca = new Cobranca
        {
            Valor = 1000m,
            DataVencimento = new DateTime(2026, 10, 6)
        };

        var service = new JurosService();

        var resultado = service.Calcular(
            cobranca,
            new DateTime(2026, 10, 7));

        Assert.Equal(25m, resultado);
    }

    [Fact]
    public void DeveCalcularJurosDeTresDiasDeAtraso()
    {
        var cobranca = new Cobranca
        {
            Valor = 1000m,
            DataVencimento = new DateTime(2026, 10, 4)
        };

        var service = new JurosService();

        var resultado = service.Calcular(
            cobranca,
            new DateTime(2026, 10, 7));

        Assert.Equal(75m, resultado);
    }

    [Fact]
    public void DeveRetornarZeroQuandoVencimentoEstaNoFuturo()
    {
        var cobranca = new Cobranca
        {
            Valor = 1000m,
            DataVencimento = new DateTime(2026, 10, 10)
        };

        var service = new JurosService();

        var resultado = service.Calcular(
            cobranca,
            new DateTime(2026, 10, 7));

        Assert.Equal(0m, resultado);
    }

    [Fact]
    public void DeveCalcularJurosParaValorDecimal()
    {
        var cobranca = new Cobranca
        {
            Valor = 250.50m,
            DataVencimento = new DateTime(2026, 10, 5)
        };

        var service = new JurosService();

        var resultado = service.Calcular(
            cobranca,
            new DateTime(2026, 10, 7));

        Assert.Equal(12.525m, resultado);
    }
}