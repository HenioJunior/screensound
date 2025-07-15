using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuAvaliarAlbum : Menu
{

    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Avaliar album");
        Console.Write("Digite o nome da banda que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {

            Banda banda = bandasRegistradas[nomeDaBanda];
            Console.Write("Agora digite o título do álbum: ");
            string tituloAlbum = Console.ReadLine()!;
            if (banda.ObterAlbumPorNome(tituloAlbum) != null)
            {
                Album album = banda.ObterAlbumPorNome(tituloAlbum);
                Console.Write($"Qual a nota que o album {tituloAlbum} merece: ");
                Avaliacao avaliacao = Avaliacao.Parse(Console.ReadLine()!);
                album.AdicionarNota(avaliacao);
                Console.WriteLine($"\nA nota {avaliacao.Nota} foi registrada com sucesso para o album {tituloAlbum}");
                Thread.Sleep(2000);
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"O álbum {tituloAlbum} não foi encontrado na discografia da banda {nomeDaBanda}.");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();

            }
        }
    }
}
