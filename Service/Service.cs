using target_desafio.Models;

namespace target_desafio.Service;

public class JurosService
{
    private const decimal TaxaDiaria = 0.025m;

    public decimal Calcular(Cobranca cobranca, DateTime dataReferencia)
    {
        var diasDeAtraso = (dataReferencia.Date - cobranca.DataVencimento.Date).Days;

        if (diasDeAtraso <= 0)
        {
            return 0;
        }

        return cobranca.Valor * TaxaDiaria * diasDeAtraso;
    }
}