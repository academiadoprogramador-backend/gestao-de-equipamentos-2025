using GestaoDeEquipamentos.Dominio.ModuloEquipamento;
using GestaoDeEquipamentos.Dominio.ModuloFabricante;

namespace GestaoDeEquipamentos.WebApp.Models;

public class CadastrarEquipamentoViewModel
{
    public string Nome { get; set; }
    public decimal PrecoAquisicao { get; set; }
    public DateTime DataFabricacao { get; set; }
    public int FabricanteId { get; set; }
    public List<SelecionarFabricanteViewModel> FabricantesDisponiveis { get; set; }

    public CadastrarEquipamentoViewModel()
    {
        FabricantesDisponiveis = new List<SelecionarFabricanteViewModel>();
    }

    public CadastrarEquipamentoViewModel(List<Fabricante> fabricantes) : this()
    {

        foreach (Fabricante f in fabricantes)
        {
            SelecionarFabricanteViewModel selecionarVm =
                new SelecionarFabricanteViewModel(f.Id, f.Nome);

            FabricantesDisponiveis.Add(selecionarVm);
        }
    }
}

public class EditarEquipamentoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal PrecoAquisicao { get; set; }
    public DateTime DataFabricacao { get; set; }
    public int FabricanteId { get; set; }
    public List<SelecionarFabricanteViewModel> FabricantesDisponiveis { get; set; }

    public EditarEquipamentoViewModel()
    {
        FabricantesDisponiveis = new List<SelecionarFabricanteViewModel>();
    }

    public EditarEquipamentoViewModel(
        int id,
        string nome,
        decimal precoAquisicao,
        DateTime dataFabricacao,
        int fabricanteId,
        List<Fabricante> fabricantes
    ) : this()
    {

        foreach (Fabricante f in fabricantes)
        {
            SelecionarFabricanteViewModel selecionarVm =
                new SelecionarFabricanteViewModel(f.Id, f.Nome);

            FabricantesDisponiveis.Add(selecionarVm);
        }

        Id = id;
        Nome = nome;
        PrecoAquisicao = precoAquisicao;
        DataFabricacao = dataFabricacao;
        FabricanteId = fabricanteId;
    }
}

public class ExcluirEquipamentoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public ExcluirEquipamentoViewModel(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class SelecionarFabricanteViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public SelecionarFabricanteViewModel(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class VisualizarEquipamentosViewModel
{
    public List<DetalhesEquipamentoViewModel> Registros { get; set; }

    public VisualizarEquipamentosViewModel(List<Equipamento> equipamentos)
    {
        Registros = new List<DetalhesEquipamentoViewModel>();

        foreach (Equipamento e in equipamentos)
        {
            DetalhesEquipamentoViewModel detalhesVM = new DetalhesEquipamentoViewModel(
                e.Id,
                e.Nome,
                e.PrecoAquisicao,
                e.DataFabricacao,
                e.Fabricante.Nome
            );

            Registros.Add(detalhesVM);
        }
    }
}

public class DetalhesEquipamentoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal PrecoAquisicao { get; set; }
    public DateTime DataFabricacao { get; set; }
    public string NomeFabricante { get; set; }

    public DetalhesEquipamentoViewModel(
        int id,
        string nome,
        decimal precoAquisicao,
        DateTime dataFabricacao,
        string nomeFabricante
    )
    {
        Id = id;
        Nome = nome;
        PrecoAquisicao = precoAquisicao;
        DataFabricacao = dataFabricacao;
        NomeFabricante = nomeFabricante;
    }

    public override string ToString()
    {
        return $"Id: {Id} - Nome: {Nome} - Fabricante: {NomeFabricante} - Preço de Aquisição: {PrecoAquisicao:C2} - Data de Fabricação: {DataFabricacao:d}";
    }
}