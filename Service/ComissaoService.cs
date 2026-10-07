using target_desafio.Models;

namespace target_desafio.Service;

public class ComissaoService
{
    public decimal Calcular(Venda venda)
    {
        if (venda.Valor < 100)
        {
            return 0;
        }

        if (venda.Valor < 500)
        {
            return venda.Valor * 0.01m;
        }

        return venda.Valor * 0.05m;
    }
}