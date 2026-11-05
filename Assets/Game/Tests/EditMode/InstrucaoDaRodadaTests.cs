using NUnit.Framework;

public class InstrucaoDaRodadaTests
{
    [TestCase(CorDoJogo.Vermelho, "Encontre o vermelho")]
    [TestCase(CorDoJogo.Azul, "Encontre o azul")]
    public void SoCor_IgnoraAGramaticaDaFormaDoAlvo(CorDoJogo cor, string esperado)
    {
        var alvo = new ObjetoDaRodada(cor, FormaDoJogo.Estrela);
        var rodada = Rodada.CriarSoCor(cor, new[] { alvo });

        Assert.AreEqual(esperado, InstrucaoDaRodada.Montar(rodada));
    }

    [TestCase(FormaDoJogo.Quadrado, CorDoJogo.Azul, "Encontre o quadrado azul")]
    [TestCase(FormaDoJogo.Circulo, CorDoJogo.Vermelho, "Encontre o círculo vermelho")]
    [TestCase(FormaDoJogo.Triangulo, CorDoJogo.Amarelo, "Encontre o triângulo amarelo")]
    [TestCase(FormaDoJogo.Estrela, CorDoJogo.Vermelho, "Encontre a estrela vermelha")]
    [TestCase(FormaDoJogo.Estrela, CorDoJogo.Roxo, "Encontre a estrela roxa")]
    [TestCase(FormaDoJogo.Estrela, CorDoJogo.Amarelo, "Encontre a estrela amarela")]
    [TestCase(FormaDoJogo.Estrela, CorDoJogo.Azul, "Encontre a estrela azul")]
    [TestCase(FormaDoJogo.Estrela, CorDoJogo.Verde, "Encontre a estrela verde")]
    [TestCase(FormaDoJogo.Estrela, CorDoJogo.Laranja, "Encontre a estrela laranja")]
    public void CorEForma_ConcordaComAFormaDoAlvo(FormaDoJogo forma, CorDoJogo cor, string esperado)
    {
        var alvo = new ObjetoDaRodada(cor, forma);
        var rodada = Rodada.CriarCorEForma(cor, forma, new[] { alvo });

        Assert.AreEqual(esperado, InstrucaoDaRodada.Montar(rodada));
    }
}
