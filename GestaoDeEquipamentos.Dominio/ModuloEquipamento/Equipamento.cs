using GestaoDeEquipamentos.Dominio.Compartilhado;
using GestaoDeEquipamentos.Dominio.ModuloFabricante;

namespace GestaoDeEquipamentos.Dominio.ModuloEquipamento;

public class Equipamento : EntidadeBase<Equipamento>
{
    public string Nome { get; set; }
    public decimal PrecoAquisicao { get; set; }
    public string NumeroSerie { get; set; }
    public Fabricante Fabricante { get; set; }
    public DateTime DataFabricacao { get; set; }

    public Equipamento() { }


    public Equipamento(
        string nome,
        decimal precoAquisicao,
        DateTime dataFabricacao,
        Fabricante fabricante
    ) : this()
    {
        Nome = nome;
        PrecoAquisicao = precoAquisicao;
        Fabricante = fabricante;
        DataFabricacao = dataFabricacao;
    }

    public Equipamento(
        string nome,
        decimal precoAquisicao,
        string numeroSerie,
        Fabricante fabricante,
        DateTime dataFabricacao
    ) : this()
    {
        Nome = nome;
        PrecoAquisicao = precoAquisicao;
        NumeroSerie = numeroSerie;
        Fabricante = fabricante;
        DataFabricacao = dataFabricacao;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo \"Nome\" é obrigatório.\n";

        else if (Nome.Length < 3)
            erros += "O campo \"Nome\" precisa conter ao menos 3 caracteres.\n";

        if (PrecoAquisicao <= 0)
            erros += "O campo \"Preço de Aquisição\" deve ser maior que zero.\n";

        if (DataFabricacao > DateTime.Now)
            erros += "O campo \"Data de Fabricação\" deve conter uma data passada.\n";

        return erros;
    }

    public override void AtualizarRegistro(Equipamento registroAtualizado)
    {
        Nome = registroAtualizado.Nome;
        PrecoAquisicao = registroAtualizado.PrecoAquisicao;
        NumeroSerie = registroAtualizado.NumeroSerie;
        Fabricante = registroAtualizado.Fabricante;
        DataFabricacao = registroAtualizado.DataFabricacao;
    }
}