using GestaoDeEquipamentos.Dominio.ModuloFabricante;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.ModuloFabricante;
using GestaoDeEquipamentos.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Controllers;

public class FabricanteController : Controller
{
    private RepositorioFabricanteEmArquivo repositorioFabricante;

    public FabricanteController()
    {
        ContextoDados contexto = new ContextoDados(true);
        repositorioFabricante = new RepositorioFabricanteEmArquivo(contexto);
    }

    public IActionResult Index()
    {
        List<Fabricante> fabricantes = repositorioFabricante.SelecionarRegistros();

        VisualizarFabricantesViewModel visualizarVm = new VisualizarFabricantesViewModel(fabricantes);

        return View(visualizarVm);
    }

    public IActionResult Cadastrar()
    {
        CadastrarFabricanteViewModel cadastrarVm = new CadastrarFabricanteViewModel();

        return View(cadastrarVm);
    }

    [HttpPost]
    public IActionResult Cadastrar(CadastrarFabricanteViewModel cadastrarVm)
    {
        Fabricante novoFabricante = new Fabricante(
            cadastrarVm.Nome,
            cadastrarVm.Email,
            cadastrarVm.Telefone
        );

        repositorioFabricante.CadastrarRegistro(novoFabricante);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Editar(int id)
    {
        Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarRegistroPorId(id);

        if (fabricanteSelecionado == null)
            return RedirectToAction(nameof(Index));

        EditarFabricanteViewModel editarVm = new EditarFabricanteViewModel(
            fabricanteSelecionado.Id,
            fabricanteSelecionado.Nome,
            fabricanteSelecionado.Email,
            fabricanteSelecionado.Telefone
        );

        return View(editarVm);
    }

    [HttpPost]
    public IActionResult Editar(int id, EditarFabricanteViewModel editarVm)
    {
        Fabricante fabricanteEditado = new Fabricante(
            editarVm.Nome,
            editarVm.Email,
            editarVm.Telefone
        );

        bool edicaoConluida = repositorioFabricante.EditarRegistro(id, fabricanteEditado);

        if (!edicaoConluida)
        {
            fabricanteEditado.Id = id;

            return View(fabricanteEditado);
        }

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Excluir(int id)
    {
        Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarRegistroPorId(id);

        if (fabricanteSelecionado == null)
            return RedirectToAction(nameof(Index));

        ExcluirFabricanteViewModel excluirVm =
            new ExcluirFabricanteViewModel(id, fabricanteSelecionado.Nome);

        return View(excluirVm);
    }

    [HttpPost]
    public IActionResult ExcluirConfirmado(int id)
    {
        repositorioFabricante.ExcluirRegistro(id);

        return RedirectToAction(nameof(Index));
    }
}
