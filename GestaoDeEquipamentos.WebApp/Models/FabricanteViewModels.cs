using GestaoDeEquipamentos.Dominio.ModuloFabricante;

namespace GestaoDeEquipamentos.WebApp.Models;

public class CadastrarFabricanteViewModel
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }

    public CadastrarFabricanteViewModel()
    {
    }
}

public class EditarFabricanteViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }

    public EditarFabricanteViewModel()
    {
    }

    public EditarFabricanteViewModel(int id, string nome, string email, string telefone)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Telefone = telefone;
    }
}

public class ExcluirFabricanteViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public ExcluirFabricanteViewModel(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}

public class VisualizarFabricantesViewModel
{
    public List<DetalhesFabricanteViewModel> Registros { get; set; }

    public VisualizarFabricantesViewModel(List<Fabricante> fabricantes)
    {
        Registros = new List<DetalhesFabricanteViewModel>();

        foreach (Fabricante f in fabricantes)
        {
            DetalhesFabricanteViewModel detalhesVm = new DetalhesFabricanteViewModel(
                f.Id,
                f.Nome,
                f.Email,
                f.Telefone
            );
            
            Registros.Add(detalhesVm);
        }
    }
}

public class DetalhesFabricanteViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }

    public DetalhesFabricanteViewModel(int id, string nome, string email, string telefone)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Telefone = telefone;
    }
}
