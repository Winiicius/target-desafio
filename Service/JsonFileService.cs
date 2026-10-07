using System.Text.Json;

namespace target_desafio.Service;

public class JsonFileService
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public T Ler<T>(string caminho)
    {
        var json = File.ReadAllText(caminho);

        var dados = JsonSerializer.Deserialize<T>(json, _options);

        if (dados is null)
        {
            throw new InvalidOperationException(
                "Não foi possível desserializar o arquivo JSON.");
        }

        return dados;
    }
}