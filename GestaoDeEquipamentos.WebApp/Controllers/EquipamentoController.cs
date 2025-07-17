using GestaoDeEquipamentos.Dominio.ModuloEquipamento;
using GestaoDeEquipamentos.Dominio.ModuloFabricante;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.ModuloFabricante;
using GestaoDeEquipamentos.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Controllers;

public class EquipamentoController : Controller
{
    private RepositorioEquipamentoEmArquivo repositorioEquipamento;
    private RepositorioFabricanteEmArquivo repositorioFabricante;

    public EquipamentoController()
    {
        ContextoDados contexto = new ContextoDados(true);
        repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);
        repositorioFabricante = new RepositorioFabricanteEmArquivo(contexto);
    }

    public IActionResult Index()
    {
        List<Equipamento> equipamentos = repositorioEquipamento.SelecionarRegistros();

        VisualizarEquipamentosViewModel visualizarVm = new VisualizarEquipamentosViewModel(equipamentos);

        return View(visualizarVm);
    }

    public IActionResult Cadastrar()
    {
        List<Fabricante> fabricantes = repositorioFabricante.SelecionarRegistros();

        CadastrarEquipamentoViewModel cadastrarVm = new CadastrarEquipamentoViewModel(fabricantes);

        return View(cadastrarVm);
    }

    [HttpPost]
    public IActionResult Cadastrar(CadastrarEquipamentoViewModel cadastrarVm)
    {
        Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarRegistroPorId(cadastrarVm.FabricanteId);

        if (fabricanteSelecionado == null)
            return RedirectToAction(nameof(Index));

        Equipamento novoEquipamento = new Equipamento(
            cadastrarVm.Nome,
            cadastrarVm.PrecoAquisicao,
            cadastrarVm.DataFabricacao,
            fabricanteSelecionado

        );

        repositorioEquipamento.CadastrarRegistro(novoEquipamento);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Editar(int id)
    {
        Equipamento equipamentoSelecionado = repositorioEquipamento.SelecionarRegistroPorId(id);

        List<Fabricante> fabricantes = repositorioFabricante.SelecionarRegistros();

        EditarEquipamentoViewModel editarVm = new EditarEquipamentoViewModel(
            equipamentoSelecionado.Id,
            equipamentoSelecionado.Nome,
            equipamentoSelecionado.PrecoAquisicao,
            equipamentoSelecionado.DataFabricacao,
            equipamentoSelecionado.Fabricante.Id,
            fabricantes
        );

        return View(editarVm);
    }

    [HttpPost]
    public IActionResult Editar(int id, EditarEquipamentoViewModel editarVm)
    {
        Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarRegistroPorId(editarVm.FabricanteId);

        Equipamento equipamentoEditado = new Equipamento(
            editarVm.Nome,
            editarVm.PrecoAquisicao,
            editarVm.DataFabricacao,
            fabricanteSelecionado
        );

        repositorioEquipamento.EditarRegistro(id, equipamentoEditado);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Excluir(int id)
    {
        Equipamento equipamentoSelecionado = repositorioEquipamento.SelecionarRegistroPorId(id);

        ExcluirEquipamentoViewModel excluirVm = new ExcluirEquipamentoViewModel(
            equipamentoSelecionado.Id,
            equipamentoSelecionado.Nome
        );

        return View(excluirVm);
    }

    [HttpPost]
    public IActionResult ExcluirConfirmado(int id)
    {
        repositorioEquipamento.ExcluirRegistro(id);

        return RedirectToAction(nameof(Index));
    }
}
