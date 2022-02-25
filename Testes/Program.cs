using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Testes
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Aeroporto aeroportos = new();
            Console.WriteLine("MOSTRANDO AEROPORTOS\n\n");
            Console.Write("Digite o estado com 2 dígitos:");
            string escolha = Console.ReadLine().ToUpper();
            var lista = aeroportos.GetListStatesAsync().Result;
            if (lista.Contains(escolha) && escolha.Length == 2)
            {
                Console.WriteLine("\n======================PESQUISANDO OS DADOS======================\n");
                await aeroportos.GetListAeroportosAsync(escolha);
            }
            else
            {
                Console.WriteLine("Dados inconsistentes... Favor, refaça a pesquisa");
            }
        }
    }
}
