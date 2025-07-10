namespace ScreenSound.Modelos;

internal class Banda
{

    public string Nome { get; }
            
    private List<Album> albuns = [];
    
    private List<Avaliacao> notas = [];
               
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

    public void AdicionarNota(int nota)
    {
        notas.Add(new Avaliacao(nota));
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