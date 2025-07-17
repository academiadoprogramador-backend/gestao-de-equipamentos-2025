using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
    private char opcaoEscolhida;

    private ContextoDados contextoDados;

    private RepositorioFabricanteEmArquivo repositorioFabricante;
    private RepositorioEquipamentoEmArquivo repositorioEquipamento;
    private RepositorioChamadoEmArquivo repositorioChamado;

    private TelaFabricante telaFabricante;
    private TelaEquipamento telaEquipamento;
    private TelaChamado telaChamado;

    public TelaPrincipal()
    {
        contextoDados = new ContextoDados(true);

        repositorioFabricante = new RepositorioFabricanteEmArquivo(contextoDados);
        repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contextoDados);
        repositorioChamado = new RepositorioChamadoEmArquivo(contextoDados);

        telaFabricante = new TelaFabricante(repositorioFabricante);

        telaEquipamento = new TelaEquipamento(
            repositorioEquipamento,
            repositorioFabricante
        );

        telaChamado = new TelaChamado(repositorioChamado, repositorioEquipamento);
    }

    public void ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|        Gestão de Equipamentos        |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Fabricantes");
        Console.WriteLine("2 - Controle de Equipamentos");
        Console.WriteLine("3 - Controle de Chamados");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        opcaoEscolhida = Console.ReadLine()[0];
    }

    public ITela? ObterTela()
    {
        if (opcaoEscolhida == '1')
            return telaFabricante;

        else if (opcaoEscolhida == '2')
            return telaEquipamento;

        else if (opcaoEscolhida == '3')
            return telaChamado;

        return null;
    }
}
