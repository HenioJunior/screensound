namespace ScreenSound.Modelos;

internal class Banda : IAvaliavel
{
    public string Nome { get; }

    private List<Album> albuns = new List<Album>();

    private List<Avaliacao> notas = new List<Avaliacao>();

    public double Media
    {
        get
        {
            if (notas.Count == 0)
            {
                return 0.0;
            }
            else
            {
                return notas.Average(nota => nota.Nota);
            }
        }
    }

    public Banda(string nome)
    {
        Nome = nome;
    }

    public void AdicionarAlbum(Album album)
    {
        albuns.Add(album);
    }

    public void RemoverAlbum(Album album)
    {
        albuns.Remove(album);
    }

    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota);
    }

    public Album? ObterAlbumPorNome(string nome)
    {
        return albuns.FirstOrDefault(a => a.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia da banda {Nome}");
        foreach (Album album in albuns)
        {
            Console.WriteLine($"Álbum: {album.Nome} ({album.DuracaoTotal})");
        }
    }
}