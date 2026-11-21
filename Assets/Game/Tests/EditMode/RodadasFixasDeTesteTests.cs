using System;
using NUnit.Framework;

public class RodadasFixasDeTesteTests
{
    [Test]
    public void TodasAsRodadasSaoValidasEComecamAbertas()
    {
        // Criar já valida RT-02: exatamente um objeto satisfaz a instrução.
        for (int i = 0; i < RodadasFixasDeTeste.Quantidade; i++)
        {
            Rodada rodada = RodadasFixasDeTeste.Criar(i);

            Assert.IsTrue(rodada.Aberta, $"posição {i}");
            Assert.AreEqual(0, rodada.Tentativas, $"posição {i}");
        }
    }

    [Test]
    public void DuasRodadasSeguidasTemInstrucoesDiferentes_InclusiveNaVoltaAoComeco()
    {
        // Dado um acerto, quando a rodada nova abre, então ela tem outra instrução (US-02.5).
        for (int i = 0; i < RodadasFixasDeTeste.Quantidade; i++)
        {
            int proxima = (i + 1) % RodadasFixasDeTeste.Quantidade;

            string atual = InstrucaoDaRodada.Montar(RodadasFixasDeTeste.Criar(i));
            string seguinte = InstrucaoDaRodada.Montar(RodadasFixasDeTeste.Criar(proxima));

            Assert.AreNotEqual(atual, seguinte, $"posições {i} e {proxima}");
        }
    }

    [Test]
    public void CadaChamadaDevolveUmaRodadaNova()
    {
        // A rodada guarda tentativas e fechamento: fechar uma não pode fechar a próxima do mesmo lugar.
        Rodada primeira = RodadasFixasDeTeste.Criar(0);
        primeira.Avaliar(primeira.IndiceDoAlvo);
        Assert.IsFalse(primeira.Aberta);

        Rodada outra = RodadasFixasDeTeste.Criar(0);

        Assert.AreNotSame(primeira, outra);
        Assert.IsTrue(outra.Aberta);
        Assert.AreEqual(0, outra.Tentativas);
    }

    [Test]
    public void PosicaoForaDaSequencia_LancaExcecao()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => RodadasFixasDeTeste.Criar(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => RodadasFixasDeTeste.Criar(RodadasFixasDeTeste.Quantidade));
    }

    [Test]
    public void AsDuasPrimeirasPosicoesSaoAsRodadasDeExemploDoInspector()
    {
        // ControladorDaRodada.RodadaDeExemplo: 0 = "Encontre o vermelho", 1 = "Encontre a estrela vermelha".
        Assert.AreEqual("Encontre o vermelho", InstrucaoDaRodada.Montar(RodadasFixasDeTeste.Criar(0)));
        Assert.AreEqual("Encontre a estrela vermelha", InstrucaoDaRodada.Montar(RodadasFixasDeTeste.Criar(1)));
    }
}
