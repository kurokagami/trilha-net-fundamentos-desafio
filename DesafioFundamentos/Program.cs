using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;

//BUG: Caso o usuario digitasse um caracter não númerico, o programa dava um erro e fechava.
//DONE: Para corrigir este bug, adicionei uma lógica que irá válidar o caracter, fazendo o fluxo seguir mesmo com caracter inválido.
//BUG: Após isso, ocorreu outro bug. Programa seguia fluxo mas fechava de qualquer maneira caso caracter fosse inválido.
//DONE: Para Corrigir este bug, adicionei um laço de repetição que irá seguir somente quando ambos forem válidos.
Console.WriteLine("Seja bem-vindo ao sistema de estacionamento!");
while (true)
{
    //Verifica se precoInicial é válido
    Console.WriteLine("Digite o preço inicial:");
    if (!decimal.TryParse(Console.ReadLine(), out precoInicial))
    {
        Console.WriteLine("Valor inválido para o preço inicial, Digite Números Válidos \nTente novamente.");
        continue; // Volta para o Inicio do loop caso seja inválido.
    }

    //Verifica se precoPorHora é válido
    Console.WriteLine("Agora digite o preço por hora:");
    if (!decimal.TryParse(Console.ReadLine(), out precoPorHora))
    {
        Console.WriteLine("Valor inválido para o preço por hora, Digite Números Válidos \nTente novamente.");
        continue; // Volta para o início do loop caso seja inválido.
    }

    // Se ambos os valores forem válidos, sairá do loop e seguirá o fluxo;
    break;
}


// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
