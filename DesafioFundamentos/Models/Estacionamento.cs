namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string veiculo = Console.ReadLine();
            if(ValidaPlaca(veiculo))
            {
                this.veiculos.Add(veiculo);
            }
            else
            {
                Console.WriteLine("A placa informada não é válida. Tente esses formatos:\n" +
                "ABC-1234 ou ABC1D23");
                AdicionarVeiculo();
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                string horasTexto = Console.ReadLine();
                int horas = 0;
                while (!int.TryParse(horasTexto, out horas))
                {
                    Console.WriteLine("O valor digitado não corresponde a um formato numérico. Digite um novo valor:");
                    horasTexto = Console.ReadLine();
                }                
                
                decimal valorTotal = this.precoInicial + (horas * this.precoPorHora); 

                // TODO: Remover a placa digitada da lista de veículos
                int indexRemove = this.veiculos.FindIndex(v => v.ToUpper() == placa.ToUpper());
                this.veiculos.RemoveAt(indexRemove);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                veiculos.ForEach(v => Console.WriteLine(v));
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private bool ValidaPlaca(string placa)
        {
            bool formatoAntigo = placa.Contains('-');
            int countNumbers = 0;
            int countLetters = 0;            
            foreach(char c in placa)
            {
                if(char.IsNumber(c))
                {
                    countNumbers++;
                }
                else if(char.IsLetter(c)){
                    countLetters ++;
                }
            }

            if(formatoAntigo)
            {
                return countNumbers == 4 && countLetters == 3 && placa.IndexOf('-') == 3;
            }
            else
            {
                return countNumbers == 3 && countLetters == 4;
            }
        }
    }
}