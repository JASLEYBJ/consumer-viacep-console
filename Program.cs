using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ConsumerViaCep.Models;

namespace ConsumerViaCep
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string cep = "01001000"; // CEP de exemplo
            string url = $"https://viacep.com.br/ws/{cep}/json/";

            using HttpClient client = new HttpClient();
            try
            {
                string response = await client.GetStringAsync(url);
                Endereco endereco = JsonSerializer.Deserialize<Endereco>(response);

                Console.WriteLine($"CEP: {endereco.cep}");
                Console.WriteLine($"Logradouro: {endereco.logradouro}");
                Console.WriteLine($"Bairro: {endereco.bairro}");
                Console.WriteLine($"Cidade: {endereco.localidade}");
                Console.WriteLine($"UF: {endereco.uf}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao acessar a API: " + ex.Message);
            }
        }
    }
}

