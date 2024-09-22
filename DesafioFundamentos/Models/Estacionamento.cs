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
            // DONE: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos";

            // Exibe a mensagem para o usuário e armazena valor.
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();

            // Verifica se a string(placa) é válida (Não Vazia e Sem Espaços).
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("A placa não pode estar vazia. Tente novamente.");
                return;
            }

            // Verifica se a placa já foi adicionada.
            if (veiculos.Any(v => v.ToUpper() == placa))
            {
                Console.WriteLine($"O veículo: {placa} já está estacionado.");
                return;
            }

            // Por fim, adiciona a placa à lista de veículos.
            this.veiculos.Add(placa);
            Console.WriteLine("Veiculo Adicionado com Sucesso.");
        }

        public void RemoverVeiculo()
        {
            // DONE: Pedir para o usuário digitar a placa e armazenar na variável placa;

            // Exibe a mensagem para o usuário e armazena valor em placa.
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa))
            {
                // DONE: Caso veículo exista. Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado.
                Console.WriteLine("Utilize (.) para separar minutos \nExemplo: 1.20 ou 01.20. \nDigite a quantidade de horas que o veículo permaneceu estacionado: ");

                // DONE: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal.         
                if(decimal.TryParse(Console.ReadLine(), out decimal horas))
                {
                    decimal valorTotal = this.precoInicial + (this.precoPorHora * horas);

                    // DONE: Por fim, Remove a placa digitada da lista de veículos.
                    veiculos.Remove(veiculos.First(x => x.ToUpper() == placa));
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                } else 
                {
                    //Caso horas for inválido para o fluxo.
                    Console.WriteLine("A quantidade de horas deve ser um número válido. \nUse ponto (.) para separar minutos.");
                }
            }
            else
            {   
                //Caso veículo não existir para o fluxo.
                Console.WriteLine($"Desculpe, o veiculo: {placa} não está estacionado aqui. \nConfira se digitou a placa corretamente.");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento.
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                // DONE: Realizar um laço de repetição, exibindo os veículos estacionados;

                // Loop para exibir os veículos estacionados.
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {   
                //Exibe mensagem caso não haja veículos estacionados.
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
