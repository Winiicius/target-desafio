# Desafio Técnico — Target Sistemas

Implementação do desafio técnico para a vaga de **Desenvolvedor/a de Sistemas Jr.**, utilizando **C# e .NET 10**.

O projeto consiste em uma aplicação de console que implementa os três exercícios propostos no desafio, com regras de negócio separadas em services e testes unitários utilizando xUnit.

## Tecnologias

- C#
- .NET 10
- xUnit
- System.Text.Json
- Git / GitHub

## Requisitos

Para executar o projeto, é necessário ter instalado:

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

Para verificar a instalação:

```bash
dotnet --version
```

## Como executar

Clone o repositório:

```bash
git clone https://github.com/Winiicius/target-desafio.git
```

Acesse a pasta do projeto:

```bash
cd target-desafio
```

Execute a aplicação:

```bash
dotnet run --project target-desafio.csproj
```

A aplicação exibirá um menu para acessar os três exercícios:

```text
========================================
       DESAFIO TÉCNICO - TARGET
========================================

1 - Calcular comissões
2 - Movimentar estoque
3 - Calcular juros
0 - Sair
```

## Exercícios

### 1. Cálculo de comissão

O projeto lê os dados de vendas do arquivo:

```text
Data/vendas.json
```

Cada venda possui vendedor e valor.

A comissão é calculada de acordo com as regras do desafio:

| Valor da venda                       | Comissão |
| ------------------------------------ | -------: |
| Menor que R$ 100,00                  |       0% |
| De R$ 100,00 até menor que R$ 500,00 |       1% |
| A partir de R$ 500,00                |       5% |

Ao final, as comissões são consolidadas e apresentadas por vendedor.

### 2. Movimentação de estoque

O estoque inicial é carregado a partir de:

```text
Data/estoque.json
```

A aplicação permite lançar movimentações de:

- Entrada de produtos
- Saída de produtos

Para cada movimentação são informados:

- Código do produto
- Tipo de movimentação
- Quantidade

A aplicação valida situações como:

- Quantidade menor ou igual a zero
- Produto inexistente
- Saída maior que o estoque disponível
- Tipo de movimentação inválido

O estoque é atualizado em memória durante a execução do programa.

> As movimentações não são persistidas no arquivo JSON. Ao reiniciar a aplicação, o estoque retorna aos valores definidos no arquivo inicial.

### 3. Cálculo de juros

O usuário informa:

- Valor da cobrança
- Data de vencimento

O sistema calcula juros de **2,5% por dia de atraso**, utilizando a data atual como referência.

Quando a cobrança ainda não venceu ou vence na data de referência, não são aplicados juros.

O programa apresenta:

- Valor dos juros
- Valor total da cobrança

## Testes

O projeto possui testes unitários para as principais regras de negócio.

Para executar todos os testes:

```bash
dotnet test Target.Desafio.slnx
```

Resultado esperado atualmente:

```text
22 testes aprovados
```

Para compilar a solução:

```bash
dotnet build Target.Desafio.slnx
```

## Estrutura do projeto

```text
target-desafio/
│
├── Data/
│   ├── estoque.json
│   └── vendas.json
│
├── Models/
│   ├── Cobranca.cs
│   ├── EstoqueData.cs
│   ├── Movimentacao.cs
│   ├── Produto.cs
│   ├── Venda.cs
│   └── VendasData.cs
│
├── Service/
│   ├── ComissaoService.cs
│   ├── EstoqueService.cs
│   ├── JsonFileService.cs
│   └── JurosService.cs
│
├── Tests/
│   └── Target.Desafio.Tests/
│       └── Service/
│           ├── ComissaoServiceTests.cs
│           ├── EstoqueServiceTests.cs
│           ├── JsonFileServiceTests.cs
│           └── JurosServiceTests.cs
│
├── Program.cs
├── Target.Desafio.slnx
├── target-desafio.csproj
└── README.md
```

## Organização

A aplicação foi estruturada separando a responsabilidade de cada parte:

- **Models**: representam os dados utilizados pela aplicação.
- **Services**: concentram as regras de negócio e leitura dos arquivos JSON.
- **Tests**: validam as principais regras de negócio.
- **Program.cs**: responsável pela interação com o usuário e pela orquestração das funcionalidades.

A aplicação não utiliza banco de dados, API ou outras dependências externas além das necessárias para o projeto.

## Validação final

O projeto foi validado com:

```bash
dotnet build Target.Desafio.slnx
dotnet test Target.Desafio.slnx
dotnet run --project target-desafio.csproj
```

Todos os **22 testes unitários** estão passando.
