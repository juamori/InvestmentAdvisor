using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace InvestmentAdvisor.Utils
{
    public static class FileHandler
    {
        public static async Task SaveToJsonAsync<T>(string filePath, T data)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(data, options);
            await File.WriteAllTextAsync(filePath, jsonString);
        }

        public static async Task<T> ReadFromJsonAsync<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return default;
            }
            var jsonString = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}