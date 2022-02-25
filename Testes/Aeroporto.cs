using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Testes
{
    public class Aeroporto
    {
        [JsonPropertyName("telImprensa")]
        public string TelImprensa { get; set; }

        [JsonPropertyName("City")]
        public string City { get; set; }

        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Index")]
        public int Index { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("numResults")]
        public object NumResults { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("SDU")]
        public string SDU { get; set; }

        [JsonPropertyName("State")]
        public string State { get; set; }

        [JsonPropertyName("telSuperintendente")]
        public string TelSuperintendente { get; set; }

        [JsonPropertyName("Url")]
        public string Url { get; set; }

        public async Task<List<Aeroporto>> GetAeroportos()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://www4.infraero.gov.br/umbraco/surface/Common/index/");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "*/*");
            var response = await client.SendAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Aeroporto>>(result);
        }

        public async Task GetListAeroportosAsync(string estado)
        {
            foreach (var item in await GetAeroportos())
            {
                if (item.State == estado)
                {
                    Console.WriteLine($"Nome: {item.Name}\n" +
                        $"SDU: {item.SDU}\n" +
                        $"Cidade: {item.City}\n" +
                        $"Estado: {item.State}\n" +
                        $"Contato: {item.Phone}\n\n");
                }
            }
        }

        public async Task<List<string>> GetListStatesAsync()
        {
            List<string> listState = new();
            foreach (var item in await GetAeroportos())
            {
                listState.Add(item.State);
            }

            return listState;
        }
    }
}
