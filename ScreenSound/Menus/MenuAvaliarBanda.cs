using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuAvaliarBanda : Menu
{

   public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Avaliar banda");
        Console.Write("Digite o nome da banda que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
            Avaliacao avaliacao = Avaliacao.Parse(Console.ReadLine()!);
            Banda banda = bandasRegistradas[nomeDaBanda];
            banda.AdicionarNota(avaliacao);
            Console.WriteLine($"\nA nota {avaliacao.Nota} foi registrada com sucesso para a banda {banda.Nome}");
            Thread.Sleep(2000);
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
