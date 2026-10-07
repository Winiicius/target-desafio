using System.Globalization;
using target_desafio.Models;
using target_desafio.Service;

var jsonService = new JsonFileService();
var comissaoService = new ComissaoService();
var estoqueService = new EstoqueService();
var caminhoData = Path.Combine(AppContext.BaseDirectory, "Data");

var opcoes = new Dictionary<string, Action>
{
    { "1", CalcularComissoes },
    { "2", MovimentarEstoque },
    { "3", CalcularJuros }
};

while (true)
{
    Console.Clear();
    Console.WriteLine("========================================");
    Console.WriteLine("       DESAFIO TÉCNICO - TARGET");
    Console.WriteLine("========================================");
    Console.WriteLine();
    Console.WriteLine("1 - Calcular comissões");
    Console.WriteLine("2 - Movimentar estoque");
    Console.WriteLine("3 - Calcular juros");
    Console.WriteLine("0 - Sair");
    Console.WriteLine();

    Console.Write("Escolha uma opção: ");
    var opcao = Console.ReadLine();

    Console.WriteLine();

    try
    {
        if (opcao == "0")
        {
            return;
        }

        if (opcoes.TryGetValue(opcao!, out var acao))
        {
            acao();
        }
        else
        {
            Console.WriteLine("Opção inválida.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro: {ex.Message}");
    }

    Console.WriteLine();
    Console.WriteLine("Pressione ENTER para continuar...");
    Console.ReadLine();
}

void CalcularComissoes()
{
    var caminho = Path.Combine(caminhoData, "vendas.json");
    var dados = jsonService.Ler<VendasData>(caminho);
    var comissoes = comissaoService.CalcularPorVendedor(dados.Vendas);

    Console.WriteLine("COMISSÕES POR VENDEDOR");
    Console.WriteLine("-----------------------");

    foreach (var comissao in comissoes)
    {
        Console.WriteLine(
            $"{comissao.Key}: {comissao.Value.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"))}");
    }
}

void MovimentarEstoque()
{
    var caminho = Path.Combine(caminhoData, "estoque.json");
    var dados = jsonService.Ler<EstoqueData>(caminho);

    while (true)
    {
        Console.WriteLine("ESTOQUE ATUAL");
        Console.WriteLine("-------------");

        foreach (var produto in dados.Estoque)
        {
            Console.WriteLine(
                $"{produto.CodigoProduto} - {produto.DescricaoProduto}: {produto.Estoque} unidades");
        }

        Console.WriteLine();
        Console.WriteLine("Digite 0 no código do produto para voltar ao menu.");
        Console.Write("Código do produto: ");

        if (!int.TryParse(Console.ReadLine(), out var codigoProduto))
        {
            Console.WriteLine("Código inválido.");
            Console.WriteLine();
            continue;
        }

        if (codigoProduto == 0)
        {
            return;
        }

        Console.Write("Tipo de movimentação (Entrada/Saída): ");
        var descricao = Console.ReadLine() ?? string.Empty;

        Console.Write("Quantidade: ");

        if (!int.TryParse(Console.ReadLine(), out var quantidade))
        {
            Console.WriteLine("Quantidade inválida.");
            Console.WriteLine();
            continue;
        }

        var movimentacao = new Movimentacao
        {
            CodigoProduto = codigoProduto,
            Quantidade = quantidade,
            Descricao = descricao
        };

        var estoqueAtual = estoqueService.ProcessarMovimentacao(
            dados.Estoque,
            movimentacao);

        Console.WriteLine();
        Console.WriteLine($"Movimentação realizada com sucesso.");
        Console.WriteLine($"Estoque atual: {estoqueAtual} unidades");
        Console.WriteLine();
    }
}

void CalcularJuros()
{
    Console.WriteLine("CÁLCULO DE JUROS");
    Console.WriteLine("----------------");

    Console.Write("Valor da cobrança: ");

    if (!decimal.TryParse(
            Console.ReadLine(),
            NumberStyles.Number,
            CultureInfo.GetCultureInfo("pt-BR"),
            out var valor))
    {
        Console.WriteLine("Valor inválido.");
        return;
    }

    Console.Write("Data de vencimento (dd/MM/yyyy): ");

    if (!DateTime.TryParseExact(
            Console.ReadLine(),
            "dd/MM/yyyy",
            CultureInfo.GetCultureInfo("pt-BR"),
            DateTimeStyles.None,
            out var dataVencimento))
    {
        Console.WriteLine("Data inválida.");
        return;
    }

    var cobranca = new Cobranca
    {
        Valor = valor,
        DataVencimento = dataVencimento
    };

    var jurosService = new JurosService();
    var juros = jurosService.Calcular(cobranca, DateTime.Today);
    var valorTotal = valor + juros;

    Console.WriteLine();
    Console.WriteLine(
        $"Juros: {juros.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"))}");

    Console.WriteLine(
        $"Valor total: {valorTotal.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"))}");
}