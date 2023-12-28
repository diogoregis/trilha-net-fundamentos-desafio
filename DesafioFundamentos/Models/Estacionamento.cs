namespace DesafioFundamentos.Models;

public class Estacionamento
{
    private decimal precoInicial;
    private decimal precoPorHora;
    private List<string> veiculos = new List<string>();

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        this.precoInicial = precoInicial;
        this.precoPorHora = precoPorHora;
    }

    public void AdicionarVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo que vai estacionar:");
        string placa = Console.ReadLine();
        if(placa != "")
        {
            veiculos.Add(placa);
            Console.WriteLine("Cadastrado com sucesso !");
            Console.WriteLine();
        } else
        {
            Console.WriteLine("Valor vazio ou invalido, tente novamente.");
            AdicionarVeiculo();
        }
        
    }

    public void RemoverVeiculo()
    {

        if(veiculos.Count == 0)
        {
            Console.WriteLine("!!! PATIO VAZIO !!!");
            return;
        }

        Console.WriteLine("Digite a placa do veículo para check-out:");
        string placa = Console.ReadLine();

        if (veiculos.Any(x => x.ToUpper().Equals(placa.ToUpper())))
        {
            Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
            int horas = Convert.ToInt32(Console.ReadLine());
            decimal valorTotal = precoPorHora * horas + precoInicial; 
            veiculos.Remove(placa);
            Console.WriteLine($"O veículo {placa} foi removido. Preço total pago: {valorTotal:C}");
        }
        else
        {
            Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
        }
    }

    public void ListarVeiculos()
    {
        if (veiculos.Any())
        {
            Console.WriteLine("Os veículos estacionados no patio:");
            Console.WriteLine("---------------------------");
            foreach(string veiculo in veiculos)
            {
                Console.WriteLine($"Placa: {veiculo}");
            }
            Console.WriteLine("---------------------------");
        }
        else
        {
            Console.WriteLine("PATIO VAZIO - Não há veículos estacionados.");
        }
    }
}
